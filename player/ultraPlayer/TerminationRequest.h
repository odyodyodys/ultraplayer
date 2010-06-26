#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "ARequest.h"
	#include "MessageType.h"

	#include "NotImplementedException.h"
#pragma endregion

class TerminationRequest: public ARequest
{
	friend class RequestFactory;

#pragma region Constructors/Destructors
private:
	TerminationRequest();
public:
	virtual ~TerminationRequest();
#pragma endregion

#pragma region ARequest members
public:
	virtual void FromString(string data);

#pragma endregion

};