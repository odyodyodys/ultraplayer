#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AResponse.h"
#include "MessageType.h"
#pragma endregion

class RemoveAddonResponse: public AResponse
{
#pragma region Constructors/Destructors
public:
	RemoveAddonResponse();
	virtual ~RemoveAddonResponse();
#pragma endregion
};