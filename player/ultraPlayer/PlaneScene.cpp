#include "PlaneScene.h"

PlaneScene::PlaneScene(void)
{
	CAutoLock lock(&_objectLock);

	_trianglesCount = _verticesCount - 2;

	// set the fvf
	_fvf = D3DFVF_XYZ | D3DFVF_DIFFUSE | D3DFVF_TEX1;

	// Set the projection matrix
	_projectionMatrix = D3DXMATRIX( 2.0f,  0.0f,  0.0f,  0.0f,
									0.0f,  2.0f,  0.0f,  0.0f,
									0.0f,  0.0f,  1.0f,  1.0f,
									0.0f,  0.0f, -1.0f,  0.0f);

	// Set camera's positioning and look-at
	_cameraPoint = D3DXVECTOR3(0.0f, 0.0f, 2.0f);
	_cameraDirection = D3DXVECTOR3(0.0f, 0.0f, 0.0f);
	_worldsUp = D3DXVECTOR3( 0.0f, 1.0f, 0.0f );

	// Set the vertices
	_vertices[0]._position = Position3d(-1.0f,  1.0f, 0.0f); // top left
	_vertices[1]._position = Position3d(-1.0f, -1.0f, 0.0f); // bottom left
	_vertices[2]._position = Position3d( 1.0f,  1.0f, 0.0f); // top right
	_vertices[3]._position = Position3d( 1.0f, -1.0f, 0.0f); // bottom right

	// set up diffusion
	_vertices[0]._color = 0xffffffff;
	_vertices[1]._color = 0xffffffff;
	_vertices[2]._color = 0xffffffff;
	_vertices[3]._color = 0xffffffff;

	// set up texture coordinates
	_vertices[0]._textureU = 0.0f;
	_vertices[0]._textureV = 0.0f; // low left

	_vertices[1]._textureU = 0.0f;
	_vertices[1]._textureV = 1.0f; // low left

	_vertices[2]._textureU = 1.0f;
	_vertices[2]._textureV = 0.0f; // low left

	_vertices[3]._textureU = 1.0f;
	_vertices[3]._textureV = 1.0f; // low left
}

PlaneScene::~PlaneScene(void)
{
	CAutoLock lock(&_objectLock);
}

