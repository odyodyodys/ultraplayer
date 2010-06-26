using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;

namespace UltraPlayerController.Communication
{
    public class PauseRequest : ARequest
    {
        #region Constructors
	        public PauseRequest(): base(MessageType.Pause)
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
