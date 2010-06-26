#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "SoundFxType.h"
#include "ASoundFx.h"
#include "ChorusSoundFx.h"
#include "CompressorSoundFx.h"
#include "DistortionSoundFx.h"
#include "EchoSoundFx.h"
#include "FlangerSoundFx.h"
#include "GargleSoundFx.h"
#include "ParamEqSoundFx.h"
#include "ReverbSoundFx.h"
#include "CommunicationProtocol.h"
#include "SoundFxPartHeaderToSoundFxTypeConverter.h"

#include "InitializationFailedException.h"
#include "ParserException.h"
#include "NotImplementedException.h"
#pragma endregion

class SoundFxFactory
{
#pragma region Fields
private:
	static SoundFxFactory* _instance;
#pragma endregion

#pragma region Constructors/Destructors
private:
	SoundFxFactory();
public:
	virtual ~SoundFxFactory();
#pragma endregion

#pragma region Methods
private:
	ASoundFx* CreateFromType(SoundFxType::Type type);
public:
	// Description: Part of the singleton pattern.
	static SoundFxFactory* Instance();
	
	// Description: Creates an ASoundFx object base on a string message
	ASoundFx* CreateSoundFx(string data);
#pragma endregion

};