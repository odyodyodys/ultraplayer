﻿using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Utilities;
using UltraPlayerController.Model.Enumerations;
using System.Collections;
using UltraPlayerController.Resources.Communication;
using Utilities.Serialize;

namespace UltraPlayerController.Model.Communication
{
    public abstract class AMessage : ISerializable
    {
        #region Fields
        protected MessageType _type;

        #endregion

        #region Constructors
        protected AMessage(MessageType type)
        {
            _type = type;
        }
        #endregion

        #region Properties
        public MessageType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
        #endregion

        #region ISerializable Members

        virtual public string ParseToString()
        {
            string request = string.Empty;

            switch (_type)
            {
                case MessageType.SetImage:
                    request = Protocol.Instance.SetImageHeader;
                    break;
                case MessageType.SetText:
                    request = Protocol.Instance.SetTextHeader;
                    break;
                case MessageType.RemoveAddon:
                    request = Protocol.Instance.RemoveAddonHeader;
                    break;
                case MessageType.Play:
                    request = Protocol.Instance.PlayHeader;
                    break;
                case MessageType.Stop:
                    request = Protocol.Instance.StopHeader;
                    break;
                case MessageType.Pause:
                    request = Protocol.Instance.PauseHeader;
                    break;
                case MessageType.Seek:
                    request = Protocol.Instance.SeekHeader;
                    break;
                case MessageType.Volume:
                    request = Protocol.Instance.VolumeHeader;
                    break;
                case MessageType.Termination:
                    request = Protocol.Instance.TerminationHeader;
                    break;
                case MessageType.WindowLayout:
                    request = Protocol.Instance.WindowLayoutHeader;
                    break;
                case MessageType.VideoLayout:
                    request = Protocol.Instance.VideoLayoutHeader;
                    break;
                case MessageType.Resume:
                    request = Protocol.Instance.ResumeHeader;
                    break;
                case MessageType.DisplayDevicesInfo:
                    request = Protocol.Instance.DisplayDevicesInfoHeader;
                    break;
                case MessageType.SoundFx:
                    request = Protocol.Instance.SoundFxHeader;
                    break;
                case MessageType.Sound3d:
                    request = Protocol.Instance.Sound3dHeader;
                    break;
                case MessageType.MidiProperties:
                    request = Protocol.Instance.MidiPropertiesHeader;
                    break;
                case MessageType.MidiOutputPortInfo:
                    request = Protocol.Instance.MidiOutputPortInfoHeader;
                    break;
                case MessageType.SetMidiOutputPort:
                    request = Protocol.Instance.SetMidiOutputPortHeader;
                    break;
                case MessageType.SetDls:
                    request = Protocol.Instance.SetDlsHeader;
                    break;
                case MessageType.SetFrequency:
                    request = Protocol.Instance.SetFrequencyHeader;
                    break;
                case MessageType.SetRate:
                    request = Protocol.Instance.SetRateHeader;
                    break;
                case MessageType.SetPlayerType:
                    request = Protocol.Instance.SetPlayerTypeHeader;
                    break;
                default:
                    //throw exception
                    break;
            }
            return request;
        }

        virtual public void ParseFromString(string textToParse)
        {
            // nothing to parse from. type is generated by response factory
        }

        #endregion

    }
}
