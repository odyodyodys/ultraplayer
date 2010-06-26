using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Model.Exceptions;
using Utilities.Pattern;
using Utilities.Convert;

namespace UltraPlayerController.Model.Utilities
{
    public class PlayerTypeToStringConverter: IConverter<PlayerType, string>
    {
        private string _audioPlayerTypeText;
        private string _midiPlayerTypeText;
        private string _singlePlayerTypeText;
        private string _multyPlayerTypeText;

	#region Constructors
        private PlayerTypeToStringConverter()
        {
            _audioPlayerTypeText = "aud";
            _midiPlayerTypeText = "mid";
            _singlePlayerTypeText = "svi";
            _multyPlayerTypeText = "mvi";
        }
        public static PlayerTypeToStringConverter Instance
        {
            get
            {
                return Singleton<PlayerTypeToStringConverter>.Instance;
            }
        }
	#endregion

        #region IConverter<PlayerType,string> Members

        public PlayerType Convert(string data)
        {
            throw new NotImplementedException();
        }

        public string Convert(PlayerType data)
        {
            string result = string.Empty;
            switch (data)
            {
                case PlayerType.SingleMedia:
                    result = _singlePlayerTypeText;
                    break;
                case PlayerType.MultiMedia:
                    result = _multyPlayerTypeText;
                    break;
                case PlayerType.Audio:
                    result = _audioPlayerTypeText;
                    break;
                case PlayerType.Midi:
                    result = _midiPlayerTypeText;
                    break;
                default:
                    break;
            }
            return result;
        }

        #endregion
    }
}
