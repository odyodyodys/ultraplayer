#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "FileUtils.h"
#include "IValidator.h"

#include "PlaybackException.h"
#include "ValidationFailedException.h"
#pragma endregion

using namespace std;

class WaveFileValidator: public IValidator<string>
{
#pragma region Fields

	static WaveFileValidator* _instance;
#pragma endregion

#pragma region Constructors/Destructors
private:
	WaveFileValidator();
public:
	virtual ~WaveFileValidator();
#pragma endregion

#pragma region IValidator members
public:
	// Description: Validates that the file is a valid wave file and
	// it is in a proper format
	bool IsValid(string data);
#pragma endregion

#pragma region Methods
public:
	// Description: Part of the singleton pattern.
	static WaveFileValidator* Instance();

	// Description: Gets the sound channel cound of a wav file
	WORD GetChannelCount(string filename);
#pragma endregion

};