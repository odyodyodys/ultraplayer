#include "AllocatorPresenter.h"

AllocatorPresenter::AllocatorPresenter(HRESULT& hr, Direct3dVmr9DshowPlayerEnvironment* environment)
{
	hr = E_FAIL;

	try
	{
		_referenceCount = 1;
		_environment = environment;
	
		CAutoLock lock(&_objectLock);
	
		hr = D3DXCreateSprite(_environment->Direct3dDevice(), &_sprite );
		if (FAILED(hr)) throw PlaybackException("Error while creating sprite","AllocatorPresenter");
	}
	catch (exception& e)
	{
		
	}
}

AllocatorPresenter::~AllocatorPresenter(void)
{
	DeleteSurfaces();
}

void AllocatorPresenter::DeleteSurfaces()
{
	CAutoLock lock(&_objectLock);

	// clean up the private textures
	_privateTexture = NULL;

	for( size_t i = 0; i < _surfaces.size(); ++i )
	{
		_surfaces[i] = NULL;
	}
}

HRESULT STDMETHODCALLTYPE AllocatorPresenter::InitializeDevice( DWORD_PTR userID, VMR9AllocationInfo *allocInfo, DWORD *numBuffers )
{
	HRESULT hr = E_FAIL;

	try
	{

		CAutoLock lock(&_objectLock);

		D3DCAPS9 d3dcaps;
		DWORD dwWidth = 1;
		DWORD dwHeight = 1;
		float fTU = 1.f;
		float fTV = 1.f;
	
		if( numBuffers == NULL )
		{
			hr = E_POINTER;
			throw PlaybackException("Invalid number of buffers", "AllocatorPresenter::InitializeDevice");
		}
	
		if( _vmrSurfaceAllocatorNotify == NULL )
		{
			hr = E_FAIL;
			throw PlaybackException("Null SurfaceAllocatorNotify", "AllocatorPresenter::InitializeDevice");
		}

		// If hardware require textures to power of two sized
		_environment->Direct3dDevice()->GetDeviceCaps( &d3dcaps );
		if( d3dcaps.TextureCaps & D3DPTEXTURECAPS_POW2 )
		{
			while( dwWidth < allocInfo->dwWidth )
			{
				dwWidth = dwWidth << 1;
			}
	
			while( dwHeight < allocInfo->dwHeight )
			{
				dwHeight = dwHeight << 1;
			}
	
			fTU = (float)(allocInfo->dwWidth) / (float)(dwWidth);
			fTV = (float)(allocInfo->dwHeight) / (float)(dwHeight);
			_scene.SourceRect( fTU, fTV );
			allocInfo->dwWidth = dwWidth;
			allocInfo->dwHeight = dwHeight;
	
		}
	
		// make sure that textures are created because
		// surfaces can not be textured onto a primitive.
		allocInfo->dwFlags |= VMR9AllocFlag_TextureSurface;
	
		DeleteSurfaces();
		_surfaces.resize(*numBuffers);
		hr = _vmrSurfaceAllocatorNotify->AllocateSurfaceHelper(allocInfo, numBuffers, & _surfaces.at(0) );
		if (FAILED(hr))
		{
			//throw PlaybackException("Could not allocate surfaces", "AllocatorPresenter::InitializeDevice");
			// Log error only.
		}

		// If failed to create a texture surface and the format is not an alpha format, cannot create a texture.
		// Create a private texture and copy the decoded images onto it.
		if(FAILED(hr) && !(allocInfo->dwFlags & VMR9AllocFlag_3DRenderTarget))
		{
			DeleteSurfaces();            
	
			// is surface YUV ?
			if (allocInfo->Format > '0000') 
			{
				D3DDISPLAYMODE dm; 
				hr = _environment->Direct3dDevice()->GetDisplayMode(NULL, &dm );
				if ( FAILED( hr )) throw PlaybackException("Failed to get display mode", "AllocatorPresenter::InitializeDevice", hr);
	
				// create the private texture
				hr = _environment->Direct3dDevice()->CreateTexture(allocInfo->dwWidth, allocInfo->dwHeight, 1, D3DUSAGE_RENDERTARGET, dm.Format, D3DPOOL_DEFAULT , &_privateTexture.p, NULL);
				if ( FAILED( hr )) throw PlaybackException("Failed to create the private texture", "AllocatorPresenter::InitializeDevice", hr);

			}

			allocInfo->dwFlags &= ~VMR9AllocFlag_TextureSurface;
			allocInfo->dwFlags |= VMR9AllocFlag_OffscreenSurface;
	
			hr = _vmrSurfaceAllocatorNotify->AllocateSurfaceHelper(allocInfo, numBuffers, & _surfaces.at(0) );
			if ( FAILED( hr )) throw PlaybackException("Failed to allocate surface helper to the allocator notify", "AllocatorPresenter::InitializeDevice", hr);
		}
	
		hr = _scene.Initialize(_environment->Direct3dDevice());
		if (FAILED(hr)) throw PlaybackException("Could not initialize scene", "AllocatorPresenter::InitializeDevice", hr);
	}
	catch (exception& e)
	{
		// make sure hr is failure to notify caller
		if (SUCCEEDED(hr))
		{
			hr = E_FAIL;
		}
	}

	return hr;
}

