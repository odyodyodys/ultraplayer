using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Communication;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Model.Utilities;
using UltraPlayerController.Resources.Communication;
using Utilities.Serialize;

namespace UltraPlayerController.Model.Communication.Request
{
    public class MidiPropertiesRequest : ARequest
    {
        #region Fields
        private bool _enableChorus;
        private bool _enableReverb;
        private float _tempo;
        #endregion

        #region Constructors
        public MidiPropertiesRequest()
            : base(MessageType.MidiProperties)
        {

        }
        #endregion

        #region ARequest members
        public override string ParseToString()
        {
            string result = string.Empty;

            result += base.ParseToString();

            result += ValueSerializer.DoBin(_enableReverb);
            result += ValueSerializer.DoBin(_enableChorus);
            result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, 1, _tempo);

            return result;
        }
        #endregion

        #region Properties
        public bool EnableChorus
        {
            get { return _enableChorus; }
            set { _enableChorus = value; }
        }
        public bool EnableReverb
        {
            get { return _enableReverb; }
            set { _enableReverb = value; }
        }
        public float Tempo
        {
            get { return _tempo; }
            set { _tempo = value; }
        }
        #endregion
    }
}
