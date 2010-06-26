#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AAddon.h"
#include "VisibleLayout.h"
#pragma endregion

class AVisibleAddon abstract: public AAddon
{
#pragma region Fields
protected:
	VisibleLayout* _layout;
#pragma endregion

#pragma region Constructors/Destructors
protected:
	AVisibleAddon(UINT id, AddonType::Type type, VisibleLayout* const layout);
public:
	virtual ~AVisibleAddon();
#pragma endregion

#pragma region AAddon members
public:
	virtual bool Initialize(APlayerEnvironment* environment)=0;
	virtual bool IsInitialized()=0;
	virtual bool Reinitialize()=0;
	virtual void Terminate()=0;
	virtual void Update(AAddon* updatedAddon)=0;
#pragma endregion

#pragma region Properties
public:
	VisibleLayout* Layout();
	void Layout(VisibleLayout* newLayout);
#pragma endregion

};