#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "IPlaybackEventHandler.h"

	#include "NotImplementedException.h"
#pragma endregion

using namespace std;

class PlaybackEventNotifier
{
#pragma region Fields
private:
	static PlaybackEventNotifier* _instance;

	list<IPlaybackEventHandler*> _eventHandlers;
	list<DWORD> _supportedEvents;
#pragma endregion

#pragma region Constructors/Destructors
private:
	PlaybackEventNotifier();
public:
	virtual ~PlaybackEventNotifier();
#pragma endregion

#pragma region Methods
public:
	// Description: Part of the singleton pattern.
	static PlaybackEventNotifier* Instance();

	// Description: Notifies registerd handlers for an newly arrived message
	void Notify(DWORD eventCode, HWND window);

	// Description: Registers a handler
	void RegisterHandler(IPlaybackEventHandler* handler);

	// Description: Unregisters a handler
	void UnregisterHandler(IPlaybackEventHandler* handler);

	// Description: Registers an event
	void RegisterEvent(DWORD eventCode);

	// Description: Unregisters an event
	void UnregisterEvent(DWORD eventCode);

	// Description: Returns true if specified event is supported
	bool SupportsEvent(DWORD eventCode);
#pragma endregion

};