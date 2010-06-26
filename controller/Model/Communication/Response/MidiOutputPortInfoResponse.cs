using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Resources.Communication;

namespace UltraPlayerController.Model.Communication.Response
{
    public class MidiOutputPortInfoResponse : AResponse
    {
        #region Fields
        private List<string> _portInfoList;
        #endregion

        #region Constructors
        public MidiOutputPortInfoResponse(): base(MessageType.MidiOutputPortInfo)
        {
            _portInfoList = new List<string>();
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

            int index = (int)(Protocol.Instance.HeaderLength + Protocol.Instance.ResponseTypeLength);
            string portsText = textToParse.Substring(index);

            // change index to match portsText
            index = 0;
            int indexOfNext = 0;
            string tmpPortName;
            while (index < portsText.Length)
            {
                index += (int)Protocol.Instance.DelimiterLength;
                indexOfNext = portsText.IndexOf(Protocol.Instance.Delimiter, index);
                
                if (indexOfNext == -1)
                {
                    indexOfNext = portsText.Length;
                }

                tmpPortName = portsText.Substring(index, indexOfNext - index);

                _portInfoList.Add(tmpPortName);

                index = indexOfNext;
            }
        }

        #endregion

        #region Properties
        public List<string> PortInfoList
        {
            get { return _portInfoList; }
        }
        #endregion
    }
}
