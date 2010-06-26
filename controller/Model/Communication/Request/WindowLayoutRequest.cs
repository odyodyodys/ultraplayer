using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Model;
using UltraPlayerController.Resources.Communication;
using UltraPlayerController.Model.Utilities;
using Utilities.Serialize;

namespace UltraPlayerController.Communication
{
    public class WindowLayoutRequest : ARequest
    {
        #region Fields
        private uint _monitorId;
        private Layout _layout;
        #endregion

        #region Constructors
        public WindowLayoutRequest(): base(MessageType.WindowLayout)
        {

        }
        #endregion

        #region ARequest Methods
        public override string ParseToString()
        {
            // get header
            string request = base.ParseToString();

            // add monitor id
            request += ValueSerializer.DoInt(Protocol.Instance.NumericParameterLength, (int)_monitorId);

            // add layout part
            request += _layout.ParseToString();

            return request;
        }
        #endregion

        #region Properties
        public uint MonitorId
        {
            set { _monitorId = value; }
        }
        public Layout Layout
        {
            set { _layout = value; }
        }
        #endregion

    }
}
