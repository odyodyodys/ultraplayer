#include "PauseRequest.h"

PauseRequest::PauseRequest(void):ARequest(MessageType::Pause)
{
}

PauseRequest::~PauseRequest(void)
{
}

void PauseRequest::FromString( string data )
{
	// nothing to parse
}