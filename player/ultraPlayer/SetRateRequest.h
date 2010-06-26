#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "ARequest.h"
#include "CommunicationProtocol.h"
#include "NumericToStringConverter.h"

#include "ParserException.h"
#pragma endregion

class SetRateRequest: public ARequest
{
	friend class RequestFactory;

#pragma region Fields
private:
	float _rate;
#pragma endregion

#pragma region Constructors/Destructors
private:
	SetRateRequest();
public:
	virtual ~SetRateRequest();
#pragma endregion

#pragma region ARequest members
public:
	virtual void FromString(string data);

#pragma endregion

#pragma region Properties
public:
	float Rate();

#pragma endregion
};