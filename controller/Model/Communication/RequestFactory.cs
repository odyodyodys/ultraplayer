using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Communication;
using UltraPlayerController.Model.Communication.Request;

namespace UltraPlayerController.Communication
{
    public class RequestFactory
    {
        #region Constructors
        private RequestFactory()
        {

        }
        #endregion

        #region Methods
        public static ARequest CreateRequest(MessageType type)
        {
            ARequest request = null;

            switch (type)
            {
                case MessageType.SetImage:
                    request = new SetImageRequest();
                    break;
                case MessageType.SetText:
                    request = new SetTextRequest();
                    break;
                case MessageType.RemoveAddon:
                    request = new RemoveAddonRequest();
                    break;
                case MessageType.Play:
                    request = new PlayRequest();
                    break;
                case MessageType.Stop:
                    request = new StopRequest();
                    break;
                case MessageType.Pause:
                    request = new PauseRequest();
                    break;
                case MessageType.Resume:
                    request = new ResumeRequest();
                    break;
                case MessageType.Seek:
                    request = new SeekRequest();
                    break;
                case MessageType.Volume:
                    request = new VolumeRequest();
                    break;
                case MessageType.Termination:
                    request = new TerminationRequest();
                    break;
                case MessageType.WindowLayout:
                    request = new WindowLayoutRequest();
                    break;
                case MessageType.VideoLayout:
                    request = new VideoLayoutRequest();
                    break;
                case MessageType.SoundFx:
                    request = new SoundFxRequest();
                    break;
                case MessageType.Sound3d:
                    request = new Sound3dRequest();
                    break;
                case MessageType.MidiProperties:
                    request = new MidiPropertiesRequest();
                    break;
                case MessageType.MidiOutputPortInfo:
                    request = new MidiOutputPortInfoRequest();
                    break;
                case MessageType.SetMidiOutputPort:
                    request = new SetMidiOutputPortRequest();
                    break;
                case MessageType.SetDls:
                    request = new SetDlsRequest();
                    break;
                case MessageType.SetFrequency:
                    request = new SetFrequencyRequest();
                    break;
                case MessageType.SetRate:
                    request = new SetRateRequest();
                    break;
                case MessageType.SetPlayerType:
                    request = new SetPlayerTypeRequest();
                    break;
                default:
                    // throw exception
                    break;
            }

            return request;

        }
        #endregion
    }
}
