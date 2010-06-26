#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "ICopyable.h"
#include "Layout.h"

#pragma endregion

class DisplayDevice: public ICopyable<DisplayDevice>
{
#pragma region Fields
private:
	UINT _deviceId;
	UINT _monitorNumber;
	Layout* _layout;
#pragma endregion

#pragma region Constructors/Destructors
public:
	DisplayDevice();
	virtual ~DisplayDevice();

	// make copy constructors inaccessible
	DisplayDevice(const DisplayDevice &refDevice);
	DisplayDevice &operator=(const DisplayDevice &refDevice);

#pragma endregion

#pragma region ICopyable members
public:
	DisplayDevice* MakeCopy();
	virtual void CopyFrom(DisplayDevice* original);
#pragma endregion

#pragma region Properties
public:
	UINT DeviceId();
	void DeviceId(UINT deviceId);
	UINT MonitorNumber();
	void MonitorNumber(UINT monitorNumber);
	Layout* MonitorLayout();
	void MonitorLayout(Layout* layout);
	
#pragma endregion

};