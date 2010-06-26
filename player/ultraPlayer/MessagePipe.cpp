#include "MessagePipe.h"

MessagePipe* MessagePipe::_instance = NULL;

MessagePipe::MessagePipe(void)
{
	_responseCreatedEvent = CreateEvent(NULL, true, false, NULL);
	_request = NULL;
	_response = NULL;
	_window = NULL;
}

MessagePipe::~MessagePipe(void)
{
	// close event
	CloseHandle(_responseCreatedEvent);

	// cleanup
	if (_request)
	{
		delete _request;
	}

	if (_response)
	{
		delete _response;
	}

}

void MessagePipe::SetRequest( ARequest* request )
{
	// reset event
	ResetEvent(_responseCreatedEvent);


	// cleanup and set new request
	if (_request)
	{
		delete _request;
	}

	_request = request;

	// send window message
	SendMessage(_window, CommunicationResources::Instance()->NewMessageInPipeEvent(), NULL, NULL);
}

ARequest* MessagePipe::GetRequest()
{
	return _request;
}

void MessagePipe::SetResponse( AResponse* response )
{
	// cleanup and set new response
	if (_response)
	{
		delete _response;
	}

	_response = response;

	// set event
	SetEvent(_responseCreatedEvent);
}

AResponse* MessagePipe::GetResponse()
{
	return _response;
}

HANDLE MessagePipe::ResponseCreatedEvent()
{
	return _responseCreatedEvent;
}

MessagePipe* MessagePipe::Instance()
{
	if (!_instance)
	{
		_instance = new MessagePipe();
	}
	return _instance;
}

void MessagePipe::SetWindow( HWND window )
{
	_window = window;
}
