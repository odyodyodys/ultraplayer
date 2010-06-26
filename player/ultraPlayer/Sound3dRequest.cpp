#include "Sound3dRequest.h"

Sound3dRequest::Sound3dRequest(void):ARequest(MessageType::Sound3d)
{
}

Sound3dRequest::~Sound3dRequest(void)
{
}

void Sound3dRequest::FromString( string data )
{
	try
	{
		int paramLength = CommunicationProtocol::Instance()->LongNumericParameterLength();
		int index = CommunicationProtocol::Instance()->HeaderLength();

		_doplerFactor = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_rolloffFactor = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_minDistance = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_maxDistance = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_sourceX = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_sourceY = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
		index += paramLength;
		_sourceZ = NumericToStringConverter::Convert<float>(data.substr(index, paramLength));
	}
	catch (exception& e)
	{
		
	}
}

float Sound3dRequest::DoplerFactor()
{
	return _doplerFactor;
}

float Sound3dRequest::RolloffFactor()
{
	return _rolloffFactor;
}

float Sound3dRequest::MinDistance()
{
	return _minDistance;
}

float Sound3dRequest::MaxDistance()
{
	return _maxDistance;
}

float Sound3dRequest::SourceX()
{
	return _sourceX;
}

float Sound3dRequest::SourceY()
{
	return _sourceY;
}

float Sound3dRequest::SourceZ()
{
	return _sourceZ;
}