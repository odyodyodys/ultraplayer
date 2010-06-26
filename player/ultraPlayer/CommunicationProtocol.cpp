#include "CommunicationProtocol.h"

CommunicationProtocol* CommunicationProtocol::_instance = NULL;

CommunicationProtocol::CommunicationProtocol(void)
{
	_maxMessageLength = 4096; // 4k
	_headerLength = 2;
	_delimiter = "::";
	_delimiterLength = _delimiter.size();
	_numericParameterLength = 4;
	_longNumericParameterLength = 8;

	 _setImageHeader	= "SI";
	 _setTextHeader		= "ST";
	 _removeAddonHeader = "RA";
	 _playHeader		= "PL";
	 _stopHeader		= "SP";
	 _pauseHeader		= "PA";
	 _resumeHeader		= "RS";
	 _seekHeader		= "SK";
	 _volumeHeader		= "VE";
	 _terminationHeader	= "DE";
	 _windowLayoutHeader= "WL";
	 _videoLayoutHeader	= "VL";
	 _displayDeviceInfoHeader = "DI";
	 _soundFxHeader = "SF";
	 _sound3dHeader = "S3";
	 _midiPropertiesHeader = "MP";
	 _midiOutputPortInfoHeader = "MO";
	 _setMidiOutputPortHeader = "SO";
	 _setDlsHeader = "DS";
	 _setFrequencyHeader = "FQ";
	 _setRateHeader = "RT";
     _setPlayerTypeHeader = "PT";

	 _chorusFxPartHeader	 = "CH";
	 _compressorFxPartHeader = "CM";
	 _distortionFxPartHeader = "DS";
	 _echoFxPartHeader		 = "EC";
	 _flangerFxPartHeader	 = "FL";
	 _gargleFxPartHeader	 = "GA";
	 _paramEqFxPartHeader	 = "EQ";
	 _reverbFxPartHeader	 = "RV";

	 _sineWaveformParameter		= "S";
	 _squareWaveformParameter	= "Q";
	 _triangleWaveformParameter	= "T";
	 _waveformParameterLength = _sineWaveformParameter.size();

	 _layoutPartsCount = 4;
	 _layoutPartLength = _numericParameterLength * _layoutPartsCount;
	 _visibleLayoutPartsCount = _layoutPartsCount + 1;
	 _visibleLayoutPartLength = _layoutPartLength + _numericParameterLength;
	 _visibleObjectPartsCount = _visibleLayoutPartsCount + 1;
	 _visibleObjectPartLength = _visibleLayoutPartLength + _numericParameterLength;

	 _responseSuccess			 = "OK";
	 _responseFailure			 = "ER";
	 _responseBad				 = "BD";
}

CommunicationProtocol::~CommunicationProtocol(void)
{
}

CommunicationProtocol* CommunicationProtocol::Instance()
{
	// TODO improve singletons
	if (!_instance)
	{
		_instance = new CommunicationProtocol();
	}

	return _instance;
}

UINT CommunicationProtocol::HeaderLength()
{
	return _headerLength;
}

string CommunicationProtocol::SetImageHeader()
{
	return _setImageHeader;
}

string CommunicationProtocol::SetTextHeader()
{
	return _setTextHeader;
}

string CommunicationProtocol::PlayHeader()
{
	return _playHeader;
}

string CommunicationProtocol::StopHeader()
{
	return _stopHeader;
}

string CommunicationProtocol::PauseHeader()
{
	return _pauseHeader;
}

string CommunicationProtocol::SeekHeader()
{
	return _seekHeader;
}

string CommunicationProtocol::VolumeHeader()
{
	return _volumeHeader;
}

string CommunicationProtocol::TerminationHeader()
{
	return _terminationHeader;
}

string CommunicationProtocol::WindowLayoutHeader()
{
	return _windowLayoutHeader;
}

string CommunicationProtocol::VideoLayoutHeader()
{
	return _videoLayoutHeader;
}

