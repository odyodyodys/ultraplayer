#include "PhaseToStringConverter.h"

PhaseToStringConverter::PhaseToStringConverter(void)
{
}

PhaseToStringConverter::~PhaseToStringConverter(void)
{
}

std::string PhaseToStringConverter::Convert( PhaseType::Type data )
{
	throw NotImplementedException("","PhaseToStringConverter::Convert");
}

PhaseType::Type PhaseToStringConverter::Convert( string data )
{
	PhaseType::Type type;

	// convert it to number
	int degrees = NumericToStringConverter::Convert<int>(data);

	try
	{
		if (degrees == -180)
		{
			type = PhaseType::Minus180;
		}
		else if (degrees == -90)
		{
			type = PhaseType::Minus90;
		}
		else if (degrees == 0)
		{
			type = PhaseType::Zero;
		}
		else if (degrees == 90)
		{
			type = PhaseType::Plus90;
		}
		else if (degrees == 180)
		{
			type = PhaseType::Plus180;
		}
		else
		{
			throw ConverterException("unsupported degrees","PhaseToStringConverter::Convert");
		}
	}
	catch (exception& e)
	{
		throw;
	}

	return type;
}