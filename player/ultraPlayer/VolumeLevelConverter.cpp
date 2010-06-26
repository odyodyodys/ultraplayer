#include "VolumeLevelConverter.h"

VolumeLevelConverter* VolumeLevelConverter::_instance = NULL;

VolumeLevelConverter::VolumeLevelConverter(void)
{
}

VolumeLevelConverter::~VolumeLevelConverter(void)
{
}

long VolumeLevelConverter::Convert( UINT percentValue )
{
	/*
	convert the linear volume 0 <-> 100 to dbVolume -10000 <-> 0
	db = 10^3 * log10((linear/100)^2) =>
	db = 2000 * log10(linear/100)
	*/

	// initialize to silence
	long dbVolume = -10000;

	if (percentValue <=100)
	{
		dbVolume = 2000 * log10(percentValue / 100.0f );
	}

	return dbVolume;
}

UINT VolumeLevelConverter::Convert( long decibelsValue )
{
	throw NotImplementedException("UINT to long", "VolumeLevelConverter::Convert");
}

VolumeLevelConverter* VolumeLevelConverter::Instance()
{
	if (!_instance)
	{
		_instance = new VolumeLevelConverter();
	}
	return _instance;
}