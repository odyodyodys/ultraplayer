using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Communication;
using UltraPlayerController.Model.Enumerations;

namespace UltraPlayerController.Model.Communication.Request
{
    public class SetDlsRequest : ARequest
    {
        #region Fields
        private string _dlsFile;
        #endregion

        #region Constructors
        public SetDlsRequest(): base(MessageType.SetDls)
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
                request += _dlsFile;
            }
            catch (System.Exception)
            {

            }
            return request;
        }
        #endregion

        #region Properties
        public string DlsFile
        {
            get { return _dlsFile; }
            set { _dlsFile = value; }
        }
        #endregion
    }
}
