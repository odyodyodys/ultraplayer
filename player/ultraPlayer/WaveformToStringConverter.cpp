#include "WaveformToStringConverter.h"

WaveformToStringConverter::WaveformToStringConverter(void)
{
}

WaveformToStringConverter::~WaveformToStringConverter(void)
{
}

std::string WaveformToStringConverter::Convert( WaveformType::Type data )
{
	throw NotImplementedException("", "WaveformToStringConverter::Convert");
}

WaveformType::Type WaveformToStringConverter::Convert( string data )
{
	WaveformType::Type type;

	// convert it to number
	int degrees = NumericToStringConverter::Convert<int>(data);

	try
	{
		if (data == CommunicationProtocol::Instance()->SineWaveformParameter())
		{
			type = WaveformType::Sine;
		}
		else if (data == CommunicationProtocol::Instance()->SquareWaveformParameter())
		{
			type = WaveformType::Square;
		}
		else if (data == CommunicationProtocol::Instance()->TriangleWaveformParameter())
		{
			type = WaveformType::Triangle;
		}
		else
		{
			throw ConverterException("unsupported waveform","WaveformToStringConverter::Convert");
		}
	}
	catch (exception& e)
	{
		throw;
	}

	return type;
}