#include "DisplayDevicesInfoResponse.h"

DisplayDevicesInfoResponse::DisplayDevicesInfoResponse(void):AResponse(MessageType::DisplayDevicesInfo)
{
}

DisplayDevicesInfoResponse::~DisplayDevicesInfoResponse(void)
{
}

std::string DisplayDevicesInfoResponse::ToString()
{
	string response;
	try
	{
		response += AResponse::ToString();

		list<DisplayDevice*>::iterator deviceIterator;
		for (deviceIterator = _devices.begin(); deviceIterator != _devices.end(); deviceIterator++)
		{
			response += NumericToStringConverter::Convert<UINT>((*deviceIterator)->MonitorNumber(), std::dec, CommunicationProtocol::Instance()->NumericParameterLength());

			response += (*deviceIterator)->MonitorLayout()->ToString();
		}

	}
	catch (exception& e)
	{
		
	}
	return response;
}

void DisplayDevicesInfoResponse::Devices( list<DisplayDevice*> devices )
{
	try
	{
		// clean devices list if not empty
		if (!_devices.empty())
		{
			list<DisplayDevice*>::iterator deviceIterator;
			list<DisplayDevice*> tmpList = _devices;
			for (deviceIterator = tmpList.begin(); deviceIterator != tmpList.end(); deviceIterator++)
			{
				if (*deviceIterator)
				{
					delete (*deviceIterator);
				}
			}
		}

		_devices = devices;
	}
	catch (exception& e)
	{
		
	}

}