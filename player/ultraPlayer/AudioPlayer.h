#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "PlaybackResultType.h"
	#include "APlayer.h"
	#include "APlayerEnvironment.h"
	#include "ComEnabledPlayerEnvironment.h"
	#include "SoundFxManager.h"
	#include "WaveFileValidator.h"
	#include "ASoundFx.h"
	#include "ChorusSoundFx.h"
	#include "CompressorSoundFx.h"
	#include "DistortionSoundFx.h"
	#include "EchoSoundFx.h"
	#include "FlangerSoundFx.h"
	#include "GargleSoundFx.h"
	#include "ParamEqSoundFx.h"
	#include "ReverbSoundFx.h"
	#include "PlaybackResources.h"
	#include "VolumeLevelConverter.h"

	#include "PlaybackException.h"
	#include "InvalidArgumentException.h"
	#include "InitializationFailedException.h"
	#include "NotImplementedException.h"
#pragma endregion

using namespace std;

class AudioPlayer: public APlayer
{

friend class PlayerFactory;

#pragma region Fields
private:
	CSound* _sound;
	CSoundManager* _soundManager;
	
	// sound fx
	SoundFxManager* _soundFxManager;

	// 3d buffer
	LPDIRECTSOUND3DBUFFER	_3dBuffer;
	DS3DBUFFER _3dBufferParams;
	
	// 3d listener
	LPDIRECTSOUND3DLISTENER	_listener; // 3D listener object
	DS3DLISTENER _listenerParams; // 3D Listener parameter

	list<ASoundFx*> _soundEffects;
	int _currentVolume;
#pragma endregion

#pragma region Constructors/Destructors
private:
	AudioPlayer(ComEnabledPlayerEnvironment* environment);
public:
	virtual ~AudioPlayer();
#pragma endregion

#pragma region Methods
private:
	// Description: Removes all sound fxs
	PlaybackResultType::Type RemoveEffects();

	// Description: Applies a sounfx to the soundfx manager
	void ApplySoundFxToFxManager(ASoundFx* fx);
public:
	// Description: Set an effect
	PlaybackResultType::Type SetEffect(ASoundFx* soundFx);

	// Description: Set spatialization properties
	PlaybackResultType::Type Set3d(float doplerFactor, float rolloffFactor, float minDistance, float maxDistance, float sourceX, float sourceY, float sourceZ);
	
	// Description: Set playback frequency (pitch, sampling rate)
	PlaybackResultType::Type SetFrequency(int frequency);
#pragma endregion

#pragma region APlayer members
public:
	virtual bool Initialize();
	virtual PlaybackResultType::Type Play(list<pair<int, string>> files);
	virtual PlaybackResultType::Type Pause();
	virtual PlaybackResultType::Type Resume();
	virtual PlaybackResultType::Type Stop();
	virtual PlaybackResultType::Type SetVolume(UINT volume);
	virtual PlaybackResultType::Type Seek(UINT milliseconds);
	virtual bool OnMonitorChanged(DisplayDevice* newDevice);
#pragma endregion
};