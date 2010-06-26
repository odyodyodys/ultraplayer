#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "ASoundFx.h"
#include "CommunicationProtocol.h"
#include "NumericToStringConverter.h"

#include "NotImplementedException.h"
#pragma endregion

class ParamEqSoundFx : public ASoundFx
{
	friend class SoundFxFactory;

#pragma region Fields
private:
	float _centerFreq;
	float _bandwidth;
	float _gain;
#pragma endregion

#pragma region Constructors/Destructors
private:
	ParamEqSoundFx();
public:
	virtual ~ParamEqSoundFx();
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
	float CenterFreq();
	void CenterFreq(float val);
	float Bandwidth();
	void Bandwidth(float val);
	float Gain();
	void Gain(float val);
#pragma endregion

};