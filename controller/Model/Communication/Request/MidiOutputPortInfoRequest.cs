using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Communication;
using UltraPlayerController.Model.Enumerations;

namespace UltraPlayerController.Model.Communication.Request
{
    public class MidiOutputPortInfoRequest: ARequest
    {
        #region Constructors
        public MidiOutputPortInfoRequest(): base(MessageType.MidiOutputPortInfo)
        {

        }
        #endregion

        #region ARequest members
        public override string ParseToString()
        {
            return base.ParseToString();
        }
        #endregion
    }
}
