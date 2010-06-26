#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
	#include "ARequest.h"
	#include "MessageTypeToStringConverter.h"
	#include "CommunicationProtocol.h"
	#include "SetImageRequest.h"
	#include "SetTextRequest.h"
	#include "RemoveAddonRequest.h"
	#include "PlayRequest.h"
	#include "PauseRequest.h"
	#include "ResumeRequest.h"
	#include "StopRequest.h"
	#include "SeekRequest.h"
	#include "VolumeRequest.h"
	#include "TerminationRequest.h"
	#include "VideoLayoutRequest.h"
	#include "WindowLayoutRequest.h"
	#include "DisplayDevicesInfoRequest.h"
	#include "SoundFxRequest.h"
	#include "Sound3dRequest.h"
	#include "MidiPropertiesRequest.h"
	#include "MidiOutputPortInfoRequest.h"
	#include "SetMidiOutputPortRequest.h"
	#include "SetDlsRequest.h"
	#include "SetFrequencyRequest.h"
	#include "SetRateRequest.h"
    #include "SetPlayerTypeRequest.h"

	#include "ParserException.h"
#pragma endregion

class RequestFactory
{
#pragma region Constructors/Destructors
public:
	RequestFactory();
	virtual ~RequestFactory();
#pragma endregion

#pragma region Methods
public:
	// Description: Creates an ARequest object base on the string message
	// Exceptions: ParserException
	static ARequest* CreateRequest(string data);
#pragma endregion

};