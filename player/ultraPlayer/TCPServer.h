#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "TCPListenerHelper.h"
	#include "MessagePipe.h"
	#include "RequestFactory.h"
	#include "ResponseType.h"

	#include "InitializationFailedException.h"
#pragma endregion

using namespace std;

class TCPServer
{

#pragma region Fields
private:
    USHORT _port;
    HANDLE _listenerTerminationEvent;
    DWORD _listenerThreadID;
    HANDLE _listenerThreadHandle;
#pragma endregion

#pragma region Constructors/Destructors
public:
    TCPServer(USHORT port);
    ~TCPServer(void);
#pragma endregion

#pragma region Methods
private:
	// Description: Tcp server method. Runs as a separate thread
    static DWORD WINAPI TCPListenerProc(LPVOID params);

public:
	// Description: Starts the server
	// Exceptions: InitializationFailedException
	void Start();

	// Description: Terminates the listening tcp server thread.
    void Stop();

	// Description: Notifies the tcp server thread that it needs to die
	void NotifyStop();
#pragma endregion
};
