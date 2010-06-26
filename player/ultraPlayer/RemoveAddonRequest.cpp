#include "RemoveAddonRequest.h"

RemoveAddonRequest::RemoveAddonRequest(void):ARequest(MessageType::RemoveAddon)
{
}

RemoveAddonRequest::~RemoveAddonRequest(void)
{
}

void RemoveAddonRequest::FromString( string data )
{
	try
	{
		int index = CommunicationProtocol::Instance()->HeaderLength();
		_addonId = NumericToStringConverter::Convert<UINT>(data.substr(index, CommunicationProtocol::Instance()->NumericParameterLength()));

	}
	catch (exception& e)
	{
		throw ParserException(e.what(), "RemoveAddonRequest::FromString");
	}
}

UINT RemoveAddonRequest::AddonId()
{
	return _addonId;
}