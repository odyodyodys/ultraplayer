#include "GargleSoundFx.h"

GargleSoundFx::GargleSoundFx(void):ASoundFx(SoundFxType::Gargle)
{
	_rate = 0;
	_waveform = WaveformType::Triangle;
}

GargleSoundFx::~GargleSoundFx(void)
{
}

float GargleSoundFx::Rate()
{
	return _rate;
}

void GargleSoundFx::Rate( float val )
{
	_rate = val;
}

WaveformType::Type GargleSoundFx::Waveform()
{
	return _waveform;
}

void GargleSoundFx::Waveform( WaveformType::Type val )
{
	_waveform = val;
}

void GargleSoundFx::FromString( string data )
{
	try
	{
		int paramLength = CommunicationProtocol::Instance()->LongNumericParameterLength();
		int index = CommunicationProtocol::Instance()->HeaderLength();

		WaveformToStringConverter* waveformConverter = new WaveformToStringConverter();
		PhaseToStringConverter* phaseConverter = new PhaseToStringConverter();

		_rate = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
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

std::string GargleSoundFx::ToString()
{
	throw NotImplementedException("","GargleSoundFx::ToString");
}

PhaseType::Type GargleSoundFx::Phase()
{
	return _phase;
}

void GargleSoundFx::Phase( PhaseType::Type val )
{
	_phase = val;
}

ASoundFx* GargleSoundFx::MakeCopy()
{
	return (ASoundFx*)(new GargleSoundFx(*this));
}

void GargleSoundFx::CopyFrom( ASoundFx* original )
{
	_rate = ((GargleSoundFx*)original)->Rate();
	_waveform = ((GargleSoundFx*)original)->Waveform();
}