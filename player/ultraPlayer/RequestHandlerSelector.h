#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "MessageType.h"
	#include "IRequestHandler.h"
	#include "MessageTypeToStringConverter.h"
#pragma endregion

using namespace std;

class RequestHandlerSelector
{
#pragma region Fields
private:
	static RequestHandlerSelector* _instance;
	map<MessageType::Type, IRequestHandler*> _listeners;
#pragma endregion

#pragma region Constructors/Destructors
private:
	RequestHandlerSelector();
public:
	virtual ~RequestHandlerSelector();
#pragma endregion

#pragma region Methods
public:
	// Description: Part of the singleton pattern.
	static RequestHandlerSelector* Instance();

	// Description: Registers a new listener for a spesific messagetype
	void RegisterListener(MessageType::Type messageType, IRequestHandler* listener);

	// Description: Gets a listener for a specified request
	IRequestHandler* GetListener(ARequest* request);
#pragma endregion

};