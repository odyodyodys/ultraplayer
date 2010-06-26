#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#pragma endregion

using namespace std;

class StringHelper
{
#pragma region Fields

#pragma endregion

#pragma region Constructors/Destructors
public:
	StringHelper();
	virtual ~StringHelper();
#pragma endregion

#pragma region Methods
public:
	// Description: Counts words in a given text
	static int WordOccurrenceCount(string const & str, string const & word );
#pragma endregion

};