HRESULT STDMETHODCALLTYPE AllocatorPresenter::TerminateDevice( DWORD_PTR Id )
{
	CAutoLock lock(&_objectLock);

	DeleteSurfaces();
	return S_OK;
}

HRESULT STDMETHODCALLTYPE AllocatorPresenter::GetSurface( DWORD_PTR userId, DWORD surfaceIndex, DWORD surfaceFlags, IDirect3DSurface9 **surface )
{
	if( surface == NULL )
	{
		return E_POINTER;
	}

	if (surfaceIndex >= _surfaces.size() ) 
	{
		return E_FAIL;
	}

	CAutoLock lock(&_objectLock);

	return _surfaces[surfaceIndex].CopyTo(surface) ;
}

HRESULT STDMETHODCALLTYPE AllocatorPresenter::AdviseNotify( IVMRSurfaceAllocatorNotify9 *surfAllocNotify )
{
	CAutoLock lock(&_objectLock);

	HRESULT hr = E_FAIL;

	try
	{
		_vmrSurfaceAllocatorNotify = surfAllocNotify;
	
		HMONITOR monitor = _environment->Direct3d()->GetAdapterMonitor( _environment->Device()->DeviceId());
	
		hr = _vmrSurfaceAllocatorNotify->SetD3DDevice(_environment->Direct3dDevice(), monitor );
		if ( FAILED( hr )) throw PlaybackException("Failed to set d3dDevice to the surface allocator notify", "AllocatorPresenter::AdviseNotify", hr);
	}
	catch (exception& e)
	{
		// make sure hr is a fail
		if (SUCCEEDED(hr))
		{
			hr = E_FAIL;
		}
	}

	return hr;
}

HRESULT STDMETHODCALLTYPE AllocatorPresenter::StartPresenting( DWORD_PTR userId )
{
	CAutoLock lock(&_objectLock);

	HRESULT hr = E_FAIL;

	try
	{
		if( _environment->Direct3dDevice() == NULL )
		{
			hr = E_FAIL;
		}

		hr = S_OK;
	}
	catch (exception& e)
	{
		if (SUCCEEDED(hr))
		{
			hr = E_FAIL;
		}
	}

	return hr;
}

HRESULT STDMETHODCALLTYPE AllocatorPresenter::StopPresenting( DWORD_PTR userId )
{
	// no need to stop something.

	return S_OK;
}

