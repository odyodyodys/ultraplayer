#include "ChorusSoundFx.h"

ChorusSoundFx::ChorusSoundFx(void):ASoundFx(SoundFxType::Chorus)
{
	_wetDryMix = 0;
	_delay = 0;
	_depth = 0;
	_feedback = 0;
	_frequency = 0;
	_waveform = WaveformType::Sine;
	_phase = PhaseType::Plus90;
}

ChorusSoundFx::~ChorusSoundFx(void)
{
}

float ChorusSoundFx::WetDryMix()
{
	return _wetDryMix;
}

void ChorusSoundFx::WetDryMix( float val )
{
	_wetDryMix = val;
}

float ChorusSoundFx::Depth()
{
	return _depth;
}

void ChorusSoundFx::Depth( float val )
{
	_depth = val;
}

float ChorusSoundFx::Feedback()
{
	return _feedback;
}

void ChorusSoundFx::Feedback( float val )
{
	_feedback = val;
}

float ChorusSoundFx::Frequency()
{
	return _frequency;
}

void ChorusSoundFx::Frequency( float val )
{
	_frequency = val;
}

float ChorusSoundFx::Delay()
{
	return _delay;
}

void ChorusSoundFx::Delay( float val )
{
	_delay = val;
}

PhaseType::Type ChorusSoundFx::Phase()
{
	return _phase;
}

void ChorusSoundFx::Phase( PhaseType::Type val )
{
	_phase = val;
}

WaveformType::Type ChorusSoundFx::Waveform()
{
	return _waveform;
}

void ChorusSoundFx::Waveform( WaveformType::Type val )
{
	_waveform = val;
}

void ChorusSoundFx::FromString( string data )
{
	try
	{
		int paramLength = CommunicationProtocol::Instance()->LongNumericParameterLength();
		int index = CommunicationProtocol::Instance()->HeaderLength();

		WaveformToStringConverter* waveformConverter = new WaveformToStringConverter();
		PhaseToStringConverter* phaseConverter = new PhaseToStringConverter();

		_wetDryMix = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_depth = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_feedback = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_frequency = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_delay = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_waveform = waveformConverter->Convert(data.substr(index, CommunicationProtocol::Instance()->WaveformParameterLength()));
		index += CommunicationProtocol::Instance()->WaveformParameterLength();
		_phase = phaseConverter->Convert(data.substr(index, paramLength));

		// cleanup
		delete waveformConverter;
		delete phaseConverter;
	}
	catch (exception& e)
	{
		
	}
}

std::string ChorusSoundFx::ToString()
{
	throw NotImplementedException("","ChorusSoundFx::ToString");
}

ASoundFx* ChorusSoundFx::MakeCopy()
{
	return (ASoundFx*)(new ChorusSoundFx(*this));
}

void ChorusSoundFx::CopyFrom( ASoundFx* original )
{
	_wetDryMix = ((ChorusSoundFx*)original)->WetDryMix();
	_depth = ((ChorusSoundFx*)original)->Depth();
	_feedback = ((ChorusSoundFx*)original)->Feedback();
	_frequency = ((ChorusSoundFx*)original)->Frequency();
	_delay = ((ChorusSoundFx*)original)->Delay();
	_waveform = ((ChorusSoundFx*)original)->Waveform();
	_phase = ((ChorusSoundFx*)original)->Phase();
}