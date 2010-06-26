#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AD3dVisibleAddon.h"
#include "Direct3dVmr9DshowPlayerEnvironment.h"
#include "Layout.h"

#include "InvalidArgumentException.h"
#include "PlaybackException.h"
#include "NotImplementedException.h"
#pragma endregion

class TextD3dVisibleAddon: public AD3dVisibleAddon
{
#pragma region Fields
private:
	string _text;
	CComPtr<ID3DXFont> _font;
	D3DCOLOR _textColor;

	int _fontHeight;
	int _fontWidth;
	UINT _fontWeight;
	bool _fontItalics;
	DWORD _fontCharset;
	string _fontName;

#pragma endregion

#pragma region Constructors/Destructors
public:
	TextD3dVisibleAddon(UINT id, VisibleLayout* const layout, string text);
	virtual ~TextD3dVisibleAddon();
#pragma endregion

#pragma region AD3dVisibleAddon members
public:
	// Description: Initializes the addon.
	virtual bool Initialize(APlayerEnvironment* environment);

	// Description: Returns true if initialized
	virtual bool IsInitialized();

	// Description: Cleans up and initializes addon
	virtual bool Reinitialize();

	// Description: Terminates addon usage
	virtual void Terminate();

	// Description: Updates self
	virtual void Update(AAddon* updatedAddon);

	// Description: Draws text
	// Steps:
	// 	1. Calculates dimensions of new Text
	// 	2. Draws text
	virtual HRESULT Draw(ID3DXSprite* sprite, UINT destinationWidth, UINT destinationHeight);
#pragma endregion

#pragma region Methods
private:
	// Description: Initializes ID3DXFont object for the device
	bool InitializeFont(int monitorHeight, IDirect3DDevice9* device);
#pragma endregion

#pragma region Properties
public:
	string Text();
	void Text(string newText);
#pragma endregion

};