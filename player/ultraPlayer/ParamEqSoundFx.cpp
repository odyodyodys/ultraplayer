#include "ParamEqSoundFx.h"

ParamEqSoundFx::ParamEqSoundFx(void):ASoundFx(SoundFxType::ParamEq)
{
	_centerFreq = 0;
	_bandwidth = 0;
	_gain = 0;
}

ParamEqSoundFx::~ParamEqSoundFx(void)
{
}

float ParamEqSoundFx::CenterFreq()
{
	return _centerFreq;
}

void ParamEqSoundFx::CenterFreq( float val )
{
	_centerFreq =val;
}

float ParamEqSoundFx::Bandwidth()
{
	return _bandwidth;
}

void ParamEqSoundFx::Bandwidth( float val )
{
	_bandwidth = val;
}

float ParamEqSoundFx::Gain()
{
	return _gain;
}

void ParamEqSoundFx::Gain( float val )
{
	_gain = val;
}

void ParamEqSoundFx::FromString( string data )
{
	try
	{
		int paramLength = CommunicationProtocol::Instance()->LongNumericParameterLength();
		int index = CommunicationProtocol::Instance()->HeaderLength();

		_centerFreq = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_bandwidth = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_gain = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
	}
	catch (exception& e)
	{

	}
}

std::string ParamEqSoundFx::ToString()
{
	throw NotImplementedException("","ParamEqSoundFx::ToString");
}

ASoundFx* ParamEqSoundFx::MakeCopy()
{
	return (ASoundFx*)(new ParamEqSoundFx(*this));
}

void ParamEqSoundFx::CopyFrom( ASoundFx* original )
{
	_centerFreq = ((ParamEqSoundFx*)original)->CenterFreq();
	_bandwidth = ((ParamEqSoundFx*)original)->Bandwidth();
	_gain = ((ParamEqSoundFx*)original)->Gain();
}