#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "ASoundFx.h"
#include "CommunicationProtocol.h"
#include "NumericToStringConverter.h"

#include "NotImplementedException.h"
#pragma endregion

class DistortionSoundFx: public ASoundFx
{
	friend class SoundFxFactory;

#pragma region Fields
private:
	float _gain;
	float _edge;
	UINT _postEqCenterFreq;
	UINT _postEqBandwidth;
	UINT _preLowpassCutoff;
#pragma endregion

#pragma region Constructors/Destructors
private:
	DistortionSoundFx();
public:
	virtual ~DistortionSoundFx();
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
	float Edge();
	void Edge(float val);
	UINT PostEqCenterFreq();
	void PostEqCenterFreq(UINT val);
	UINT PostEqBandwidth();
	void PostEqBandwidth(UINT val);
	UINT PreLowpassCutoff();
	void PreLowpassCutoff(UINT val);
#pragma endregion

};