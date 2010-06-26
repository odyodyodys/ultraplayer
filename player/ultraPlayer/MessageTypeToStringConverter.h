#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "IConverter.h"
	#include "MessageType.h"
	#include "CommunicationProtocol.h"

	#include "NotImplementedException.h"
#pragma endregion

class MessageTypeToStringConverter: public IConverter<string, MessageType::Type>
{
#pragma region Fields

#pragma endregion

#pragma region Constructors/Destructors
public:
	MessageTypeToStringConverter();
	virtual ~MessageTypeToStringConverter();
#pragma endregion

#pragma region IConverter members
public:

	// Description: Not implemented. Should convert messagetype enumeration to string
	// Exceptions: NotImplementedException
	virtual string Convert(MessageType::Type data);

	// Description: Converts a string to message type enumeration
	// Exceptions: ConverterException
	virtual MessageType::Type Convert(string data);

#pragma endregion

};