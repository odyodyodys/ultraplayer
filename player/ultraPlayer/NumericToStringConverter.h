#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
#pragma endregion

using namespace std;

class NumericToStringConverter
{
#pragma region Constructors/Destructors
public:
	NumericToStringConverter()
	{
	
	}
	virtual ~NumericToStringConverter()
	{

	}
#pragma endregion

#pragma region Methods
public:
	// Description: Converts data from type1 to string in the desired base. Fills with zeros until desired string length
	template <class type1>
	static string Convert(type1 data, std::ios_base& (*base)(std::ios_base&), string::size_type stringLength = 0)
	{
		std::ostringstream stream;
		stream << base << data;
		
		string converted = stream.str();
		
		// add preceding zeros if needed
		if (stringLength > converted.length())
		{
			converted.insert(0, stringLength-converted.length(), '0');
		}
		
		return converted;
	}

	// Description: Converts from text to numeric type specified (type1) in the base specified
	template <class type1>
	static type1 Convert(const std::string& text, std::ios_base& (*base)(std::ios_base&) = std::dec)
	{
		type1 result;
		std::istringstream stream(text);
		stream >> base >> result;
		return result;
	}


#pragma endregion

};