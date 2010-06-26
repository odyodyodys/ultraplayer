#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AResponse.h"
#pragma endregion

class WindowLayoutResponse:public AResponse
{
#pragma region Constructors/Destructors
public:
	WindowLayoutResponse();
	virtual ~WindowLayoutResponse();
#pragma endregion
};