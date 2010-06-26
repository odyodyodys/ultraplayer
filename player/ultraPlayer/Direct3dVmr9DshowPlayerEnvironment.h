#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "Vmr9DshowPlayerEnvironment.h"

#include "InitializationFailedException.h"
#pragma endregion

class Direct3dVmr9DshowPlayerEnvironment: public Vmr9DshowPlayerEnvironment
{
#pragma region Fields
private:
	CComPtr<IDirect3D9> _direct3D;
	CComPtr<IDirect3DDevice9> _direct3dDevice;
	CComPtr<IDirect3DSurface9> _renderSurface;
#pragma endregion

#pragma region Constructors/Destructors
public:
	Direct3dVmr9DshowPlayerEnvironment(HWND window, DisplayDevice* device);
	virtual ~Direct3dVmr9DshowPlayerEnvironment();
#pragma endregion

#pragma region Methods
private:
	// Description: Creates a 3d device for the current monitor/window set
	bool CreateDirect3dDevice();
	
	// Description: Cleans up data
	void CleanUp();
#pragma endregion

#pragma region Properties
public:
	IDirect3D9* Direct3d();
	IDirect3DDevice9* Direct3dDevice();
	IDirect3DSurface9* RenderTarget();
#pragma endregion

#pragma region Vmr9DshowPlayerEnvironment Methods
public:
	virtual bool Initialize();
	virtual bool Reset();
#pragma endregion

};