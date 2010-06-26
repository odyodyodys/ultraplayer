#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
	#include "IStringParser.h"
	#include "NumericToStringConverter.h"
	#include "CommunicationProtocol.h"

	#include "NotImplementedException.h"
	#include "ParserException.h"
#pragma endregion

class Layout: public IStringParser
{
#pragma region Fields
private:
	short int _x;
	short int _y;
	short int _width;
	short int _height;
#pragma endregion

#pragma region Constructors/Destructors
public:
	Layout();
	virtual ~Layout();
#pragma endregion

#pragma region IStringParser members
public:
	virtual void FromString(string data);
	virtual string ToString();
#pragma endregion

#pragma region Properties
public:
	short int X();
	void X(short int val);
	short int Y();
	void Y(short int val);
	short int Width();
	void Width(short int val);
	short int Height();
	void Height(short int val);
#pragma endregion

};