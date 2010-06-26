#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "ASoundFx.h"
#include "CommunicationProtocol.h"
#include "NumericToStringConverter.h"

#include "NotImplementedException.h"
#pragma endregion

class ReverbSoundFx:public ASoundFx, public IStringParser
{
	friend class SoundFxFactory;

#pragma region Fields
private:
	float _inGain;
	float _reverbMix;
	float _reverbTime;
	float _highFreqRtRatio;
#pragma endregion

#pragma region Constructors/Destructors
private:
	ReverbSoundFx();
public:
	virtual ~ReverbSoundFx();
#pragma endregion

#pragma region ASoundFx members
public:
	virtual void FromString(string data);
	virtual string ToString();
	virtual ASoundFx* MakeCopy();
	virtual void CopyFrom(ASoundFx* original);
#pragma endregion

#pragma region Properties
public:
	float InGain();
	void InGain(float val);
	float ReverbMix();
	void ReverbMix(float val);
	float ReverbTime();
	void ReverbTime(float val);
	float HighFreqRtRatio();
	void HighFreqRtRatio(float val);
#pragma endregion

};