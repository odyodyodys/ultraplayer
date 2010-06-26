#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "ARequest.h"
#include "MessageType.h"
#include "CommunicationProtocol.h"
#include "NumericToStringConverter.h"

#include "ParserException.h"
#include "NotImplementedException.h"
#pragma endregion

class Sound3dRequest: public ARequest
{
	friend class RequestFactory;

#pragma region Fields
private:
	float _doplerFactor;
	float _rolloffFactor;
	float _minDistance;
	float _maxDistance;
	float _sourceX;
	float _sourceY;
	float _sourceZ;
#pragma endregion

#pragma region Constructors/Destructors
private:
	Sound3dRequest();
public:
	virtual ~Sound3dRequest();
#pragma endregion

#pragma region ARequest members
public:
	virtual void FromString(string data);

#pragma endregion

#pragma region Properties
public:
		float DoplerFactor();
		float RolloffFactor();
		float MinDistance();
		float MaxDistance();
		float SourceX();
		float SourceY();
		float SourceZ();
#pragma endregion
};