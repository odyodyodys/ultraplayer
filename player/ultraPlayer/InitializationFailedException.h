#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "BaseException.h"
	#include "NumericToStringConverter.h"
#pragma endregion

using namespace std;

class InitializationFailedException: public BaseException
{

public:
	InitializationFailedException(string errorCause, string where)
	{
		_cause = "InitializationFailedException: " + where + "." +  errorCause;
	}

	InitializationFailedException(string errorCause, string where, HRESULT hr)
	{
		_cause = "InitializationFailedException: " + where + ": " + errorCause + ": " + NumericToStringConverter::Convert<int>(hr, std::hex);
	}

};