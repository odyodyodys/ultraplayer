#include "ARequest.h"

ARequest::ARequest(MessageType::Type messageType):AMessage(messageType)
{
}

ARequest::~ARequest(void)
{
}

string ARequest::ToString()
{
	throw NotImplementedException("","ARequest::ToString");
}