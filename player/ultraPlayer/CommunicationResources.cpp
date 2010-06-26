#include "CommunicationResources.h"

CommunicationResources* CommunicationResources::_instance = NULL;

CommunicationResources::CommunicationResources(void)
{
	_newMessageInPipeEvent = WM_USER + 3;
}

CommunicationResources::~CommunicationResources(void)
{
}

CommunicationResources* CommunicationResources::Instance()
{
	if (!_instance)
	{
		_instance = new CommunicationResources();
	}
	return _instance;
}

DWORD CommunicationResources::NewMessageInPipeEvent()
{
	return _newMessageInPipeEvent;
}