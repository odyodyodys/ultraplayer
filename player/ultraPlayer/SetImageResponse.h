#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AResponse.h"
#pragma endregion

class SetImageResponse:public AResponse
{
#pragma region Constructors/Destructors
public:
	SetImageResponse();
	virtual ~SetImageResponse();
#pragma endregion
};