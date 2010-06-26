#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "PlaybackResources.h"
	#include "PlaybackEventNotifier.h"
	#include "Layout.h"
	#include "MonitorUtils.h"
	#include "DisplayDevice.h"
	#include "IRequestHandler.h"
	#include "RequestHandlerSelector.h"
	#include "MessagePipe.h"
	#include "CommunicationResources.h"
	#include "ARequest.h"
	#include "AResponse.h"
	#include "resource.h"

	#include "InitializationFailedException.h"
#pragma endregion

class WindowManager
{
#pragma region Fields
private:
	HWND _windowHandle;
	HINSTANCE _hinstance;
	list<DisplayDevice*> _displayDevices;
	static HBITMAP _logo;
	static bool _shouldDraw;
	DisplayDevice* _currentDevice;
#pragma endregion

#pragma region Constructors/Destructors
public:
	WindowManager(HINSTANCE hinstance);
	~WindowManager();
#pragma endregion

#pragma region Methods
private:
	// Description: Window message callback method. Handles window events
	static LRESULT CALLBACK WindowMsgCallback(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam);

	// Description: Is called on form paint event
	static void OnPaint(HWND hwnd);

	// Description: Deletes display device list
	void CleanUpDisplayDevices();

	// Description: Updates the display devices list
	void UpdateDisplayDevices();

	// Description: Focuses window
	void FocusWindow();

	// Description: Gets info about the primary device
	DisplayDevice* GetPrimaryDisplayDevice();

public:
	// Description: Creates window
	// Exceptions: InitializationFailedException
	void CreateVideoWindow();

	// Description: if param is true, window will become visible
	void SetWindowVisibility(bool visibleWindow);

	// Description: Sets the position and size of the window
	bool SetWindowLayout(UINT monitorNumber, Layout* layout);

	// Description: Gets the display devices enumerated
	list<DisplayDevice*> GetDisplayDevices();
#pragma endregion

#pragma region Properties
public:
	HWND WindowHandle();
	DisplayDevice* CurrentDevice();

#pragma endregion

};