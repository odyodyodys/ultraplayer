#include "SetFrequencyRequest.h"

SetFrequencyRequest::SetFrequencyRequest(void):ARequest(MessageType::SetFrequency)
{
}

SetFrequencyRequest::~SetFrequencyRequest(void)
{
}

int SetFrequencyRequest::Frequency()
{
	return _frequency;
}

void SetFrequencyRequest::FromString( string data )
{
	try
	{
		UINT headerLength = CommunicationProtocol::Instance()->HeaderLength();

		// Get everything after the header and convert it to float
		string frequencyPart = data.substr(headerLength, data.size() - headerLength);

		_frequency = NumericToStringConverter::Convert<float>(frequencyPart);
	}
	catch (exception& e)
	{
		throw ParserException(e.what(), "SetFrequencyRequest::FromString");
	}
}