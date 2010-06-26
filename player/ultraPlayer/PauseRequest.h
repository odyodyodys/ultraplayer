#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "ARequest.h"
	#include "MessageType.h"	

	#include "NotImplementedException.h"
#pragma endregion

class PauseRequest: public ARequest
{
	friend class RequestFactory;

#pragma region Constructors/Destructors
private:
	PauseRequest();
public:
	virtual ~PauseRequest();
#pragma endregion

#pragma region ARequest members
public:
	virtual void FromString(string data);

#pragma endregion

};