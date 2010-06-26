#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "BaseException.h"
#pragma endregion

using namespace std;

class ParserException: public BaseException
{

public:
	ParserException(string errorCause, string where)
	{
		_cause = "ParserException: " + where + "." +  errorCause;
	}

};