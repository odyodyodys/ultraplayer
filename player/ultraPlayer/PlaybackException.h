#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "BaseException.h"
	#include "NumericToStringConverter.h"
#pragma endregion

using namespace std;

class PlaybackException: public BaseException
{

public:
	PlaybackException(string errorCause, string where)
	{
		_cause = "PlaybackException: " + where + ": " + errorCause;
	}

	PlaybackException(string errorCause, string where, HRESULT hr)
	{
		_cause = "PlaybackException: " + where + ": " + errorCause + ": " + NumericToStringConverter::Convert<int>(hr, std::hex);
	}

};