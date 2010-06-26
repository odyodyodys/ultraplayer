#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AResponse.h"
#pragma endregion

class VolumeResponse:public AResponse
{
#pragma region Constructors/Destructors
public:
	VolumeResponse();
	virtual ~VolumeResponse();
#pragma endregion
};