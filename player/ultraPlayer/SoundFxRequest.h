#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "ARequest.h"
#include "ASoundFx.h"
#include "MessageType.h"
#include "CommunicationProtocol.h"
#include "SoundFxFactory.h"
#include "StringHelper.h"

#include "ParserException.h"
#include "NotImplementedException.h"
#pragma endregion

class SoundFxRequest:public ARequest
{
	friend class RequestFactory;

#pragma region Fields
private:
	std::list<ASoundFx*> _soundFxs;
#pragma endregion

#pragma region Constructors/Destructors
private:
	SoundFxRequest();
public:
	virtual ~SoundFxRequest();
#pragma endregion

#pragma region ARequest members
public:
	virtual void FromString(string data);

#pragma endregion

#pragma region Properties
public:
	std::list<ASoundFx*> SoundFxs();
#pragma endregion

};