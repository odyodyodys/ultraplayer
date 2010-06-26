#include "CompressorSoundFx.h"

CompressorSoundFx::CompressorSoundFx(void):ASoundFx(SoundFxType::Compressor)
{
	_gain = 0;
	_attack = 0;
	_release = 0;
	_threshold = 0;
	_ratio = 0;
	_predelay = 0;
}

CompressorSoundFx::~CompressorSoundFx(void)
{
}

float CompressorSoundFx::Gain()
{
	return _gain;
}

void CompressorSoundFx::Gain( float val )
{
	_gain = val;
}

float CompressorSoundFx::Attack()
{
	return _attack;
}

void CompressorSoundFx::Attack( float val )
{
	_attack = val;
}

float CompressorSoundFx::Release()
{
	return _release;
}

void CompressorSoundFx::Release( float val )
{
	_release = val;
}

float CompressorSoundFx::Threshold()
{
	return _threshold;
}

void CompressorSoundFx::Threshold( float val )
{
	_threshold = val;
}

float CompressorSoundFx::Ratio()
{
	return _ratio;
}

void CompressorSoundFx::Ratio( float val )
{
	_ratio = val;
}

float CompressorSoundFx::Predelay()
{
	return _predelay;
}

void CompressorSoundFx::Predelay( float val )
{
	_predelay = val;
}

void CompressorSoundFx::FromString( string data )
{
	try
	{
		int paramLength = CommunicationProtocol::Instance()->LongNumericParameterLength();
		int index = CommunicationProtocol::Instance()->HeaderLength();

		_gain = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_attack = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_release = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_threshold = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_ratio = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_predelay = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
	}
	catch (exception& e)
	{

	}

}

std::string CompressorSoundFx::ToString()
{
	throw NotImplementedException("","CompressorSoundFx::ToString");
}

ASoundFx* CompressorSoundFx::MakeCopy()
{
	return (ASoundFx*)(new CompressorSoundFx(*this));
}

void CompressorSoundFx::CopyFrom( ASoundFx* original )
{
	_gain = ((CompressorSoundFx*)original)->Gain();
	_attack = ((CompressorSoundFx*)original)->Attack();
	_release = ((CompressorSoundFx*)original)->Release();
	_threshold = ((CompressorSoundFx*)original)->Threshold();
	_ratio = ((CompressorSoundFx*)original)->Ratio();
	_predelay = ((CompressorSoundFx*)original)->Predelay();

}