#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#pragma endregion

template <typename type1>
__interface ICopyable
{

#pragma region Methods
public:
	// Description: Returns a copy of self
	type1* MakeCopy();

	// Description: Gets values from original
	void CopyFrom(type1* original);

#pragma endregion

};