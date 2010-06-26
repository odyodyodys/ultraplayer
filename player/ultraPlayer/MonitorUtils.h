#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "Layout.h"
#include "DisplayDevice.h"
#pragma endregion

class MonitorUtils
{
#pragma region Fields
private:
	static MonitorUtils* _instance;
#pragma endregion

#pragma region Constructors/Destructors
private:
	MonitorUtils();
public:
	virtual ~MonitorUtils();

#pragma endregion

#pragma region Methods
public:
	// Description: Part of the singleton pattern.
	static MonitorUtils* Instance();

	// Description: Returns a list having all local, non-virtual monitors
	// caller is responsible for deleting list objects
	list<DisplayDevice*> GetMonitorsInfo();
#pragma endregion

};