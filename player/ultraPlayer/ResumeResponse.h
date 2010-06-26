#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AResponse.h"
#pragma endregion

class ResumeResponse:public AResponse
{
#pragma region Constructors/Destructors
public:
	ResumeResponse();
	virtual ~ResumeResponse();
#pragma endregion
};