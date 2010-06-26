#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "VisibleLayout.h"
#pragma endregion

// describes a unique visible object
class VisibleObject
{
#pragma region Fields
private:
	UINT _id;
	VisibleLayout* _layout;
#pragma endregion

#pragma region Constructors/Destructors
public:
	VisibleObject();
	virtual ~VisibleObject();
#pragma endregion

#pragma region VisibleLayout members
public:
	virtual void FromString(string data);
	virtual string ToString();
#pragma endregion

#pragma region Properties
public:
	void Id(UINT id);
	UINT Id();
	VisibleLayout* Layout();
	void Layout(VisibleLayout* layout);
#pragma endregion

};