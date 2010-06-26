#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "APlayer.h"
#include "PlayerType.h"
#include "PlaybackResultType.h"
#include "APlayerEnvironment.h"
#include "ComEnabledPlayerEnvironment.h"
#include "MidiWrapper.h"
#include "MidiPortInfo.h"
#include "VolumeLevelConverter.h"

#include "PlaybackException.h"
#include "NotImplementedException.h"
#pragma endregion

class MidiPlayer: public APlayer
{

	friend class PlayerFactory;

#pragma region Fields
private:
	MidiWrapper* _midiMusic;
#pragma endregion

#pragma region Constructors/Destructors
private:
	MidiPlayer(ComEnabledPlayerEnvironment* environment);
public:
	virtual ~MidiPlayer();
#pragma endregion

#pragma region APlayer members
public:
	virtual bool Initialize();
	virtual PlaybackResultType::Type Play(list<pair<int, string>> files);
	virtual PlaybackResultType::Type Pause();
	virtual PlaybackResultType::Type Resume();
	virtual PlaybackResultType::Type Stop();
	virtual PlaybackResultType::Type SetVolume(UINT volume);
	virtual PlaybackResultType::Type Seek(UINT milliseconds);
	virtual bool OnMonitorChanged(DisplayDevice* newDevice);
#pragma endregion

#pragma region Methods
public:
	// Description: Returns available midi output ports
	list<string> GetMidiOutputPortList();

	// Description: Sets the output midi port
	PlaybackResultType::Type SetMidiOutputPort(string midiPortDescription);

	// Description: Sets midi properties: reverb, chorus and tempo
	PlaybackResultType::Type SetMidiProperties(bool enableReverb, bool enableChorus, float tempo);

	// Description: Sets spatialization properties
	PlaybackResultType::Type Set3dPosition(float x, float y, float z);

	// Description: Sets wavetable file to be used in the playback
	PlaybackResultType::Type SetDlsFile(string dlsFile);
#pragma endregion

};