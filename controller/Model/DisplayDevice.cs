using System;
using System.Collections.Generic;
using System.Text;

namespace UltraPlayerController.Model
{
    public class DisplayDevice
    {
        #region Fields
        private uint _deviceId;
        private uint _monitorId;
        private Layout _layout;
        #endregion

        #region Properties
        public uint DeviceId
        {
            set
            {
                _deviceId = value;
            }
            get
            {
                return _deviceId;
            }
        }
        public uint MonitorId
        {
            set
            {
                _monitorId = value;
            }
            get
            {
                return _monitorId;
            }
        }
        public Layout Layout
        {
            set
            {
                _layout = value;
            }
            get
            {
                return _layout;
            }
        }
        #endregion

        #region Properties
        // convert to ui friendly string
        public string UiFriendlyString()
        {
            return _monitorId.ToString() + ": " + _layout.SizeX.ToString() + "x" + _layout.SizeY.ToString();
        }
        #endregion
    }
}
