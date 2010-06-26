#include "DisplayDevicesInfoRequest.h"

DisplayDevicesInfoRequest::DisplayDevicesInfoRequest(void):ARequest(MessageType::DisplayDevicesInfo)
{
}

DisplayDevicesInfoRequest::~DisplayDevicesInfoRequest(void)
{
}

void DisplayDevicesInfoRequest::FromString( string data )
{
	// Nothing to parse
}