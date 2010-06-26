#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "ARequest.h"
	#include "MessageType.h"
	#include "CommunicationProtocol.h"
	#include "NumericToStringConverter.h"

	#include "ParserException.h"
	#include "NotImplementedException.h"
#pragma endregion

class PlayRequest: public ARequest
{
friend class RequestFactory;
#pragma region Fields
private:
	list<pair<int, string>> _files;
#pragma endregion

#pragma region Constructors/Destructors
private:
	PlayRequest();
public:
	virtual ~PlayRequest();
#pragma endregion

#pragma region ARequest members
public:
	virtual void FromString(string data);

#pragma endregion

#pragma region Properties
public:
	list<pair<int,string>> Files();
#pragma endregion

};