string CommunicationProtocol::ResponseSuccess()
{
	return _responseSuccess;
}

string CommunicationProtocol::ResponseFailure()
{
	return _responseFailure;
}

string CommunicationProtocol::ResponseBad()
{
	return _responseBad;
}

string CommunicationProtocol::Delimiter()
{
	return _delimiter;
}

UINT CommunicationProtocol::DelimiterLength()
{
	return _delimiterLength;
}

UINT CommunicationProtocol::LayoutPartLength()
{
	return _layoutPartLength;
}

UINT CommunicationProtocol::LayoutPartsCount()
{
	return _layoutPartsCount;
}

string CommunicationProtocol::ResumeHeader()
{
	return _resumeHeader;
}

string CommunicationProtocol::DisplayDeviceHeader()
{
	return _displayDeviceInfoHeader;
}

string CommunicationProtocol::SoundFxHeader()
{
	return _soundFxHeader;
}

UINT CommunicationProtocol::NumericParameterLength()
{
	return _numericParameterLength;
}

UINT CommunicationProtocol::LongNumericParameterLength()
{
	return _longNumericParameterLength;
}

UINT CommunicationProtocol::VisibleLayoutPartsCount()
{
	return _visibleLayoutPartsCount;
}

UINT CommunicationProtocol::VisibleLayoutPartLength()
{
	return _visibleLayoutPartLength;
}

UINT CommunicationProtocol::VisibleObjectPartsCount()
{
	return _visibleObjectPartsCount;
}

UINT CommunicationProtocol::VisibleObjectPartLength()
{
	return _visibleObjectPartLength;
}

string CommunicationProtocol::RemoveAddonHeader()
{
	return _removeAddonHeader;
}

std::string CommunicationProtocol::ChorusFxPartHeader()
{
	return _chorusFxPartHeader;
}

std::string CommunicationProtocol::CompressorFxPartHeader()
{
	return _compressorFxPartHeader;
}

std::string CommunicationProtocol::DistortionFxPartHeader()
{
	return _distortionFxPartHeader;
}

std::string CommunicationProtocol::EchoFxPartHeader()
{
	return _echoFxPartHeader;
}

std::string CommunicationProtocol::FlangerFxPartHeader()
{
	return _flangerFxPartHeader;
}

std::string CommunicationProtocol::GargleFxPartHeader()
{
	return _gargleFxPartHeader;
}

std::string CommunicationProtocol::ParamEqFxPartHeader()
{
	return _paramEqFxPartHeader;
}

std::string CommunicationProtocol::ReverbFxPartHeader()
{
	return _reverbFxPartHeader;
}

std::string CommunicationProtocol::SineWaveformParameter()
{
	return _sineWaveformParameter;
}

std::string CommunicationProtocol::SquareWaveformParameter()
{
	return _squareWaveformParameter;
}

std::string CommunicationProtocol::TriangleWaveformParameter()
{
	return _triangleWaveformParameter;
}

UINT CommunicationProtocol::WaveformParameterLength()
{
	return _waveformParameterLength;
}

UINT CommunicationProtocol::MaxMessageLength()
{
	return _maxMessageLength;
}

std::string CommunicationProtocol::Sound3dHeader()
{
	return _sound3dHeader;
}

std::string CommunicationProtocol::MidiPropertiesHeader()
{
	return _midiPropertiesHeader;
}

std::string CommunicationProtocol::MidiOutputPortInfoHeader()
{
	return _midiOutputPortInfoHeader;
}

std::string CommunicationProtocol::SetMidiOutputPortHeader()
{
	return _setMidiOutputPortHeader;
}

std::string CommunicationProtocol::SetDlsHeader()
{
	return _setDlsHeader;
}

std::string CommunicationProtocol::SetFrequencyHeader()
{
	return _setFrequencyHeader;
}

std::string CommunicationProtocol::SetRateHeader()
{
	return _setRateHeader;
}

std::string CommunicationProtocol::SetPlayerTypeHeader()
{
    return _setPlayerTypeHeader;
}
