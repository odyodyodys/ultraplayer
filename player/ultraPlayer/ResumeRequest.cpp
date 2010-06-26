#include "ResumeRequest.h"

ResumeRequest::ResumeRequest(void):ARequest(MessageType::Resume)
{
}

ResumeRequest::~ResumeRequest(void)
{
}

void ResumeRequest::FromString( string data )
{
	// nothing to parse
}