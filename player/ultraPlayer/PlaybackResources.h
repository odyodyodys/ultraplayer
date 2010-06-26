#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
#pragma endregion

class PlaybackResources
{
#pragma region Fields
private:
	static PlaybackResources* _instance;

	// Custom window messages
	DWORD _dshowEventCode; // thrown on DShow events
	DWORD _displayChangedEventCode; // thrown when window switches monitor
	DWORD _suppressLogoDrawingEventCode;
	DWORD _allowLogoDrawingEventCode;
	// max sources in the vmr9 interface
	UINT _maxVmr9Sources;
#pragma endregion

#pragma region Constructors/Destructors
private:
	PlaybackResources();
public:
	virtual ~PlaybackResources();
#pragma endregion

#pragma region Methods
public:
	// Description: Part of the singleton pattern.
	static PlaybackResources* Instance();
#pragma endregion

#pragma region Properties
public:
	DWORD DshowEventCode();
	DWORD DisplayChangedEventCode();
	UINT MaxVmr9Sources();
	DWORD SuppressLogoDrawingEventCode();
	DWORD AllowLogoDrawingEventCode();
#pragma endregion

};