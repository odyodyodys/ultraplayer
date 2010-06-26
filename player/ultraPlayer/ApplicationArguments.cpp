#include "ApplicationArguments.h"

ApplicationArguments* ApplicationArguments::_instance = NULL;

ApplicationArguments::ApplicationArguments(void)
{
	_delimiter = ' ';
	_playerArgumentLength = 3;
	_audioPlayerArgument = "aud";
	_singleVideoPlayerArgument = "svi";
	_multiVideoPlayerArgument = "mvi";
	_midiPlayerArgument = "mid";
}

ApplicationArguments::~ApplicationArguments(void)
{
}

ApplicationArguments* ApplicationArguments::Instance()
{
	if (!_instance)
	{
		_instance = new ApplicationArguments();
	}

	return _instance;
}

char ApplicationArguments::Delimiter()
{
	return _delimiter;
}

std::string ApplicationArguments::AudioPlayerArgument()
{
	return _audioPlayerArgument;
}

std::string ApplicationArguments::SingleVideoPlayerArgument()
{
	return _singleVideoPlayerArgument;
}

std::string ApplicationArguments::MultiVideoPlayerArgument()
{
	return _multiVideoPlayerArgument;
}

std::string ApplicationArguments::MidiPlayerArgument()
{
	return _midiPlayerArgument;
}

UINT ApplicationArguments::PlayerArgumentLength()
{
	return _playerArgumentLength;
}