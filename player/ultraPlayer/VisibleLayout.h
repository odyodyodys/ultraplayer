#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "NumericToStringConverter.h"
	#include "CommunicationProtocol.h"
	#include "Layout.h"

	#include "NotImplementedException.h"
	#include "ParserException.h"
#pragma endregion

using namespace std;

class VisibleLayout: public Layout
{
#pragma region Fields
private:
	short int _alpha;
#pragma endregion

#pragma region Constructors/Destructors
public:
	VisibleLayout();
	virtual ~VisibleLayout();
#pragma endregion

#pragma region Properties
public:
	short int Alpha();
	void Alpha(short int val);
#pragma endregion

#pragma region Layout members
public:
	virtual void FromString(string data);
	virtual string ToString();
#pragma endregion
};