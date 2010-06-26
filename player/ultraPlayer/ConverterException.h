#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "BaseException.h"
#pragma endregion

using namespace std;

class ConverterException: public BaseException
{

public:
	ConverterException(string errorCause, string where)
	{
		_cause = "ConverterException: " + where + "." +  errorCause;
	}

};