#pragma once

#pragma region headers
	#include "ApplicationHeaders.h"
#pragma endregion

using namespace std;

class CommunicationProtocol
{
#pragma region Fields
private:
	static CommunicationProtocol* _instance;

	// General
	UINT _maxMessageLength;
	UINT _headerLength;

	string _delimiter;
	UINT _delimiterLength;
	UINT _numericParameterLength;
	UINT _longNumericParameterLength;

	// Headers
	string _setImageHeader;
	string _setTextHeader;
	string _removeAddonHeader;
	string _playHeader;
	string _stopHeader;
	string _pauseHeader;
	string _resumeHeader;
	string _seekHeader;
	string _volumeHeader;
	string _terminationHeader;
	string _windowLayoutHeader;
	string _videoLayoutHeader;
	string _displayDeviceInfoHeader;
	string _soundFxHeader;
	string _sound3dHeader;
	string _midiPropertiesHeader;
	string _midiOutputPortInfoHeader;
	string _setMidiOutputPortHeader;
	string _setDlsHeader;
	string _setFrequencyHeader;
	string _setRateHeader;
    string _setPlayerTypeHeader;

	// length
	UINT _layoutSubsetLength;
	UINT _layoutPartsCount;
	UINT _layoutPartLength;
	UINT _visibleLayoutPartsCount;
	UINT _visibleLayoutPartLength;
	UINT _visibleObjectPartsCount;
	UINT _visibleObjectPartLength;

	// sound effects
	string _chorusFxPartHeader;
	string _compressorFxPartHeader;
	string _distortionFxPartHeader;
	string _echoFxPartHeader;
	string _flangerFxPartHeader;
	string _gargleFxPartHeader;
	string _paramEqFxPartHeader;
	string _reverbFxPartHeader;
	string _sineWaveformParameter;
	string _squareWaveformParameter;
	string _triangleWaveformParameter;
	UINT _waveformParameterLength;

	// Response
	string _responseSuccess;
	string _responseFailure;
	string _responseBad;
#pragma endregion

#pragma region Constructors/Destructors
private:
	CommunicationProtocol();
public:
	virtual ~CommunicationProtocol();
#pragma endregion

#pragma region Methods
public:
	// Description: Part of the singleton pattern.
	static CommunicationProtocol* Instance();
#pragma endregion

#pragma region Properties
public:
	UINT MaxMessageLength();
	UINT HeaderLength();
	string Delimiter();
	UINT DelimiterLength();
	UINT NumericParameterLength();
	UINT LongNumericParameterLength();
	string SetImageHeader();
	string SetTextHeader();
	string RemoveAddonHeader();
	string PlayHeader();
	string StopHeader();
	string PauseHeader();
	string ResumeHeader();
	string SeekHeader();
	string VolumeHeader();
	string TerminationHeader();
	string WindowLayoutHeader();
	string VideoLayoutHeader();
	string DisplayDeviceHeader();
	string SoundFxHeader();
	string Sound3dHeader();
	string MidiPropertiesHeader();
	string MidiOutputPortInfoHeader();
	string SetMidiOutputPortHeader();
	string SetDlsHeader();
	string SetFrequencyHeader();
	string SetRateHeader();
    string SetPlayerTypeHeader();
	string ChorusFxPartHeader();
	string CompressorFxPartHeader();
	string DistortionFxPartHeader();
	string EchoFxPartHeader();
	string FlangerFxPartHeader();
	string GargleFxPartHeader();
	string ParamEqFxPartHeader();
	string ReverbFxPartHeader();
	string SineWaveformParameter();
	string SquareWaveformParameter();
	string TriangleWaveformParameter();
	UINT WaveformParameterLength();
	UINT LayoutPartsCount();
	UINT LayoutPartLength();
	UINT VisibleLayoutPartsCount();
	UINT VisibleLayoutPartLength();
	UINT VisibleObjectPartsCount();
	UINT VisibleObjectPartLength();
	UINT VolumeSubsetLength();
	string ResponseSuccess();
	string ResponseFailure();
	string ResponseBad();
#pragma endregion

};