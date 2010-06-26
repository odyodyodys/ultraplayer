#include "SetDlsRequest.h"

SetDlsRequest::SetDlsRequest(void):ARequest(MessageType::SetDls)
{
}

SetDlsRequest::~SetDlsRequest(void)
{
}

std::string SetDlsRequest::DlsFile()
{
	return _dlsFile;
}

void SetDlsRequest::FromString( string data )
{
	try
	{
		int index = CommunicationProtocol::Instance()->HeaderLength();

		_dlsFile = data.substr(index, data.length() - index);
	}
	catch (exception& e)
	{

	}
}