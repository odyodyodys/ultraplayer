#include "APlayerEnvironment.h"

APlayerEnvironment::APlayerEnvironment(HWND window)
{
	_window = window;
}

APlayerEnvironment::~APlayerEnvironment(void)
{
}

HWND APlayerEnvironment::Window()
{
	CAutoLock lock(&_objectLock);

	return _window;
}

void APlayerEnvironment::Window( HWND window )
{
	CAutoLock lock(&_objectLock);

	_window = window;
}