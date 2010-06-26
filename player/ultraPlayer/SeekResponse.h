#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AResponse.h"
#pragma endregion

class SeekResponse:public AResponse
{
#pragma region Constructors/Destructors
public:
	SeekResponse();
	virtual ~SeekResponse();
#pragma endregion
};