#include "Vmr9DshowPlayerEnvironment.h"

Vmr9DshowPlayerEnvironment::Vmr9DshowPlayerEnvironment(HWND window, DisplayDevice* device):DshowPlayerEnvironment(window, device)
{

}

Vmr9DshowPlayerEnvironment::~Vmr9DshowPlayerEnvironment(void)
{
}

bool Vmr9DshowPlayerEnvironment::Initialize()
{
	CAutoLock lock(&_objectLock);

	// nothing to do
	return true;
}

bool Vmr9DshowPlayerEnvironment::Reset()
{
	CAutoLock lock(&_objectLock);

	// nothing to do
	return true;
}