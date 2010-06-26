#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AD3dVisibleAddon.h"
#include "Direct3dVmr9DshowPlayerEnvironment.h"

#include "NotImplementedException.h"
#include "InvalidArgumentException.h"
#include "PlaybackException.h"
#pragma endregion

class ImageD3dVisibleAddon: public AD3dVisibleAddon
{
#pragma region Fields
private:
	string _filename;
	CComPtr<IDirect3DTexture9> _imageTexture;
#pragma endregion

#pragma region Constructors/Destructors
public:
	ImageD3dVisibleAddon(UINT id, VisibleLayout* const layout, string filename);
	virtual ~ImageD3dVisibleAddon();
#pragma endregion

#pragma region AD3dVisibleAddon members
public:
	// Description: Initializes addon. Creates a 3d surface base on the provided image.
	virtual bool Initialize(APlayerEnvironment* environment);

	// Description: Returns true if addon is initialized
	virtual bool IsInitialized();

	// Description: Cleans up and reinitializes addon
	virtual bool Reinitialize();

	// Description: Terminates addon usage
	virtual void Terminate();

	// Description: Updates self.
	virtual void Update(AAddon* updatedAddon);

	// Description: Draws the texture loaded using sprite
	// Steps:
	// 	1. Calculates scaling
	// 	2. Calculates translation
	// 	3. Computes transformation
	// 	4. Draws texture
	virtual HRESULT Draw(ID3DXSprite* sprite, UINT destinationWidth, UINT destinationHeight);
#pragma endregion

#pragma region Properties
public:
	string Filename();
#pragma endregion
};