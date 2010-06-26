#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "APlayerEnvironment.h"

#include "NotImplementedException.h"
#pragma endregion

class ComEnabledPlayerEnvironment: public APlayerEnvironment
{
#pragma region Constructors/Destructors
public:
	ComEnabledPlayerEnvironment(HWND window);
	virtual ~ComEnabledPlayerEnvironment();
#pragma endregion

#pragma region APlayerEnvironment members
public:
	virtual bool Initialize();
	virtual bool Reset();
#pragma endregion

};