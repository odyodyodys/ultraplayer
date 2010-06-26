#include "AMessage.h"

AMessage::AMessage(MessageType::Type messageType)
{
	_messageType = messageType;
}

AMessage::~AMessage(void)
{
}

MessageType::Type AMessage::MessageType()
{
	return _messageType;
}