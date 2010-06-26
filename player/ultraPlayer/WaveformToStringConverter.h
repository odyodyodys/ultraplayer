#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "IConverter.h"
#include "WaveformType.h"
#include "CommunicationProtocol.h"
#include "NumericToStringConverter.h"

#include "NotImplementedException.h"
#pragma endregion

class WaveformToStringConverter:public IConverter<string, WaveformType::Type>
{
#pragma region Fields

#pragma endregion

#pragma region Constructors/Destructors
public:
	WaveformToStringConverter();
	virtual ~WaveformToStringConverter();
#pragma endregion

#pragma region IConverter members
public:
	// Description: Not Implemented
	// Exceptions: NotImplementedException
	virtual string Convert(WaveformType::Type data);

	// Description: Converts string to waveformtype enumaration
	// Exceptions: ConverterException
	virtual WaveformType::Type Convert(string data);

#pragma endregion


};