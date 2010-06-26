#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AddonType.h"
#include "APlayerEnvironment.h"
#pragma endregion

class AAddon abstract
{
#pragma region Fields
protected:
	CCritSec _objectLock;
	UINT _id;
	AddonType::Type _type;
#pragma endregion

#pragma region Constructors/Destructors
protected:
	AAddon(UINT id, AddonType::Type type);
public:
	virtual ~AAddon();
#pragma endregion

#pragma region Methods
public:
	// Description: Initializes an addon
	virtual bool Initialize(APlayerEnvironment* environment)=0;
	
	// Description: Returns true if addon is initialized
	virtual bool IsInitialized()=0;
	
	// Description: Reinitializes the addon after emvironment changes
	virtual bool Reinitialize()=0;
	
	// Description: Terminates the addon and releases any resources used
	virtual void Terminate()=0;

	// Description: Updates self based on updated addon.
	virtual void Update(AAddon* updatedAddon)=0;

#pragma endregion

#pragma region Properties
public:
	UINT Id();
	AddonType::Type Type();
#pragma endregion

};