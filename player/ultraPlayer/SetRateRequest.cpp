#include "SetRateRequest.h"

SetRateRequest::SetRateRequest(void):ARequest(MessageType::SetRate)
{
	_rate = 1;
}

SetRateRequest::~SetRateRequest(void)
{
}

float SetRateRequest::Rate()
{
	return _rate;
}

void SetRateRequest::FromString( string data )
{
	try
	{
		UINT headerLength = CommunicationProtocol::Instance()->HeaderLength();

		// Get everything after the header and convert it to float
		string ratePart = data.substr(headerLength, data.size() - headerLength);

		_rate = NumericToStringConverter::Convert<float>(ratePart);
	}
	catch (exception& e)
	{
		throw ParserException(e.what(), "SetRateRequest::FromString");
	}
}
