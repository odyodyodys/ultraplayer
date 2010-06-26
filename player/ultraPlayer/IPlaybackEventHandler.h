#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
#pragma endregion

__interface IPlaybackEventHandler
{
#pragma region Methods
public:
	// Description: Handles an event that occured on a window
	virtual void HandleEvent(DWORD eventCode, HWND window);
#pragma endregion

};