#include "Direct3dVmr9DshowPlayerEnvironment.h"

Direct3dVmr9DshowPlayerEnvironment::Direct3dVmr9DshowPlayerEnvironment(HWND window, DisplayDevice* device):Vmr9DshowPlayerEnvironment(window, device)
{

}

Direct3dVmr9DshowPlayerEnvironment::~Direct3dVmr9DshowPlayerEnvironment(void)
{
}

bool Direct3dVmr9DshowPlayerEnvironment::Initialize()
{
	bool success = false;
	CAutoLock lock(&_objectLock);
	
	try
	{
		success = CreateDirect3dDevice();
		if (!success)
		{
			throw InitializationFailedException("Could not create direct3d device", "Direct3dVmr9DshowPlayerEnvironment::Initialize");
		}
	}
	catch (exception& e)
	{
		success = false;
	}

	return success;
}

bool Direct3dVmr9DshowPlayerEnvironment::Reset()
{
	// object is inaccessible while reseting.

	bool success = true;
	CAutoLock lock(&_objectLock);

	try
	{
		success &= Initialize();
	}
	catch(exception& e)
	{
		success = false;
	}
	return success;
}

bool Direct3dVmr9DshowPlayerEnvironment::CreateDirect3dDevice()
{
	bool success = false;
	HRESULT hr = E_FAIL;
	CAutoLock lock(&_objectLock);

	try
	{

		// Uninitialize previous instances
		CleanUp();

		// Create direct3d
		_direct3D = Direct3DCreate9(D3D_SDK_VERSION);
		if (_direct3D == NULL)
		{
			throw InitializationFailedException("Could not create direct3d device","Direct3dVmr9DshowPlayerEnvironment::CreateDirect3dDevice");
		}


		D3DDISPLAYMODE displayMode = {0};

		// Display mode
		hr = _direct3D->GetAdapterDisplayMode( _displayDevice->DeviceId(), &displayMode);

		D3DPRESENT_PARAMETERS presentParams;
		ZeroMemory(&presentParams, sizeof(presentParams));
		presentParams.Windowed = TRUE;
		presentParams.hDeviceWindow = _window;
		presentParams.SwapEffect = D3DSWAPEFFECT_COPY;
		presentParams.BackBufferFormat = displayMode.Format;

		// back buffer has the same dimensions as the monitor used.
		// It could have the window dimensions, but in case of maximize resolution would be poor.
		presentParams.BackBufferHeight = _displayDevice->MonitorLayout()->Height();
		presentParams.BackBufferWidth = _displayDevice->MonitorLayout()->Width();
		presentParams.BackBufferCount = 1;

		// create the device
		hr = _direct3D->CreateDevice(_displayDevice->DeviceId(), D3DDEVTYPE_HAL, _window, D3DCREATE_SOFTWARE_VERTEXPROCESSING | D3DCREATE_MULTITHREADED, &presentParams, &_direct3dDevice);
		if ( FAILED( hr )) throw InitializationFailedException("Failed to create the direct3d device", "Direct3dVmr9DshowPlayerEnvironment::CreateDirect3dDevice", hr);

		hr = _direct3dDevice->GetRenderTarget( 0, &_renderSurface );
		if (FAILED(hr)) throw InitializationFailedException("Error while getting render target", "Direct3dVmr9DshowPlayerEnvironment::CreateDirect3dDevice");

		success = true;
	}
	catch (exception& e)
	{
		success = false;
	}

	return success;
}

void Direct3dVmr9DshowPlayerEnvironment::CleanUp()
{
	CAutoLock lock(&_objectLock);

	if(_renderSurface.p != NULL)
	{
		_renderSurface.Attach(NULL);
	}

	// Delete the previous device
	if (_direct3dDevice.p != NULL)
	{
		_direct3dDevice.Attach(NULL);
	}        

	// Delete the previous direct3d
	if (_direct3D.p != NULL)
	{
		_direct3D.Attach(NULL);
	}
}

IDirect3D9* Direct3dVmr9DshowPlayerEnvironment::Direct3d()
{
	CAutoLock lock(&_objectLock);

	// Does not add ref, just the pointer
	return _direct3D.p;
}

IDirect3DDevice9* Direct3dVmr9DshowPlayerEnvironment::Direct3dDevice()
{
	CAutoLock lock(&_objectLock);

	// Does not add ref, just the pointer
	return _direct3dDevice.p;
}

IDirect3DSurface9* Direct3dVmr9DshowPlayerEnvironment::RenderTarget()
{
	CAutoLock lock(&_objectLock);

	// Does not add ref, just the pointer
	return _renderSurface.p;
}