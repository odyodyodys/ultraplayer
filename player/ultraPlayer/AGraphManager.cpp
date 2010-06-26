#include "AGraphManager.h"

AGraphManager::AGraphManager(UINT maxSources)
{
	_maxSources = maxSources;
	_rotId = 0;

	InitializeSourcesList();

	// Initialize COM server.
	CoInitializeEx(NULL, COINIT_MULTITHREADED);
}

AGraphManager::~AGraphManager(void)
{
}

void AGraphManager::Initialize( list<pair<int, string>> files, DshowPlayerEnvironment* const environment )
{
	// TODO return values(success/failure)

	HRESULT hr = E_FAIL;

	//Check if this graph can support the amount of files
	if (files.size() == 0 || files.size() > _maxSources)
	{
		return;
	}

	Stop();
	CleanUp();

	hr = CreateInstances();
	if (FAILED(hr))
	{
		return;
	}

	hr = AddFiltersToGraph(files);
	if (FAILED(hr))
	{
		return;
	}

	hr = ConfigureFilters(environment);
	if (FAILED(hr))
	{
		return;
	}
}

void AGraphManager::Run()
{
	// TODO return values

	HRESULT hr = 0;

	// check if the graph has been initialized
	if (!_filterGraph || !_mediaEvent || !_mediaControl)
	{
		return;
	}

	// run the graph
	hr = _mediaControl->Run();
	if (FAILED(hr))
	{
		return;
	}
}

void AGraphManager::Resume()
{
	// TODO check that the graph has been built

	// media control->run() does not start from the beginning.
	Run();

}

void AGraphManager::Pause()
{
	// TODO return values

	HRESULT hr = 0;

	// check if the graph has been initialized
	if (!_filterGraph || !_mediaEvent || !_mediaControl)
	{
		return;
	}

	// Pause the graph
	hr = _mediaControl->Pause();
	if (FAILED(hr))
	{
		return;
	}
}

void AGraphManager::Render()
{
	// TODO should return success

	HRESULT hr = E_FAIL;
	
	try
	{
		if (_filterGraph == NULL)
		{
			throw PlaybackException("Could not render the graph because it is not fully constructed", "AGraphManager::Render");
		}
		
		list<CAdapt<CComPtr<IBaseFilter>>>::iterator iterator;
		for (iterator = _sourceFilters.begin() ; iterator != _sourceFilters.end(); iterator++)
		{
			if ( iterator->m_T != NULL)
			{
				CComPtr<IPin> sourcePin = GetPin((iterator->m_T).p, PINDIR_OUTPUT);
				if (sourcePin != NULL)
				{
					try 
					{
						hr = _filterGraph->RenderEx(sourcePin, AM_RENDEREX_RENDERTOEXISTINGRENDERERS, NULL);
					}
					catch(...)
					{
					}
				}
			}
		}
	}
	catch (exception& e)
	{
		hr = E_FAIL;
	}

	//return hr;
}

void AGraphManager::Stop()
{
	// TODO should return success

	HRESULT hr = E_FAIL;

	try
	{
		// check if graph is initialized at all before stopping
		if (!_filterGraph)
		{
			return;
		}

		// Stop playback
		hr = _mediaControl->Stop();
		if (FAILED(hr))
		{
			throw PlaybackException("couldn't stop", "AGraphManager::Stop", hr);
		}
	
		// wait to stop
		long eventCode = 0;
		_mediaEvent->WaitForCompletion(250, &eventCode);
		if (FAILED(hr))
		{
			throw PlaybackException("fail while waiting to stop", "AGraphManager::Stop", hr);
		}
	
		// validate that the graph is stopped
		FILTER_STATE filterState;
		hr = _mediaControl->GetState(250, (OAFilterState*) &filterState);
		if (FAILED(hr))
		{
			throw PlaybackException("couldn't get mediaControl state", "AGraphManager::Stop", hr);
		}
	
		// if after all efforts the graph cannot stop, mark the error and return
		// Resources will be freed when the destructor is called.
		if (filterState != FILTER_STATE::State_Stopped)
		{
			throw PlaybackException("GraphManager has difficulties in stopping the graph. All resources will be forced to get released.", "AGraphManager::Stop", hr);
		}
	}
	catch (exception& e)
	{
		hr = E_FAIL;
	}

	// return hr;

}

