#include "DisplayDevice.h"

DisplayDevice::DisplayDevice(void)
{
	_deviceId = 0;
	_monitorNumber = 0;
	_layout = NULL;
}

DisplayDevice::~DisplayDevice(void)
{
	if (_layout)
	{
		delete _layout;
	}
}

UINT DisplayDevice::DeviceId()
{
	return _deviceId;
}

void DisplayDevice::DeviceId( UINT deviceId )
{
_deviceId = deviceId;
}
UINT DisplayDevice::MonitorNumber()
{
	return _monitorNumber;
}

void DisplayDevice::MonitorNumber( UINT monitorNumber )
{
	_monitorNumber = monitorNumber;
}

Layout* DisplayDevice::MonitorLayout()
{
	// Caller should not delete instance
	return _layout;
}

void DisplayDevice::MonitorLayout( Layout* layout )
{
	// Caller should not delete instance
	if (_layout)
	{
		delete _layout;
	}

	_layout = layout;

}

DisplayDevice* DisplayDevice::MakeCopy()
{
	DisplayDevice* copy = new DisplayDevice();
	
	copy->MonitorNumber(MonitorNumber());
	copy->MonitorLayout(new Layout(*(MonitorLayout())));
	copy->DeviceId(DeviceId());
	
	return copy;
}

void DisplayDevice::CopyFrom( DisplayDevice* original )
{
	// device id
	_deviceId = original->DeviceId();
	
	// layout
	if (_layout)
	{
		delete _layout;
	}
	_layout = new Layout(*(original->MonitorLayout()));

	// monitorNumber
	_monitorNumber = original->MonitorNumber();
}