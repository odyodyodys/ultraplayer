#include "EchoSoundFx.h"

EchoSoundFx::EchoSoundFx(void):ASoundFx(SoundFxType::Echo)
{
	_wetDryMix = 0;
	_feedback = 0;
	_leftDelay = 0;
	_rightDelay = 0;
	_panDelay = 0;
}

EchoSoundFx::~EchoSoundFx(void)
{
}

float EchoSoundFx::WetDryMix()
{
	return _wetDryMix;
}

void EchoSoundFx::WetDryMix( float val )
{
	_wetDryMix = val;
}

float EchoSoundFx::Feedback()
{
	return _feedback;
}

void EchoSoundFx::Feedback( float val )
{
	_feedback = val;
}

float EchoSoundFx::LeftDelay()
{
	return _leftDelay;
}

void EchoSoundFx::LeftDelay( float val )
{
	_leftDelay = val;
}

float EchoSoundFx::RightDelay()
{
	return _rightDelay;
}

void EchoSoundFx::RightDelay( float val )
{
	_rightDelay = val;
}

float EchoSoundFx::PanDelay()
{
	return _panDelay;
}

void EchoSoundFx::PanDelay( float val )
{
	_panDelay = val;
}

void EchoSoundFx::FromString( string data )
{
	try
	{
		int paramLength = CommunicationProtocol::Instance()->LongNumericParameterLength();
		int index = CommunicationProtocol::Instance()->HeaderLength();

		_wetDryMix = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_feedback = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_leftDelay = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_rightDelay = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_panDelay = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
	}
	catch (exception& e)
	{

	}
}

std::string EchoSoundFx::ToString()
{
	throw NotImplementedException("","EchoSoundFx::ToString");
}

ASoundFx* EchoSoundFx::MakeCopy()
{
	return (ASoundFx*)(new EchoSoundFx(*this));
}

void EchoSoundFx::CopyFrom( ASoundFx* original )
{
	_wetDryMix = ((EchoSoundFx*)original)->WetDryMix();
	_feedback = ((EchoSoundFx*)original)->Feedback();
	_leftDelay = ((EchoSoundFx*)original)->LeftDelay();
	_rightDelay = ((EchoSoundFx*)original)->RightDelay();
	_panDelay = ((EchoSoundFx*)original)->PanDelay();

}