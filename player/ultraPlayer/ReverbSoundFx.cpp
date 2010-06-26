#include "ReverbSoundFx.h"

ReverbSoundFx::ReverbSoundFx(void):ASoundFx(SoundFxType::Reverb)
{
	_inGain = 0;
	_reverbMix = 0;
	_reverbTime = 0;
	_highFreqRtRatio = 0;
}

ReverbSoundFx::~ReverbSoundFx(void)
{
}

float ReverbSoundFx::InGain()
{
	return _inGain;
}

void ReverbSoundFx::InGain( float val )
{
	_inGain = val;
}

float ReverbSoundFx::ReverbMix()
{
	return _reverbMix;
}

void ReverbSoundFx::ReverbMix( float val )
{
	_reverbMix = val;
}

float ReverbSoundFx::ReverbTime()
{
	return _reverbTime;
}

void ReverbSoundFx::ReverbTime( float val )
{
	_reverbTime = val;
}

float ReverbSoundFx::HighFreqRtRatio()
{
	return _highFreqRtRatio;
}

void ReverbSoundFx::HighFreqRtRatio( float val )
{
	_highFreqRtRatio = val;
}

void ReverbSoundFx::FromString( string data )
{
	try
	{
		int paramLength = CommunicationProtocol::Instance()->LongNumericParameterLength();
		int index = CommunicationProtocol::Instance()->HeaderLength();

		_inGain = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_reverbMix = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_reverbTime = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_highFreqRtRatio = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));

	}
	catch (exception& e)
	{

	}
}

std::string ReverbSoundFx::ToString()
{
	throw NotImplementedException("","ReverbSoundFx::ToString");
}

ASoundFx* ReverbSoundFx::MakeCopy()
{
	return (ASoundFx*)(new ReverbSoundFx(*this));
}

void ReverbSoundFx::CopyFrom( ASoundFx* original )
{
	_inGain = ((ReverbSoundFx*)original)->InGain();
	_reverbMix = ((ReverbSoundFx*)original)->ReverbMix();
	_reverbTime = ((ReverbSoundFx*)original)->ReverbTime();
	_highFreqRtRatio= ((ReverbSoundFx*)original)->HighFreqRtRatio();
}