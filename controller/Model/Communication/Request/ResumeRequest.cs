using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;

namespace UltraPlayerController.Communication
{
    public class ResumeRequest : ARequest
    {
        #region Constructors
	        public ResumeRequest(): base(MessageType.Resume)
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
