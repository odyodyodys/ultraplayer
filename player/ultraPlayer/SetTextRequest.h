#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "ARequest.h"
	#include "MessageType.h"
	#include "CommunicationProtocol.h"
	#include "ParserException.h"
	#include "VisibleObject.h"

	#include "NotImplementedException.h"
#pragma endregion

class SetTextRequest:public ARequest
{
	friend class RequestFactory;

#pragma region Fields
private:
	VisibleObject* _objectProperties;
	string _text;
#pragma endregion

#pragma region Constructors/Destructors
private:
	SetTextRequest();
public:
	virtual ~SetTextRequest();
#pragma endregion

#pragma region ARequest members
public:
	virtual void FromString(string data);
#pragma endregion

#pragma region Properties
public:
	VisibleObject* ObjectProperties();
	std::string Text();
#pragma endregion
};