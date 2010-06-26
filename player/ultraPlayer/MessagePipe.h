#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "ARequest.h"
#include "AResponse.h"
#include "CommunicationResources.h"
#pragma endregion

class MessagePipe
{
#pragma region Fields
private:
	HANDLE _responseCreatedEvent;
	ARequest* _request;
	AResponse* _response;

	// used to throw events at
	HWND _window;

	static MessagePipe* _instance;
#pragma endregion

#pragma region Constructors/Destructors
private:
	MessagePipe();
public:
	virtual ~MessagePipe();
#pragma endregion

#pragma region Methods
public:
	// Description: Part of the singleton pattern.
	static MessagePipe* Instance();
#pragma endregion

#pragma region Methods
public:
	// Description: Sets a new request and notifies listening window
	void SetRequest(ARequest* request);

	// Description: Gets the request
	ARequest* GetRequest();

	// Description: Sets a new response and raises the appropriate event
	void SetResponse(AResponse* response);

	// Description: Gets the response
	AResponse* GetResponse();

	// Description: Gets an event handle indicating that a response has been created
	HANDLE ResponseCreatedEvent();

	// Description: Sets the listening window
	void SetWindow(HWND window);
#pragma endregion

};