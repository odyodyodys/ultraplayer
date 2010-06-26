#include "AudioPlayer.h"

AudioPlayer::AudioPlayer(ComEnabledPlayerEnvironment* environment):APlayer(PlayerType::Audio, (APlayerEnvironment*)environment)
{
	_soundManager = new CSoundManager();
	_sound = NULL;

	_soundFxManager = new SoundFxManager();

	_3dBuffer = NULL;
	_listener = NULL;
	_currentVolume = 100;
}

AudioPlayer::~AudioPlayer(void)
{
}

bool AudioPlayer::Initialize()
{
	bool success = false;
	HRESULT hr = E_FAIL;
	try
	{
		if (!_environment->Initialize())
		{
			throw InitializationFailedException("_environment->Initialize","AudioPlayer::Initialize");
		}

		hr = _soundManager->Initialize(_environment->Window(), DSSCL_PRIORITY);
		if (FAILED(hr))
		{
			throw InitializationFailedException("_soundManager->Initialize", "AudioPlayer::Initialize" , hr);
		}

		// format to stereo, 22kHz and 16-bit output.
		hr = _soundManager->SetPrimaryBufferFormat(2, 22050, 16);
		if (FAILED(hr))
		{
			throw InitializationFailedException("_soundManager->SetPrimaryBufferFormat", "AudioPlayer::Initialize" , hr);
		}

		// get the 3d listener
		hr = _soundManager->Get3DListenerInterface(&_listener);
		if (FAILED(hr))
		{
			throw InitializationFailedException("_soundManager->Get3DListenerInterface", "AudioPlayer::Initialize" , hr);
		}

		// Get listener parameters
		_listenerParams.dwSize = sizeof(DS3DLISTENER);
		hr = _listener->GetAllParameters( &_listenerParams );
		if (FAILED(hr))
		{
			throw InitializationFailedException("_soundManager->GetAllParameters", "AudioPlayer::Initialize" , hr);
		}

		success = true;
	}
	catch (exception& e)
	{
		success = false;
	}
	return success;
}

PlaybackResultType::Type AudioPlayer::Play( list<pair<int, string>> files )
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;
	HRESULT hr = E_FAIL;
	try
	{
		// get first file in list
		if (files.size() < 1)
		{
			throw InvalidArgumentException("files","AudioPlayer::Play");
		}

		list<pair<int, string>>::iterator it = files.begin();
		string file = (*it).second;

		// validate wave file
		if (!WaveFileValidator::Instance()->IsValid(file))
		{
			throw InvalidArgumentException("file not valid wave file", "AudioPlayer::Play");
		}

		// cleanup
		_soundFxManager->DisableAllFx();
		if( _sound )
		{
			_sound->Stop();
			_sound->Reset();
			SAFE_DELETE(_sound);
		}

		// verify the sound has only one channel
		if (WaveFileValidator::Instance()->GetChannelCount(file) != 1)
		{
			throw InvalidArgumentException("wave doesn't have one channel only", "AudioPlayer::Play");
		}
		
		
		USES_CONVERSION;
		hr = _soundManager->Create(&_sound, A2W(file.c_str()), DSBCAPS_CTRLVOLUME | DSBCAPS_CTRLFX | DSBCAPS_GLOBALFOCUS | DSBCAPS_CTRL3D | DSBCAPS_CTRLFREQUENCY, DS3DALG_HRTF_FULL);
		if (hr == DSERR_BUFFERTOOSMALL)
		{
			// DSERR_BUFFERTOOSMALL will be returned if the buffer is
			// less than DSBSIZE_FX_MIN (150ms) and the buffer is created
			// with DSBCAPS_CTRLFX.
			throw InvalidArgumentException("wave duration too short. Cannot apply effects on files with less than 150ms duration", "AudioPlayer::Play");
		}
//		[OBSOLETE. Vista/7 doesn't support it, although it works fine]
// 		else if (hr == DS_NO_VIRTUALIZATION)
// 		{
// 			throw InvalidArgumentException("The 3D virtualization algorithm requested is not supported under this operating system.", "AudioPlayer::Play");
// 		}
		else if (FAILED(hr))
		{
			throw PlaybackException("_soundManager->Create", "AudioPlayer::Play");
		}

		// Get the 3D buffer from the secondary buffer
		hr = _sound->Get3DBufferInterface( 0, &_3dBuffer );
		if( FAILED(hr) )
		{
			throw PlaybackException("Could not get 3D buffer.", "AudioPlayer::Play");
		}

		// Get the 3D buffer parameters
		_3dBufferParams.dwSize = sizeof(DS3DBUFFER);
		hr = _3dBuffer->GetAllParameters( &_3dBufferParams );
		if( FAILED(hr) )
		{
			throw PlaybackException("Could not get 3D buffer parameters.", "AudioPlayer::Play");
		}

		// Set new 3D buffer parameters with head realtive flag
		_3dBufferParams.dwMode = DS3DMODE_HEADRELATIVE;
		hr = _3dBuffer->SetAllParameters( &_3dBufferParams, DS3D_IMMEDIATE );
		if( FAILED(hr) )
		{
			throw PlaybackException("Could not set 3d buffer params with DS3DMODE_HEADRELATIVE flag.", "AudioPlayer::Play");
		}

		// initialize effects manager
		hr = _soundFxManager->Initialize( _sound->GetBuffer( 0 ), TRUE );
		if (FAILED(hr))
		{
			throw PlaybackException("_soundFxManager->Initialize", "AudioPlayer::Play");
		}

		for (list<ASoundFx*>::iterator it = _soundEffects.begin(); it != _soundEffects.end(); it++)
		{
			_soundFxManager->SetFxEnable((*it)->Type());
		}
		
		hr = _soundFxManager->ActivateFx();
		if (FAILED(hr))
		{
			throw PlaybackException("Could not activate soundFxs", "AudioPlayer::Play");
		}

		hr = _soundFxManager->LoadCurrentFxParameters();

		hr = _sound->Play(0, DSBPLAY_LOOPING);
		if (FAILED(hr))
		{
			throw PlaybackException("_sound->Play", "AudioPlayer::Play");
		}

		if (!_sound->IsSoundPlaying())
		{
			throw PlaybackException("didnt start playing","AudioPlayer::Play");
		}

		// set volume if needed
		if (_currentVolume > 0)
		{
			SetVolume(_currentVolume);
		}


		result = PlaybackResultType::Success;
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}
	return result;
}

