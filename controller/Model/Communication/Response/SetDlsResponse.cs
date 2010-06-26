using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;

namespace UltraPlayerController.Model.Communication.Response
{
    public class SetDlsResponse:AResponse
    {
        #region Constructors
        public SetDlsResponse():base(MessageType.SetDls)
        {

        }
        #endregion
    }
}
