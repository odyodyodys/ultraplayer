#include "SeekRequest.h"

SeekRequest::SeekRequest(void):ARequest(MessageType::Seek)
{
}

SeekRequest::~SeekRequest(void)
{
}

void SeekRequest::FromString( string data )
{
	try
	{
		UINT headerLength = CommunicationProtocol::Instance()->HeaderLength();

		// Get everything after the header and convert it to UINT
		string millisecPart = data.substr(headerLength, data.size() - headerLength);
	
		_milliseconds = NumericToStringConverter::Convert<UINT>(millisecPart);
	}
	catch (exception& e)
	{
		throw ParserException(e.what(), "SeekRequest::FromString");
	}

}

UINT SeekRequest::Milliseconds()
{
	return _milliseconds;
}