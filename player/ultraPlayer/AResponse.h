#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "ResponseType.h"
#include "AMessage.h"
#include "CommunicationProtocol.h"

#include "CommunicationException.h"
#include "NotImplementedException.h"
#pragma endregion

class AResponse abstract: public AMessage
{
#pragma region Fields
protected:
	ResponseType::Type _responseType;
#pragma endregion

#pragma region Constructors/Destructors
protected:
	AResponse(MessageType::Type messageType);
public:
	virtual ~AResponse();
#pragma endregion

#pragma region AMessage Methods
public:
	virtual void FromString(string data);
	virtual string ToString();
#pragma endregion

#pragma region Properties
public:
	ResponseType::Type ResponseType();
	void ResponseType(ResponseType::Type responseType);
#pragma endregion

};