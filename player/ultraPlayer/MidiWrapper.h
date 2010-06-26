#pragma once

#pragma region headers
#include "ApplicationHeaders.h"
#include "MidiPortInfo.h"
#include "MidiEffectType.h"

#include "InitializationFailedException.h"
#include "PlaybackException.h"
#include "NotImplementedException.h"
#include "InvalidArgumentException.h"
#pragma endregion

class MidiWrapper
{
#pragma region Fields
private:
	list<MidiPortInfo*> _midiOutputPorts;
	int _maxMidiOuputPorts;
	string _dlsFile;
	string _currentFile;
	string _currentPort;

	IDirectMusic*			   _music;
	IDirectMusic8*			   _music8;
	IDirectMusicLoader8*       _loader;
	IDirectMusicPerformance8*  _performance;
	IDirectMusicSegment8*      _segment;
	IDirectMusicPort8*		   _musicPort;		
	IDirectMusicSegmentState*  _segmentState;
	IDirectMusicSegmentState8* _segmentState8;
	IDirectMusicAudioPath8*    _3dAudioPath;
	IDirectSound3DBuffer8*	   _3dSoundBuffer;
	IDirectMusicCollection8*   _musicCollection;
#pragma endregion

#pragma region Constructors/Destructor
public:
	MidiWrapper();
	~MidiWrapper();
#pragma endregion

#pragma region Methods
private:
	// Description: Stops and cleans up
	void CleanUp();

	// Description: Populates midi output ports
	HRESULT PopulatePorts();

	// Description: Returns S_OK if segment is currently being heard from the speakers
	HRESULT IsPlaying();

	// Description: Sets 3d buffer mode
	HRESULT SetMode(DWORD mode);

	// Description: sets the max distance 
	HRESULT SetMaxDistance(D3DVALUE maxDistance);
public:
	// Description: Creates com objects, initializes performance, buffer and 3d buffer,
	// and sets the default parameters
	bool Initialize();

	// Description: Sets the midi output port
	HRESULT SelectPort(string portDescription);

	// Description: Loads a midi file
	HRESULT LoadMidi(string filename);

	// Description: Plays the segment into the performace
	HRESULT Play(); 

	// Description: Pauses performance
	HRESULT Pause();

	// Description: Resumes the performance
	HRESULT Resume();

	// Description: Stops performance and sets start point to the begin of the segment
	HRESULT Stop();

	// Description: Sets spatialization
	HRESULT SetPosition(D3DVALUE x,D3DVALUE y,D3DVALUE z);

	// Description: Sets the master volume
	HRESULT SetMasterVolume(long volume);

	// Description: Sets the tempo
	HRESULT SetMasterTempo(float tempo);

	// Description: enables effects
	HRESULT SetEffect(bool enableReverb, bool enableChorus);

	// Description: Sets wavetable file (dls) to be downloaded to the performance
	HRESULT SetDlsFile(string dlsFile);
#pragma endregion

#pragma region Properties
public:
	list<MidiPortInfo*> GetPortsInfo();
#pragma endregion

};