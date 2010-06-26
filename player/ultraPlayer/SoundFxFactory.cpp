#include "SoundFxFactory.h"

SoundFxFactory* SoundFxFactory::_instance = NULL;

SoundFxFactory::SoundFxFactory(void)
{
}

SoundFxFactory::~SoundFxFactory(void)
{
}

ASoundFx* SoundFxFactory::CreateSoundFx( string data )
{
	ASoundFx* soundFx = NULL;

	try
	{
		// get soundfx type
		string headerPart = data.substr(0, CommunicationProtocol::Instance()->HeaderLength());
		SoundFxPartHeaderToSoundFxTypeConverter* converter = new SoundFxPartHeaderToSoundFxTypeConverter();
		SoundFxType::Type type = converter->Convert(headerPart);

		soundFx = CreateFromType(type);

		if (soundFx)
		{
			soundFx->FromString(data);
		}
		else
		{
			throw InitializationFailedException("could not initialize soundfx from string","SoundFxFactory::CreateSoundFx");
		}
	}
	catch(exception& e )
	{
		//rethrow, method not able to handle the error
		throw;
	}

	return soundFx;

}

SoundFxFactory* SoundFxFactory::Instance()
{
	if (!_instance)
	{
		_instance = new SoundFxFactory();
	}

	return _instance;
}

ASoundFx* SoundFxFactory::CreateFromType( SoundFxType::Type type )
{
	ASoundFx* soundFx = NULL;

	try
	{
		switch (type)
		{
		case SoundFxType::Chorus:
			soundFx = new ChorusSoundFx();
			break;
		case SoundFxType::Compressor:
			soundFx = new CompressorSoundFx();
			break;
		case SoundFxType::Distortion:
			soundFx = new DistortionSoundFx();
			break;
		case SoundFxType::Echo:
			soundFx = new EchoSoundFx();
			break;
		case SoundFxType::Flanger:
			soundFx = new FlangerSoundFx();
			break;
		case SoundFxType::Gargle:
			soundFx = new GargleSoundFx();
			break;
		case SoundFxType::ParamEq:
			soundFx = new ParamEqSoundFx();
			break;
		case SoundFxType::Reverb:
			soundFx = new ReverbSoundFx();
			break;
		default:
			throw ParserException("sound fx not supported", "SoundFxFactory::CreateFromType");
		}
	}
	catch (exception& e)
	{
		throw;
	}

	return soundFx;
}