HRESULT PlaneScene::Initialize( IDirect3DDevice9* device )
{
	HRESULT hr = E_FAIL;

	try
	{
		if( ! device )
		{
			hr = E_POINTER;
			throw PlaybackException("NULL direct3dDevice","PlaneScene::Initialize");
		}

		CAutoLock lock(&_objectLock);
	
		// Do not cull back faces.
		hr = device->SetRenderState(D3DRS_CULLMODE, D3DCULL_NONE);
		if (FAILED(hr)) throw PlaybackException("Error while setting Cullmode","PlaneScene::Initialize", hr);
	
		// Do not enable lighting
		hr = device->SetRenderState(D3DRS_LIGHTING, FALSE);
		if (FAILED(hr)) throw PlaybackException("Error while setting lighting","PlaneScene::Initialize", hr);
	
		// Enable Alpha blending
		hr = device->SetRenderState(D3DRS_ALPHABLENDENABLE, TRUE);
		if (FAILED(hr)) throw PlaybackException("Error while setting Alpha blending","PlaneScene::Initialize", hr);
	
		// Set source blending mode
		hr = device->SetRenderState(D3DRS_SRCBLEND, D3DBLEND_SRCALPHA);
		if (FAILED(hr)) throw PlaybackException("Error while setting source blending mode","PlaneScene::Initialize", hr);
	
		// Set destination blending mode
		hr = device->SetRenderState(D3DRS_DESTBLEND, D3DBLEND_INVSRCALPHA);
		if (FAILED(hr)) throw PlaybackException("Error while setting destination blending mode","PlaneScene::Initialize", hr);
	
		// Enable per pixel alpha testing.
		hr = device->SetRenderState(D3DRS_ALPHATESTENABLE, TRUE);
		if (FAILED(hr)) throw PlaybackException("Error while setting per pixel alpha testing","PlaneScene::Initialize", hr);
	
		// Set per pixel alpha testing value
		hr = device->SetRenderState(D3DRS_ALPHAREF, 0x00);
		if (FAILED(hr)) throw PlaybackException("Error while setting per pixel alpha testing value","PlaneScene::Initialize", hr);
	
		// Accept per pixel alpha with alpha value greater than the testing value (see exact above call)
		hr = device->SetRenderState(D3DRS_ALPHAFUNC, D3DCMP_GREATER);
		if (FAILED(hr)) throw PlaybackException("Error while setting per pixel alpha accept value","PlaneScene::Initialize", hr);

		// Set texture sampling
		hr = device->SetSamplerState(0, D3DSAMP_ADDRESSU, D3DTADDRESS_CLAMP);
		if (FAILED(hr)) throw PlaybackException("Error while setting D3DSAMP_ADDRESSU","PlaneScene::Initialize", hr);
		hr = device->SetSamplerState(0, D3DSAMP_ADDRESSV, D3DTADDRESS_CLAMP);
		if (FAILED(hr)) throw PlaybackException("Error while setting D3DSAMP_ADDRESSV","PlaneScene::Initialize", hr);
		hr = device->SetSamplerState(0, D3DSAMP_MAGFILTER, D3DTEXF_LINEAR);
		if (FAILED(hr)) throw PlaybackException("Error while setting D3DSAMP_MAGFILTER","PlaneScene::Initialize", hr);
		hr = device->SetSamplerState(0, D3DSAMP_MINFILTER, D3DTEXF_LINEAR);
		if (FAILED(hr)) throw PlaybackException("Error while setting D3DSAMP_MINFILTER","PlaneScene::Initialize", hr);
		hr = device->SetSamplerState(0, D3DSAMP_MIPFILTER, D3DTEXF_LINEAR);
		if (FAILED(hr)) throw PlaybackException("Error while setting D3DSAMP_MIPFILTER","PlaneScene::Initialize", hr);
	
		// Initiate the vertex buffer.
		_vertexBuffer.Attach(NULL);
		hr = device->CreateVertexBuffer(sizeof(_vertices), D3DUSAGE_WRITEONLY, _fvf , D3DPOOL_MANAGED, &_vertexBuffer, NULL );
		if (FAILED(hr)) throw PlaybackException("Error while creating vertex buffer","PlaneScene::Initialize", hr);

		// Get the back buffer
		CComPtr<IDirect3DSurface9> backBuffer;
		hr = device->GetBackBuffer( 0, 0, D3DBACKBUFFER_TYPE_MONO, & backBuffer.p);
		if (FAILED(hr)) throw PlaybackException("Error while setting the back buffer","PlaneScene::Initialize", hr);
	
		// Get details about the back buffer surface
		D3DSURFACE_DESC backBufferDesc;
		hr = backBuffer->GetDesc( &backBufferDesc );
		if (FAILED(hr)) throw PlaybackException("Error while getting back buffer info","PlaneScene::Initialize", hr);
	
		// Transform the device according to the created transformation matrix
		hr = device->SetTransform( D3DTS_PROJECTION, &_projectionMatrix);
		if (FAILED(hr)) throw PlaybackException("Error while setting projection matrix","PlaneScene::Initialize", hr);

		// Build a left-handed, look-at matrix
		D3DXMATRIX matrixView;
		D3DXMatrixLookAtLH( &matrixView, &_cameraPoint, &_cameraDirection, &_worldsUp);
	
		hr = device->SetTransform( D3DTS_VIEW, &matrixView );
		if (FAILED(hr)) throw PlaybackException("Error while setting view matrix","PlaneScene::Initialize", hr);
	}
	catch (exception& e)
	{
		// TODO log error

		hr = E_FAIL;
	}

	return hr;
}

void PlaneScene::SourceRect( float width, float height )
{
	CAutoLock lock(&_objectLock);

	// low left
	_vertices[0]._textureU = 0.0f;
	_vertices[0]._textureV = 0.0f;

	// high left
	_vertices[1]._textureU = 0.0f;
	_vertices[1]._textureV = height;

	// low right
	_vertices[2]._textureU = width;
	_vertices[2]._textureV = 0.0f;

	// high right
	_vertices[3]._textureU = width;
	_vertices[3]._textureV = height;
}

