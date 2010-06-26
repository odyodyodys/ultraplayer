#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "AResponse.h"
#pragma endregion

class SetDlsResponse:public AResponse
{
#pragma region Constructors/Destructors
public:
	SetDlsResponse();
	virtual ~SetDlsResponse();
#pragma endregion
};