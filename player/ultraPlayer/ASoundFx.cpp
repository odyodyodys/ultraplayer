#include "ASoundFx.h"

ASoundFx::ASoundFx(SoundFxType::Type type)
{
	_type = type;
}

ASoundFx::~ASoundFx(void)
{
}

SoundFxType::Type ASoundFx::Type()
{
	return _type;
}