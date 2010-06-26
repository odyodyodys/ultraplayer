#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AResponse.h"
#include "MessageType.h"
#pragma endregion

class Sound3dResponse: public AResponse
{
#pragma region Constructors/Destructors
public:
	Sound3dResponse();
	virtual ~Sound3dResponse();
#pragma endregion
};