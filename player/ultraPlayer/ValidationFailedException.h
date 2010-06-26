#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "BaseException.h"
#pragma endregion

using namespace std;

class ValidationFailedException: public BaseException
{

public:
	ValidationFailedException(string invalidExpression, string where)
	{
		_cause = "ValidationFailedException: " +  invalidExpression;
	}

};