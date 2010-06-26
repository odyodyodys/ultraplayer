using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Communication;
using UltraPlayerController.Resources.Communication;
using UltraPlayerController.Model.Utilities;
using Utilities.Serialize;

namespace UltraPlayerController.Model.Communication.Request
{
    class RemoveAddonRequest : ARequest
    {
        #region Fields
        private uint _addonId;
        #endregion

        #region Constructors
        public RemoveAddonRequest(): base(MessageType.RemoveAddon)
        {

        }
        #endregion

        #region ARequest members
        public override string ParseToString()
        {
            string request = string.Empty;

            try
            {
                request += base.ParseToString();

                request += ValueSerializer.DoInt(Protocol.Instance.NumericParameterLength, (int)_addonId);
            }
            catch (System.Exception)
            {
            	
            }
            return request;
        }
        #endregion

#region Properties
	public uint AddonId
    {
        set
        {
            _addonId = value;
        }
    }
#endregion
    }
}
