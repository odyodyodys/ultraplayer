#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AVisibleAddon.h"
#pragma endregion

class AD3dVisibleAddon abstract: public AVisibleAddon
{
#pragma region Constructors/Destructors
protected:
	AD3dVisibleAddon(UINT id, AddonType::Type type, VisibleLayout* const layout);
public:
	virtual ~AD3dVisibleAddon();
#pragma endregion

#pragma region AVisibleAddon members
public:
	virtual bool Initialize(APlayerEnvironment* environment)=0;
	virtual bool IsInitialized()=0;
	virtual bool Reinitialize()=0;
	virtual void Terminate()=0;
	virtual void Update(AAddon* updatedAddon)=0;
#pragma endregion

#pragma region Methods
public:
	// Description: Draws the content of the addon to the provided sprite. Drawing should be as fast as possible
	virtual HRESULT Draw(ID3DXSprite* sprite, UINT destinationWidth, UINT destinationHeight)=0;
#pragma endregion

};