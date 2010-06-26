#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "IConverter.h"
#include "PhaseType.h"
#include "NumericToStringConverter.h"

#include "NotImplementedException.h"
#pragma endregion

class PhaseToStringConverter: public IConverter<string, PhaseType::Type>
{
#pragma region Fields

#pragma endregion

#pragma region Constructors/Destructors
public:
	PhaseToStringConverter();
	virtual ~PhaseToStringConverter();
#pragma endregion

#pragma region IConverter members
public:
	// Description: NotImplemented.
	// Exceptions: NotImplementedException
	virtual string Convert(PhaseType::Type data);

	// Description: Converts a string to phasetype enumeration
	// Exceptions: ConverterException
	virtual PhaseType::Type Convert(string data);

#pragma endregion

};