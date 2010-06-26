using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Utilities;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Model.Communication;

namespace UltraPlayerController.Communication
{
    public abstract class ARequest : AMessage
    {
        protected ARequest(MessageType type):base(type)
        {
        }

        #region AMessage Members

        public override string ParseToString()
        {
            return base.ParseToString();
        }

        public override void ParseFromString(string textToParse)
        {
            //no need to support deserialization
            throw new NotImplementedException();
        }

        #endregion
    }
}
