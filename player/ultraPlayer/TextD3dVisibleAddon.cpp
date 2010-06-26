#include "TextD3dVisibleAddon.h"

TextD3dVisibleAddon::TextD3dVisibleAddon(UINT id, VisibleLayout* const layout, string text):AD3dVisibleAddon(id, AddonType::D3dText, layout)
{
	_text = text;
	_textColor = D3DCOLOR_ARGB(_layout->Alpha(), 255, 255, 255);

	_fontHeight = 0;
	_fontWidth = 0;
	_fontWeight= FW_DONTCARE;
	_fontItalics= false;
	_fontCharset= DEFAULT_CHARSET;
	_fontName = "Arial";
}

TextD3dVisibleAddon::~TextD3dVisibleAddon(void)
{
	CAutoLock lock(&_objectLock);

}

bool TextD3dVisibleAddon::Initialize(APlayerEnvironment* environment)
{
	CAutoLock lock(&_objectLock);

	bool success = true;
	try
	{
		success &= InitializeFont(((Direct3dVmr9DshowPlayerEnvironment*)environment)->Device()->MonitorLayout()->Height(), ((Direct3dVmr9DshowPlayerEnvironment*)environment)->Direct3dDevice());
	}
	catch (exception& e)
	{
		success = false;
	}
	return success;
}

bool TextD3dVisibleAddon::IsInitialized()
{
	bool success = true;
	try
	{
		CAutoLock lock(&_objectLock);

		success &= _font != NULL;
		success &= !_text.empty();
	}
	catch (exception& e)
	{
		success = false;
	}
	return success;
	
}

bool TextD3dVisibleAddon::Reinitialize()
{
	CAutoLock lock(&_objectLock);

	throw NotImplementedException("TextD3dVisibleAddon::Reinitialize","");
}

void TextD3dVisibleAddon::Terminate()
{
	CAutoLock lock(&_objectLock);

	throw NotImplementedException("TextD3dVisibleAddon::Terminate","");
}

HRESULT TextD3dVisibleAddon::Draw(ID3DXSprite* sprite, UINT destinationWidth, UINT destinationHeight )
{
	HRESULT hr = E_FAIL;

	try
	{
		CAutoLock lock(&_objectLock);

		// validate addon
		if ( !sprite) throw InvalidArgumentException("sprite","TextD3dVisibleAddon::Draw");
		if (!IsInitialized()) throw PlaybackException("Addon not initialized","TextD3dVisibleAddon::Draw");

		hr = sprite->Begin(D3DXSPRITE_ALPHABLEND);

		// calculate the dimensions of the new text.
		RECT drawnRect = {0};
		drawnRect.top    = destinationHeight*(_layout->Y()/1000.0f);
		drawnRect.bottom = destinationHeight*((_layout->Y() + _layout->Height())/1000.f);
		drawnRect.left   = destinationWidth*(_layout->X()/1000.0f);
		drawnRect.right  = destinationWidth*((_layout->X() + _layout->Width())/1000.f);

		USES_CONVERSION;
		hr = _font->DrawText(NULL, A2W(_text.c_str()), -1, &drawnRect, DT_CENTER | DT_VCENTER, _textColor);

		hr = sprite->End();
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

void TextD3dVisibleAddon::Update( AAddon* updatedAddon )
{
	CAutoLock lock(&_objectLock);

	try
	{
		//verify addon type
		if (updatedAddon->Type() != _type)
		{
			throw InvalidArgumentException("updatedAddon->Type", "TextD3dVisibleAddon::Update");
		}
	
		// copy layout
		AVisibleAddon::Layout(((TextD3dVisibleAddon*)updatedAddon)->Layout());

		_textColor = D3DCOLOR_ARGB(AVisibleAddon::Layout()->Alpha(), 255, 255 , 255);
	
		// update text
		_text = ((TextD3dVisibleAddon*)updatedAddon)->Text();

		CComPtr<IDirect3DDevice9> device;
		_font->GetDevice(&device);
		InitializeFont(_fontHeight*15, device);
	
	}
	catch (exception& e)
	{
		
	}
}

std::string TextD3dVisibleAddon::Text()
{
	CAutoLock lock(&_objectLock);

	return _text;
}

void TextD3dVisibleAddon::Text( string newText )
{
	CAutoLock lock(&_objectLock);

	_text = newText;
}

bool TextD3dVisibleAddon::InitializeFont( int monitorHeight, IDirect3DDevice9* device )
{
	bool success = false;

	try
	{
		// release previous font
		if (_font)
		{
			_font.Attach(NULL);
		}

		HRESULT hr = E_FAIL;

		_fontHeight = monitorHeight/15.0f;
		_fontWidth = 0;
		_fontWeight = FW_DONTCARE;
		_fontItalics = false;
		_fontCharset = DEFAULT_CHARSET;
		_fontName = "Arial";

		USES_CONVERSION;
		hr = D3DXCreateFont(device, _fontHeight , _fontWidth, _fontWeight, 0, _fontItalics, _fontCharset, OUT_DEFAULT_PRECIS, CLEARTYPE_NATURAL_QUALITY, DEFAULT_PITCH | FF_DONTCARE, A2W(_fontName.c_str()), &_font);
		if (FAILED(hr)) throw InitializationFailedException("Could not create font", "TextD3dVisibleAddon::Initialize", hr);

		success = true;
	}
	catch (exception& e)
	{
		success = false;
	}

	return success;
}