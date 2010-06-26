#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "ARequest.h"
#include "MessageType.h"	

#include "NotImplementedException.h"
#pragma endregion

class ResumeRequest: public ARequest
{
	friend class RequestFactory;

#pragma region Constructors/Destructors
private:
	ResumeRequest();
public:
	virtual ~ResumeRequest();
#pragma endregion

#pragma region ARequest members
public:
	virtual void FromString(string data);

#pragma endregion

};