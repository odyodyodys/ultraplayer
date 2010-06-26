#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "MessageType.h"
#include "IStringParser.h"
#pragma endregion

class AMessage abstract: public IStringParser
{
#pragma region Fields
protected:
	MessageType::Type _messageType;
#pragma endregion

#pragma region Constructors/Destructors
protected:
	AMessage(MessageType::Type messageType);
public:
	virtual ~AMessage();
#pragma endregion

#pragma region IStringParser Methods
public:
	virtual void FromString(string data)=0;
	virtual string ToString()=0;

#pragma endregion

#pragma region Properties
public:
	MessageType::Type MessageType();
#pragma endregion

};