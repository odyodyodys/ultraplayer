using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Model.Communication.Response;
using UltraPlayerController.Resources.Communication;
using UltraPlayerController.Model.Exceptions;
using UltraPlayerController.Model;
using Utilities.Pattern;

namespace UltraPlayerController.Communication
{
    public class ResponseFactory
    {
        #region Fields
        private Dictionary<string, MessageType> _messageHeaderMapper;
        #endregion

        #region Constructors
        private ResponseFactory()
        {
            try
            {
	            _messageHeaderMapper = new Dictionary<string, MessageType>();
	
	            // map messages. header to message type
	            _messageHeaderMapper.Add(Protocol.Instance.DisplayDevicesInfoHeader, MessageType.DisplayDevicesInfo);
	            _messageHeaderMapper.Add(Protocol.Instance.PauseHeader, MessageType.Pause);
	            _messageHeaderMapper.Add(Protocol.Instance.PlayHeader, MessageType.Play);
	            _messageHeaderMapper.Add(Protocol.Instance.ResumeHeader, MessageType.Resume);
	            _messageHeaderMapper.Add(Protocol.Instance.SeekHeader, MessageType.Seek);
	            _messageHeaderMapper.Add(Protocol.Instance.SetImageHeader, MessageType.SetImage);
	            _messageHeaderMapper.Add(Protocol.Instance.SetTextHeader, MessageType.SetText);
	            _messageHeaderMapper.Add(Protocol.Instance.RemoveAddonHeader, MessageType.RemoveAddon);
	            _messageHeaderMapper.Add(Protocol.Instance.StopHeader, MessageType.Stop);
	            _messageHeaderMapper.Add(Protocol.Instance.TerminationHeader, MessageType.Termination);
	            _messageHeaderMapper.Add(Protocol.Instance.VideoLayoutHeader, MessageType.VideoLayout);
	            _messageHeaderMapper.Add(Protocol.Instance.VolumeHeader, MessageType.Volume);
	            _messageHeaderMapper.Add(Protocol.Instance.WindowLayoutHeader, MessageType.WindowLayout);
	            _messageHeaderMapper.Add(Protocol.Instance.SoundFxHeader, MessageType.SoundFx);
	            _messageHeaderMapper.Add(Protocol.Instance.Sound3dHeader, MessageType.Sound3d);
	            _messageHeaderMapper.Add(Protocol.Instance.MidiPropertiesHeader, MessageType.MidiProperties);
	            _messageHeaderMapper.Add(Protocol.Instance.MidiOutputPortInfoHeader, MessageType.MidiOutputPortInfo);
	            _messageHeaderMapper.Add(Protocol.Instance.SetMidiOutputPortHeader, MessageType.SetMidiOutputPort);
	            _messageHeaderMapper.Add(Protocol.Instance.SetDlsHeader, MessageType.SetDls);
	            _messageHeaderMapper.Add(Protocol.Instance.SetFrequencyHeader, MessageType.SetFrequency);
                _messageHeaderMapper.Add(Protocol.Instance.SetRateHeader, MessageType.SetRate);
                _messageHeaderMapper.Add(Protocol.Instance.SetPlayerTypeHeader, MessageType.SetPlayerType);
            }
            catch (System.Exception)
            {

            }
        }

        public static ResponseFactory Instance
        {
            get
            {
                return Singleton<ResponseFactory>.Instance;
            }
        }
        #endregion

        #region Methods

        public AResponse CreateResponse(string responseData)
        {
            AResponse response = null;

            try
            {
                // validate length
                if (responseData.Length < Protocol.Instance.HeaderLength)
                {
                    throw new ParserException("invalid responseData length");
                }

                // get the header
                string header = responseData.Substring(0, (int)Protocol.Instance.HeaderLength);

                switch (_messageHeaderMapper[header])
                {
                    case MessageType.DisplayDevicesInfo:
                        response = new DisplayDeviceInfoResponse();
                        break;
                    case MessageType.Pause:
                        response = new PauseResponse();
                        break;
                    case MessageType.Play:
                        response = new PlayResponse();
                        break;
                    case MessageType.Resume:
                        response = new ResumeResponse();
                        break;
                    case MessageType.Seek:
                        response = new SeekResponse();
                        break;
                    case MessageType.SetImage:
                        response = new SetImageResponse();
                        break;
                    case MessageType.SetText:
                        response = new SetTextResponse();
                        break;
                    case MessageType.RemoveAddon:
                        response = new RemoveAddonResponse();
                        break;
                    case MessageType.Stop:
                        response = new StopResponse();
                        break;
                    case MessageType.Termination:
                        response = new TerminationResponse();
                        break;
                    case MessageType.VideoLayout:
                        response = new VideoLayoutResponse();
                        break;
                    case MessageType.Volume:
                        response = new VolumeResponse();
                        break;
                    case MessageType.WindowLayout:
                        response = new WindowLayoutResponse();
                        break;
                    case MessageType.SoundFx:
                        response = new SoundFxResponse();
                        break;
                    case MessageType.Sound3d:
                        response = new Sound3dResponse();
                        break;
                    case MessageType.MidiProperties:
                        response = new MidiPropertiesResponse();
                        break;
                    case MessageType.MidiOutputPortInfo:
                        response = new MidiOutputPortInfoResponse();
                        break;
                    case MessageType.SetMidiOutputPort:
                        response = new SetMidiOutputPortResponse();
                        break;
                    case MessageType.SetDls:
                        response = new SetDlsResponse();
                        break;
                    case MessageType.SetFrequency:
                        response = new SetFrequencyResponse();
                        break;
                    case MessageType.SetRate:
                        response = new SetRateResponse();
                        break;
                    case MessageType.SetPlayerType:
                        response = new SetPlayerTypeResponse();
                        break;
                    default:
                        throw new ParserException("invalid message header");
                }
                response.ParseFromString(responseData);
            }
            catch (System.Exception e)
            {
                throw e;
            }

            return response;

        }
        #endregion

    }
}
