#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AResponse.h"
#pragma endregion

class SetFrequencyResponse:public AResponse
{
#pragma region Constructors/Destructors
public:
	SetFrequencyResponse();
	virtual ~SetFrequencyResponse();
#pragma endregion
};