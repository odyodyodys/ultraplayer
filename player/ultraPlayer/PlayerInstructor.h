#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "IRequestHandler.h"
#include "APlayer.h"
#include "MultiVideoPlayer.h"
#include "SingleVideoPlayer.h"
#include "AudioPlayer.h"
#include "MidiPlayer.h"
#include "ARequest.h"
#include "AResponse.h"
#include "PlayRequest.h"
#include "PlayResponse.h"
#include "PauseRequest.h"
#include "PauseResponse.h"
#include "ResumeRequest.h"
#include "ResumeResponse.h"
#include "StopRequest.h"
#include "StopResponse.h"
#include "SeekRequest.h"
#include "SeekResponse.h"
#include "SetImageRequest.h"
#include "SetImageResponse.h"
#include "SetTextRequest.h"
#include "SetTextResponse.h"
#include "RemoveAddonRequest.h"
#include "RemoveAddonResponse.h"
#include "VolumeRequest.h"
#include "VolumeResponse.h"
#include "VideoLayoutRequest.h"
#include "VideoLayoutResponse.h"
#include "GeneralFailureResponse.h"
#include "ResponseType.h"
#include "PlaybackResultType.h"
#include "SoundFxRequest.h"
#include "SoundFxResponse.h"
#include "Sound3dRequest.h"
#include "Sound3dResponse.h"
#include "MidiPropertiesRequest.h"
#include "MidiPropertiesResponse.h"
#include "MidiOutputPortInfoRequest.h"
#include "MidiOutputPortInfoResponse.h"
#include "SetMidiOutputPortRequest.h"
#include "SetMidiOutputPortResponse.h"
#include "SetDlsRequest.h"
#include "SetDlsResponse.h"
#include "SetFrequencyRequest.h"
#include "SetFrequencyResponse.h"
#include "SetRateRequest.h"
#include "SetRateResponse.h"

#include "HandlerException.h"
#pragma endregion

class PlayerInstructor: public IRequestHandler
{
#pragma region Fields
private:
	APlayer* _player;
#pragma endregion

#pragma region Constructors/Destructors
public:
	PlayerInstructor();
	virtual ~PlayerInstructor();
#pragma endregion

#pragma region IRequestHandler members
public:
	virtual AResponse* HandleRequest(ARequest* request);
#pragma endregion

#pragma region Methods
private:
	// Description: Handles play request
	AResponse* HandlePlayRequest(PlayRequest* request);

	// Description: Handles pause request
	AResponse* HandlePauseRequest(PauseRequest* request);

	// Description: Handles resume request
	AResponse* HandleResumeRequest(ResumeRequest* request);

	// Description: Handles stop request
	AResponse* HandleStopRequest(StopRequest* request);

	// Description: Handles seek request
	AResponse* HandleSeekRequest(SeekRequest* request);

	// Description: Handles volume request
	AResponse* HandleVolumeRequest(VolumeRequest* request);

	// Description: Handles set image request
	AResponse* HandleSetImageRequest(SetImageRequest* request);

	// Description: Handles set text request
	AResponse* HandleSetTextRequest(SetTextRequest* request);

	// Description: Handles remove addon request
	AResponse* HandleRemoveAddonRequest(RemoveAddonRequest* request);

	// Description: Handles video layout request
	AResponse* HandleVideoLayoutRequest(VideoLayoutRequest* request);

	// Description: Handles soundfx request
	AResponse* HandleSoundFxRequest(SoundFxRequest* request);

	// Description: Handles sound 3d request
	AResponse* HandleSound3dRequest(Sound3dRequest* request);

	// Description: Handles midi properties request
	AResponse* HandleMidiPropertiesRequest(MidiPropertiesRequest* request);

	// Description: Handles midi output info request
	AResponse* HandleMidiOutputPortInfoRequest(MidiOutputPortInfoRequest* request);

	// Description: Handles set output port request
	AResponse* HandleSetMidiOutputPortRequest(SetMidiOutputPortRequest* request);

	// Description: Handles set dls request
	AResponse* HandleSetDlsRequest(SetDlsRequest* request);

	// Description: Handles set frequency request
	AResponse* HandleSetFrequencyRequest(SetFrequencyRequest* request);

	// Description: Handles set rate request
	AResponse* HandleSetRateRequest(SetRateRequest* request);

public:
    // Switches to another "APlayer" instance
    void SetPlayer(APlayer* player);
#pragma endregion

};