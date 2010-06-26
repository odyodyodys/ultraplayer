#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "SoundFxType.h"
#include "IStringParser.h"
#include "ICopyable.h"
#pragma endregion


class ASoundFx abstract: public IStringParser, public ICopyable<ASoundFx>
{
#pragma region Fields
protected:
	SoundFxType::Type _type;
#pragma endregion

#pragma region Constructors/Destructors
protected:
	ASoundFx(SoundFxType::Type type);
public:
	virtual ~ASoundFx();
#pragma endregion

#pragma region Properties
public:
	SoundFxType::Type Type();
#pragma endregion

#pragma region IStringParser members
public:
	virtual void FromString(string data)=0;
	virtual string ToString()=0;
#pragma endregion

#pragma region ICopyable members
public:
	 ASoundFx* MakeCopy()=0;
	virtual void CopyFrom(ASoundFx* original)=0;
#pragma endregion

};