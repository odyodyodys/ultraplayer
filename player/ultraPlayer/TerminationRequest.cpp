#include "TerminationRequest.h"

TerminationRequest::TerminationRequest(void):ARequest(MessageType::Termination)
{
}

TerminationRequest::~TerminationRequest(void)
{
}

void TerminationRequest::FromString( string data )
{
	// nothing to parse
}