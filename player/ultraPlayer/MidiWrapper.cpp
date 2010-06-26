#include "MidiWrapper.h"

MidiWrapper::MidiWrapper()
{
	_music			= NULL; 
	_music8			= NULL; 
	_loader			= NULL;
	_performance	= NULL; 
	_segment		= NULL;
	_musicPort		= NULL; 		
	_segmentState	= NULL; 
	_segmentState8	= NULL; 
	_3dAudioPath	= NULL; 
	_3dSoundBuffer	= NULL;
	_musicCollection = NULL;

	_maxMidiOuputPorts = 30;
	_dlsFile = "";
}

MidiWrapper::~MidiWrapper()
{
	CleanUp();

	// clean up port list
	list<MidiPortInfo*>::iterator portIt;
	for (portIt = _midiOutputPorts.begin(); portIt != _midiOutputPorts.end(); portIt++)
	{
		delete *portIt;
	}
}	

bool MidiWrapper::Initialize()
{
	HRESULT hr = E_FAIL;
	bool success = false;
	try
	{
		hr = CoCreateInstance(CLSID_DirectMusicLoader,NULL, CLSCTX_INPROC,IID_IDirectMusicLoader8, (void**)&_loader);
		if (FAILED(hr))
		{
			throw InitializationFailedException("CoCreateInstance(CLSID_DirectMusicLoader", "MidiWrapper::Initialize", hr);
		}
	
		hr = CoCreateInstance(CLSID_DirectMusicPerformance,NULL, CLSCTX_INPROC,IID_IDirectMusicPerformance8, (void**)&_performance);
		if (FAILED(hr))
		{
			throw InitializationFailedException("CoCreateInstance(CLSID_DirectMusicPerformance", "MidiWrapper::Initialize", hr);
		}
	
		// initialize audio for 3D environment with the appropriate performance and the standard audiopath
		hr = _performance->InitAudio(&_music, NULL, NULL, DMUS_APATH_DYNAMIC_STEREO, 64, DMUS_AUDIOF_ALL,NULL);
		if (FAILED(hr))
		{
			throw InitializationFailedException("_performance->InitAudio", "MidiWrapper::Initialize", hr);
		}
	
		hr = _performance->CreateStandardAudioPath(DMUS_APATH_DYNAMIC_3D, 64, TRUE, &_3dAudioPath);
		if (FAILED(hr))
		{
			throw InitializationFailedException("_performance->CreateStandardAudioPath", "MidiWrapper::Initialize", hr);
		}
	
		// create the 3D directsound buffer
		hr = _3dAudioPath->GetObjectInPath(DMUS_PCHANNEL_ALL, DMUS_PATH_BUFFER, 0, GUID_NULL, 0, IID_IDirectSound3DBuffer, (LPVOID*) &_3dSoundBuffer);
		if (FAILED(hr))
		{
			throw InitializationFailedException("_3dAudioPath->GetObjectInPath", "MidiWrapper::Initialize", hr);
		}

		// Invoke the new interface pointer for IDirectMusic8
		hr = _music->QueryInterface(IID_IDirectMusic8,(LPVOID*)&_music8);
		if (FAILED(hr))
		{
			throw InitializationFailedException("", "MidiWrapper::Initialize", hr);
		}
	
		// Release the old interface, not needed any more
		SAFE_RELEASE(_music);

		// Set default parameters
		hr = SetMaxDistance(D3DVALUE(5.2));
		if (FAILED(hr))
		{
			throw InitializationFailedException("SetMaxDistance(D3DVALUE(5.2))", "MidiWrapper::Initialize", hr);
		}

		hr = SetMode(DS3DMODE_HEADRELATIVE);
		if (FAILED(hr))
		{
			throw InitializationFailedException("SetMode(DS3DMODE_HEADRELATIVE)", "MidiWrapper::Initialize", hr);
		}

		hr = SetPosition(0, 0, 0);
		if (FAILED(hr))
		{
			throw InitializationFailedException("SetPosition(0, 0, 0)", "MidiWrapper::Initialize", hr);
		}

		hr = PopulatePorts();
		if (FAILED(hr))
		{
			throw InitializationFailedException("PopulatePorts()", "MidiWrapper::Initialize", hr);
		}

		success = true;
	}
	catch (exception& e)
	{
		success = false;
	}
	return success;
}

