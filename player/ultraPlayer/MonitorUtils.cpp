#include "MonitorUtils.h"

MonitorUtils* MonitorUtils::_instance = NULL;

MonitorUtils::MonitorUtils(void)
{
}

MonitorUtils::~MonitorUtils(void)
{
}

MonitorUtils* MonitorUtils::Instance()
{
	if (!_instance)
	{
		_instance = new MonitorUtils();
	}

	return _instance;
}

list<DisplayDevice*> MonitorUtils::GetMonitorsInfo()
{
	// get info about all system monitors

	list<DisplayDevice*> monitors;

	DISPLAY_DEVICE displayDevice;
	DISPLAY_DEVICE monitorDevice;
	HMONITOR monitorHandle = 0;
	MONITORINFO monitorInfo;
	DEVMODE deviceMode;
	DWORD deviceIndex = 0; // device index
	int monitorNumber = 1; // as used by Display Properties > Settings
	bool returnValue = false;

	ZeroMemory(&displayDevice,sizeof(displayDevice));
	displayDevice.cb = sizeof(displayDevice);

	// enumerate display devices, seek for not virtual monitors
	while (EnumDisplayDevices(0, deviceIndex, &displayDevice, 0) )
	{
		if (!(displayDevice.StateFlags & DISPLAY_DEVICE_MIRRORING_DRIVER)) // ignore virtual mirror displays
		{
			// get information about the monitor attached to this display adapter. dual headed cards
			// and laptop video cards can have multiple monitors attached

			ZeroMemory(&monitorDevice, sizeof(monitorDevice));
			monitorDevice.cb = sizeof(monitorDevice);
			DWORD monitorIndex = 0;

			while ( EnumDisplayDevices(displayDevice.DeviceName, monitorIndex, &monitorDevice, 0)  )
			{
				// Do stuff for each attached monitor to this display device.
				if (monitorDevice.StateFlags & DISPLAY_DEVICE_ACTIVE)
				{
					// get information about the display's position and the current display mode
					ZeroMemory(&deviceMode, sizeof(deviceMode));
					deviceMode.dmSize = sizeof(deviceMode);

					//Try to retrieve the current settings for the display device.
					if (!EnumDisplaySettingsEx(displayDevice.DeviceName, ENUM_CURRENT_SETTINGS, &deviceMode, 0))
					{
						// if fails, retrieve the settings for the display device that are currently stored in the registry.
						EnumDisplaySettingsEx(displayDevice.DeviceName, ENUM_REGISTRY_SETTINGS, &deviceMode, 0);
					}


					ZeroMemory(&monitorInfo, sizeof(monitorInfo));
					monitorInfo.cbSize = sizeof(monitorInfo);

					// Check if the device is attached & get the monitor handle
					if (displayDevice.StateFlags & DISPLAY_DEVICE_ATTACHED_TO_DESKTOP)
					{

						POINT monitorOrigin = { deviceMode.dmPosition.x, deviceMode.dmPosition.y };
						monitorHandle = MonitorFromPoint(monitorOrigin, MONITOR_DEFAULTTONULL);

						// monitor is enabled. only enabled displays have a monitor handle
						if (monitorHandle)
						{
							// try to get monitor info

							if (GetMonitorInfo(monitorHandle, &monitorInfo))
							{
								DisplayDevice* newDevice = new DisplayDevice();
								newDevice->DeviceId(deviceIndex);
								newDevice->MonitorNumber(monitorNumber);
								Layout* newLayout = new Layout();
								newLayout->Y(deviceMode.dmPosition.y);
								newLayout->X(deviceMode.dmPosition.x);
								newLayout->Height(deviceMode.dmPelsHeight);
								newLayout->Width(deviceMode.dmPelsWidth);
								newDevice->MonitorLayout(newLayout);
								monitors.push_back(newDevice);

								monitorNumber++;
							}

						}// have monitor handle

					}// device attached

				}// device is active

				monitorIndex++;

			}// while. monitor enumerator

		}// if not virtual monitor

		deviceIndex++;

	}// while. display device enumerator

	return monitors;

}