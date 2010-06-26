#include "SetMidiOutputPortRequest.h"

SetMidiOutputPortRequest::SetMidiOutputPortRequest(void):ARequest(MessageType::SetMidiOutputPort)
{
}

SetMidiOutputPortRequest::~SetMidiOutputPortRequest(void)
{
}

void SetMidiOutputPortRequest::FromString( string data )
{
	try
	{
		int index = CommunicationProtocol::Instance()->HeaderLength();

		_portName = data.substr(index, data.length() - index);
	}
	catch (exception& e)
	{

	}
}

std::string SetMidiOutputPortRequest::PortName()
{
	return _portName;
}