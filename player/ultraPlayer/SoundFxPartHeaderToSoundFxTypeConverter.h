#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "IConverter.h"
#include "SoundFxType.h"
#include "CommunicationProtocol.h"

#include "NotImplementedException.h"
#pragma endregion

class SoundFxPartHeaderToSoundFxTypeConverter: public IConverter<string, SoundFxType::Type>
{
#pragma region Fields

#pragma endregion

#pragma region Constructors/Destructors
public:
	SoundFxPartHeaderToSoundFxTypeConverter();
	virtual ~SoundFxPartHeaderToSoundFxTypeConverter();
#pragma endregion

#pragma region IConverter members
public:
	// Description: Not implemented
	// Exceptions: NotImplementedException
	virtual string Convert(SoundFxType::Type data);

	// Description: Converts a string to soundfxtype enumeration
	// Exceptions: NotImplementedException
	virtual SoundFxType::Type Convert(string data);

#pragma endregion

};