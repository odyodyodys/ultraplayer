#include "TCPServer.h"

TCPServer::TCPServer(USHORT port)
{
    _port = port;
	_listenerTerminationEvent = NULL;
	_listenerThreadHandle = NULL;
	_listenerThreadID = 0;
}

TCPServer::~TCPServer(void)
{
}

DWORD WINAPI TCPServer::TCPListenerProc( LPVOID params )
{
    // Validate the parameters

    TCPListenerHelper* helper = (TCPListenerHelper*) params;

    // validate the event handle.
    if (helper->TerminationEvent() == NULL)
    {
        // error, close the application
        PostQuitMessage(0);
    }

    USHORT portNumber = helper->ListeningPort();
    HANDLE terminationEvent = helper->TerminationEvent();

    // free the parameters object to avoid a memory leak
    delete params;
    SOCKET server;
    WSADATA wsaData;
    sockaddr_in local;

    // Set Winsock version to use.
    byte sockVerLow = 2;
    byte sockVerHigh = 2;

    WORD winsockVersionToUse = MAKEWORD(sockVerLow,sockVerHigh);

    // Initiate Winsock
    int winsockStartupValue = WSAStartup( winsockVersionToUse,&wsaData);
    if(winsockStartupValue!=0)
    {
        // cannot find usable winsock dll
        return 0;
    }
    else if (LOBYTE(wsaData.wVersion) != sockVerLow || HIBYTE(wsaData.wVersion) != sockVerHigh)
    {
        // cannot find usable winsock dll
        return 0;
    }

    //Address family is Internetwork UDP/TCP
    local.sin_family = AF_INET; 

    //Wild card IP address
    local.sin_addr.s_addr = INADDR_ANY; 

    //Converts the host port number value to TCP/IP network byte order (which is big-endian).
    local.sin_port = htons((u_short)portNumber); //port to use

    // Create the socket as a stream
    server = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    if(server == INVALID_SOCKET)
    {
        return 0;
    }

    //Associate a local address with a socket.
    if( bind(server, (sockaddr*) &local, sizeof(local))!=0)
    {
        return 0;
    }

    //Number of maximum pending connections
    int maxPendingConnections = 10;

    // Instruct the socket listener on the length of the pending-connections queue
    if(listen(server, maxPendingConnections) != 0)
    {
        return 0;
    }

    // Client side variables
    SOCKET client;
    sockaddr_in clientAddress;
    int clientAddressLength = sizeof(clientAddress);

    // the response string.
    std::string request;
    std::string response;

	// Initialize COM server.
	if (FAILED(CoInitializeEx(NULL, COINIT_MULTITHREADED)))
	{
		return 0;
	}	

    while (WaitForSingleObject(terminationEvent, 0 ) == WAIT_TIMEOUT)
    {
        //Permit an incoming connection attempt on the socket.
        client = accept(server, (struct sockaddr*) &clientAddress, &clientAddressLength);
        if(client == INVALID_SOCKET)
        {
            WSACleanup();
            return 0;
        }

        char receiveBuffer[4096]; // data to receive
		SecureZeroMemory(&receiveBuffer, 4096);
        int receiveState = recv(client, receiveBuffer, sizeof(receiveBuffer) , 0);
        request = receiveBuffer;

        if(receiveState == SOCKET_ERROR)
        {
            int val = WSAGetLastError();
            if(val == WSAENOTCONN)
            {
                // socket not connected
            }
            else if(val == WSAESHUTDOWN )
            {
                // socket has been shut down
            }
            return 0;
        }

		// send notification across main thread and wait for the response
		MessagePipe::Instance()->SetRequest(RequestFactory::CreateRequest(request));
		WaitForSingleObject(MessagePipe::Instance()->ResponseCreatedEvent(), INFINITE);
		AResponse* listenerResponse = MessagePipe::Instance()->GetResponse();

		// serialize response
 		response = listenerResponse->ToString();

		// it is being deleted by the message pipe
		listenerResponse = NULL;

        // respond to client
        send(client, response.c_str(), response.length(), 0);
        closesocket(client);
    }

    closesocket(server);
    WSACleanup();
    return 0;
}

void TCPServer::Start()
{
	try
	{
	    // create the termination event and set it as unset.
	    _listenerTerminationEvent = CreateEvent( NULL, true, false, NULL);
		if (!_listenerTerminationEvent)
		{
			throw InitializationFailedException("Could not create listenerThread event", "TCPServer::Start");
		}
	
	    TCPListenerHelper* tcpListenerHelper = new TCPListenerHelper();
	    tcpListenerHelper->ListeningPort(_port);
	    tcpListenerHelper->TerminationEvent(_listenerTerminationEvent);

	    // Create the player instructor thread suspended
	    _listenerThreadHandle = CreateThread(NULL,0,TCPListenerProc,(LPVOID)tcpListenerHelper, CREATE_SUSPENDED,&_listenerThreadID);
	
	    // check if the thread has started
		if (!_listenerThreadHandle)
		{
			throw InitializationFailedException("Could not create TCPListenerProc thread", "TCPServer::Start");
		}

		ResumeThread(_listenerThreadHandle);
	}
	catch (exception& e)
	{
		// TODO log error
		// cleanup
		Stop();
		throw InitializationFailedException(e.what(), "TCPServer::Start");
    }
}

void TCPServer::Stop()
{
	NotifyStop();

    // give a second to the thread to terminate its self, if it is delayed force its termination
    // a thread's handle is an event that is fired when the thread exits.
    if (WaitForSingleObject(_listenerThreadHandle, 1000) == WAIT_TIMEOUT )
    {
        if(_listenerThreadHandle != NULL)
        {
            TerminateThread(_listenerThreadHandle, 0);
			CloseHandle(_listenerThreadHandle);
        }
    }
}

void TCPServer::NotifyStop()
{
    // set the termination event
    SetEvent(_listenerTerminationEvent);
}