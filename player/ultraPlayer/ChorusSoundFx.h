#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "ASoundFx.h"
#include "WaveformType.h"
#include "PhaseType.h"
#include "NumericToStringConverter.h"
#include "CommunicationProtocol.h"
#include "PhaseToStringConverter.h"
#include "WaveformToStringConverter.h"

#include "NotImplementedException.h"
#pragma endregion

class ChorusSoundFx : public ASoundFx
{
	friend class SoundFxFactory;

#pragma region Fields
private:
	float _wetDryMix;
	float _depth;
	float _feedback;
	float _frequency;
	float _delay;
	WaveformType::Type _waveform;
	PhaseType::Type _phase;
#pragma endregion

#pragma region Constructors/Destructors
private:
	ChorusSoundFx();
public:
	virtual ~ChorusSoundFx();
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
	float WetDryMix();
	void WetDryMix(float val);
	float Depth();
	void Depth(float val);
	float Feedback();
	void Feedback(float val);
	float Frequency();
	void Frequency(float val);
	float Delay();
	void Delay(float val);
	WaveformType::Type Waveform();
	void Waveform(WaveformType::Type val);
	PhaseType::Type Phase();
	void Phase(PhaseType::Type val);
#pragma endregion

};