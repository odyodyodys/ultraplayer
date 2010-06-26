#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "APlayer.h"
	#include "AGraphManager.h"
	#include "PlayerType.h"
	#include "DshowPlayerEnvironment.h"
	#include "PlaybackResources.h"

	#include "PlaybackException.h"
#pragma endregion

class ADShowPlayer abstract : public APlayer
{
#pragma region Fields
protected:
	AGraphManager* _graphManager;
#pragma endregion

#pragma region Constructors/Destructors
protected:
	ADShowPlayer(PlayerType::Type playerType, DshowPlayerEnvironment* environment);
public:
	virtual ~ADShowPlayer();
#pragma endregion

#pragma region Derived from APlayer
public:
	virtual bool Initialize()=0;
	virtual PlaybackResultType::Type Play(list<pair<int, string>> files);
	virtual PlaybackResultType::Type Pause();
	virtual PlaybackResultType::Type Resume();
	virtual PlaybackResultType::Type Stop();
	virtual PlaybackResultType::Type SetVolume(UINT volume);
	virtual PlaybackResultType::Type Seek(UINT milliseconds);
	virtual bool OnMonitorChanged(DisplayDevice* newDevice)=0;
#pragma endregion

#pragma region Methods
public:
	// Description: Sets the playback rate
	virtual PlaybackResultType::Type SetRate(float rate);
#pragma endregion

};