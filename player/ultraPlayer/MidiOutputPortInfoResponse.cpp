#include "MidiOutputPortInfoResponse.h"

MidiOutputPortInfoResponse::MidiOutputPortInfoResponse(void):AResponse(MessageType::MidiOutputPortInfo)
{
}

MidiOutputPortInfoResponse::~MidiOutputPortInfoResponse(void)
{
}

void MidiOutputPortInfoResponse::MidiOutputPorts( list<string> val )
{
	_midiOutputPorts = val;
}

std::string MidiOutputPortInfoResponse::ToString()
{
	string response;
	try
	{
		response += AResponse::ToString();

		list<string>::iterator outputPortIterator;
		for (outputPortIterator = _midiOutputPorts.begin(); outputPortIterator != _midiOutputPorts.end(); outputPortIterator++)
		{
			response += CommunicationProtocol::Instance()->Delimiter();
			response += *outputPortIterator;
		}

	}
	catch (exception& e)
	{

	}
	return response;
}