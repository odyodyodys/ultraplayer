#include "Program.h"

int WINAPI WinMain( HINSTANCE instance, HINSTANCE prevInstance, LPSTR arguments, int showWindow )
{	
	try
	{
		// start the player (silence is golden..)
		StartPlayer(arguments, instance);
	}
	catch (exception& e)
	{
		// TODO log error
		return 0;
	}

    // message loop
	MSG windowMessage;
    while(GetMessage(&windowMessage, NULL, 0, 0) > 0 )
    {
        TranslateMessage(&windowMessage);
        DispatchMessage(&windowMessage);
    }

	CleanUp();

    return (int)windowMessage.wParam;
}

void StartPlayer( LPSTR arguments, HINSTANCE hinstance )
{
	try
	{
		string args = arguments;

		// Get player's instance
		UltraPlayer* player = UltraPlayer::Instance();

		// Set hinstance
		player->HInstance(hinstance);

        if (args.size() == 0)
        {
            throw InvalidArgumentException("args.size() == 0", "UltraPlayer.StartPlayer");
        }

		// create player
		player->Initialize();

        // Start the player
        player->Start(NumericToStringConverter::Convert<int>(args));

	}
	catch (exception& e)
	{
		// throw initialization exception with the reason of the thrown exception
		throw InitializationFailedException(e.what(), "UltraPlayer::StartPlayer");
	}
}

void CleanUp()
{
	// Note this might delay because server needs some time to die
	UltraPlayer::Instance()->Stop();

	// delete player
	delete UltraPlayer::Instance();
}

void SetErrorHandling()
{
	//Set the error handling for all threads of the process
	//SEM_FAILCRITICALERRORS: the system sends the error to the calling process.
	SetErrorMode(SEM_FAILCRITICALERRORS);

	//Enables the application to supersede the top-level exception handler of each thread and process.
	SetUnhandledExceptionFilter((LPTOP_LEVEL_EXCEPTION_FILTER) UnhandledExceptionHandler);
}

LONG WINAPI UnhandledExceptionHandler( struct _EXCEPTION_POINTERS* exceptionInfo )
{
	// Unhandled exception occured

	// uninitialize Com server.
	CoUninitialize();

	// Stop the player
	CleanUp();	

	// TODO Log exception parameters

	return EXCEPTION_EXECUTE_HANDLER;
}