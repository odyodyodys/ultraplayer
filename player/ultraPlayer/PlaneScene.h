#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "CustomVertex.h"

#include "PlaybackException.h"
#pragma endregion

class PlaneScene
{
#pragma region Fields
private:

	DWORD _fvf; // Direct3D Custom Flexible Vertex Format

	UINT _trianglesCount;

	D3DXMATRIX	_projectionMatrix;

	D3DXVECTOR3 _cameraPoint;
	D3DXVECTOR3 _cameraDirection;
	D3DXVECTOR3 _worldsUp;

	static const int _verticesCount = 4;
	CustomVertex _vertices[_verticesCount];

	CComPtr<IDirect3DVertexBuffer9> _vertexBuffer;

	CCritSec _objectLock;
#pragma endregion

#pragma region Constructors/Destructors
public:
	PlaneScene();
	virtual ~PlaneScene();
#pragma endregion

#pragma region Methods
public:
	// Description: Initializes the scene, sets the parameters and builds the world
	HRESULT Initialize( IDirect3DDevice9* device );

	// Description: Draws a texture on the world
	HRESULT DrawScene( IDirect3DDevice9* device, IDirect3DTexture9* texture );

	// Description: Sets the UV mapping of the texture
	void SourceRect( float width, float height );
#pragma endregion

};