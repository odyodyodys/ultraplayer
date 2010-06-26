using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;

namespace UltraPlayerController.Model.Communication.Response
{
    public class SetFrequencyResponse : AResponse
    {
        #region Constructors
        public SetFrequencyResponse(): base(MessageType.SetFrequency)
        {

        }
        #endregion
    }
}
