#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "ARequest.h"
	#include "MessageType.h"
	#include "VisibleObject.h"

	#include "NotImplementedException.h"
#pragma endregion

class SetImageRequest: public ARequest
{
	friend class RequestFactory;

#pragma region Fields
private:
	VisibleObject* _objectProperties;
	string _filename;
#pragma endregion

#pragma region Constructors/Destructors
private:
	SetImageRequest();
public:
	virtual ~SetImageRequest();
#pragma endregion

#pragma region ARequest members
public:
	virtual void FromString(string data);

#pragma endregion

#pragma region Properties
public:
	VisibleObject* ObjectProperties();
	string Filename();
#pragma endregion
};