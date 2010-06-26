#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "BaseException.h"
#pragma endregion

using namespace std;

class CommunicationException: public BaseException
{

public:
	CommunicationException(string errorCause, string where)
	{
		_cause = "CommunicationException: " + where + "." +  errorCause;
	}
};