HRESULT STDMETHODCALLTYPE AllocatorPresenter::PresentImage( DWORD_PTR userId, VMR9PresentationInfo *presInfo )
{
	HRESULT hr = E_FAIL;
	CAutoLock lock(&_objectLock);

	try
	{
		// if we are in the middle of the display change
		if( NeedToHandleDisplayChange() )
		{
			// Device lost. Reseting environment
			_environment->Reset();
		}
	
		hr = PresentHelper(presInfo);
	
		// Restore video memory after device lost while presenting
		if( hr == D3DERR_DEVICELOST)
		{
			if (_environment->Direct3dDevice()->TestCooperativeLevel() == D3DERR_DEVICENOTRESET)
			{
				DeleteSurfaces();
	
				_environment->Reset();
	
				HMONITOR monitor = _environment->Direct3d()->GetAdapterMonitor( _environment->Device()->DeviceId() );
	
				hr = _vmrSurfaceAllocatorNotify->ChangeD3DDevice(_environment->Direct3dDevice(), monitor );
				if ( FAILED( hr ))
				{
					throw PlaybackException("Could not change d3dDevice", "AllocatorPresenter::PresentImage", hr);
				}
			}
	
			hr = S_OK;
		}
	}
	catch (exception& e)
	{
		// make sure hr is fail
		if (SUCCEEDED(hr))
		{
			hr = E_FAIL;
		}
	}

	return hr;
}

HRESULT STDMETHODCALLTYPE AllocatorPresenter::QueryInterface( REFIID riid, void** object )
{
	HRESULT hr = E_NOINTERFACE;

	CAutoLock lock(&_objectLock);

	if( object == NULL )
	{
		hr = E_POINTER;
	} 
	else if( riid == IID_IVMRSurfaceAllocator9 )
	{
		*object = static_cast<IVMRSurfaceAllocator9*>( this );
		AddRef();
		hr = S_OK;
	} 
	else if( riid == IID_IVMRImagePresenter9 )
	{
		*object = static_cast<IVMRImagePresenter9*>( this );
		AddRef();
		hr = S_OK;
	} 
	else if( riid == IID_IUnknown )
	{
		*object =static_cast<IUnknown*>(static_cast<IVMRSurfaceAllocator9*>( this ) );
		AddRef();
		hr = S_OK;    
	}

	return hr;
}

ULONG STDMETHODCALLTYPE AllocatorPresenter::AddRef()
{
	return InterlockedIncrement(&_referenceCount);
}

ULONG STDMETHODCALLTYPE AllocatorPresenter::Release()
{
	ULONG ret = InterlockedDecrement(&_referenceCount);

	if( ret == 0 )
	{
		delete this;
	}

	return ret;
}

bool AllocatorPresenter::NeedToHandleDisplayChange()
{
	bool success = false;
	HRESULT hr = E_FAIL;

	try
	{
		if( ! _vmrSurfaceAllocatorNotify )
		{
			throw PlaybackException("surfaceAllocatorNotify is null","AllocatorPresenter::NeedToHandleDisplayChange");
		}
	
		D3DDEVICE_CREATION_PARAMETERS parameters;
		hr = _environment->Direct3dDevice()->GetCreationParameters(&parameters);
		if( FAILED(hr) ) throw PlaybackException("Could not get creating parameters for direct3d", "AllocatorPresenter::NeedToHandleDisplayChange");
	
		// Get the monitor in which allocator was created
		HMONITOR currentMonitor = _environment->Direct3d()->GetAdapterMonitor( parameters.AdapterOrdinal );
		
		HMONITOR monitor = _environment->Direct3d()->GetAdapterMonitor( _environment->Device()->DeviceId());
	
		success = monitor != currentMonitor;
	}
	catch (exception& e)
	{
		success = false;
	}

	return success;
}

