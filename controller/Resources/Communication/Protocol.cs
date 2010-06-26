using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model;
using Utilities.Pattern;

namespace UltraPlayerController.Resources.Communication
{
    public class Protocol
    {
        #region Fields
        private uint _headerLength;
        private string _delimiter;
        private uint _delimiterLength;

        private string _setImageHeader;
        private string _setTextHeader;
        private string _removeAddonHeader;
        private string _playHeader;
        private string _stopHeader;
        private string _pauseHeader;
        private string _resumeHeader;
        private string _seekHeader;
        private string _volumeHeader;
        private string _terminationHeader;
        private string _windowLayoutHeader;
        private string _videoLayoutHeader;
        private string _displayDevicesInfoHeader;
        private string _soundFxHeader;
        private string _sound3dHeader;
        private string _midiPropertiesHeader;
        private string _midiOutputPortInfoHeader;
        private string _setMidiOutputPortHeader;
        private string _setDlsHeader;
        private string _setFrequencyHeader;
        private string _setRateHeader;
        private string _setPlayerTypeHeader;

        private string _chorusFxPartHeader;
        private string _compressorFxPartHeader;
        private string _distortionFxPartHeader;
        private string _echoFxPartHeader;
        private string _flangerFxPartHeader;
        private string _gargleFxPartHeader;
        private string _paramEqFxPartHeader;
        private string _reverbFxPartHeader;

        private string _sineWaveformParameter;
        private string _squareWaveformParameter;
        private string _triangleWaveformParameter;
        private uint _waveformParameterLength;

        private uint _responseTypeLength;
        private string _responseTypeSuccess;
        private string _responseTypeFailure;
        private string _responseTypeBad;

        private uint _numericParameterLength;
        private uint _longNumericParameterLength;
        #endregion

        #region Constructors
        private Protocol()
        {
            _headerLength = 2;
            _delimiter = "::";
            _delimiterLength = (uint)_delimiter.Length;

            _setImageHeader = "SI";
            _setTextHeader = "ST";
            _removeAddonHeader = "RA";
            _playHeader = "PL";
            _stopHeader = "SP";
            _pauseHeader = "PA";
            _resumeHeader = "RS";
            _seekHeader = "SK";
            _volumeHeader = "VE";
            _terminationHeader = "DE";
            _windowLayoutHeader = "WL";
            _videoLayoutHeader = "VL";
            _displayDevicesInfoHeader = "DI";
            _soundFxHeader = "SF";
            _sound3dHeader = "S3";
            _midiPropertiesHeader = "MP";
            _midiOutputPortInfoHeader = "MO";
            _setMidiOutputPortHeader = "SO";
            _setDlsHeader = "DS";
            _setFrequencyHeader = "FQ";
            _setRateHeader = "RT";
            _setPlayerTypeHeader = "PT";

            _chorusFxPartHeader = "CH";
            _compressorFxPartHeader = "CM";
            _distortionFxPartHeader = "DS";
            _echoFxPartHeader = "EC";
            _flangerFxPartHeader = "FL";
            _gargleFxPartHeader = "GA";
            _paramEqFxPartHeader = "EQ";
            _reverbFxPartHeader = "RV";

            _sineWaveformParameter = "S";
            _squareWaveformParameter = "Q";
            _triangleWaveformParameter = "T";
            _waveformParameterLength = (uint)_sineWaveformParameter.Length;

            _responseTypeLength = 2;
            _responseTypeSuccess = "OK";
            _responseTypeFailure = "ER";
            _responseTypeBad = "BD";

            _numericParameterLength = 4;
            _longNumericParameterLength = 8;
        }
        public static Protocol Instance
        {
            get
            {
                return Singleton<Protocol>.Instance;
            }
        }
        #endregion

        #region Properties
        public string Delimiter
        {
            get { return _delimiter; }
        }
        public uint DelimiterLength
        {
            get { return _delimiterLength; }
        }
        public string SetImageHeader
        {
            get { return _setImageHeader; }
        }
        public string SetTextHeader
        {
            get { return _setTextHeader; }
        }
        public string PlayHeader
        {
            get { return _playHeader; }
        }
        public string StopHeader
        {
            get { return _stopHeader; }
        }
        public string PauseHeader
        {
            get { return _pauseHeader; }
        }
        public string ResumeHeader
        {
            get { return _resumeHeader; }
        }
        public string SeekHeader
        {
            get { return _seekHeader; }
        }
        public string VolumeHeader
        {
            get { return _volumeHeader; }
        }
        public string TerminationHeader
        {
            get { return _terminationHeader; }
        }
        public string WindowLayoutHeader
        {
            get { return _windowLayoutHeader; }
        }
        public string VideoLayoutHeader
        {
            get { return _videoLayoutHeader; }
        }
        public string DisplayDevicesInfoHeader
        {
            get { return _displayDevicesInfoHeader; }
        }
        public string SoundFxHeader
        {
            get { return _soundFxHeader; }
        }
        public string Sound3dHeader
        {
            get { return _sound3dHeader; }
        }
        public string MidiPropertiesHeader
        {
            get { return _midiPropertiesHeader; }
        }
        public string MidiOutputPortInfoHeader
        {
            get { return _midiOutputPortInfoHeader; }
        }
        public string SetMidiOutputPortHeader
        {
            get { return _setMidiOutputPortHeader; }
        }
        public string SetDlsHeader
        {
            get { return _setDlsHeader; }
        }
        public string SetFrequencyHeader
        {
            get { return _setFrequencyHeader; }
        }
        public string SetRateHeader
        {
            get { return _setRateHeader; }
        }
        public string SetPlayerTypeHeader
        {
            get { return _setPlayerTypeHeader; }
        }
        public uint HeaderLength
        {
            get { return _headerLength; }
        }
        public string ResponseTypeSuccess
        {
            get { return _responseTypeSuccess; }
        }
        public string ResponseTypeFailure
        {
            get { return _responseTypeFailure; }
        }
        public string ResponseTypeBad
        {
            get { return _responseTypeBad; }
        }
        public uint ResponseTypeLength
        {
            get { return _responseTypeLength; }
        }
        public uint NumericParameterLength
        {
            get { return _numericParameterLength; }
        }
        public uint LongNumericParameterLength
        {
            get { return _longNumericParameterLength; }
        }
        public string RemoveAddonHeader
        {
            get { return _removeAddonHeader; }
        }

        public string ChorusFxPartHeader
        {
            get { return _chorusFxPartHeader; }
        }
        public string CompressorFxPartHeader
        {
            get { return _compressorFxPartHeader; }
        }
        public string DistortionFxPartHeader
        {
            get { return _distortionFxPartHeader; }
        }
        public string EchoFxPartHeader
        {
            get { return _echoFxPartHeader; }
        }
        public string FlangerFxPartHeader
        {
            get { return _flangerFxPartHeader; }
        }
        public string GargleFxPartHeader
        {
            get { return _gargleFxPartHeader; }
        }
        public string ParamEqFxPartHeader
        {
            get { return _paramEqFxPartHeader; }
        }
        public string ReverbFxPartHeader
        {
            get { return _reverbFxPartHeader; }
        }
        public string SineWaveformParameter
        {
            get { return _sineWaveformParameter; }
        }
        public string SquareWaveformParameter
        {
            get { return _squareWaveformParameter; }
        }
        public string TriangleWaveformParameter
        {
            get { return _triangleWaveformParameter; }
        }
        public uint WaveformParameterLength
        {
            get { return _waveformParameterLength; }
        }
        #endregion
    }
}
