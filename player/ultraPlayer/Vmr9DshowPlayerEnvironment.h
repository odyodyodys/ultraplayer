#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "DshowPlayerEnvironment.h"
#pragma endregion

class Vmr9DshowPlayerEnvironment: public DshowPlayerEnvironment
{

#pragma region Constructors/Destructors
public:
	Vmr9DshowPlayerEnvironment(HWND window, DisplayDevice* device);
	virtual ~Vmr9DshowPlayerEnvironment();
#pragma endregion

#pragma region DshowPlayerEnvironment Methods
public:
	virtual bool Initialize();
	virtual bool Reset();
#pragma endregion

};