#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "IConverter.h"

	#include "NotImplementedException.h"
#pragma endregion

class VolumeLevelConverter: public IConverter<UINT, long>
{
#pragma region Fields
private:
	static VolumeLevelConverter* _instance;
#pragma endregion

#pragma region Constructors/Destructors
private:
	VolumeLevelConverter();
public:
	virtual ~VolumeLevelConverter();
#pragma endregion

#pragma region Methods
public:
	// Description: Part of the singleton pattern.
	static VolumeLevelConverter* Instance();
#pragma endregion

#pragma region IConverter members
public:
	// Description: Converts a decibel sound level to percent value. -10000 is silence while 0 is full volume
	UINT Convert(long decibelsValue);

	// Description: Converts a percentage value to decibel value. -10000 is silence while 0 is full volume
	long Convert(UINT percentValue);
#pragma endregion
};
