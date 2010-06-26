#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
#pragma endregion


class TCPListenerHelper
{
#pragma region Fields
private:
    HANDLE _terminationEvent;
    USHORT _port;
#pragma endregion

#pragma region Constructors/Destructor
public:
    TCPListenerHelper(void);
    ~TCPListenerHelper(void);
#pragma endregion

#pragma region Properties
public:
    void TerminationEvent(HANDLE terminationEvent);
    HANDLE TerminationEvent();

    void ListeningPort(USHORT port);
    USHORT ListeningPort();
#pragma endregion
};
