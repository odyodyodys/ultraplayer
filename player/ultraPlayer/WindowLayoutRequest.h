#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "ARequest.h"
	#include "Layout.h"
	#include "MessageType.h"

	#include "NotImplementedException.h"
#pragma endregion

class WindowLayoutRequest: public ARequest
{

	friend class RequestFactory;

#pragma region Fields
private:
	UINT _monitorNumber;
	Layout* _layout;
#pragma endregion

#pragma region Constructors/Destructors
private:
	WindowLayoutRequest();
public:
	virtual ~WindowLayoutRequest();
#pragma endregion

#pragma region ARequest members
public:
	virtual void FromString(string data);

#pragma endregion

#pragma region Properties
public:
	Layout* GetLayout();
	UINT MonitorNumber();
#pragma endregion

};