#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AResponse.h"
#include "MessageType.h"
#pragma endregion

class SetPlayerTypeResponse: public AResponse
{
#pragma region Constructors/Destructors
public:
	SetPlayerTypeResponse();
	~SetPlayerTypeResponse();
#pragma endregion
};
