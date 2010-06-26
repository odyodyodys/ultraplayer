#include "VolumeRequest.h"

VolumeRequest::VolumeRequest(void):ARequest(MessageType::Volume)
{
}

VolumeRequest::~VolumeRequest(void)
{
}

void VolumeRequest::FromString( string data )
{
	try
	{
		int index = CommunicationProtocol::Instance()->HeaderLength();
		_volume = NumericToStringConverter::Convert<UINT>(data.substr(index, CommunicationProtocol::Instance()->NumericParameterLength()));
	}
	catch (exception& e)
	{
		throw ParserException(e.what(), "VolumeRequest::FromString");
	}
}

UINT VolumeRequest::Volume()
{
	return _volume;
}