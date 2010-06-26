#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "ARequest.h"
	#include "CommunicationProtocol.h"
	#include "NumericToStringConverter.h"
	#include "MessageType.h"

	#include "ParserException.h"
#pragma endregion

class RemoveAddonRequest: public ARequest
{
	friend class RequestFactory;

#pragma region Fields
private:
	UINT _addonId;
#pragma endregion

#pragma region Constructors/Destructors
private:
	RemoveAddonRequest();
public:
	virtual ~RemoveAddonRequest();
#pragma endregion

#pragma region ARequest members
public:
	virtual void FromString(string data);

#pragma endregion

#pragma region Properties
public:
	UINT AddonId();
#pragma endregion

};