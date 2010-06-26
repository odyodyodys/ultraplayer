#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#pragma endregion

class APlayerEnvironment abstract
{
#pragma region Fields
protected:
	HWND _window;

	CCritSec _objectLock;

#pragma endregion

#pragma region Constructors/Destructors
public:
	APlayerEnvironment(HWND window);
	virtual ~APlayerEnvironment();
#pragma endregion

#pragma region Properties
public:
	HWND Window();
	void Window(HWND window);
#pragma endregion

#pragma region Methods
public:
	// Description: Initializes environment
	virtual bool Initialize()=0;

	// Description: Resets environment (re initialization)
	virtual bool Reset()=0;
#pragma endregion

};