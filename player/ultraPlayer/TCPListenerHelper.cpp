#include "TCPListenerHelper.h"

TCPListenerHelper::TCPListenerHelper(void)
{
}

TCPListenerHelper::~TCPListenerHelper(void)
{
}

void TCPListenerHelper::TerminationEvent( HANDLE terminationEvent )
{
	// TODO throw exception on wrong arguments
	_terminationEvent = terminationEvent;
}

HANDLE TCPListenerHelper::TerminationEvent()
{
    return _terminationEvent;
}

void TCPListenerHelper::ListeningPort( USHORT port )
{
    if (port > 1024 && port < 65536)
    {
        _port = port;
    }
    else
    {
        _port = 0;
    }
}

USHORT TCPListenerHelper::ListeningPort()
{
    return _port;
}