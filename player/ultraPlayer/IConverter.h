#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "ConverterException.h"
#pragma endregion

template <typename type1, typename type2>
__interface IConverter
{
#pragma region Methods
public:
	type1 Convert(type2 data);
	type2 Convert(type1 data);
#pragma endregion

};