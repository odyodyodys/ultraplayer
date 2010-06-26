#include "SetImageRequest.h"

SetImageRequest::SetImageRequest(void):ARequest(MessageType::SetImage)
{
	_objectProperties = new VisibleObject();
}

SetImageRequest::~SetImageRequest(void)
{
	if (_objectProperties)
	{
		delete _objectProperties;
	}
}

void SetImageRequest::FromString( string data )
{
	try
	{
		int index = CommunicationProtocol::Instance()->HeaderLength();
		_objectProperties->FromString( data.substr(index, CommunicationProtocol::Instance()->VisibleObjectPartLength()));
		index += CommunicationProtocol::Instance()->VisibleObjectPartLength();
		_filename = data.substr(index, data.length() - index);
	}
	catch (exception& e)
	{
		throw ParserException(e.what(), "SetImageRequest::FromString");
	}
}

VisibleObject* SetImageRequest::ObjectProperties()
{
	// caller should not delete it
	return _objectProperties;
}

std::string SetImageRequest::Filename()
{
	return _filename;
}