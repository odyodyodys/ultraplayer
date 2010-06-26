using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;

namespace UltraPlayerController.Communication
{
    public class TerminationRequest:ARequest
    {
        #region Constructors
	        public TerminationRequest(): base(MessageType.Termination)
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
