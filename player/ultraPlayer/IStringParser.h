#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
#pragma endregion

using namespace std;

__interface IStringParser
{
#pragma region Methods
public:
	// Description: Parses data from string and converts it into fields
	virtual void FromString(string data);

	// Description: Serializes self data
	virtual string ToString();
#pragma endregion

};