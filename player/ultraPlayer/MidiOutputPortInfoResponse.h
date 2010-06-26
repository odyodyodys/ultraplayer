#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AResponse.h"
#include "CommunicationProtocol.h"
#pragma endregion

class MidiOutputPortInfoResponse: public AResponse
{
#pragma region Fields
private:
	list<string> _midiOutputPorts;
#pragma endregion

#pragma region Constructors/Destructors
public:
	MidiOutputPortInfoResponse();
	virtual ~MidiOutputPortInfoResponse();
#pragma endregion

#pragma region AResponse Methods
public:
	virtual string ToString();
#pragma endregion

#pragma region Properties
public:
	void MidiOutputPorts(list<string> val);

#pragma endregion

};