HRESULT MidiWrapper::PopulatePorts()
{
	HRESULT hr = S_OK;
	try
	{
		_midiOutputPorts.clear();

		DWORD index = 0;
		while (hr == S_OK)
		{
			DMUS_PORTCAPS portInfo;
			ZeroMemory(&portInfo, sizeof(portInfo));
			portInfo.dwSize = sizeof(DMUS_PORTCAPS);
			hr = _music8->EnumPort(index++, &portInfo);

			if (hr == S_OK)
			{
				MidiPortInfo* info = new MidiPortInfo();
				USES_CONVERSION;
				info->PortDescription(W2A(portInfo.wszDescription));
				info->Class(portInfo.dwClass);
				info->EffectFlags(portInfo.dwEffectFlags);
				info->Flags(portInfo.dwFlags);
				info->MaxAudioChannels(portInfo.dwMaxAudioChannels);
				info->MaxChannelGroups(portInfo.dwMaxChannelGroups);
				info->MaxVoices(portInfo.dwMaxVoices);
				info->Type(portInfo.dwType);
				info->SynthGuid(portInfo.guidPort);
	
				_midiOutputPorts.push_back(info);
			}
		}

		// if everything went ok, hr should be s_false. Change it to absolute success
		if (hr == S_FALSE)
		{
			hr = S_OK;
		}
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

HRESULT MidiWrapper::SelectPort(string portDescription)
{
	HRESULT hr = E_FAIL;

	try
	{
		_currentPort = portDescription;

		// get the midiPortInfo
		bool foundPortInfo = false;
		list<MidiPortInfo*>::iterator portIt;
		MidiPortInfo* selectedPortInfo = NULL;
		for (portIt = _midiOutputPorts.begin(); portIt != _midiOutputPorts.end(); portIt++)
		{
			if ((*portIt)->PortDescription() == _currentPort)
			{
				foundPortInfo = true;
				selectedPortInfo = *portIt;
			}
		}

		// return error if not found
		if (!foundPortInfo || selectedPortInfo == NULL)
		{
			throw InvalidArgumentException("portDescription:" + _currentPort, "MidiWrapper::SelectPort");
		}

		DMUS_PORTPARAMS portParams;
		ZeroMemory(&portParams, sizeof(DMUS_PORTPARAMS));
		
		// Set the params for this port
		portParams.dwSize = sizeof(DMUS_PORTPARAMS);
		portParams.dwValidParams = DMUS_PORTPARAMS_CHANNELGROUPS;
		portParams.dwChannelGroups = 1;
	
		// If the port allows an audiopath
		if (selectedPortInfo->Flags() & DMUS_PC_AUDIOPATH)
		{
			portParams.dwFeatures = DMUS_PORT_FEATURE_AUDIOPATH;    
		}

		// create midi port
		hr = _music8->CreatePort(selectedPortInfo->SynthGuid(), &portParams, &_musicPort, NULL);
		if (FAILED(hr))
		{
			throw PlaybackException("_music8->CreatePort", "MidiWrapper::SelectPort", hr);
		}
	
		// activate port
		hr=_musicPort->Activate(TRUE);
		if (FAILED(hr))
		{
			throw PlaybackException("_music8->Activate", "MidiWrapper::SelectPort", hr);
		}

	}
	catch (exception& e)
	{
		// make sure hr points to failure
		if (SUCCEEDED(hr))
		{
			hr = E_FAIL;
		}
	}

	return hr;
}

HRESULT MidiWrapper::LoadMidi(string filename)
{
	//load a midi file into a segment

	HRESULT hr = E_FAIL;

	try
	{
		WCHAR wstrMidi[256];
	
		// release segment
		SAFE_RELEASE(_segment);
	
		// Converts ANSI (8-bits) to the UNICODE (16-bit) string
		LPCSTR szMidi;
		szMidi = filename.c_str();
		MultiByteToWideChar(CP_ACP, 0, szMidi, -1, wstrMidi, 256);
	
		// Then load it into the segment
		hr=_loader->LoadObjectFromFile(CLSID_DirectMusicSegment, IID_IDirectMusicSegment8, wstrMidi, (LPVOID*) &_segment);
		if (FAILED(hr))
		{
			throw PlaybackException("_loader->LoadObjectFromFile", "MidiWrapper::LoadMidi", hr);
		}
	
		// In case it is a midi file mark it is a standard midi file
		hr =_segment->SetParam(GUID_StandardMIDIFile, 0xFFFFFFFF, 0, 0, NULL);
		if(FAILED(hr))
		{
			throw PlaybackException("_segment->SetParam", "MidiWrapper::LoadMidi", hr);
		}

		// load dls collection if set
		if (!_dlsFile.empty())
		{
			SAFE_RELEASE(_musicCollection);
			DMUS_OBJECTDESC objDesc;
			mbstowcs(objDesc.wszFileName, _dlsFile.c_str(), DMUS_MAX_FILENAME);
			objDesc.dwSize = sizeof(DMUS_OBJECTDESC);
			objDesc.guidClass = CLSID_DirectMusicCollection;  
			objDesc.dwValidData = DMUS_OBJ_CLASS | DMUS_OBJ_FILENAME | DMUS_OBJ_FULLPATH;
			// get music collection
			hr = _loader->GetObject(&objDesc, IID_IDirectMusicCollection8, (void **) &_musicCollection);
			// connect segment to dls collection
			hr = _segment->SetParam(GUID_ConnectToDLSCollection, 0xFFFFFFFF, DMUS_SEG_ALLTRACKS, 0, (void*)_musicCollection);
		}
	
		// Finally, download band data to the performance  
		hr = _segment->Download(_performance);
	}
	catch (exception& e)
	{
		// make sure hr points to failure
		if (SUCCEEDED(hr))
		{
			hr = E_FAIL;
		}
	}

	return hr;
}

HRESULT MidiWrapper::Play()
{
	// play segment

	HRESULT hr = E_FAIL;	

	try
	{
		// Play the segment and store the segment state
		hr = _performance->PlaySegmentEx(_segment, NULL, NULL, 0, 0, &_segmentState, NULL, _3dAudioPath );
		if (FAILED(hr))
		{
			throw PlaybackException("_performance->PlaySegmentEx", "MidiWrapper::Play", hr);
		}
	
		// get the new interface for SegmentState
		hr =_segmentState->QueryInterface(IID_IDirectMusicSegmentState8, (LPVOID*)&_segmentState8);
		if (FAILED(hr))
		{
			throw PlaybackException("_segmentState->QueryInterface", "MidiWrapper::Play", hr);
		}
	
		// release segmentState
		SAFE_RELEASE(_segmentState);
	}
	catch (exception& e)
	{
		// make sure hr points to failure
		if (SUCCEEDED(hr))
		{
			hr = E_FAIL;
		}
	}
	return hr;
}	

HRESULT MidiWrapper::Pause()
{
	HRESULT hr = E_FAIL;
	
	try
	{
		MUSIC_TIME mtNow;
	
		// Stops the segment playback
		hr = _performance->Stop(NULL, NULL, 0, 0);
		if (FAILED(hr))
		{
			throw PlaybackException("_performance->Stop", "MidiWrapper::Play", hr);
		}
	
		// Get the position before the pause
		hr = _segmentState8->GetSeek(&mtNow);
		if (FAILED(hr))
		{
			throw PlaybackException("_segmentState8->GetSeek", "MidiWrapper::Play", hr);
		}
	
		// Set restart point
		hr = _segment->SetStartPoint(mtNow);
		if (FAILED(hr))
		{
			throw PlaybackException("_segment->SetStartPoint", "MidiWrapper::Play", hr);
		}
	}
	catch (exception& e)
	{
		// make sure hr points to failure
		if (SUCCEEDED(hr))
		{
			hr = E_FAIL;
		}
	}
	return hr;
}

HRESULT MidiWrapper::Resume()
{
	HRESULT hr = E_FAIL;

	try
	{
		if (IsPlaying() == S_FALSE)
		{
			hr = Play();
			if (FAILED(hr))
			{
				throw PlaybackException("Play()", "MidiWrapper::Resume", hr);
			}
		}
	}
	catch (exception& e)
	{
		// make sure hr points to failure
		if (SUCCEEDED(hr))
		{
			hr = E_FAIL;
		}
	}
	return hr;
}

HRESULT MidiWrapper::IsPlaying()
{
	HRESULT hr = E_FAIL;

	try
	{
		hr = _performance->IsPlaying(_segment, NULL);
		if (FAILED(hr))
		{
			throw PlaybackException("_performance->IsPlaying", "MidiWrapper::IsPlaying", hr);
		}
	}
	catch (exception& e)
	{
		// make sure hr points to failure
		if (SUCCEEDED(hr))
		{
			hr = E_FAIL;
		}
	}

	return hr;
}

HRESULT MidiWrapper::Stop()
{
	HRESULT hr = E_FAIL;

	try
	{
		if (_segment)
		{
			hr=_segment->SetStartPoint(0);
			if (FAILED(hr))
			{
				throw PlaybackException("_segment->SetStartPoint", "MidiWrapper::Stop", hr);
			}
		}

		if (_performance)
		{
			hr=_performance->Stop(NULL,NULL,0,0);
			if (FAILED(hr))
			{
				throw PlaybackException("_performance->Stop", "MidiWrapper::Stop", hr);
			}
		}

	}
	catch (exception& e)
	{
		// make sure hr points to failure
		if (SUCCEEDED(hr))
		{
			hr = E_FAIL;
		}
	}

	return hr;
}

HRESULT MidiWrapper::SetPosition(D3DVALUE x, D3DVALUE y, D3DVALUE z)
{	
	HRESULT hr = E_FAIL;

	try
	{
		hr = _3dSoundBuffer->SetPosition(x, y, z, DS3D_IMMEDIATE);
		if (FAILED(hr))
		{
			throw PlaybackException("_3dSoundBuffer->SetPosition", "MidiWrapper::SetPosition", hr);
		}
	}
	catch (exception& e)
	{
		// make sure hr points to failure
		if (SUCCEEDED(hr))
		{
			hr = E_FAIL;
		}
	}

	return hr;
}

HRESULT MidiWrapper::SetMode(DWORD mode)
{
	HRESULT hr = E_FAIL;

	try
	{
		hr = _3dSoundBuffer->SetMode(mode, DS3D_IMMEDIATE);
		if (FAILED(hr))
		{
			throw PlaybackException("_3dSoundBuffer->SetMode", "MidiWrapper::SetMode", hr);
		}
	}
	catch (exception& e)
	{
		// make sure hr points to failure
		if (SUCCEEDED(hr))
		{
			hr = E_FAIL;
		}	
	}

	return hr;
}

HRESULT MidiWrapper::SetMaxDistance(D3DVALUE maxDistance)
{	
	HRESULT hr = E_FAIL;

	try
	{
		hr = _3dSoundBuffer->SetMaxDistance(maxDistance, DS3D_IMMEDIATE);
		if (FAILED(hr))
		{
			throw PlaybackException("_3dSoundBuffer->SetMaxDistance", "MidiWrapper::SetMaxDistance", hr);
		}
	}
	catch (exception& e)
	{
		// make sure hr points to failure
		if (SUCCEEDED(hr))
		{
			hr = E_FAIL;
		}	
	}
	return hr;
}

HRESULT MidiWrapper::SetMasterTempo(float tempo)
{
	HRESULT hr = E_FAIL;

	try
	{
		hr = _performance->SetGlobalParam(GUID_PerfMasterTempo, (void*)&tempo, sizeof(float));
		if (FAILED(hr))
		{
			throw PlaybackException("_performance->SetGlobalParam", "MidiWrapper::SetMasterTempo", hr);
		}
	}
	catch (exception& e)
	{
		// make sure hr points to failure
		if (SUCCEEDED(hr))
		{
			hr = E_FAIL;
		}	
	}
	return hr;
}

HRESULT MidiWrapper::SetMasterVolume(long volume)
{
	// only in software synth. mode

	HRESULT hr = E_FAIL;

	try
	{
		hr = _performance->SetGlobalParam(GUID_PerfMasterVolume, (void*)&volume, sizeof(long));
		if (FAILED(hr))
		{
			throw PlaybackException("_performance->SetGlobalParam", "MidiWrapper::SetGlobalParam", hr);
		}
	}
	catch (exception& e)
	{
		// make sure hr points to failure
		if (SUCCEEDED(hr))
		{
			hr = E_FAIL;
		}	
	}
	return hr;
}


HRESULT MidiWrapper::SetEffect(bool enableReverb, bool enableChorus)
{
	HRESULT hr = E_FAIL;

	try
	{
		if (!_musicPort)
		{
			throw PlaybackException("_musicPort is null", "MidiWrapper::SetEffect");
		}

		// Get the IKsControl interface
		IKsControl *pControl;
		hr = _musicPort->QueryInterface(IID_IKsControl, (void**)&pControl);
		if (FAILED(hr))
		{
			throw PlaybackException("_musicPort->QueryInterface(IID_IKsControl", "MidiWrapper::SetEffect");
		}
	
		if (SUCCEEDED(hr))
		{
			DWORD dwEffects = 0;
			if(enableReverb)
			{
				dwEffects |= MidiEffectType::Reverb;
			}
			if (enableChorus)
			{
				dwEffects |= MidiEffectType::Chorus;
			}

			ULONG cb = 0;
			KSPROPERTY ksp;
			ZeroMemory(&ksp, sizeof(ksp));
			ksp.Set = GUID_DMUS_PROP_Effects;
			ksp.Id = 0;
			ksp.Flags = KSPROPERTY_TYPE_SET;
	
			hr = pControl->KsProperty(&ksp, sizeof(ksp), (LPVOID)&dwEffects, sizeof(dwEffects), &cb);
			if (FAILED(hr))
			{
				throw PlaybackException("pControl->KsProperty", "MidiWrapper::SetEffect");
			}

			SAFE_RELEASE(pControl);
		}
	}
	catch (exception& e)
	{
		// make sure hr points to failure
		if (SUCCEEDED(hr))
		{
			hr = E_FAIL;
		}	
	}

	return hr;
}

list<MidiPortInfo*> MidiWrapper::GetPortsInfo()
{
	// NOTE: Caller should NOT release list

	return _midiOutputPorts;
}

HRESULT MidiWrapper::SetDlsFile( string dlsFile )
{
	HRESULT hr = E_FAIL;

	try
	{
		CleanUp();

		_dlsFile = dlsFile;
		
		Initialize();

		hr = SelectPort(_currentPort);
		if (FAILED(hr))
		{
			throw PlaybackException("SelectPort", "MidiWrapper::SetDlsFile", hr);
		}

		hr = LoadMidi(_currentFile);
		if (FAILED(hr))
		{
			throw PlaybackException("LoadMidi", "MidiWrapper::SetDlsFile", hr);
		}
	}
	catch (exception& e)
	{
		// make sure hr points to failure
		if (SUCCEEDED(hr))
		{
			hr = E_FAIL;
		}	
	}

	return hr;
}

void MidiWrapper::CleanUp()
{
	Stop();

	// Remove ports and closedown the performance
	if (_loader)
	{	
		_loader->ReleaseObjectByUnknown(_segment);
		SAFE_RELEASE(_loader);
	}

	SAFE_RELEASE(_segmentState);
	SAFE_RELEASE(_segmentState8);
	SAFE_RELEASE(_3dAudioPath);
	SAFE_RELEASE(_3dSoundBuffer);
	SAFE_RELEASE(_segment);
	SAFE_RELEASE(_music);
	SAFE_RELEASE(_music8);	

	if (_performance)		
	{
		_performance->RemovePort(_musicPort);
		_performance->CloseDown();
		SAFE_RELEASE(_musicPort);
	}

	SAFE_RELEASE(_musicPort);
}