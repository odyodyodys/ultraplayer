#include "VideoLayoutRequest.h"

VideoLayoutRequest::VideoLayoutRequest(void):ARequest(MessageType::VideoLayout)
{
	
}

VideoLayoutRequest::~VideoLayoutRequest(void)
{
	// cleanup
	list<VisibleLayout*>::iterator iterator;
	for(iterator = _layouts.begin(); iterator != _layouts.end(); iterator++)
	{
		if ((*iterator))
		{
			delete *iterator;
		}
	}
}

void VideoLayoutRequest::FromString( string data )
{
	try
	{
		int index = CommunicationProtocol::Instance()->HeaderLength();
		int visibleLayoutLength = CommunicationProtocol::Instance()->VisibleLayoutPartsCount() * CommunicationProtocol::Instance()->NumericParameterLength();

		//check parts length
		if((data.length() - index)%visibleLayoutLength != 0)
		{
			throw ParserException("Invalid layout parts length", "VideoLayoutRequest::FromString");
		}

		while (index < data.length())
		{
			VisibleLayout* newLayout = new VisibleLayout();
			newLayout->FromString(data.substr(index, visibleLayoutLength));
			index += visibleLayoutLength;

			// add new layer
			_layouts.push_back(newLayout);
		}
	}
	catch (exception& e)
	{
		throw ParserException(e.what(), "VideoLayoutRequest::FromString");
	}
}

list<VisibleLayout*> VideoLayoutRequest::Layouts()
{
	// caller should not delete it
	return _layouts;
}