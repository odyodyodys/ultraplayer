#include "PlaybackEventNotifier.h"

PlaybackEventNotifier* PlaybackEventNotifier::_instance = NULL;

PlaybackEventNotifier::PlaybackEventNotifier(void)
{
}

PlaybackEventNotifier::~PlaybackEventNotifier(void)
{
}

PlaybackEventNotifier* PlaybackEventNotifier::Instance()
{
	if (!_instance)
	{
		_instance = new PlaybackEventNotifier();
	}

	return _instance;
}

void PlaybackEventNotifier::Notify(DWORD eventCode, HWND window)
{
	// New DShow event fired, notify all handlers
	for (list<IPlaybackEventHandler*>::iterator iter = _eventHandlers.begin(); iter != _eventHandlers.end(); iter++)
	{
		(*iter)->HandleEvent(eventCode, window);
	}	
}

void PlaybackEventNotifier::RegisterHandler( IPlaybackEventHandler* handler )
{
	_eventHandlers.push_back(handler);
}

void PlaybackEventNotifier::UnregisterHandler( IPlaybackEventHandler* handler )
{
	_eventHandlers.remove(handler);
}

void PlaybackEventNotifier::RegisterEvent( DWORD eventCode )
{
	_supportedEvents.push_back(eventCode);
}

void PlaybackEventNotifier::UnregisterEvent( DWORD eventCode )
{
	_supportedEvents.remove(eventCode);
}

bool PlaybackEventNotifier::SupportsEvent( DWORD eventCode )
{
	bool success = false;

	try
	{
		for (list<DWORD>::iterator iter = _supportedEvents.begin(); iter != _supportedEvents.end(); iter++)
		{
			if (*iter == eventCode)
			{
				success = true;
				break;
			}
		}
	}
	catch (exception& e)
	{
		success = false;
	}
	return success;
}