using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Communication;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Model.Utilities;
using UltraPlayerController.Resources.Communication;
using Utilities.Serialize;

namespace UltraPlayerController.Model.Communication.Request
{
    public class SetFrequencyRequest : ARequest
    {
        #region Fields
        private int _frequency;
        #endregion

        #region Constructors
        public SetFrequencyRequest(): base(MessageType.SetFrequency)
        {

        }
        #endregion

        #region ARequest members
        public override string ParseToString()
        {
            string request = string.Empty;
            try
            {
                request += base.ParseToString();
                request += ValueSerializer.DoInt(Protocol.Instance.LongNumericParameterLength, _frequency);
            }
            catch (System.Exception)
            {

            }
            return request;
        }
        #endregion

        #region Properties

        public int Frequency
        {
            get { return _frequency; }
            set { _frequency = value; }
        }
        #endregion
    }
}
