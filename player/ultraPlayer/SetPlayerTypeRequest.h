#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "ARequest.h"
#include "MessageType.h"
#include "CommunicationProtocol.h"
#include "RequestFactory.h"
#include "PlayerType.h"
#include "PlayerTypeToStringConverter.h"

#include "CommunicationException.h"
#pragma endregion

class SetPlayerTypeRequest: public ARequest
{
    friend class RequestFactory;

#pragma region Fields
private:
    PlayerType::Type _playerType;
#pragma endregion

#pragma region Constructors/Destructors
private:
	SetPlayerTypeRequest();
public:
    ~SetPlayerTypeRequest();
#pragma endregion

#pragma region ARequest members
public:
    virtual void FromString(string data);

#pragma endregion

#pragma region Properties
public:
    PlayerType::Type PlayerType();
#pragma endregion
};
