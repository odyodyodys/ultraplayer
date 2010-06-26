#include "WindowManager.h"

HBITMAP WindowManager::_logo = NULL;
bool WindowManager::_shouldDraw = true;

WindowManager::WindowManager(HINSTANCE hinstance)
{
	_hinstance = hinstance;
	_windowHandle = NULL;
	_shouldDraw = true;

	UpdateDisplayDevices();

	// default to primary display device
	_currentDevice = GetPrimaryDisplayDevice();

}

WindowManager::~WindowManager(void)
{
	// TODO check who is responsible for destroying the window

	CleanUpDisplayDevices();
}

HWND WindowManager::WindowHandle()
{
	return _windowHandle;
}

void WindowManager::CreateVideoWindow()
{
	try
	{
		WNDCLASSEX windowClass;
	
		// Register the Window Class
		windowClass.cbSize        = sizeof(WNDCLASSEX);
		windowClass.style         = 0;
		windowClass.lpfnWndProc   = WindowMsgCallback;
		windowClass.cbClsExtra    = 0;
		windowClass.cbWndExtra    = 0;
		windowClass.hInstance     = _hinstance;
		windowClass.hIcon         = LoadIcon(NULL, IDI_APPLICATION);
		windowClass.hCursor       = LoadCursor(NULL, IDC_ARROW);
		windowClass.hbrBackground = (HBRUSH)(COLOR_WINDOW+1);
		windowClass.lpszMenuName  = NULL;
		windowClass.lpszClassName = L"Ultra Player";
		windowClass.hIconSm       = LoadIcon(NULL, IDI_APPLICATION);
	
		if(!RegisterClassEx(&windowClass))
		{
			throw InitializationFailedException("Could not register window class", "CreateClassAndWindow");
		}

		// Create the Window
		_windowHandle = CreateWindowEx(WS_EX_APPWINDOW, L"Ultra Player" , L"Ultra Player", WS_POPUP /*|WS_VISIBLE*/, CW_USEDEFAULT, CW_USEDEFAULT, 1, 1, NULL, NULL, _hinstance, NULL);
		Layout* windowLayout = new Layout();
		windowLayout->X(350);
		windowLayout->Y(100);
		windowLayout->Width(350);
		windowLayout->Height(300);
		SetWindowLayout(_currentDevice->MonitorNumber(), windowLayout );
		delete windowLayout;
	
		if(!_windowHandle)
		{
			throw InitializationFailedException("Could not create window", "CreateClassAndWindow");
		}
	}
	catch (exception& e)
	{
		throw InitializationFailedException(e.what(), "WindowManager::CreateVideoWindow");
	}

}

LRESULT CALLBACK WindowManager::WindowMsgCallback( HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam )
{
	LRESULT result = 0;

	if (msg == CommunicationResources::Instance()->NewMessageInPipeEvent())
	{

		// TODO might throw exception on unknown message. Send appropriate error response if this is the case.
		IRequestHandler* listener = RequestHandlerSelector::Instance()->GetListener(MessagePipe::Instance()->GetRequest());

		// use requestFactory to convert it and pass the ARequest object to the listener,
		// set the new response to the pipe.
		MessagePipe::Instance()->SetResponse(listener->HandleRequest(MessagePipe::Instance()->GetRequest()));
	}
	else if (PlaybackEventNotifier::Instance()->SupportsEvent(msg))
	{
		PlaybackEventNotifier::Instance()->Notify(msg, hwnd);
	}
	else if (msg == (WM_PAINT | WM_MOVE) && _shouldDraw)
	{
		OnPaint(hwnd);
	}
	else if (msg == WM_CREATE)
	{
		HINSTANCE hInstance = GetWindowInstance(hwnd);
		_logo = LoadBitmap(hInstance,MAKEINTRESOURCE(IDB_BITMAP1));
	}
	else if (msg == WM_CLOSE)
	{
		DestroyWindow(hwnd);
	}
	else if (msg == WM_DESTROY)
	{
		DeleteObject(_logo);
		PostQuitMessage(0);
	}
	else if(msg == PlaybackResources::Instance()->AllowLogoDrawingEventCode())
	{
		_shouldDraw = true;
		InvalidateRect(hwnd, NULL, true);
	}
	else if (msg == PlaybackResources::Instance()->SuppressLogoDrawingEventCode())
	{
		_shouldDraw = false;
	}

	return DefWindowProc(hwnd, msg, wParam, lParam);
}

void WindowManager::SetWindowVisibility( bool visibleWindow )
{
	// TODO check if window has been created

	ShowWindow(_windowHandle, visibleWindow);

	if (visibleWindow)
	{
		UpdateWindow(_windowHandle);
	}
}

