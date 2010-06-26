#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#pragma endregion

template <typename T>
__interface IValidator
{

#pragma region Methods
public:
	// Description: Returns true if object contains valid data
	bool IsValid(T data);
#pragma endregion

};