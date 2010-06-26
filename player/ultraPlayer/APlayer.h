#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "IRequestHandler.h"
	#include "ARequest.h"
	#include "PlaybackResultType.h"
	#include "PlayerType.h"
	#include "APlayerEnvironment.h"
	#include "DisplayDevice.h"

#pragma endregion

using namespace std;

class APlayer abstract
{
#pragma region Fields
protected:
	PlayerType::Type _playerType;
	list<pair<int, string>> _files;
	APlayerEnvironment* _environment;

#pragma endregion

#pragma region Constructors/Destructor
protected:
	APlayer(PlayerType::Type playerType, APlayerEnvironment* environment);
public:
    virtual ~APlayer(void);
#pragma endregion

#pragma region Properties
public:
	PlayerType::Type PlayerType();
#pragma endregion

#pragma region Methods
public:
	// Description: Initializes player
	virtual bool Initialize()=0;

	// Description: Plays media files
	virtual PlaybackResultType::Type Play(list<pair<int, string>> files)=0;

	// Description: Pauses playback
	virtual PlaybackResultType::Type Pause()=0;

	// Description: Resumes playback
	virtual PlaybackResultType::Type Resume()=0;

	// Description: Stops playback
	virtual PlaybackResultType::Type Stop()=0;

	// Description: Sets the output volume of the playback
	virtual PlaybackResultType::Type SetVolume(UINT volume)=0;

	// Description: Seeks to a position within the media file
	virtual PlaybackResultType::Type Seek(UINT milliseconds)=0;

	// Description: Is called when application is moved to another monitor
	virtual bool OnMonitorChanged(DisplayDevice* newDevice)=0;

#pragma endregion
};
