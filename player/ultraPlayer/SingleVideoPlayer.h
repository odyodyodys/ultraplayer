#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "PlaybackResultType.h"
	#include "ADShowPlayer.h"
	#include "SingleVideoGraphManager.h"
	#include "PlaybackEventNotifier.h"
	#include "Direct3dVmr9DshowPlayerEnvironment.h"

	#include "NotImplementedException.h"
#pragma endregion

class SingleVideoPlayer: public ADShowPlayer
{

	friend class PlayerFactory;

#pragma region Constructors/Destructors
private:
	SingleVideoPlayer( Direct3dVmr9DshowPlayerEnvironment* environment);
public:
	virtual ~SingleVideoPlayer();
#pragma endregion

#pragma region ADShowPlayer members
public:
	virtual bool Initialize();
	virtual bool OnMonitorChanged(DisplayDevice* newDevice);
#pragma endregion

#pragma region Methods
public:
	// Description: Sets image on top of video. Call is forwarded to GraphManager 
	PlaybackResultType::Type SetImage(UINT addonId, VisibleLayout* layout, string filename);

	// Description: Sets image on top of video. Call is forwarded to GraphManager 
	PlaybackResultType::Type SetText(UINT addonId, VisibleLayout* layout, string text);

	// Description: Removes an addon
	PlaybackResultType::Type RemoveAddon(UINT addonId);
#pragma endregion

};