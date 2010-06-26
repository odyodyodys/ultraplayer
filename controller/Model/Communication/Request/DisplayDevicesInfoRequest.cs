using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;

namespace UltraPlayerController.Communication
{
    public class DisplayDevicesInfoRequest:ARequest
    {
        #region Constructors
	        public DisplayDevicesInfoRequest(): base(MessageType.DisplayDevicesInfo)
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
