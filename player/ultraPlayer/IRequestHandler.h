#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "ARequest.h"
	#include "AResponse.h"
	#include "ResponseType.h"
#pragma endregion

__interface IRequestHandler
{
#pragma region Methods
public:
	// Description: Handles a ARequest message and responses with a AResponse message
	virtual AResponse* HandleRequest(ARequest* request);
#pragma endregion
};