PlaybackResultType::Type AudioPlayer::Pause()
{
	// not supported
	return PlaybackResultType::Failure;
}

PlaybackResultType::Type AudioPlayer::Resume()
{
	// not supported
	return PlaybackResultType::Failure;
}

PlaybackResultType::Type AudioPlayer::Stop()
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;
	try
	{
		if (_sound)
		{
			_sound->Stop();
			_sound->Reset();
		}

		RemoveEffects();

		_soundFxManager->DisableAllFx();

		result = PlaybackResultType::Success;
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}
	return result;
}

PlaybackResultType::Type AudioPlayer::SetVolume( UINT volume )
{
	PlaybackResultType::Type result= PlaybackResultType::Failure;
	try
	{
		if (!_sound)
		{
			throw PlaybackException("Nothing is currently playing", "AudioPlayer::SetVolume");
		}

		_currentVolume = volume;
		LPDIRECTSOUNDBUFFER soundBuffer = _sound->GetBuffer(0);
		HRESULT hr = soundBuffer->SetVolume(VolumeLevelConverter::Instance()->Convert((UINT)_currentVolume));
		if (FAILED(hr))
		{
			throw PlaybackException("soundBuffer->SetVolume","AudioPlayer::SetVolume");
		}

		result = PlaybackResultType::Success;
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}
	return result;
}

PlaybackResultType::Type AudioPlayer::Seek( UINT milliseconds )
{
return PlaybackResultType::Failure;
}

PlaybackResultType::Type AudioPlayer::SetEffect(ASoundFx* soundFx)
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;
	bool exists = false;
	try
	{
		// check if exists
		ASoundFx* foundSoundFx = NULL;
		for(list<ASoundFx*>::iterator it = _soundEffects.begin(); it != _soundEffects.end(); it++)
		{
			if ((*it)->Type() == soundFx->Type() )
			{
				exists = true;
				foundSoundFx = *it;
				break;
			}
		}

		if (exists)
		{
			// update it
			foundSoundFx->CopyFrom(soundFx);
		}
		else
		{
			//insert new (make a copy of it)
			_soundEffects.push_back(soundFx->MakeCopy());

			_soundFxManager->SetFxEnable(soundFx->Type());
		}

		ApplySoundFxToFxManager(soundFx);

		result = PlaybackResultType::Success;
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}
	return result;
}

PlaybackResultType::Type AudioPlayer::RemoveEffects()
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;
	try
	{
		//TODO lock object
	
		for(list<ASoundFx*>::iterator it = _soundEffects.begin(); it != _soundEffects.end(); it++)
		{
			if (*it)
			{
				delete *it;
			}
		}
	
		_soundEffects.clear();

		result = PlaybackResultType::Success;
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}

	return result;
}

