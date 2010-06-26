#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "APlayer.h"
	#include "PlayerType.h"
	#include "MultiVideoPlayer.h"
	#include "SingleVideoPlayer.h"
	#include "AudioPlayer.h"
	#include "MidiPlayer.h"
	#include "DisplayDevice.h"

	#include "NotImplementedException.h"
	#include "InitializationFailedException.h"
#pragma endregion

class PlayerFactory
{
#pragma region Constructors/Destructors
public:
	PlayerFactory();
	~PlayerFactory();
#pragma endregion

#pragma region Methods
public:
	// Description: Part of a factory pattern. Creates player objects.
	static APlayer* CreatePlayer(PlayerType::Type playerType, HWND windowHandle, DisplayDevice* const displayDevice );
#pragma endregion

};