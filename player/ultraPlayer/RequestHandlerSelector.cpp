#include "RequestHandlerSelector.h"

RequestHandlerSelector* RequestHandlerSelector::_instance = NULL;

RequestHandlerSelector::RequestHandlerSelector(void)
{
}

RequestHandlerSelector::~RequestHandlerSelector(void)
{
}

RequestHandlerSelector* RequestHandlerSelector::Instance()
{
	if (_instance == NULL)
	{
		_instance = new RequestHandlerSelector();
		if (_instance == NULL)
		{
			// error. TODO improve singletons
		}
	}
	return _instance;
}

void RequestHandlerSelector::RegisterListener( MessageType::Type messageType, IRequestHandler* listener )
{
	_listeners[messageType] = listener;
}

IRequestHandler* RequestHandlerSelector::GetListener( ARequest* request )
{
	map<MessageType::Type, IRequestHandler*>::iterator item = _listeners.find(request->MessageType());

	// found listener
	if (item == _listeners.end())
	{
		// TODO throw communication exception. unsupported message
	}

	return (*item).second;

}