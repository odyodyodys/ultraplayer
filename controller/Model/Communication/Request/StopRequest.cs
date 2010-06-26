using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;

namespace UltraPlayerController.Communication
{
    public class StopRequest : ARequest
    {
        #region Constructors
	        public StopRequest(): base(MessageType.Stop)
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
