#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AResponse.h"
#pragma endregion

class SetTextResponse:public AResponse
{
#pragma region Constructors/Destructors
public:
	SetTextResponse();
	virtual ~SetTextResponse();
#pragma endregion
};