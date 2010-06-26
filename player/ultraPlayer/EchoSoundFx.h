#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "ASoundFx.h"
#include "CommunicationProtocol.h"
#include "NumericToStringConverter.h"

#include "NotImplementedException.h"
#pragma endregion

class EchoSoundFx:public ASoundFx
{
	friend class SoundFxFactory;

#pragma region Fields
private:
	float _wetDryMix;
	float _feedback;
	float _leftDelay;
	float _rightDelay;
	float _panDelay;
#pragma endregion

#pragma region Constructors/Destructors
private:
	EchoSoundFx();
public:
	virtual ~EchoSoundFx();
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
	float Feedback();
	void Feedback(float val);
	float LeftDelay();
	void LeftDelay(float val);
	float RightDelay();
	void RightDelay(float val);
	float PanDelay();
	void PanDelay(float val);
#pragma endregion

};