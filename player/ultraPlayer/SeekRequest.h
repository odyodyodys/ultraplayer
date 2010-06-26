#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "ARequest.h"
	#include "NumericToStringConverter.h"
	#include "MessageType.h"
	#include "CommunicationProtocol.h"

	#include "ParserException.h"
	#include "NotImplementedException.h"
#pragma endregion

class SeekRequest:public ARequest
{
	friend class RequestFactory;

#pragma region Fields
private:
	UINT _milliseconds;
#pragma endregion

#pragma region Constructors/Destructors
private:
	SeekRequest();
public:
	virtual ~SeekRequest();
#pragma endregion

#pragma region ARequest members
public:
	virtual void FromString(string data);

#pragma endregion

#pragma region Properties
public:
	UINT Milliseconds();
#pragma endregion

};