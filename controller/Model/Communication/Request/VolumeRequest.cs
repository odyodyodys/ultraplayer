using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Model.Utilities;
using UltraPlayerController.Resources.Communication;
using Utilities.Serialize;

namespace UltraPlayerController.Communication
{
    public class VolumeRequest: ARequest
    {
        #region Fields
        	private int _volume;
        #endregion
#region Properties
	
	        public int Volume
	        {
	            set
	            {
	                _volume = value;
	            }
	        }
#endregion

        #region Constructors
	        public VolumeRequest():base(MessageType.Volume)
	        {
	
	        }
        #endregion

            #region ARequest members
            public override string ParseToString()
            {
                string request = base.ParseToString();

                request += ValueSerializer.DoInt(Protocol.Instance.NumericParameterLength, _volume);

                return request;
            }
            #endregion

    }
}
