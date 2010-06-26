#include "WindowLayoutRequest.h"

WindowLayoutRequest::WindowLayoutRequest(void):ARequest(MessageType::WindowLayout)
{
	_layout = NULL;
}

WindowLayoutRequest::~WindowLayoutRequest(void)
{
	if (_layout)
	{
		delete _layout;
	}
}

void WindowLayoutRequest::FromString( string data )
{
	try
	{
		int index = CommunicationProtocol::Instance()->HeaderLength();
		int layoutLength = CommunicationProtocol::Instance()->NumericParameterLength() + CommunicationProtocol::Instance()->LayoutPartLength();

		//check parts length
		if((data.length() - index) != layoutLength)
		{
			throw ParserException("Invalid layout part length", "WindowLayoutRequest::FromString");
		}

		// parse monitor id
		_monitorNumber = NumericToStringConverter::Convert<UINT>(data.substr(index, CommunicationProtocol::Instance()->NumericParameterLength()));
		index += CommunicationProtocol::Instance()->NumericParameterLength();

		// parse layout
		Layout* newLayout = new Layout();
		newLayout->FromString(data.substr(index, layoutLength));
		
		// add the layer
		_layout = newLayout;

	}
	catch (exception& e)
	{
		throw ParserException(e.what(), "WindowLayoutRequest::FromString");
	}
}

Layout* WindowLayoutRequest::GetLayout()
{
	return _layout;
}

UINT WindowLayoutRequest::MonitorNumber()
{
	return _monitorNumber;
}