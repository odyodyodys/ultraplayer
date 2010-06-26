#include "AVisibleAddon.h"

AVisibleAddon::AVisibleAddon( UINT id, AddonType::Type type, VisibleLayout* const layout ):AAddon(id, type)
{
	_layout = new VisibleLayout(*layout);
}
AVisibleAddon::~AVisibleAddon(void)
{
	CAutoLock lock(&_objectLock);
	if (_layout)
	{
		delete _layout;
	}
}

VisibleLayout* AVisibleAddon::Layout()
{
	CAutoLock lock(&_objectLock);
	
	// caller should not alter/delete instance
	return _layout;
}

void AVisibleAddon::Layout( VisibleLayout* newLayout )
{
	CAutoLock lock(&_objectLock);

	if (_layout)
	{
		delete _layout;
	}
	_layout = new VisibleLayout(*newLayout);
}