#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AResponse.h"
#pragma endregion

class TerminationResponse:public AResponse
{
#pragma region Constructors/Destructors
public:
	TerminationResponse();
	virtual ~TerminationResponse();
#pragma endregion
};