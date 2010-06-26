#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "ASoundFx.h"
#include "PhaseType.h"
#include "WaveformType.h"
#include "WaveformToStringConverter.h"
#include "PhaseToStringConverter.h"
#include "CommunicationProtocol.h"
#include "NumericToStringConverter.h"

#include "NotImplementedException.h"
#pragma endregion

class GargleSoundFx:public ASoundFx
{
	friend class SoundFxFactory;

#pragma region Fields
private:
	float _rate;
	WaveformType::Type _waveform;
	PhaseType::Type _phase;
#pragma endregion

#pragma region Constructors/Destructors
private:
	GargleSoundFx();
public:
	virtual ~GargleSoundFx();
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
	float Rate();
	void Rate(float val);
	WaveformType::Type Waveform();
	void Waveform(WaveformType::Type val);
	PhaseType::Type Phase();
	void Phase(PhaseType::Type val);
#pragma endregion

};