void AudioPlayer::ApplySoundFxToFxManager(ASoundFx* fx)
{
	try
	{
		switch (fx->Type())
		{
		case SoundFxType::Chorus:
			DSFXChorus paramsChorus;
			paramsChorus.fWetDryMix = ((ChorusSoundFx*)fx)->WetDryMix();
			paramsChorus.fDepth = ((ChorusSoundFx*)fx)->Depth();
			paramsChorus.fFeedback = ((ChorusSoundFx*)fx)->Feedback();
			paramsChorus.fFrequency = ((ChorusSoundFx*)fx)->Frequency();
			paramsChorus.fDelay = ((ChorusSoundFx*)fx)->Delay();

			switch (((ChorusSoundFx*)fx)->Waveform())
			{
			case WaveformType::Triangle:
				paramsChorus.lWaveform = DSFXCHORUS_WAVE_TRIANGLE;
				break;
			case WaveformType::Sine:
				paramsChorus.lWaveform = DSFXCHORUS_WAVE_SIN;
				break;
			}

			switch (((ChorusSoundFx*)fx)->Phase())
			{
			case PhaseType::Minus180:
				paramsChorus.lPhase = DSFXCHORUS_PHASE_NEG_180;
				break;
			case PhaseType::Minus90:
				paramsChorus.lPhase = DSFXCHORUS_PHASE_NEG_90;
				break;
			case PhaseType::Zero:
				paramsChorus.lPhase = DSFXCHORUS_PHASE_ZERO;
				break;
			case PhaseType::Plus90:
				paramsChorus.lPhase = DSFXCHORUS_PHASE_90;
				break;
			case PhaseType::Plus180:
				paramsChorus.lPhase = DSFXCHORUS_PHASE_180;
				break;
			}

			_soundFxManager->ParamsChorus(paramsChorus) ;

			break;
		case SoundFxType::Compressor:
			DSFXCompressor paramsCompressor;
			paramsCompressor.fGain = ((CompressorSoundFx*)fx)->Gain();
			paramsCompressor.fAttack = ((CompressorSoundFx*)fx)->Attack();
			paramsCompressor.fRelease = ((CompressorSoundFx*)fx)->Release();
			paramsCompressor.fThreshold = ((CompressorSoundFx*)fx)->Threshold();
			paramsCompressor.fRatio = ((CompressorSoundFx*)fx)->Ratio();
			paramsCompressor.fPredelay = ((CompressorSoundFx*)fx)->Predelay();

			_soundFxManager->ParamsCompressor(paramsCompressor) ;

			break;
		case SoundFxType::Distortion:
			DSFXDistortion paramsDistortion;
			paramsDistortion.fGain = ((DistortionSoundFx*)fx)->Gain();
			paramsDistortion.fEdge = ((DistortionSoundFx*)fx)->Edge();
			paramsDistortion.fPostEQCenterFrequency = ((DistortionSoundFx*)fx)->PostEqCenterFreq();
			paramsDistortion.fPostEQBandwidth = ((DistortionSoundFx*)fx)->PostEqBandwidth();
			paramsDistortion.fPreLowpassCutoff = ((DistortionSoundFx*)fx)->PreLowpassCutoff();
			
			_soundFxManager->ParamsDistortion(paramsDistortion) ;

			break;
		case SoundFxType::Echo:
			DSFXEcho paramsEcho;
			paramsEcho.fWetDryMix = ((EchoSoundFx*)fx)->WetDryMix();
			paramsEcho.fFeedback = ((EchoSoundFx*)fx)->Feedback();
			paramsEcho.fLeftDelay = ((EchoSoundFx*)fx)->LeftDelay();
			paramsEcho.fRightDelay = ((EchoSoundFx*)fx)->RightDelay();
			paramsEcho.lPanDelay = ((EchoSoundFx*)fx)->PanDelay();
			
			_soundFxManager->ParamsEcho(paramsEcho) ;

			break;
		case SoundFxType::Flanger:
			DSFXFlanger paramsFlanger;
			paramsFlanger.fWetDryMix = ((FlangerSoundFx*)fx)->WetDryMix();
			paramsFlanger.fDepth = ((FlangerSoundFx*)fx)->Depth();
			paramsFlanger.fFeedback = ((FlangerSoundFx*)fx)->Feedback();
			paramsFlanger.fFrequency = ((FlangerSoundFx*)fx)->Frequency();
			paramsFlanger.fDelay = ((FlangerSoundFx*)fx)->Delay();
			
			switch (((FlangerSoundFx*)fx)->Waveform())
			{
			case WaveformType::Triangle:
				paramsFlanger.lWaveform = DSFXFLANGER_WAVE_TRIANGLE;
				break;
			case WaveformType::Sine:
				paramsFlanger.lWaveform = DSFXFLANGER_WAVE_SIN;
				break;
			}

			switch (((FlangerSoundFx*)fx)->Phase())
			{
			case PhaseType::Minus180:
				paramsFlanger.lPhase = DSFXFLANGER_PHASE_NEG_180;
				break;
			case PhaseType::Minus90:
				paramsFlanger.lPhase = DSFXFLANGER_PHASE_90;
				break;
			case PhaseType::Zero:
				paramsFlanger.lPhase = DSFXFLANGER_PHASE_ZERO;
				break;
			case PhaseType::Plus90:
				paramsFlanger.lPhase = DSFXFLANGER_PHASE_90;
				break;
			case PhaseType::Plus180:
				paramsFlanger.lPhase = DSFXFLANGER_PHASE_180;
				break;
			}

			_soundFxManager->ParamsFlanger(paramsFlanger) ;
	
			break;
		case SoundFxType::Gargle:
			DSFXGargle paramsGargle;
			paramsGargle.dwRateHz = ((GargleSoundFx*)fx)->Rate();
	
			switch (((FlangerSoundFx*)fx)->Waveform())
			{
			case WaveformType::Triangle:
				paramsGargle.dwWaveShape = DSFXGARGLE_WAVE_TRIANGLE;
				break;
			case WaveformType::Square:
				paramsGargle.dwWaveShape = DSFXGARGLE_WAVE_SQUARE;
				break;
			}
			
			_soundFxManager->ParamsGargle(paramsGargle) ;

			break;
		case SoundFxType::ParamEq:
			DSFXParamEq paramsParamEq;
			paramsParamEq.fCenter = ((ParamEqSoundFx*)fx)->CenterFreq();
			paramsParamEq.fBandwidth = ((ParamEqSoundFx*)fx)->Bandwidth();
			paramsParamEq.fGain = ((ParamEqSoundFx*)fx)->Gain();
			
			_soundFxManager->ParamsParamEq(paramsParamEq) ;

			break;
		case SoundFxType::Reverb:
			DSFXWavesReverb paramsReverb;
			paramsReverb.fInGain = ((ReverbSoundFx*)fx)->InGain();
			paramsReverb.fReverbMix = ((ReverbSoundFx*)fx)->ReverbMix();
			paramsReverb.fReverbTime = ((ReverbSoundFx*)fx)->ReverbTime();
			paramsReverb.fHighFreqRTRatio = ((ReverbSoundFx*)fx)->HighFreqRtRatio();

			_soundFxManager->ParamsReverb(paramsReverb) ;

			break;
		default:
			throw PlaybackException("sound fx not supported", "SoundFxFactory::CreateFromType");
		}
	}
	catch (exception& e)
	{
		
	}
}

