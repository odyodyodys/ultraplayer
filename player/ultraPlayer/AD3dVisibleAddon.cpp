#include "AD3dVisibleAddon.h"

AD3dVisibleAddon::AD3dVisibleAddon(UINT id, AddonType::Type type, VisibleLayout* const layout):AVisibleAddon(id, type, layout)
{
}

AD3dVisibleAddon::~AD3dVisibleAddon(void)
{
	CAutoLock lock(&_objectLock);
}
