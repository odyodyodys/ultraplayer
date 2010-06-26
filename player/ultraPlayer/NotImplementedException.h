#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "BaseException.h"
#pragma endregion

using namespace std;

class NotImplementedException: public BaseException
{

#pragma region Constructors/Destructors
public:
	NotImplementedException(string codeDescriptor, string where)
	{
		_cause = "NotImplementedException: " + where + "." + codeDescriptor;
	}
#pragma endregion

};