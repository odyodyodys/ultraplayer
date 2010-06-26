#include "SingleVideoGraphManager.h"

SingleVideoGraphManager::SingleVideoGraphManager(void):AGraphManager(1)
{
	_addonManager = new AddonManager<AD3dVisibleAddon>();
}

SingleVideoGraphManager::~SingleVideoGraphManager(void)
{

	CleanUp();

	if (_addonManager)
	{
		delete _addonManager;
	}
}

HRESULT SingleVideoGraphManager::CreateInstances()
{
	HRESULT hr = E_FAIL;

	try
	{
		// Create the graph
		hr = _filterGraph.CoCreateInstance(CLSID_FilterGraph , NULL, CLSCTX_INPROC);
		if (FAILED(hr)) throw PlaybackException("couldn't create FilterGraph", "SingleVideoGraphManager::CreateInstances", hr);

		// Create the media Control interface
		hr = _filterGraph.QueryInterface(&_mediaControl);
		if (FAILED(hr)) throw PlaybackException("couldn't create mediaControl", "SingleVideoGraphManager::CreateInstances", hr);

		// Create the media Event interface
		hr = _filterGraph.QueryInterface(&_mediaEvent);
		if (FAILED(hr)) throw PlaybackException("couldn't create mediaEvent", "SingleVideoGraphManager::CreateInstances", hr);

		// Create the media Position interface
		hr = _filterGraph.QueryInterface(&_mediaSeeking);
		if (FAILED(hr))throw PlaybackException("couldn't create mediaSeeking", "SingleVideoGraphManager::CreateInstances", hr);

		// Create the basic audio interface
		hr = _filterGraph.QueryInterface(&_basicAudio);
		if (FAILED(hr)) throw PlaybackException("couldn't create basicAudio", "SingleVideoGraphManager::CreateInstances", hr);
	}
	catch (exception& e)
	{
		hr = E_FAIL;
	}

	return hr;
}

HRESULT SingleVideoGraphManager::AddFiltersToGraph(list<pair<int, string>> files)
{
	HRESULT hr = E_FAIL;

	try
	{
		_numberOfStreams = 1;

		// add the first source file to the graph
		list<pair<int, string>>::iterator fileIterator = files.begin();
		USES_CONVERSION;

		string mediaFilename = (*fileIterator).second;
		wstring sourceName = L"Media Source: ";
		sourceName += A2W(mediaFilename.c_str());
		hr = _filterGraph->AddSourceFilter(A2W((*fileIterator).second.c_str()), sourceName.c_str(), &(_sourceFilters.begin()->m_T));
		if (FAILED(hr)) throw PlaybackException("couldn't add sourceFilter", "SingleVideoGraphManager::AddFiltersToGraph", hr);

		// Create the audio renderer
		hr = CoCreateInstance(CLSID_DSoundRender, NULL, CLSCTX_INPROC, IID_IBaseFilter, (void**)&_audioRenderer);
		if (SUCCEEDED(hr))
		{
			hr = _filterGraph->AddFilter(_audioRenderer,L"DirectSound");
		}
		else
		{
			throw PlaybackException("couldn't add audioRenderer", "SingleVideoGraphManager::AddFiltersToGraph", hr);
		}
	}
	catch (exception& e)
	{
		//TODO release all 
		hr = E_FAIL;
	}

	return hr;
}

HRESULT SingleVideoGraphManager::ConfigureFilters(DshowPlayerEnvironment* const environment)
{
	HRESULT hr = E_FAIL;

	try
	{
		// cast environment
		Direct3dVmr9DshowPlayerEnvironment* vmrEnvironment = (Direct3dVmr9DshowPlayerEnvironment*) environment;

		// Enable event notifications
		hr = _mediaEvent->SetNotifyFlags(0x00);
		if (FAILED(hr)) throw PlaybackException("couldn't set event notification flag", "MultiVideoGraphManager::ConfigureFilters", hr);

		// Set event notification window
		hr = _mediaEvent->SetNotifyWindow((OAHWND)vmrEnvironment->Window(), PlaybackResources::Instance()->DshowEventCode(), 0);
		if (FAILED(hr)) throw PlaybackException("couldn't set event notification window", "MultiVideoGraphManager::ConfigureFilters", hr);

		// Set the time format
		hr = _mediaSeeking->SetTimeFormat(&TIME_FORMAT_MEDIA_TIME);
		if (FAILED(hr)) throw PlaybackException("couldn't set time format", "MultiVideoGraphManager::ConfigureFilters", hr);

		// Build the VMR9
		hr = BuildVmr(vmrEnvironment);
		if (FAILED(hr)) throw PlaybackException("couldn't create vmr9 instances","MultiVideoGraphManager::ConfigureFilters");

		// Add graph to ROT
		hr = Rot::Add(_filterGraph, _rotId);
		if (FAILED(hr)) throw PlaybackException("couldn't add graph to rot","MultiVideoGraphManager::ConfigureFilters");
	}
	catch (exception& e)
	{
		hr = E_FAIL;
	}

	return hr;
}

