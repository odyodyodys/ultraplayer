using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Communication;
using UltraPlayerController.Model.Enumerations;

namespace UltraPlayerController.Model.Communication.Request
{
    public class SetMidiOutputPortRequest : ARequest
    {
        #region Fields
        private string _portDescription;
        #endregion

        #region Constructors
        public SetMidiOutputPortRequest(): base(MessageType.SetMidiOutputPort)
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
                request += _portDescription;
            }
            catch (System.Exception )
            {

            }
            return request;
        }
        #endregion
        #region Properties

        public string PortDescription
        {
            get { return _portDescription; }
            set { _portDescription = value; }
        }
        #endregion
    }
}