HRESULT PlaneScene::DrawScene( IDirect3DDevice9* device, IDirect3DTexture9* texture )
{
	HRESULT hr = E_FAIL;

	try
	{
		CAutoLock lock(&_objectLock);

		if( !( device && texture ) )
		{
			hr = E_POINTER;
			throw PlaybackException("Either Device or Texture was null","PlaneScene::DrawScene");
		}
	
		if( _vertexBuffer.p == NULL )
		{
			hr = D3DERR_INVALIDCALL;
			throw PlaybackException("Vertex buffer was null.","PlaneScene::DrawScene");
		}

		// write the new vertex information into the buffer
		void* pointerToWriteVertices;
		hr = _vertexBuffer->Lock(0, 0, &pointerToWriteVertices, 0);
		if ( FAILED( hr )) throw PlaybackException("Failed to lock vertex buffer.","PlaneScene::DrawScene", hr);
		memcpy(pointerToWriteVertices, _vertices, sizeof(_vertices)); 
		hr = _vertexBuffer->Unlock();
		if ( FAILED( hr )) throw PlaybackException("Failed to unlock vertex buffer.","PlaneScene::DrawScene", hr);


		// clear the scene so there are no artifacts left
		hr = device->Clear( 0L, NULL, D3DCLEAR_TARGET, D3DCOLOR_XRGB(0, 0, 0), 1.0f, 0L );
		if ( FAILED( hr )) throw PlaybackException("Failed to clear surface.","PlaneScene::DrawScene", hr);
	
		hr = device->BeginScene();
		if ( FAILED( hr )) throw PlaybackException("Failed to BeginScene.","PlaneScene::DrawScene", hr);
		hr = device->SetTexture( 0, texture);
		if ( FAILED( hr )) throw PlaybackException("Failed to set texture on the device","PlaneScene::DrawScene", hr);
		hr = device->SetTextureStageState(0, D3DTSS_ALPHAOP, D3DTOP_MODULATE);
		if ( FAILED( hr )) throw PlaybackException("Failed to set texture stage: D3DTSS_ALPHAOP, D3DTOP_MODULATE","PlaneScene::DrawScene", hr);
		hr = device->SetTextureStageState(0, D3DTSS_ALPHAARG1, D3DTA_TEXTURE);
		if ( FAILED( hr )) throw PlaybackException("Failed to set texture stage: D3DTSS_ALPHAARG1, D3DTA_TEXTURE","PlaneScene::DrawScene", hr);
		hr = device->SetTextureStageState(0, D3DTSS_ALPHAARG2, D3DTA_DIFFUSE);
		if ( FAILED( hr )) throw PlaybackException("Failed to set texture stage: D3DTSS_ALPHAARG2, D3DTA_DIFFUSE","PlaneScene::DrawScene", hr);
		hr = hr = device->SetTextureStageState(0, D3DTSS_COLORARG1, D3DTA_TEXTURE);
		if ( FAILED( hr )) throw PlaybackException("Failed to set texture stage: D3DTSS_COLORARG1, D3DTA_TEXTURE","PlaneScene::DrawScene", hr);
		hr = device->SetFVF( _fvf );
		if ( FAILED( hr )) throw PlaybackException("Failed to set FVF.","PlaneScene::DrawScene", hr);
		hr = device->SetStreamSource(0, _vertexBuffer, 0, sizeof(CustomVertex) );
		if ( FAILED( hr )) throw PlaybackException("Failed to set StreamSource to the device.","PlaneScene::DrawScene", hr);

		//draw quad 
		hr = device->DrawPrimitive(D3DPT_TRIANGLESTRIP, 0, _trianglesCount); 
		if ( FAILED( hr )) throw PlaybackException("Failed to draw primitive.","PlaneScene::DrawScene", hr);
	
		// Remove the texture from the device
		hr = device->SetTexture( 0, NULL);
		if ( FAILED( hr )) throw PlaybackException("Failed to remove Texture from the device.","PlaneScene::DrawScene", hr);

		hr = device->EndScene();
		if ( FAILED( hr )) throw PlaybackException("Failed to end scene.","PlaneScene::DrawScene", hr);
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