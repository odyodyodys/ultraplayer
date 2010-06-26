#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "BaseException.h"
#pragma endregion

using namespace std;

class InvalidArgumentException: public BaseException
{

public:
	InvalidArgumentException(string arguments, string where)
	{
		_cause = "InvalidArgumentException: " +  arguments;
	}

};