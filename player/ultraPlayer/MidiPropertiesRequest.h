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

class MidiPropertiesRequest: public ARequest
{
	friend class RequestFactory;

#pragma region Fields
private:
	bool _enableReverb;
	bool _enableChorus;
	float _tempo;
#pragma endregion

#pragma region Constructors/Destructors
private:
	MidiPropertiesRequest();
public:
	virtual ~MidiPropertiesRequest();
#pragma endregion

#pragma region ARequest members
public:
	virtual void FromString(string data);

#pragma endregion

#pragma region Properties
public:
	
	bool EnableReverb();
	bool EnableChorus();
	float Tempo();
#pragma endregion

};