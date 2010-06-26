#pragma once

#pragma region Headers
	#include "ApplicationHeaders.h"
	#include "IPlaybackEventHandler.h"
	#include "DshowPlayerEnvironment.h"
	#include "Rot.h"
	#include "VolumeLevelConverter.h"

	#include "PlaybackException.h"
#pragma endregion

using namespace std;

class AGraphManager abstract: public IPlaybackEventHandler
{
#pragma region Fields
protected:
	CComPtr<IFilterGraph2> _filterGraph;
	list<CAdapt<CComPtr<IBaseFilter>>> _sourceFilters;
	CComPtr<IMediaControl> _mediaControl;
	CComPtr<IMediaEventEx> _mediaEvent;
	CComPtr<IMediaSeeking> _mediaSeeking;

	//controls the volume and balance of the audio stream
	CComPtr<IBasicAudio> _basicAudio;

	CComPtr<IBaseFilter> _audioRenderer;
	CComPtr<IBaseFilter> _videoRenderer;

	UINT _maxSources;
	DWORD _rotId;

#pragma endregion

#pragma region Constructors/Destructor
protected:
    AGraphManager(UINT maxSources);
public:
    virtual ~AGraphManager(void);
#pragma endregion

#pragma region IPlaybackEventHandler members
public:
	virtual void HandleEvent(DWORD eventCode, HWND window);
#pragma endregion

#pragma region Methods
protected:
	// Description: Creates com instances that have to do with the graph and playback in general
	virtual HRESULT CreateInstances()=0;

	// Description: Adds created filters to the graph
	virtual HRESULT AddFiltersToGraph(list<pair<int, string>> files)=0;

	// Description: Configures filters
	virtual HRESULT ConfigureFilters(DshowPlayerEnvironment* const _environment)=0;

	// Description: Cleans up everything
	virtual void CleanUp()=0;

	// Description: Initialize empty list with the number of max sources
	void InitializeSourcesList();

	// Description: Get pin from a filter. Caller must release when done.
	IPin* GetPin(IBaseFilter *filter, PIN_DIRECTION pinDirection);

public:
	// Description: Stops playback and creates a new filter graph able to render provided sources
	void Initialize(list<pair<int, string>> files, DshowPlayerEnvironment* const environment);

	// Description: Runs the graph
	void Run();

	// Description: Pauses the graph
    void Pause();

	// Description: Resumes the graph
	void Resume();

	// Description: Renders all source output pins
	virtual void Render();

	// Description: Stops the graph
    virtual void Stop();

	// Description: Sets the playback volume
	virtual void SetVolume(UINT volume);

	// Description: Sets the playback rate
	virtual HRESULT SetRate(float rate);

	// Description: Sets the position in millisecond to seek to, from the begining
	// of the track. If more than one, durations is considered the longest.
	bool SeekTo(long milliseconds);
#pragma endregion
};
