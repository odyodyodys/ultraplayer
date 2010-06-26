#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "ARequest.h"
#include "MessageType.h"
#pragma endregion

class MidiOutputPortInfoRequest: public ARequest
{
	friend class RequestFactory;

#pragma region Constructors/Destructors
private:
	MidiOutputPortInfoRequest();
public:
	virtual ~MidiOutputPortInfoRequest();
#pragma endregion

#pragma region ARequest members
public:
	virtual void FromString(string data);

#pragma endregion

};