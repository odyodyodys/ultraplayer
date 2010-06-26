#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#pragma endregion

class CommunicationResources
{
#pragma region Fields
private:
	static CommunicationResources* _instance;

	DWORD _newMessageInPipeEvent;
#pragma endregion

#pragma region Constructors/Destructors
private:
	CommunicationResources();
public:
	virtual ~CommunicationResources();
#pragma endregion

#pragma region Methods
public:
	// Description: Part of the singleton pattern.
	static CommunicationResources* Instance();
	
	DWORD NewMessageInPipeEvent();
#pragma endregion

};