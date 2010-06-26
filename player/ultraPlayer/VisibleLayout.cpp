#include "VisibleLayout.h"

VisibleLayout::VisibleLayout(void)
{
	_alpha = 0;
}

VisibleLayout::~VisibleLayout(void)
{
}

short int VisibleLayout::Alpha()
{
	return _alpha;
}

void VisibleLayout::Alpha( short int val )
{
	_alpha = val;
}

void VisibleLayout::FromString( string data )
{
	int index = 0;
	int layoutSubsetLength = CommunicationProtocol::Instance()->NumericParameterLength();

	try
	{
		Layout::FromString(data.substr(index, CommunicationProtocol::Instance()->LayoutPartLength()));
		index += CommunicationProtocol::Instance()->LayoutPartLength();
		_alpha = NumericToStringConverter::Convert<short>(data.substr(index, layoutSubsetLength));
	}
	catch (exception& e)
	{
		throw ParserException(e.what(), "VisibleLayout::FromString");
	}
}

std::string VisibleLayout::ToString()
{
	throw NotImplementedException("","VisibleLayout::ToString");
}