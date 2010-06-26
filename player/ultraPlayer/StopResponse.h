#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AResponse.h"
#pragma endregion

class StopResponse:public AResponse
{
#pragma region Constructors/Destructors
public:
	StopResponse();
	virtual ~StopResponse();
#pragma endregion
};