#include "MidiPlayer.h"

MidiPlayer::MidiPlayer(ComEnabledPlayerEnvironment* environment):APlayer(PlayerType::Midi, (APlayerEnvironment*) environment)
{
	_midiMusic = new MidiWrapper();
}

MidiPlayer::~MidiPlayer(void)
{
	if (_midiMusic)
	{
		delete _midiMusic;
	}
}

bool MidiPlayer::Initialize()
{
	bool success = true;
	try
	{
		success &= _environment->Initialize();
		success &= _midiMusic->Initialize();
	}
	catch (exception& e)
	{
		success = false;
	}
	return success;
}

PlaybackResultType::Type MidiPlayer::Play( list<pair<int, string>> files )
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;

	try
	{
		if (!_midiMusic)
		{
			throw PlaybackException("_midiMusic is null", "MidiPlayer::Play");
		}

		_midiMusic->Stop();

		list<pair<int, string>>::iterator fileIterator = files.begin();
		string mediaFilename = (*fileIterator).second;

		HRESULT hr = _midiMusic->LoadMidi(mediaFilename);
		if (FAILED(hr))
		{
			throw PlaybackException("Could not load", "MidiPlayer::Play");
		}

		hr = _midiMusic->Play();
		if (FAILED(hr))
		{
			throw PlaybackException("Could not play", "MidiPlayer::Play");
		}

		result = PlaybackResultType::Success;
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}

	return result;
}

PlaybackResultType::Type MidiPlayer::Pause()
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;
	try
	{
		if (!_midiMusic)
		{
			throw PlaybackException("_midiMusic is null", "MidiPlayer::Play");
		}

		_midiMusic->Pause();

		result = PlaybackResultType::Success;
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}
	return result;
}

PlaybackResultType::Type MidiPlayer::Resume()
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;
	try
	{
		if (!_midiMusic)
		{
			throw PlaybackException("_midiMusic is null", "MidiPlayer::Play");
		}

		_midiMusic->Play();

		result = PlaybackResultType::Success;
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}
	return result;
}

PlaybackResultType::Type MidiPlayer::Stop()
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;
	try
	{
		if (!_midiMusic)
		{
			throw PlaybackException("_midiMusic is null", "MidiPlayer::Play");
		}

		_midiMusic->Stop();

		result = PlaybackResultType::Success;
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}
	return result;
}

PlaybackResultType::Type MidiPlayer::SetVolume( UINT volume )
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;
	try
	{
		if (!_midiMusic)
		{
			throw PlaybackException("_midiMusic is null", "MidiPlayer::SetVolume");
		}

		_midiMusic->SetMasterVolume(VolumeLevelConverter::Instance()->Convert(volume));

		result = PlaybackResultType::Success;
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}
	return result;
}

PlaybackResultType::Type MidiPlayer::Seek( UINT milliseconds )
{
	throw NotImplementedException("", "MidiPlayer::Seek");
}

list<string> MidiPlayer::GetMidiOutputPortList()
{
	list<string> portList;
	try
	{
		list<MidiPortInfo*> portInfoList = _midiMusic->GetPortsInfo();
		list<MidiPortInfo*>::iterator portInfoListIterator;
		for (portInfoListIterator = portInfoList.begin(); portInfoListIterator != portInfoList.end(); portInfoListIterator++)
		{
			portList.push_back((*portInfoListIterator)->PortDescription());
		}
	}
	catch (exception& e)
	{
		
	}
	return portList;
}

PlaybackResultType::Type MidiPlayer::SetMidiOutputPort( string midiPortDescription )
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;
	try
	{
		// validate data
		if (midiPortDescription.empty())
		{
			throw InvalidArgumentException("midiPortDescription.empty", "MidiPlayer::SetMidiOutputPort");
		}

		// Delete the previous _midiMusic object
		delete _midiMusic;
		
		// create a new one
		_midiMusic = new MidiWrapper();

		// initialize it
		_midiMusic->Initialize();

		// select the new port
		HRESULT hr = _midiMusic->SelectPort(midiPortDescription);
		if (SUCCEEDED(hr))
		{
			result = PlaybackResultType::Success;
		}
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}
	return result;
}

PlaybackResultType::Type MidiPlayer::SetMidiProperties( bool enableReverb, bool enableChorus, float tempo )
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;
	try
	{
		HRESULT hr = _midiMusic->SetMasterTempo(tempo);
		if (FAILED(hr))
		{
			throw PlaybackException("_midiMusic->SetMasterTempo", "MidiPlayer::SetMidiProperties");
		}

		hr = _midiMusic->SetEffect(enableReverb, enableChorus);
		if (FAILED(hr))
		{
			throw PlaybackException("_midiMusic->SetEffect", "MidiPlayer::SetMidiProperties");
		}

		result = PlaybackResultType::Success;
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}
	return result;
}

PlaybackResultType::Type MidiPlayer::Set3dPosition( float x, float y, float z )
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;
	try
	{
		HRESULT hr = _midiMusic->SetPosition(y, y, z);
		if (FAILED(hr))
		{
			throw PlaybackException("_midiMusic->SetPosition", "MidiPlayer::Set3dPosition");
		}

		result = PlaybackResultType::Success;
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}
	return result;
}

PlaybackResultType::Type MidiPlayer::SetDlsFile( string dlsFile )
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;
	try
	{
		HRESULT hr = _midiMusic->SetDlsFile(dlsFile);
		if (FAILED(hr))
		{
			throw PlaybackException("_midiMusic->SetDlsFile", "MidiPlayer::SetDlsFile");
		}

		result = PlaybackResultType::Success;
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}
	return result;
}

bool MidiPlayer::OnMonitorChanged(DisplayDevice* newDevice)
{
	// does not care
	return true;
}