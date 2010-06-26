#include "FlangerSoundFx.h"

FlangerSoundFx::FlangerSoundFx(void):ASoundFx(SoundFxType::Flanger)
{
	_wetDryMix = 0;
	_depth = 0;
	_feedback = 0;
	_frequency = 0;
	_delay = 0;
	_waveform = WaveformType::Sine;
	_phase = PhaseType::Zero;
}

FlangerSoundFx::~FlangerSoundFx(void)
{
}

float FlangerSoundFx::WetDryMix()
{
	return _wetDryMix;
}

void FlangerSoundFx::WetDryMix( float val )
{
	_wetDryMix = val;
}

float FlangerSoundFx::Depth()
{
	return _depth;
}

void FlangerSoundFx::Depth( float val )
{
	_depth = val;
}

float FlangerSoundFx::Feedback()
{
	return _feedback;
}

void FlangerSoundFx::Feedback( float val )
{
	_feedback = val;
}

float FlangerSoundFx::Frequency()
{
	return _frequency;
}

void FlangerSoundFx::Frequency( float val )
{
	_frequency = val;
}

float FlangerSoundFx::Delay()
{
	return _delay;
}

void FlangerSoundFx::Delay( float val )
{
	_delay = val;
}

WaveformType::Type FlangerSoundFx::Waveform()
{
	return _waveform;
}

void FlangerSoundFx::Waveform( WaveformType::Type val )
{
	_waveform = val;
}

PhaseType::Type FlangerSoundFx::Phase()
{
	return _phase;
}

void FlangerSoundFx::Phase( PhaseType::Type val )
{
	_phase = val;
}

void FlangerSoundFx::FromString( string data )
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

std::string FlangerSoundFx::ToString()
{
	throw NotImplementedException("","FlangerSoundFx::ToString");
}

ASoundFx* FlangerSoundFx::MakeCopy()
{
	return (ASoundFx*)(new FlangerSoundFx(*this));
}

void FlangerSoundFx::CopyFrom( ASoundFx* original )
{
	_wetDryMix = ((FlangerSoundFx*)original)->WetDryMix();
	_depth = ((FlangerSoundFx*)original)->Depth();
	_feedback = ((FlangerSoundFx*)original)->Feedback();
	_frequency = ((FlangerSoundFx*)original)->Frequency();
	_delay = ((FlangerSoundFx*)original)->Delay();
	_waveform = ((FlangerSoundFx*)original)->Waveform();
	_phase = ((FlangerSoundFx*)original)->Phase();
}