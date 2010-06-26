#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "MessageType.h"
	#include "AMessage.h"

	#include "NotImplementedException.h"
#pragma endregion

using namespace std;

class ARequest abstract: public AMessage
{

#pragma region Constructors/Destructors
protected:
	ARequest(MessageType::Type messageType);
public:
	virtual ~ARequest();
#pragma endregion

#pragma region AMessage Methods
public:
	virtual void FromString(string data)=0;
	virtual string ToString();
#pragma endregion
};