void AGraphManager::HandleEvent(DWORD eventCode, HWND window)
{
	try
	{
		if (_mediaEvent == NULL)
		{
			// make sure this is not called after the renderer has stopped and the interfaces have been released.
			throw PlaybackException("mediaEvent not initialized","AGraphManager::HandleEvent");
		}
	
		HRESULT hr = E_FAIL;
		long eventCode = 0;
		long eventParam1 = 0;
		long eventParam2 = 0;
	
		// because window and dshow events are asynchronous, maybe there are more than one events in the dshow event queue
		while (SUCCEEDED(_mediaEvent->GetEvent(&eventCode, &eventParam1, &eventParam2, 0)))
		{
			// release any resource associated with the event
			hr = _mediaEvent->FreeEventParams(eventCode, eventParam1, eventParam2);
			if (FAILED(hr))
			{
				throw PlaybackException("couldn't free graph event parameters", "AGraphManager::HandleEvent", hr);
			}
	
			switch (eventCode)
			{
			case EC_COMPLETE:      
				Stop();
				break;
			case EC_ERRORABORT:
				Stop();
				throw PlaybackException("error abort, while playback", "AGraphManager::HandleEvent");
				break;
			}
		}
	
		//TODO Log params on error
	}
	catch (exception& e)
	{
		
	}

}

void AGraphManager::SetVolume( UINT volume )
{
	try
	{
		if (!_basicAudio)
		{
			throw PlaybackException("basicAudio not initialized", "AGraphManager::SetVolume");
		}

		HRESULT hr = _basicAudio->put_Volume(VolumeLevelConverter::Instance()->Convert(volume));
		if (FAILED(hr))
		{
			throw  PlaybackException("could not set volume", "AGraphManager::SetVolume", hr);
		}

	}
	catch (exception& e)
	{
		throw e;
	}
}

IPin* AGraphManager::GetPin( IBaseFilter *filter, PIN_DIRECTION pinDirection )
{
	BOOL found = FALSE;
	IPin *tmpPin = NULL;
	IPin *neededPin = NULL;
	CComPtr<IEnumPins> pinEnumerator;

	filter->EnumPins(&pinEnumerator);
	while(pinEnumerator->Next(1, &tmpPin, 0) == S_OK && !found)
	{
		PIN_DIRECTION currentPinDirection;
		tmpPin->QueryDirection(&currentPinDirection);
		if (pinDirection == currentPinDirection)
		{
			found = true;
			neededPin = tmpPin;
		}
		else
		{
			tmpPin->Release();
		}
	}
	return neededPin;
}

void AGraphManager::InitializeSourcesList()
{
	// initialize sources
	for (int i = 0; i < _maxSources; i++)
	{
		CAdapt<CComPtr<IBaseFilter>> emptyItem;
		_sourceFilters.push_back(emptyItem);
		emptyItem.m_T.p = NULL;
	}
}

bool AGraphManager::SeekTo( long milliseconds )
{
	bool success = false;

	if (!_mediaSeeking)
	{
		return false;
	}

	// convert it to 100ns. Note: 1second = 10.000.000
	LONGLONG newPosition = milliseconds * 10000;

	HRESULT hr = _mediaSeeking->SetPositions(&newPosition, AM_SEEKING_AbsolutePositioning, 0, AM_SEEKING_NoPositioning);
	
	// check result. s_false means didn't succeeded in this particular method
	if (SUCCEEDED(hr) && hr != S_FALSE)
	{
		success = true;
	}

	return success;
}

HRESULT AGraphManager::SetRate( float rate )
{
	HRESULT hr = E_FAIL;

	try
	{
		if (!_mediaSeeking)
		{
			return false;
		}
	
		hr = _mediaSeeking->SetRate((double)rate);
	}
	catch (exception& e)
	{
		if (SUCCEEDED(hr))
		{
			hr = E_FAIL;
		}
	}	

	return hr;
}