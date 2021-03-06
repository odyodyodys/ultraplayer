#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "ASoundFx.h"
#include "CommunicationProtocol.h"
#include "NumericToStringConverter.h"

#include "NotImplementedException.h"
#pragma endregion

class CompressorSoundFx:public ASoundFx
{
	friend class SoundFxFactory;

#pragma region Fields
private:
	float _gain;
	float _attack;
	float _release;
	float _threshold;
	float _ratio;
	float _predelay;
#pragma endregion

#pragma region Constructors/Destructors
private:
	CompressorSoundFx();
public:
	virtual ~CompressorSoundFx();
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
	float Gain();
	void Gain(float val);
	float Attack();
	void Attack(float val);
	float Release();
	void Release(float val);
	float Threshold();
	void Threshold(float val);
	float Ratio();
	void Ratio(float val);
	float Predelay();
	void Predelay(float val);
#pragma endregion

};