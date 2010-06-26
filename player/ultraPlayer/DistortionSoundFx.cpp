#include "DistortionSoundFx.h"

DistortionSoundFx::DistortionSoundFx(void):ASoundFx(SoundFxType::Distortion)
{
	_gain = 0;
	_edge = 0;
	_postEqCenterFreq = 0;
	_postEqBandwidth = 0;
	_preLowpassCutoff = 0;
}

DistortionSoundFx::~DistortionSoundFx(void)
{
}

float DistortionSoundFx::Gain()
{
	return _gain;
}

void DistortionSoundFx::Gain( float val )
{
	_gain = val;
}

float DistortionSoundFx::Edge()
{
	return _edge;
}

void DistortionSoundFx::Edge( float val )
{
	_edge = val;
}

UINT DistortionSoundFx::PostEqCenterFreq()
{
	return _postEqCenterFreq;
}

void DistortionSoundFx::PostEqCenterFreq( UINT val )
{
	_postEqCenterFreq = val;
}

UINT DistortionSoundFx::PostEqBandwidth()
{
	return _postEqBandwidth;
}

void DistortionSoundFx::PostEqBandwidth( UINT val )
{
	_postEqBandwidth = val;
}

UINT DistortionSoundFx::PreLowpassCutoff()
{
	return _preLowpassCutoff;
}

void DistortionSoundFx::PreLowpassCutoff( UINT val )
{
	_preLowpassCutoff = val;
}

void DistortionSoundFx::FromString( string data )
{
	try
	{
		int paramLength = CommunicationProtocol::Instance()->LongNumericParameterLength();
		int index = CommunicationProtocol::Instance()->HeaderLength();

		_gain = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_edge = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_postEqCenterFreq = NumericToStringConverter::Convert<UINT>(data.substr(index, paramLength));
		index += paramLength;
		_postEqBandwidth = NumericToStringConverter::Convert<UINT>(data.substr(index, paramLength));
		index += paramLength;
		_postEqCenterFreq = NumericToStringConverter::Convert<UINT>(data.substr(index, paramLength));

	}
	catch (exception& e)
	{

	}
}

std::string DistortionSoundFx::ToString()
{
	throw NotImplementedException("","DistortionSoundFx::ToString");
}

ASoundFx* DistortionSoundFx::MakeCopy()
{
	return (ASoundFx*)(new DistortionSoundFx(*this));
}

void DistortionSoundFx::CopyFrom( ASoundFx* original )
{	
	_gain = ((DistortionSoundFx*)original)->Gain();
	_edge = ((DistortionSoundFx*)original)->Edge();
	_postEqCenterFreq = ((DistortionSoundFx*)original)->PostEqCenterFreq();
	_postEqBandwidth = ((DistortionSoundFx*)original)->PostEqBandwidth();
	_preLowpassCutoff = ((DistortionSoundFx*)original)->PreLowpassCutoff();
}