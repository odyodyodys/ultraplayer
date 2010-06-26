#include "ImageD3dVisibleAddon.h"

ImageD3dVisibleAddon::ImageD3dVisibleAddon(UINT id, VisibleLayout* const layout, string filename):AD3dVisibleAddon(id, AddonType::D3dImage, layout)
{
	_filename = filename;
}

ImageD3dVisibleAddon::~ImageD3dVisibleAddon(void)
{

}

bool ImageD3dVisibleAddon::Initialize(APlayerEnvironment* environment)
{
	bool success = false;
	try
	{
		CAutoLock lock(&_objectLock);

		USES_CONVERSION;
		HRESULT hr = D3DXCreateTextureFromFile(((Direct3dVmr9DshowPlayerEnvironment*)environment)->Direct3dDevice(), A2W(_filename.c_str()), &_imageTexture);
		if (FAILED(hr)) throw InitializationFailedException("Could not create texture", "ImageD3dVisibleAddon::Initialize", hr);

		success = true;
	}
	catch (exception& e)
	{
		success = false;
	}
	return success;
}

bool ImageD3dVisibleAddon::IsInitialized()
{
	bool success = true;
	try
	{
		CAutoLock lock(&_objectLock);

		success &= !_filename.empty();
		success &= _imageTexture != NULL;
	}
	catch (exception& e)
	{
		success = false;
	}
	return success;
}

bool ImageD3dVisibleAddon::Reinitialize()
{
	CAutoLock lock(&_objectLock);

	throw NotImplementedException("ImageD3dVisibleAddon::Reinitialize","");
}

void ImageD3dVisibleAddon::Terminate()
{
	CAutoLock lock(&_objectLock);

	// nothing to do
}

HRESULT ImageD3dVisibleAddon::Draw( ID3DXSprite* sprite, UINT destinationWidth, UINT destinationHeight )
{
	HRESULT hr = E_FAIL;

	try
	{
		CAutoLock lock(&_objectLock);

		// validate addon
		if ( !sprite) throw InvalidArgumentException("sprite","ImageD3dVisibleAddon::Draw");
		if (!IsInitialized()) throw PlaybackException("Addon not initialized","ImageD3dVisibleAddon::Draw");

		hr = sprite->Begin(D3DXSPRITE_ALPHABLEND);

		// Calculate Scaling
		D3DSURFACE_DESC imageTextureDescription;
		hr = _imageTexture->GetLevelDesc(0, &imageTextureDescription);
		if (FAILED(hr)) throw PlaybackException("Could not get image texture description.", "ImageD3dVisibleAddon::Draw", hr);

		float widthScaleFactor = (float)(0.001f*(_layout->Width())* destinationWidth/imageTextureDescription.Width);
		float heightScaleFactor = (float)(0.001f*(_layout->Height())* destinationHeight/imageTextureDescription.Height);
		
		D3DXMATRIX imageStretchMatrix;
		D3DXMatrixScaling(&imageStretchMatrix, widthScaleFactor, heightScaleFactor, 0);

		// Calculate translation
		D3DXMATRIX imageTranslationMatrix;

		float originXTranslateFactor = destinationWidth*(_layout->X()/1000.0f);
		float originYTranslateFactor = destinationHeight*(_layout->Y()/1000.0f);

		D3DXMatrixTranslation(&imageTranslationMatrix,originXTranslateFactor, originYTranslateFactor,0);

		// Calculate the whole transformation.
		// Important note: Changing the order of the last two arguments results in different transformation.
		D3DXMATRIX completeTransformation;
		D3DXMatrixMultiply(&completeTransformation, &imageStretchMatrix, &imageTranslationMatrix);
	
		// Set the transformation
		hr = sprite->SetTransform(&completeTransformation);
		if (FAILED(hr)) throw PlaybackException("Failed to set transformation on sprite", "ImageD3dVisibleAddon::Draw", hr);

		RECT sourceRect = {0};
		sourceRect.bottom = imageTextureDescription.Height;
		sourceRect.right = imageTextureDescription.Width;

		// Draw the texture	
		hr = sprite->Draw(_imageTexture, &sourceRect, NULL, NULL,  D3DCOLOR_ARGB(_layout->Alpha(), 255, 255, 255));
		if (FAILED(hr)) throw PlaybackException("Could not draw", "ImageD3dVisibleAddon::Draw",  hr);

		// Drawingn is done.
		hr = sprite->End();
		if (FAILED(hr)) throw PlaybackException("Could not end drawing", "ImageD3dVisibleAddon::Draw",  hr);
	
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

void ImageD3dVisibleAddon::Update( AAddon* updatedAddon )
{
	try
	{
		CAutoLock lock(&_objectLock);

		//verify addon type
		if (updatedAddon->Type() != _type)
		{
			throw InvalidArgumentException("updatedAddon->Type", "ImageD3dVisibleAddon::Update");
		}

		// get device
		CComPtr<IDirect3DDevice9> device;
		_imageTexture->GetDevice(&device);

		// release texture
		_imageTexture.Attach(NULL);

		// update filename
		_filename = ((ImageD3dVisibleAddon*)updatedAddon)->Filename();

		// copy layout
		AVisibleAddon::Layout(((ImageD3dVisibleAddon*)updatedAddon)->Layout());

		USES_CONVERSION;
		HRESULT hr = D3DXCreateTextureFromFile(device, A2W(_filename.c_str()), &_imageTexture);
		if (FAILED(hr)) throw InitializationFailedException("Could not create texture", "ImageD3dVisibleAddon::Initialize", hr);

	}
	catch (exception& e)
	{
		
	}
}

std::string ImageD3dVisibleAddon::Filename()
{
	CAutoLock lock(&_objectLock);

	return _filename;
}