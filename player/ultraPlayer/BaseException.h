#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#pragma endregion

using namespace std;

class BaseException abstract: public std::exception
{
protected:
	string _cause;

public:

	virtual const char* what() const throw()
	{
		return  _cause.c_str();
	}
};