bool WindowManager::SetWindowLayout(UINT monitorNumber,  Layout* layout )
{
	bool success = false;

	try
	{
		UpdateDisplayDevices();

		// get requested monitor info
		DisplayDevice* device = NULL;
		for (list<DisplayDevice*>::iterator iter = _displayDevices.begin(); iter != _displayDevices.end(); iter++)
		{
			if ((*iter)->MonitorNumber() == monitorNumber )
			{
				device = *iter;
				break;
			}
		}

		// check if found
		if (!device)
		{
			// current device becomes the primary.
			_currentDevice = GetPrimaryDisplayDevice();
			throw exception();
		}

		_currentDevice = device;

		// compute layout
		layout->X(_currentDevice->MonitorLayout()->X() + (_currentDevice->MonitorLayout()->Width()*layout->X())/1000.0f);
		layout->Y(_currentDevice->MonitorLayout()->Y() + (_currentDevice->MonitorLayout()->Height()*layout->Y())/1000.0f);
		layout->Width((_currentDevice->MonitorLayout()->Width() * layout->Width())/1000.0f);
		layout->Height((_currentDevice->MonitorLayout()->Height() * layout->Height())/1000.0f);

		// TODO get screen size and compute window size based on layout
		success = SetWindowPos(_windowHandle, NULL, layout->X(), layout->Y(), layout->Width(), layout->Height(), 0) ? true : false ;

		// if successful, notify that monitor has been switched

	}
	catch (exception& e)
	{
		success = false;
	}

	return success;
}

list<DisplayDevice*> WindowManager::GetDisplayDevices()
{

	// Caller should release list

	UpdateDisplayDevices();

	// Make a copy of _devices list
	list<DisplayDevice*> tmpList;
	list<DisplayDevice*>::iterator iter;
	for (iter = _displayDevices.begin(); iter != _displayDevices.end(); iter++)
	{
		if (*iter != NULL)
		{
			DisplayDevice* newDevice = new DisplayDevice();
			newDevice->DeviceId((*iter)->DeviceId());
			newDevice->MonitorNumber((*iter)->MonitorNumber());
			newDevice->MonitorLayout(new Layout(*(*iter)->MonitorLayout()));
			tmpList.push_back(newDevice);
		}
	}

	return tmpList;
}

void WindowManager::CleanUpDisplayDevices()
{
	list<DisplayDevice*>::iterator iter;
	for (iter = _displayDevices.begin(); iter != _displayDevices.end(); iter++)
	{
		if (*iter)
		{
			delete *iter;
		}
	}

	// make it reusable
	_displayDevices.clear();

}

DisplayDevice* WindowManager::GetPrimaryDisplayDevice()
{
	// caller should NOT delete instance.

	UpdateDisplayDevices();

	DisplayDevice* primaryDisplay = NULL;
	for(list<DisplayDevice*>::iterator it = _displayDevices.begin(); it != _displayDevices.end(); it++)
	{
		if ((*it)->MonitorNumber() == 1)
		{
			primaryDisplay = *it;
			break;
		}
	}

	return primaryDisplay;
}

void WindowManager::UpdateDisplayDevices()
{
	CleanUpDisplayDevices();
	_displayDevices = MonitorUtils::Instance()->GetMonitorsInfo();
}

void WindowManager::FocusWindow()
{
	SetForegroundWindow(_windowHandle); 
}

void WindowManager::OnPaint(HWND hwnd)
{
	PAINTSTRUCT paint;
	HDC destinationDc = BeginPaint(hwnd, &paint);

	HDC sourceDc = CreateCompatibleDC(NULL);
	HBITMAP bitmapHandle = SelectBitmap(sourceDc, _logo);

	// transfer the contents of the drawing surface from one DC to another.
	BITMAP bitmap;
	GetObject(_logo,sizeof(bitmap), &bitmap);
	RECT destRect = {0};
	GetWindowRect(hwnd, &destRect);
	SetStretchBltMode(destinationDc, HALFTONE);
	StretchBlt(destinationDc, 0, 0, destRect.right - destRect.left, destRect.bottom - destRect.top, sourceDc, 0, 0, bitmap.bmWidth, bitmap.bmHeight, SRCCOPY);

	SelectBitmap(sourceDc, bitmapHandle);
	DeleteDC(sourceDc);

	// EndPaint balances off the BeginPaint call.
	EndPaint(hwnd, &paint);
	
}

DisplayDevice* WindowManager::CurrentDevice()
{
	// caller should NOT delete
	return _currentDevice;
}