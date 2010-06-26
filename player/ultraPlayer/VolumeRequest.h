#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "ARequest.h"
	#include "MessageType.h"
	#include "CommunicationProtocol.h"
	#include "NumericToStringConverter.h"

	#include "ParserException.h"
	#include "NotImplementedException.h"
#pragma endregion

class VolumeRequest: public ARequest
{
	friend class RequestFactory;

#pragma region Fields
private:
	UINT _volume;
#pragma endregion

#pragma region Constructors/Destructors
private:
	VolumeRequest();
public:
	virtual ~VolumeRequest();
#pragma endregion

#pragma region ARequest members
public:
	virtual void FromString(string data);

#pragma endregion

#pragma region Properties
public:
	UINT Volume();
#pragma endregion

};