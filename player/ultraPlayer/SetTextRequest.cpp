#include "SetTextRequest.h"

SetTextRequest::SetTextRequest(void):ARequest(MessageType::SetText)
{
	_objectProperties = new VisibleObject();
}

SetTextRequest::~SetTextRequest(void)
{
	if (_objectProperties)
	{
		delete _objectProperties;
	}
}

void SetTextRequest::FromString( string data )
{
	try
	{
		int index = CommunicationProtocol::Instance()->HeaderLength();
		_objectProperties->FromString( data.substr(index, CommunicationProtocol::Instance()->VisibleObjectPartLength()));
		index += CommunicationProtocol::Instance()->VisibleObjectPartLength();
		_text = data.substr(index, data.length() - index);
	}
	catch (exception& e)
	{
		throw ParserException(e.what(), "SetTextRequest::FromString");
	}
}

std::string SetTextRequest::Text()
{
	return _text;
}

VisibleObject* SetTextRequest::ObjectProperties()
{
	// caller should not delete it
	return _objectProperties;
}