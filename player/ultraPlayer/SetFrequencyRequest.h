#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "ARequest.h"
#include "CommunicationProtocol.h"
#include "NumericToStringConverter.h"

#include "ParserException.h"
#pragma endregion

class SetFrequencyRequest:public ARequest
{
	friend class RequestFactory;

#pragma region Fields
private:
	int _frequency;
#pragma endregion

#pragma region Constructors/Destructors
private:
	SetFrequencyRequest();
public:
	virtual ~SetFrequencyRequest();
#pragma endregion

#pragma region ARequest members
public:
	virtual void FromString(string data);
#pragma endregion

#pragma region Properties
public:
	int Frequency();
#pragma endregion
};