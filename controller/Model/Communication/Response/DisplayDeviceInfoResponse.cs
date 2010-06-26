using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Resources.Communication;

namespace UltraPlayerController.Model.Communication.Response
{
    public class DisplayDeviceInfoResponse : AResponse
    {
        #region Fields
        private List<DisplayDevice> _devices;
        #endregion

        #region Constructors
        public DisplayDeviceInfoResponse()
            : base(MessageType.DisplayDevicesInfo)
        {
            _devices = new List<DisplayDevice>();
        }
        #endregion

        #region AResponse Members

        public override string ParseToString()
        {
            // no need to support deserialization
            throw new NotImplementedException();
        }

        public override void ParseFromString(string textToParse)
        {
            base.ParseFromString(textToParse);

            uint noOfDeviceParams = 5;
            int index = (int)(Protocol.Instance.HeaderLength + Protocol.Instance.ResponseTypeLength);
            string devicesText = textToParse.Substring(index);

            int numberOfDevices = (int)(devicesText.Length / (noOfDeviceParams * Protocol.Instance.NumericParameterLength));
            List<DisplayDevice> devices = new List<DisplayDevice>();
            for (int i = 0; i < numberOfDevices; i++)
            {
                DisplayDevice newDevice = new DisplayDevice();

                string deviceText = devicesText.Substring((int)(i * Protocol.Instance.NumericParameterLength * noOfDeviceParams), (int)(noOfDeviceParams * Protocol.Instance.NumericParameterLength));

                int internalIndex = 0;

                // parse monitor Id
                newDevice.MonitorId = uint.Parse(deviceText.Substring(internalIndex, (int)(Protocol.Instance.NumericParameterLength)));
                internalIndex += (int)(Protocol.Instance.NumericParameterLength);

                // parse layout
                Layout newLayout = new Layout();
                newLayout.OriginX = int.Parse(deviceText.Substring(internalIndex, (int)(Protocol.Instance.NumericParameterLength)));
                internalIndex += (int)(Protocol.Instance.NumericParameterLength);
                newLayout.OriginY = int.Parse(deviceText.Substring(internalIndex, (int)(Protocol.Instance.NumericParameterLength)));
                internalIndex += (int)(Protocol.Instance.NumericParameterLength);
                newLayout.SizeX = int.Parse(deviceText.Substring(internalIndex, (int)(Protocol.Instance.NumericParameterLength)));
                internalIndex += (int)(Protocol.Instance.NumericParameterLength);
                newLayout.SizeY = int.Parse(deviceText.Substring(internalIndex, (int)(Protocol.Instance.NumericParameterLength)));

                newDevice.Layout = newLayout;

                _devices.Add(newDevice);


            }


        }

        #endregion

        #region Properties
        public List<DisplayDevice> Devices
        {
            get
            {
                return _devices;
            }
        }
        #endregion

    }
}
