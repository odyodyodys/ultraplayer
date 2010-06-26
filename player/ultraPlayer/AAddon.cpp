#include "AAddon.h"

AAddon::AAddon(UINT id, AddonType::Type type)
{
	_id = id;
	_type = type;
}

AAddon::~AAddon(void)
{
	CAutoLock lock(&_objectLock);
}

AddonType::Type AAddon::Type()
{
	CAutoLock lock(&_objectLock);
	return _type;
}

UINT AAddon::Id()
{
	CAutoLock lock(&_objectLock);
	return _id;
}