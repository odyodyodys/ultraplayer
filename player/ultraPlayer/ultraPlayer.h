#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "APlayer.h"
#include "MultiVideoPlayer.h"
#include "PlayerType.h"
#include "TCPServer.h"
#include "PlayerFactory.h"
#include "WindowManager.h"
#include "ARequest.h"
#include "PlayerInstructor.h"
#include "WindowLayoutRequest.h"
#include "WindowLayoutResponse.h"
#include "GeneralFailureResponse.h"
#include "MonitorUtils.h"
#include "DisplayDevicesInfoRequest.h"
#include "DisplayDevicesInfoResponse.h"
#include "DisplayDevice.h"
#include "TerminationRequest.h"
#include "TerminationResponse.h"
#include "SetPlayerTypeRequest.h"
#include "SetPlayerTypeResponse.h"

#include "NotImplementedException.h"
#pragma endregion

class UltraPlayer: public IRequestHandler
{
#pragma region Fields
private:
	static UltraPlayer* _instance;
	HINSTANCE _hinstance;
	APlayer* _player;
	PlayerInstructor* _playerInstructor;
	TCPServer* _server;
	WindowManager* _windowManager;

#pragma endregion

#pragma region Constructors/Destructor
private:
	UltraPlayer(void);
public:
	~UltraPlayer(void);
#pragma endregion

#pragma region Methods
public:
	// Description: Part of the singleton pattern.
	static UltraPlayer* Instance();

	// Description: Creates a player base on the requested type
	// Exceptions: InitializationFailedException
	void Initialize();

	// Description: Starts the player
	// Exceptions: InitializationFailedException
	void Start(USHORT port);

	// Description: Stops all application activity
	void Stop();
private:
    // Description: Sets up a player object
    void SetUpPlayer( PlayerType::Type playerType );

#pragma endregion

#pragma region Properties
public:
	void HInstance(HINSTANCE hinstance);
#pragma endregion

#pragma region IRequestHandler members
public:

	//Description: Handles termination, windowLayout messages
	virtual AResponse* HandleRequest(ARequest* request);
#pragma endregion

#pragma region Methods
private:
	// Description: Handles window layout request
	AResponse* HandleWindowLayoutRequest(WindowLayoutRequest* request);

	// Description: Handles Display device info request
	AResponse* HandleDisplayDeviceInfoRequest(DisplayDevicesInfoRequest* request);

	// Description: Handles termination request
	AResponse* HandleTerminationRequest(TerminationRequest* request);

    // Description: Handles Set Player Type request
    AResponse* HandleSetPlayerTypeRequest(SetPlayerTypeRequest* request);
#pragma endregion
};
