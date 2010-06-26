#include "StopRequest.h"

StopRequest::StopRequest(void):ARequest(MessageType::Stop)
{
}

StopRequest::~StopRequest(void)
{
}

void StopRequest::FromString( string data )
{
	// nothing to parse
}