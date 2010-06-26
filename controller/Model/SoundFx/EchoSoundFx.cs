using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Resources.Communication;
using Utilities.Math;
using UltraPlayerController.Model.Utilities;
using Utilities.Serialize;

namespace UltraPlayerController.Model.SoundFx
{
    public class EchoSoundFx : ASoundFx
    {
        #region Fields
        private MathValue _wetDryMix;
        private MathValue _feedback;
        private MathValue _leftDelay;
        private MathValue _rightDelay;
        private MathValue _panDelay;
        #endregion

        #region Constructors
        public EchoSoundFx()
            : base(SoundFxType.Echo)
        {
            _wetDryMix = new MathValue();
         _feedback = new MathValue();
         _leftDelay = new MathValue();
         _rightDelay = new MathValue();
         _panDelay = new MathValue();

         _wetDryMix.Min = 0; // DSFXECHO_WETDRYMIX_MIN
         _wetDryMix.Max = 100; // DSFXECHO_WETDRYMIX_MAX
            _wetDryMix.Default = 50; 
            _wetDryMix.Unit = MathUnitType.percent ;
            _wetDryMix.FriendlyName = "WetDryMix";
            _wetDryMix.Step = 0.1f;

            _feedback.Min = 0; // DSFXECHO_FEEDBACK_MIN
            _feedback.Max = 100; // DSFXECHO_FEEDBACK_MAX
            _feedback.Default = 50; 
            _feedback.Unit = MathUnitType.percent ;
            _feedback.FriendlyName = "Feedback";
            _feedback.Step = 0.1f;

            _leftDelay.Min = 1; // DSFXECHO_LEFTDELAY_MIN
            _leftDelay.Max = 2000; // DSFXECHO_LEFTDELAY_MAX
            _leftDelay.Default = 500; 
            _leftDelay.Unit = MathUnitType.ms ;
            _leftDelay.FriendlyName = "LeftDelay";
            _leftDelay.Step = 0.1f;

            _rightDelay.Min = 1; // DSFXECHO_RIGHTDELAY_MIN
            _rightDelay.Max = 2000; // DSFXECHO_RIGHTDELAY_MAX
            _rightDelay.Default = 500; 
            _rightDelay.Unit = MathUnitType.ms ;
            _rightDelay.FriendlyName = "RightDelay";
            _rightDelay.Step = 0.1f;

            _panDelay.Min = 0; // DSFXECHO_PANDELAY_MIN
            _panDelay.Max = 1; // DSFXECHO_PANDELAY_MAX
            _panDelay.Default = 0; 
            _panDelay.Unit = MathUnitType.boolean ;
            _panDelay.FriendlyName = "PanDelay";
            _panDelay.Step = 0.1f;

        }
        #endregion

        #region Properties

        public MathValue WetDryMix
        {
            get { return _wetDryMix; }
            set { _wetDryMix = value; }
        }
        public MathValue Feedback
        {
            get { return _feedback; }
            set { _feedback = value; }
        }
        public MathValue LeftDelay
        {
            get { return _leftDelay; }
            set { _leftDelay = value; }
        }
        public MathValue RightDelay
        {
            get { return _rightDelay; }
            set { _rightDelay = value; }
        }
        public MathValue PanDelay
        {
            get { return _panDelay; }
            set { _panDelay = value; }
        }
        #endregion

        #region ASoundFx Members

        public override string ParseToString()
        {
            string result = string.Empty;

            try
            {
                result += base.ParseToString();

                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _wetDryMix.Precision(), _wetDryMix.Value);
                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _feedback.Precision(), _feedback.Value);
                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _leftDelay.Precision(), _leftDelay.Value);
                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _rightDelay.Precision(), _rightDelay.Value);
                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _panDelay.Precision(), _panDelay.Value);

            }
            catch (System.Exception)
            {
                // throw
            }

            return result;
        }

        public override void ParseFromString(string textToParse)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