void SingleVideoGraphManager::CleanUp()
{
	// remove it as a dshow event listener
	PlaybackEventNotifier::Instance()->UnregisterHandler(this);

	// unregister allocator from addonManager
	_addonManager->UnregisterExpandable(_allocator);

	// Remove graph from ROT
	Rot::Remove(_rotId);

	// Release all source filters
	list<CAdapt<CComPtr<IBaseFilter>>>::iterator iterator;
	for (iterator = _sourceFilters.begin() ; iterator != _sourceFilters.end(); iterator++)
	{
		if ((*iterator).m_T)
		{
			((*iterator).m_T.p)->Release();
			((*iterator).m_T.p) = NULL;
		}
	}

	_basicAudio.Attach(NULL);
	_audioRenderer.Attach(NULL);
	_videoRenderer.Attach(NULL);
	_mediaControl.Attach(NULL);
	_mediaEvent.Attach(NULL);
	_mediaSeeking.Attach(NULL);
	_vmrFilterConfig.Attach(NULL);
	_allocator.Attach(NULL);
	_filterGraph.Attach(NULL);
}

HRESULT SingleVideoGraphManager::SetAllocatorPresenter(Direct3dVmr9DshowPlayerEnvironment*  environment)
{
	HRESULT hr = E_FAIL;

	try
	{
		CComPtr<IVMRSurfaceAllocatorNotify9> vmrSurfaceAllocatorNotify;
		hr = _videoRenderer.QueryInterface(&vmrSurfaceAllocatorNotify);
		if (FAILED(hr)) throw PlaybackException("could not query IVMRSurfaceAllocatorNotify9 interface from renderer", "SingleVideoGraphManager::SetAllocatorPresenter", hr);

		_allocator.Attach(new AllocatorPresenter(hr, environment));
		if (FAILED(hr)) throw PlaybackException("could not allocatorPresenter", "SingleVideoGraphManager::SetAllocatorPresenter", hr);

		// let the allocator and the notify know about each other
		// Note: userId is "this" which is unique because no two allocators run at the same time.
		hr = vmrSurfaceAllocatorNotify->AdviseSurfaceAllocator((DWORD)_allocator.p , _allocator);
		if (FAILED(hr)) throw PlaybackException("Failed to advice surface allocator", "SingleVideoGraphManager::SetAllocatorPresenter", hr);
	
		hr = _allocator->AdviseNotify(vmrSurfaceAllocatorNotify);
		if (FAILED(hr)) throw PlaybackException("Failed to advice notify", "SingleVideoGraphManager::SetAllocatorPresenter", hr);

		// register allocator to addonManager
		_addonManager->RegisterExpandable(_allocator);

	}
	catch (exception& e)
	{
		// make sure hr is fail
		if (SUCCEEDED(hr))
		{
			hr = E_FAIL;
		}
	}

 	return hr;

}

