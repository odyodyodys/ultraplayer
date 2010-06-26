#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AResponse.h"
#pragma endregion

class PlayResponse:public AResponse
{
#pragma region Constructors/Destructors
public:
	PlayResponse();
	virtual ~PlayResponse();
#pragma endregion
};