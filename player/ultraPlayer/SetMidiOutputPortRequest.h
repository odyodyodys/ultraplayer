#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "ARequest.h"
#include "MessageType.h"
#include "CommunicationProtocol.h"
#pragma endregion

class SetMidiOutputPortRequest:public ARequest
{
	friend class RequestFactory;

#pragma region Fields
private:
	string _portName;
#pragma endregion

#pragma region Constructors/Destructors
private:
	SetMidiOutputPortRequest();
public:
	virtual ~SetMidiOutputPortRequest();
#pragma endregion

#pragma region ARequest members
public:
	virtual void FromString(string data);

#pragma endregion

#pragma region Properties
public:
	string PortName();
#pragma endregion

};