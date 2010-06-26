#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "BaseException.h"
#pragma endregion

using namespace std;

class HandlerException: public BaseException
{

public:
	HandlerException(string errorCause, string where)
	{
		_cause = "HandlerException: " + where + "." +  errorCause;
	}
};