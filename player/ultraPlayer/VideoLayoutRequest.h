#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "ARequest.h"
	#include "VisibleLayout.h"
	#include "MessageType.h"
	#include "CommunicationProtocol.h"
	#include "NumericToStringConverter.h"

	#include "ParserException.h"
	#include "NotImplementedException.h"
#pragma endregion

class VideoLayoutRequest: public ARequest
{
	friend class RequestFactory;

#pragma region Fields
private:
	list<VisibleLayout*> _layouts;
#pragma endregion

#pragma region Constructors/Destructors
private:
	VideoLayoutRequest();
public:
	virtual ~VideoLayoutRequest();
#pragma endregion

#pragma region ARequest members
public:
	virtual void FromString(string data);

#pragma endregion

#pragma region Properties
public:
	list<VisibleLayout*> Layouts();
#pragma endregion

};