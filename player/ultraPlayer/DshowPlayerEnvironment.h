#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "APlayerEnvironment.h"
#include "Layout.h"
#include "DisplayDevice.h"
#pragma endregion

class DshowPlayerEnvironment: public APlayerEnvironment
{
#pragma region Fields
protected:
	DisplayDevice* _displayDevice;
#pragma endregion

#pragma region Constructors/Destructors
public:
	DshowPlayerEnvironment(HWND window, DisplayDevice* device);
	virtual ~DshowPlayerEnvironment();
#pragma endregion

#pragma region Properties
public:
	DisplayDevice* Device() const;
#pragma endregion

#pragma region Methods
public:
	// Description: Switches playback to another device
	bool SwitchToDevice(DisplayDevice* newDevice);
#pragma endregion

#pragma region APlayerEnvironment Methods
public:
	virtual bool Initialize()=0;
	virtual bool Reset()=0;
#pragma endregion

};