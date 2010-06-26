#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "PlaybackResultType.h"
	#include "ADShowPlayer.h"
	#include "MultiVideoGraphManager.h"
	#include "VisibleLayout.h"
	#include "PlaybackEventNotifier.h"
	#include "PlayerType.h"
	#include "Vmr9DshowPlayerEnvironment.h"

	#include "NotImplementedException.h"
#pragma endregion

class MultiVideoPlayer : public ADShowPlayer
{
	
	friend class PlayerFactory;

#pragma region Constructors/Desctructor
private:
	MultiVideoPlayer(Vmr9DshowPlayerEnvironment* environment);
public:
    ~MultiVideoPlayer(void);
#pragma endregion

#pragma region ADShowPlayer
public:
	virtual bool Initialize();
	virtual bool OnMonitorChanged(DisplayDevice* newDevice);
#pragma endregion

#pragma region Methods
public:
	// Description: Sets layout for the specified video
	PlaybackResultType::Type VideoLayout(int videoId, VisibleLayout* layout);
#pragma endregion

};