HRESULT AllocatorPresenter::PresentHelper( VMR9PresentationInfo* presInfo )
{
	HRESULT hr = E_FAIL;

	try
	{
		// parameter validation
		if( presInfo == NULL )
		{
			hr = E_POINTER;
			throw PlaybackException(" presentationInfo is null", "AllocatorPresenter::PresentHelper");
		}
		else if( presInfo->lpSurf == NULL )
		{
			hr = E_POINTER;
			throw PlaybackException(" presentationInfo surface is null", "AllocatorPresenter::PresentHelper");
		}
	
		CAutoLock lock(&_objectLock);

		hr = _environment->Direct3dDevice()->SetRenderTarget( 0, _environment->RenderTarget() );
		if ( FAILED( hr )) throw PlaybackException("Failed to SetRenderTarget", "AllocatorPresenter::PresentHelper");
	
		// if a  private texture wasn't created
		// blt the decoded image onto the texture.
		if( _privateTexture != NULL )
		{   
			CComPtr<IDirect3DSurface9> surface;
			hr = _privateTexture->GetSurfaceLevel( 0 , &surface.p );
			if ( FAILED( hr )) throw PlaybackException("Failed to get surface", "AllocatorPresenter::PresentHelper");
	
			// copy the full surface onto the texture's surface
			hr = _environment->Direct3dDevice()->StretchRect( presInfo->lpSurf, NULL, surface, NULL, D3DTEXF_NONE );
			if ( FAILED( hr )) throw PlaybackException("Failed to copy the full surface onto the texture's surface", "AllocatorPresenter::PresentHelper");	
	
			hr = _scene.DrawScene(_environment->Direct3dDevice(), _privateTexture.p );
			if ( FAILED( hr )) throw PlaybackException("Failed to draw scene", "AllocatorPresenter::PresentHelper");
	
		}
		else // if textures are allocated by VMR all it is needed to do is to get them from the surface
		{
			// Get current frame
			CComPtr<IDirect3DTexture9> texture;
			hr = presInfo->lpSurf->GetContainer( __uuidof(IDirect3DTexture9), (LPVOID*) &(texture.p) );
			if ( FAILED( hr )) throw PlaybackException("Failed to get current frame texture from surface", "AllocatorPresenter::PresentHelper");
	
			// Draw the current frame.
			hr = _scene.DrawScene(_environment->Direct3dDevice(), texture );
	
	
			// Call addons
			list<AD3dVisibleAddon*> addons = StartUsingAddons();
			if (!addons.empty())
			{
				try
				{
					hr = _environment->Direct3dDevice()->BeginScene();
					if ( FAILED( hr )) throw PlaybackException("Failed BeginScene", "AllocatorPresenter::PresentHelper");

					// get display mode
					D3DDISPLAYMODE dispMode = {0};
					hr = _environment->Direct3dDevice()->GetDisplayMode(0, &dispMode);
					if ( FAILED( hr )) throw PlaybackException("Failed to get displayMode.", "AllocatorPresenter::PresentHelper", hr);

					// draw all addons
					for (list<AD3dVisibleAddon*>::iterator addonIter = addons.begin(); addonIter != addons.end(); addonIter++)
					{
						if ((*addonIter)->IsInitialized())
						{
							(*addonIter)->Draw(_sprite, dispMode.Width, dispMode.Height);
						}						
					}

					_environment->Direct3dDevice()->EndScene();
					if ( FAILED( hr )) throw PlaybackException("Failed EndScene", "AllocatorPresenter::PresentHelper");

				}
				catch (exception& e)
				{
					_environment->Direct3dDevice()->EndScene();
				}

			}
			StopUsingAddons();
		}
	
		hr = _environment->Direct3dDevice()->Present( NULL, NULL, NULL, NULL );
		if ( FAILED( hr )) throw PlaybackException("Failed to present", "AllocatorPresenter::PresentHelper");
	}
	catch (exception& e)
	{
		// make sure hr is fail
		if (SUCCEEDED(hr))
		{
			hr = E_FAIL;
		}
	}

	return hr;
}