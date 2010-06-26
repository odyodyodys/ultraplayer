#include "SoundFxRequest.h"

SoundFxRequest::SoundFxRequest(void):ARequest(MessageType::SoundFx)
{
}

SoundFxRequest::~SoundFxRequest(void)
{
	for (std::list<ASoundFx*>::iterator it = _soundFxs.begin(); it != _soundFxs.end(); it++)
	{
		if (*it != NULL)
		{
			delete *it;
		}
	}
}

void SoundFxRequest::FromString( string data )
{
	try
	{
		// add header
		int index = CommunicationProtocol::Instance()->HeaderLength();

		while (index < data.length())
		{
			// add delimiter
			index += CommunicationProtocol::Instance()->DelimiterLength();

			// get next delimiter
			string::size_type delimiterPos = data.find(CommunicationProtocol::Instance()->Delimiter().c_str(), index);

			if (delimiterPos >= data.length())
			{
				// if this is the last effect, get all until end of data
				_soundFxs.push_back(SoundFxFactory::Instance()->CreateSoundFx(data.substr(index, data.length() - index)));
			}
			else
			{
				// get until next delimiter
				_soundFxs.push_back(SoundFxFactory::Instance()->CreateSoundFx(data.substr(index, delimiterPos - index)));
			}

			index = delimiterPos;
		}

	}
	catch (exception& e)
	{
		throw ParserException(e.what(), "SoundFxRequest::FromString");
	}
}

std::list<ASoundFx*> SoundFxRequest::SoundFxs()
{
	// caller should not release
	return _soundFxs;
}