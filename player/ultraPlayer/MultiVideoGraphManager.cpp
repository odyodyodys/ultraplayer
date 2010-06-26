#include "MultiVideoGraphManager.h"

MultiVideoGraphManager::MultiVideoGraphManager(void):AGraphManager(PlaybackResources::Instance()->MaxVmr9Sources())
{
}

MultiVideoGraphManager::~MultiVideoGraphManager(void)
{
}

HRESULT MultiVideoGraphManager::CreateInstances()
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
		if (FAILED(hr)) throw PlaybackException("couldn't create mediaSeeking", "SingleVideoGraphManager::CreateInstances", hr);

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

HRESULT MultiVideoGraphManager::AddFiltersToGraph(list<pair<int, string>> files)
{
	HRESULT hr = E_FAIL;

	try
	{
		_numberOfStreams = (DWORD)files.size();

		// add all source files to the graph
		list<pair<int, string>>::iterator fileIterator;
		list<CAdapt<CComPtr<IBaseFilter>>>::iterator sourceFilterIterator = _sourceFilters.begin();
	
		for (fileIterator = files.begin(); fileIterator != files.end(); fileIterator++ )
		{	
			USES_CONVERSION;
			string test = (*fileIterator).second;

			wstring sourceName = L"Media Source: ";
			sourceName += A2W(test.c_str());

			hr = _filterGraph->AddSourceFilter(A2W((*fileIterator).second.c_str()), sourceName.c_str(), &(sourceFilterIterator->m_T));
			if (FAILED(hr)) throw PlaybackException("couldn't add sourceFilter", "SingleVideoGraphManager::AddFiltersToGraph", hr);

			// advance to the next sourceFilter
			sourceFilterIterator++;
		}


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

HRESULT MultiVideoGraphManager::ConfigureFilters(DshowPlayerEnvironment* environment)
{
	HRESULT hr = E_FAIL;

	try
	{
		// Enable event notifications
		hr = _mediaEvent->SetNotifyFlags(0x00);
		if (FAILED(hr)) throw PlaybackException("couldn't set event notification flag", "MultiVideoGraphManager::ConfigureFilters", hr);

		// Set event notification window
		hr = _mediaEvent->SetNotifyWindow((OAHWND)environment->Window(), PlaybackResources::Instance()->DshowEventCode(), 0);
		if (FAILED(hr)) throw PlaybackException("couldn't set event notification window", "MultiVideoGraphManager::ConfigureFilters", hr);

		// Set the time format
		hr = _mediaSeeking->SetTimeFormat(&TIME_FORMAT_MEDIA_TIME);
		if (FAILED(hr)) throw PlaybackException("couldn't set time format", "MultiVideoGraphManager::ConfigureFilters", hr);

		// Build the VMR9
		hr = BuildVmr(environment->Window());
		if (FAILED(hr)) throw PlaybackException("couldn't create vmr9 instances","MultiVideoGraphManager::ConfigureFilters");

		// Stretch vmr9 to window
		hr = StretchVmrToVideoWindow(environment->Window());
		if (FAILED(hr)) throw PlaybackException("couldn't stretch vmr to video window","MultiVideoGraphManager::ConfigureFilters");

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

void MultiVideoGraphManager::CleanUp()
{
	// remove it as a dshow event listener
	PlaybackEventNotifier::Instance()->UnregisterHandler(this);

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
	_vmrMixerControl.Attach(NULL);
	_vmrMonitorConfig.Attach(NULL);
	_vmrWindowlessControl.Attach(NULL);
	_filterGraph.Attach(NULL);
}

HRESULT MultiVideoGraphManager::BuildVmr(HWND window)
{
	HRESULT hr = E_FAIL;

	try
	{
		if (_filterGraph == NULL) throw PlaybackException("null filterGraph","MultiVideoGraphManager::BuildVmr");
	
		// Build the Vmr9
		hr = CoCreateInstance(CLSID_VideoMixingRenderer9, 0, CLSCTX_INPROC_SERVER, IID_IBaseFilter, (void**) &_videoRenderer);
		if (FAILED(hr)) throw PlaybackException("Could not create an instance of the VMR9","MultiVideoGraphManager::BuildVmr", hr);
	
		// Add the Vmr9 to the graph
		hr = _filterGraph->AddFilter(_videoRenderer.p, L"VMR9");
		if (FAILED(hr)) throw PlaybackException("Could not add the VMR9 to the Graph", "MultiVideoGraphManager::BuildVmr", hr);
	
		// Get needed interface instances from the VMR9
		hr = _videoRenderer->QueryInterface(IID_IVMRFilterConfig9, (void**) &_vmrFilterConfig);
		if (FAILED(hr)) throw PlaybackException("Could not get vmrFilterConfig instance", "MultiVideoGraphManager::BuildVmr", hr);

		// Set the rendering mode. Note: Needs to be done prior getting VMRWindowlessControl9 
		hr = _vmrFilterConfig->SetRenderingMode(VMR9Mode_Windowless);
		if (FAILED(hr)) throw PlaybackException("Could not ","MultiVideoGraphManager::ConfigureVmr", hr);

		// Set number of streams
		hr = _vmrFilterConfig->SetNumberOfStreams(_numberOfStreams);
		if (FAILED(hr)) throw PlaybackException("Could not ","MultiVideoGraphManager::ConfigureVmr", hr);

		hr = _videoRenderer->QueryInterface(IID_IVMRWindowlessControl9, (void**) &_vmrWindowlessControl);
		if (FAILED(hr)) throw PlaybackException("Could not get vmrWindowlessControl instance", "MultiVideoGraphManager::BuildVmr", hr);

		// Set Clipping Window
		hr = _vmrWindowlessControl->SetVideoClippingWindow(window);
		if (FAILED(hr)) throw PlaybackException("Could not ","MultiVideoGraphManager::ConfigureVmr", hr);

		// Set the aspect ratio
		// TODO. get this from the client
		hr = _vmrWindowlessControl->SetAspectRatioMode(VMR9AspectRatioMode::VMR9ARMode_LetterBox);
		if (FAILED(hr)) throw PlaybackException("Could not ","MultiVideoGraphManager::ConfigureVmr", hr);

		hr = _videoRenderer->QueryInterface(IID_IVMRMixerControl9, (void**) &_vmrMixerControl);
		if (FAILED(hr)) throw PlaybackException("Could not get vmrMixerControl instance", "MultiVideoGraphManager::BuildVmr", hr);

		hr = _videoRenderer->QueryInterface(IID_IVMRMonitorConfig9, (void**) &_vmrMonitorConfig);
		if (FAILED(hr)) throw PlaybackException("Could not get vmrMonitorConfig instance", "MultiVideoGraphManager::BuildVmr", hr);

		// register to playbackEventNotifier, it needs to get notified for window resize
		PlaybackEventNotifier::Instance()->RegisterHandler(this);
	}
	catch (exception& e)
	{
		hr = E_FAIL;
	}

	return hr;
}

HRESULT MultiVideoGraphManager::StretchVmrToVideoWindow(HWND window)
{
	HRESULT hr = E_FAIL;

	try
	{
		// verify graph existence
		if (!(_filterGraph && _vmrWindowlessControl)) throw PlaybackException("Graph not initialized","MultiVideoGraphManager::StretchVmrToVideoWindow");

		// Video size
		LONG  width;
		LONG  height;
		LONG  aspectRatioWidth;
		LONG  aspectRatioHeight;
		_vmrWindowlessControl->GetNativeVideoSize(&width, &height, &aspectRatioWidth, &aspectRatioHeight);
		RECT videoRect;
		videoRect.left = 0;
		videoRect.top = 0;
		videoRect.right = width;
		videoRect.bottom = height;
	
		RECT windowRect;
		GetClientRect(window, &windowRect);
	
		hr = _vmrWindowlessControl->SetVideoPosition(&videoRect, &windowRect);
	}
	catch (exception& e)
	{
		hr = E_FAIL;
	}

	return hr;
}

HRESULT MultiVideoGraphManager::SetVideoLayout( int index, RECT layout )
{
	HRESULT hr = E_FAIL;

	try
	{
		// validate rectangle
		if (!IsLayerValid(index)) throw PlaybackException("Invalid layer index","MultiVideoGraphManager::SetVideoLayout");

		// create normalized rect
		VMR9NormalizedRect normalizedRect = NormalizeRect(&layout);
	
		// apply rect
		hr = _vmrMixerControl->SetOutputRect(index, &normalizedRect);
	}
	catch (exception& e)
	{
		// make sure hr is failure
		if (SUCCEEDED(hr))
		{
			hr = E_FAIL;
		}
	}

	return hr;
}

bool MultiVideoGraphManager::IsLayerValid( int layerIndex )
{
	bool success = false;

	try
	{
		// advance to the needed element(there must be a simpler way though)
		list<CAdapt<CComPtr<IBaseFilter>>>::iterator iterator = _sourceFilters.begin();
		for (int i = 0; i < layerIndex; i++, iterator++);

		success = (*iterator).m_T != NULL;
	}
	catch (exception& e)
	{
		success = false;
	}

	return success;
}

VMR9NormalizedRect MultiVideoGraphManager::NormalizeRect( LPRECT layoutRect )
{
	VMR9NormalizedRect normalizedRect;

	RECT videoRect;
	if (GetVideoRect(&videoRect)) 
	{
		int normalizedWidth = videoRect.right - videoRect.left;
		int normalizedHeight = videoRect.bottom - videoRect.top;
		
		try 
		{
			normalizedRect.left =  (float) layoutRect->left  / 1000.0f;
		}
		catch(...)
		{
			normalizedRect.left = 0.0f;
		}

		try 
		{
			normalizedRect.right =  (float) layoutRect->right / 1000.0f;
		}
		catch(...)
		{
			normalizedRect.right = 1.0f;
		}

		try 
		{
			normalizedRect.top = (float)layoutRect->top / 1000.0f;
		}
		catch(...) 
		{
			normalizedRect.top = 0.0f;
		}

		try 
		{
			normalizedRect.bottom = (float) layoutRect->bottom / 1000.0f;
		}
		catch(...)
		{
			normalizedRect.bottom = 1.0f;
		}
	}

	return normalizedRect;
}

bool MultiVideoGraphManager::GetVideoRect( LPRECT rect )
{
	HRESULT hr = E_FAIL;
	bool success = false;

	try
	{
		if (rect == NULL) throw PlaybackException("Can't return video size, rect struct invalid", "MultiVideoGraphManager::GetVideoRect");
	
		if (_vmrWindowlessControl == NULL) throw PlaybackException("Vmr not initialized", "MultiVideoGraphManager::GetVideoRect");

		long width;
		long height;
		long aspectRatioWidth;
		long aspectRatioHeight;
		hr = _vmrWindowlessControl->GetNativeVideoSize(&width, &height, &aspectRatioWidth, &aspectRatioHeight);
		if (FAILED(hr)) throw PlaybackException("Can't get video size, VMR error", "MultiVideoGraphManager::GetVideoRect", hr);

		rect->left = 0;
		rect->top = 0;
		rect->right = width;
		rect->bottom = height;

		success = true;
	}
	catch (exception& e)
	{
		success = false;
	}

	return success;
}

HRESULT MultiVideoGraphManager::SetVideoAlpha( int index, int alpha )
{
	HRESULT hr = E_FAIL;

	try
	{
		// validate rectangle
		if (!IsLayerValid(index)) throw PlaybackException("Invalid layer index","MultiVideoGraphManager::SetVideoAlpha");

		// convert to float (0 <->1)
		float floatAlpha = 0;
		floatAlpha = alpha /255.0f;

		// apply alpha
		hr = _vmrMixerControl->SetAlpha(index, floatAlpha);
	}
	catch (exception& e)
	{
		hr = E_FAIL;		
	}

	return hr;
}

void MultiVideoGraphManager::HandleEvent( DWORD eventCode, HWND window )
{
	// handle base dshow messages
	AGraphManager::HandleEvent(eventCode, window);

	// the resize of the window
	if (eventCode == WM_SIZE)
	{
		StretchVmrToVideoWindow(window);
	}

}