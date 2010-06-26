#include "MidiPropertiesRequest.h"

MidiPropertiesRequest::MidiPropertiesRequest(void):ARequest(MessageType::MidiProperties)
{
}

MidiPropertiesRequest::~MidiPropertiesRequest(void)
{
}

void MidiPropertiesRequest::FromString( string data )
{
	try
	{
		int paramLength = CommunicationProtocol::Instance()->LongNumericParameterLength();
		int index = CommunicationProtocol::Instance()->HeaderLength();

		if (data.substr(index, 1) == "1")
		{
			_enableReverb = true;
		}
		else if (data.substr(index, 1) == "0")
		{
			_enableReverb = false;
		}
		else
		{
			throw ParserException("reverb param:" + data.substr(index, 1), "MidiPropertiesRequest::FromString");
		}

		index++;
		if (data.substr(index, 1) == "1")
		{
			_enableChorus = true;
		}
		else if (data.substr(index, 1) == "0")
		{
			_enableChorus = false;
		}
		else
		{
			throw ParserException("chorus param:" + data.substr(index, 1), "MidiPropertiesRequest::FromString");
		}


		index++;
		_tempo = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
	}
	catch (exception& e)
	{

	}
}

bool MidiPropertiesRequest::EnableReverb()
{
	return _enableReverb;
}

bool MidiPropertiesRequest::EnableChorus()
{
	return _enableChorus;
}

float MidiPropertiesRequest::Tempo()
{
	return _tempo;
}