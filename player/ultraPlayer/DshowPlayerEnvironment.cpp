#include "DshowPlayerEnvironment.h"

DshowPlayerEnvironment::DshowPlayerEnvironment(HWND window, DisplayDevice* device):APlayerEnvironment(window)
{
	_displayDevice = device->MakeCopy();
}

DshowPlayerEnvironment::~DshowPlayerEnvironment()
{
	if (_displayDevice)
	{
		delete _displayDevice;
	}
}

DisplayDevice* DshowPlayerEnvironment:: Device() const
{
	// caller should NOT delete
	return _displayDevice;
}

bool DshowPlayerEnvironment::SwitchToDevice( DisplayDevice* newDevice )
{
	bool success = true;

	try
	{
		CAutoLock lock(&_objectLock);

		if (_displayDevice)
		{
			delete _displayDevice;
		}

		_displayDevice = newDevice->MakeCopy();

		success &= Reset();
	}
	catch (exception& e)
	{
		success = false;
	}

	return success;
}