PlaybackResultType::Type AudioPlayer::Set3d( float dopplerFactor, float rolloffFactor, float minDistance, float maxDistance, float sourceX, float sourceY, float sourceZ )
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;
	HRESULT hr = E_FAIL;
	try
	{
		// apply listener's parameters
		_listenerParams.flDopplerFactor = dopplerFactor;
		_listenerParams.flRolloffFactor = rolloffFactor;
		hr = _listener->SetAllParameters(&_listenerParams, DS3D_IMMEDIATE );
		if (FAILED(hr))
		{
			throw PlaybackException("_listener->SetAllParameters", "AudioPlayer::Set3d");
		}

		// apply source's parameters
		_3dBufferParams.flMinDistance = minDistance;
		_3dBufferParams.flMaxDistance = maxDistance;
		D3DVECTOR position;
		position.x = sourceX;
		position.y = sourceY;
		position.z = sourceZ;
		memcpy( &_3dBufferParams.vPosition, &position, sizeof(D3DVECTOR) );
		memcpy( &_3dBufferParams.vVelocity, &position, sizeof(D3DVECTOR) );
		hr = _3dBuffer->SetAllParameters(&_3dBufferParams, DS3D_IMMEDIATE );
		if (FAILED(hr))
		{
			throw PlaybackException("_3dBuffer->SetAllParameters", "AudioPlayer::Set3d");
		}



		result = PlaybackResultType::Success;
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}

	return result;
}

PlaybackResultType::Type AudioPlayer::SetFrequency( int frequency )
{
	PlaybackResultType::Type result = PlaybackResultType::Failure;
	try
	{
		HRESULT hr = E_FAIL;

		if (_sound)
		{
			LPDIRECTSOUNDBUFFER buff = _sound->GetBuffer(0);
			HRESULT hr = buff->SetFrequency(frequency);
			if (FAILED(hr))
			{
				throw PlaybackException("buff->SetFrequency", "AudioPlayer::SetFrequency");
			}
		}		

		result = PlaybackResultType::Success;
	}
	catch (exception& e)
	{
		result = PlaybackResultType::Failure;
	}

	return result;
}

bool AudioPlayer::OnMonitorChanged(DisplayDevice* newDevice)
{
	// does not care
	return true;
}