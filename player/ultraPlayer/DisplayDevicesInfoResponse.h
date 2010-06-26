#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AResponse.h"
#include "Layout.h"
#include "DisplayDevice.h"
#include "NumericToStringConverter.h"
#pragma endregion

class DisplayDevicesInfoResponse: public AResponse
{
#pragma region Fields
private:
	list<DisplayDevice*> _devices;
#pragma endregion

#pragma region Constructors/Destructors
public:
	DisplayDevicesInfoResponse();
	virtual ~DisplayDevicesInfoResponse();
#pragma endregion

#pragma region AResponse Methods
public:
	virtual string ToString();
#pragma endregion

#pragma region Properties
public:
	void Devices(list<DisplayDevice*> devices);
#pragma endregion

};