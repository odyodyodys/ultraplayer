#include "VisibleObject.h"

VisibleObject::VisibleObject(void)
{
	_layout = new VisibleLayout();
}

VisibleObject::~VisibleObject(void)
{
	if (_layout)
	{
		delete _layout;
	}
}

void VisibleObject::Id( UINT id )
{
	_id = id;
}

UINT VisibleObject::Id()
{
	return _id;
}

void VisibleObject::FromString( string data )
{
	int index = 0;
	int numericLength = CommunicationProtocol::Instance()->NumericParameterLength();

	try
	{
		_id = NumericToStringConverter::Convert<UINT>(data.substr(index, numericLength));
		index += CommunicationProtocol::Instance()->NumericParameterLength();
		_layout->FromString(data.substr(index, CommunicationProtocol::Instance()->VisibleLayoutPartLength()));		
	}
	catch (exception& e)
	{
		throw ParserException(e.what(), "FromString::FromString");
	}
}

std::string VisibleObject::ToString()
{
	throw NotImplementedException("","VisibleObject::ToString");
}

VisibleLayout* VisibleObject::Layout()
{
	// caller should not delete
	return _layout;
}

void VisibleObject::Layout( VisibleLayout* layout )
{
	throw NotImplementedException("","VisibleObject::Layout");
}