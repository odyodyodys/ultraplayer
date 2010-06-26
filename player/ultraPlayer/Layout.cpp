#include "Layout.h"

Layout::Layout(void)
{
	_x = 0;
	_y = 0;
	_width = 0;
	_height = 0;
}
Layout::~Layout(void)
{
}

short int Layout::X()
{
	return _x;
}

void Layout::X( short int val )
{
	_x = val;
}

short int Layout::Y()
{
	return _y;
}

void Layout::Y( short int val )
{
	_y = val;
}

short int Layout::Width()
{
	return _width;
}

void Layout::Width( short int val )
{
	_width = val;
}

short int Layout::Height()
{
	return _height;
}

void Layout::Height( short int val )
{
	_height = val;
}

std::string Layout::ToString()
{
	string text;
	try
	{
		text += NumericToStringConverter::Convert<short int>(_x, std::dec, CommunicationProtocol::Instance()->NumericParameterLength());
		text += NumericToStringConverter::Convert<short int>(_y, std::dec, CommunicationProtocol::Instance()->NumericParameterLength());
		text += NumericToStringConverter::Convert<short int>(_width, std::dec, CommunicationProtocol::Instance()->NumericParameterLength());
		text += NumericToStringConverter::Convert<short int>(_height, std::dec, CommunicationProtocol::Instance()->NumericParameterLength());

	}
	catch (exception& e)
	{
		text = "";
	}
	return text;
}

void Layout::FromString( string data )
{
	int index = 0;
	int layoutSubsetLength = CommunicationProtocol::Instance()->NumericParameterLength();

	try
	{
		_x = NumericToStringConverter::Convert<short>(data.substr(index, layoutSubsetLength));
		index += layoutSubsetLength;
		_y = NumericToStringConverter::Convert<short>(data.substr(index, layoutSubsetLength));
		index += layoutSubsetLength;
		_width = NumericToStringConverter::Convert<short>(data.substr(index, layoutSubsetLength));
		index += layoutSubsetLength;
		_height = NumericToStringConverter::Convert<short>(data.substr(index, layoutSubsetLength));
	}
	catch (exception& e)
	{
		throw ParserException(e.what(), "Layout::FromString");
	}
}