HRESULT SingleVideoGraphManager::BuildVmr(Direct3dVmr9DshowPlayerEnvironment* environment)
{
	HRESULT hr = E_FAIL;

	try
	{
		if (_filterGraph == NULL) throw PlaybackException("null filterGraph","MultiVideoGraphManager::BuildVmr");

		// Build the Vmr9
		hr = CoCreateInstance(CLSID_VideoMixingRenderer9, 0, CLSCTX_INPROC_SERVER, IID_IBaseFilter, (void**) &_videoRenderer);
		if (FAILED(hr)) throw PlaybackException("Could not create an instance of the VMR9","MultiVideoGraphManager::BuildVmr", hr);

		// Get needed interface instances from the VMR9
		hr = _videoRenderer->QueryInterface(IID_IVMRFilterConfig9, (void**) &_vmrFilterConfig);
		if (FAILED(hr)) throw PlaybackException("Could not get vmrFilterConfig instance", "MultiVideoGraphManager::BuildVmr", hr);

		// Set the rendering mode. 
		hr = _vmrFilterConfig->SetRenderingMode(VMR9Mode_Renderless);
		if (FAILED(hr)) throw PlaybackException("Could not ","MultiVideoGraphManager::ConfigureVmr", hr);

		// Set allocator-presenter
		SetAllocatorPresenter(environment);

		// Set number of streams
		hr = _vmrFilterConfig->SetNumberOfStreams(_numberOfStreams);
		if (FAILED(hr)) throw PlaybackException("Could not ","MultiVideoGraphManager::ConfigureVmr", hr);

		// Add the Vmr9 to the graph
		hr = _filterGraph->AddFilter(_videoRenderer.p, L"VMR9");
		if (FAILED(hr)) throw PlaybackException("Could not add the VMR9 to the Graph", "MultiVideoGraphManager::BuildVmr", hr);

		// register to dshow event listener, it needs to get notified for window resize
		PlaybackEventNotifier::Instance()->RegisterHandler(this);
	}
	catch (exception& e)
	{
		hr = E_FAIL;
	}

	return hr;
}

void SingleVideoGraphManager::HandleEvent( DWORD eventCode, HWND window)
{
	// handle base dshow messages
	AGraphManager::HandleEvent(eventCode, window);

	// the resize of the window
	if (eventCode == WM_SIZE)
	{
		//StretchVmrToVideoWindow(window);
	}
}

bool SingleVideoGraphManager::SetImage(UINT addonId, VisibleLayout* layout, string filename, Direct3dVmr9DshowPlayerEnvironment* environment)
{
	bool success = false;

	try
	{
		ImageD3dVisibleAddon* addon = new ImageD3dVisibleAddon(addonId, layout, filename);
	
		// initialize addon
		if(!addon->Initialize(environment))
		{
			throw InitializationFailedException("Could not initialize addon", "SingleVideoGraphManager::SetImage");
		}
	
		// register addon
		_addonManager->RegisterAddon(addon);

		success = true;
	}
	catch (exception& e)
	{
		success = false;
	}

	return success;
}

bool SingleVideoGraphManager::SetText(UINT addonId, VisibleLayout* layout, string text, Direct3dVmr9DshowPlayerEnvironment* environment)
{
	bool success = false;

	try
	{
		TextD3dVisibleAddon* addon = new TextD3dVisibleAddon(addonId, layout, text);

		// initialize addon
		if(!addon->Initialize(environment))
		{
			throw InitializationFailedException("Could not initialize addon", "SingleVideoGraphManager::SetText");
		}

		// register addon
		_addonManager->RegisterAddon(addon);

		success = true;
	}
	catch (exception& e)
	{
		success = false;
	}

	return success;
}

bool SingleVideoGraphManager::RemoveAddon( UINT addonId )
{
	bool success = false;

	try
	{
		// unregister addon
		_addonManager->UnregisterAddon(addonId);

		success = true;
	}
	catch (exception& e)
	{
		success = false;
	}

	return success;
}

HRESULT SingleVideoGraphManager::OnDeviceChanged(Direct3dVmr9DshowPlayerEnvironment* environment)
{
	HRESULT hr = E_FAIL;

	try
	{
		HMONITOR monitor = environment->Direct3d()->GetAdapterMonitor(environment->Device()->DeviceId());
		if (!monitor)
		{
			throw PlaybackException("could not get monitor from direct3d", "SingleVideoGraphManager::OnDeviceChanged");
		}

		if (!_videoRenderer)
		{
			return S_OK;
		}

		CComPtr<IVMRSurfaceAllocatorNotify9> allocNotify = NULL;
		hr = _videoRenderer->QueryInterface(&allocNotify);
		if (FAILED(hr))
		{
			throw PlaybackException("_videoRenderer->QueryInterface", "SingleVideoGraphManager::OnDeviceChanged");
		}	

		hr = allocNotify->ChangeD3DDevice(environment->Direct3dDevice(), monitor);
		if (FAILED(hr))
		{
			throw PlaybackException("allocNotify->ChangeD3DDevice", "SingleVideoGraphManager::OnDeviceChanged");
		}		

	}
	catch (exception& e)
	{
		
	}
	return hr;
}