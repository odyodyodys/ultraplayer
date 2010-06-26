using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Model.Utilities;
using UltraPlayerController.Resources.Communication;
using Utilities.Serialize;

namespace UltraPlayerController.Communication
{
    public class SeekRequest : ARequest
    {
        #region Fields
        private int _seekTime; // milliseconds
        #endregion

        #region Properties
        public int SeekTime
        {
            set
            {
                _seekTime = value;
            }
            get
            {
                return _seekTime;
            }
        }
        #endregion

        #region Constructors
        public SeekRequest(): base(MessageType.Seek)
        {

        }
        #endregion

        #region ARequest members
        public override string ParseToString()
        {
            string request = base.ParseToString();

            request += ValueSerializer.DoInt(Protocol.Instance.NumericParameterLength, _seekTime);

            return request;
        }
        #endregion
    }
}