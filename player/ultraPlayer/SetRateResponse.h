#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AResponse.h"
#pragma endregion

class SetRateResponse: public AResponse
{
#pragma region Constructors/Destructors
public:
	SetRateResponse();
	virtual ~SetRateResponse();
#pragma endregion
};