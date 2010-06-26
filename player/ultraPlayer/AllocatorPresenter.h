#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "PlaneScene.h"
#include "Direct3dVmr9DshowPlayerEnvironment.h"
#include "AExpandable.h"
#include "AD3dVisibleAddon.h"
#pragma endregion

class AllocatorPresenter : public AExpandable<AD3dVisibleAddon>, public  IVMRSurfaceAllocator9, public IVMRImagePresenter9
{
#pragma region Fields
private:
	CCritSec _objectLock;
	volatile long _referenceCount;
	PlaneScene _scene;

	// If the device does not support textures in the native video format, it will use this for frame drawing
	CComPtr<IDirect3DTexture9> _privateTexture;
	
	CComPtr<ID3DXSprite> _sprite;
	CComPtr<IVMRSurfaceAllocatorNotify9> _vmrSurfaceAllocatorNotify;
	vector<CComPtr<IDirect3DSurface9>> _surfaces;

	Direct3dVmr9DshowPlayerEnvironment* _environment;

#pragma endregion

#pragma region Constructors/Destructors
public:
	AllocatorPresenter(HRESULT& hr, Direct3dVmr9DshowPlayerEnvironment* environment);
	virtual ~AllocatorPresenter();
#pragma endregion

#pragma region Methods
private:
	// Description: Deletes surfaces
	void DeleteSurfaces();
#pragma endregion

#pragma region IVMRSurfaceAllocator9 Methods
public:
	virtual HRESULT STDMETHODCALLTYPE InitializeDevice( DWORD_PTR userID, VMR9AllocationInfo *allocInfo, DWORD *numBuffers);
	virtual HRESULT STDMETHODCALLTYPE TerminateDevice( DWORD_PTR Id);
	virtual HRESULT STDMETHODCALLTYPE GetSurface( DWORD_PTR userId, DWORD surfaceIndex, DWORD surfaceFlags, IDirect3DSurface9 **surface);
	virtual HRESULT STDMETHODCALLTYPE AdviseNotify( IVMRSurfaceAllocatorNotify9 *surfAllocNotify);
#pragma endregion

#pragma region IVMRImagePresenter9 Methods
public:
	virtual HRESULT STDMETHODCALLTYPE StartPresenting( DWORD_PTR userId);
	virtual HRESULT STDMETHODCALLTYPE StopPresenting( DWORD_PTR userId);
	virtual HRESULT STDMETHODCALLTYPE PresentImage( DWORD_PTR userId, VMR9PresentationInfo *presentationInfo);
#pragma endregion
#pragma region IUnknown
	virtual HRESULT STDMETHODCALLTYPE QueryInterface( REFIID riid, void** object);
	virtual ULONG STDMETHODCALLTYPE AddRef();
	virtual ULONG STDMETHODCALLTYPE Release();
#pragma endregion

#pragma region Methods
private:
	// Description: Checks whether it is needed to switch device
	bool NeedToHandleDisplayChange();

	// Description: Helper method that does all the drawing. Calls planeScene and addons to be drawing on each video frame
	HRESULT PresentHelper(VMR9PresentationInfo* presInfo);
#pragma endregion
};