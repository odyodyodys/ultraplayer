using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Resources.Communication;

namespace UltraPlayerController.Communication
{
    public class PlayRequest : ARequest
    {
        #region Fields
        private List<string> _tracks;
        #endregion

        #region Constructors
        public PlayRequest()
            : base(MessageType.Play)
        {
        }
        #endregion

        #region Properties
        public List<string> Tracks
        {
            set
            {
                _tracks = value;
            }
        }
        #endregion

        #region ARequest members
        public override string ParseToString()
        {
            string request = base.ParseToString();

            for (int i = 0; i < _tracks.Count; i++)
            {
                string tmpRequest = Protocol.Instance.Delimiter;
                tmpRequest += string.Format("{0:00}", i);
                tmpRequest += _tracks[i];

                request += tmpRequest;
            }

            return request;
        }
        #endregion




    }
}
