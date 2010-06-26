#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AResponse.h"
#pragma endregion

class SetMidiOutputPortResponse:public AResponse
{
#pragma region Constructors/Destructors
public:
	SetMidiOutputPortResponse();
	virtual ~SetMidiOutputPortResponse();
#pragma endregion
};