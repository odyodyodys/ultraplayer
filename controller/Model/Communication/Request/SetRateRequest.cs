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
    public class SetRateRequest : ARequest
    {
        #region Fields
        private float _rate;

        #endregion

        #region Constructors
        public SetRateRequest() : base(MessageType.SetRate)
        {

        }
        #endregion

        #region Properties
        public float Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }
        #endregion

        #region ARequest members
        public override string ParseToString()
        {
            string request = base.ParseToString();

            request += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, 2, _rate);

            return request;
        }
        #endregion
    }
}
