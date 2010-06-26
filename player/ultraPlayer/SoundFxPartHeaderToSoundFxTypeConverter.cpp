#include "SoundFxPartHeaderToSoundFxTypeConverter.h"

SoundFxPartHeaderToSoundFxTypeConverter::SoundFxPartHeaderToSoundFxTypeConverter(void)
{
}

SoundFxPartHeaderToSoundFxTypeConverter::~SoundFxPartHeaderToSoundFxTypeConverter(void)
{
}

std::string SoundFxPartHeaderToSoundFxTypeConverter::Convert( SoundFxType::Type data )
{
	throw NotImplementedException("","SoundFxPartHeaderToSoundFxTypeConverter::Convert");
}

SoundFxType::Type SoundFxPartHeaderToSoundFxTypeConverter::Convert( string data )
{
	SoundFxType::Type type;

	try
	{
		if (data == CommunicationProtocol::Instance()->ChorusFxPartHeader())
		{
			type = SoundFxType::Chorus;
		}
		else if (data == CommunicationProtocol::Instance()->CompressorFxPartHeader())
		{
			type = SoundFxType::Compressor;
		}
		else if (data == CommunicationProtocol::Instance()->DistortionFxPartHeader())
		{
			type = SoundFxType::Distortion;
		}
		else if (data == CommunicationProtocol::Instance()->EchoFxPartHeader())
		{
			type = SoundFxType::Echo;
		}
		else if (data == CommunicationProtocol::Instance()->FlangerFxPartHeader())
		{
			type = SoundFxType::Flanger;
		}
		else if (data == CommunicationProtocol::Instance()->GargleFxPartHeader())
		{
			type = SoundFxType::Gargle;
		}
		else if (data == CommunicationProtocol::Instance()->ParamEqFxPartHeader())
		{
			type = SoundFxType::ParamEq;
		}
		else if (data == CommunicationProtocol::Instance()->ReverbFxPartHeader())
		{
			type = SoundFxType::Reverb;
		}
		else
		{
			throw ConverterException("unknown sound fx header part","SoundFxPartHeaderToSoundFxTypeConverter::Convert");
		}
	}
	catch (exception& e)
	{
		throw;
	}

	return type;
}