#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "UltraPlayer.h"
	#include "PlayerType.h"
	#include "NumericToStringConverter.h"

	#include "InitializationFailedException.h"
	#include "InvalidArgumentException.h"
#pragma endregion


// Description: Starts the player
// Exceptions:	InitializationFailedException
void StartPlayer(LPSTR arguments, HINSTANCE instance);

// Description: Stops and releases UltraPlayer instance
void CleanUp();

// Description: Sets top level error handling for all threads of the process
void SetErrorHandling();

// Description: Top level exception handler method.
LONG WINAPI UnhandledExceptionHandler(struct _EXCEPTION_POINTERS* exceptionInfo);

// Description: Application entry point
int WINAPI WinMain(HINSTANCE instance, HINSTANCE prevInstance, LPSTR arguments, int showWindow );
