#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AResponse.h"
#pragma endregion

class PauseResponse:public AResponse
{
#pragma region Constructors/Destructors
public:
	PauseResponse();
	virtual ~PauseResponse();
#pragma endregion
};