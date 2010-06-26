#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
#pragma endregion

using namespace std;

class ApplicationArguments
{
#pragma region Fields
private:
	char _delimiter;
	UINT _playerArgumentLength;
	string _audioPlayerArgument;
	string _singleVideoPlayerArgument;
	string _multiVideoPlayerArgument;
	string _midiPlayerArgument;

	static ApplicationArguments* _instance;
#pragma endregion

#pragma region Constructors/Destructors
private:
	ApplicationArguments();
public:
	virtual ~ApplicationArguments();
#pragma endregion

#pragma region Methods
public:
	// Description: Part of the singleton pattern.
	static ApplicationArguments* Instance();

	char Delimiter();
	UINT PlayerArgumentLength();
	string AudioPlayerArgument();
	string SingleVideoPlayerArgument();
	string MultiVideoPlayerArgument();
	string MidiPlayerArgument();

#pragma endregion

};