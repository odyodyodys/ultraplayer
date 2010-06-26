#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "PlayerType.h"
#include "IConverter.h"

#include "ConverterException.h"
#include "NotImplementedException.h"
#pragma endregion

using namespace std;

class PlayerTypeToStringConverter: public IConverter<PlayerType::Type, string>
{
#pragma region Fields
private:
	static PlayerTypeToStringConverter* _instance;
#pragma endregion

#pragma region Constructors/Destructors
public:
	PlayerTypeToStringConverter();
	~PlayerTypeToStringConverter();
#pragma endregion

#pragma region Methods
public:
	static PlayerTypeToStringConverter* Instance();
#pragma endregion

#pragma region IConverter members
public:
    PlayerType::Type Convert(string data);
    string Convert(PlayerType::Type data);	
#pragma endregion
};
