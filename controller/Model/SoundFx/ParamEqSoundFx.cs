using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Resources.Communication;
using Utilities.Math;
using UltraPlayerController.Model.Utilities;
using Utilities.Serialize;

namespace UltraPlayerController.Model.SoundFx
{
    public class ParamEqSoundFx : ASoundFx
    {
        #region Fields
        private MathValue _centerFreq;
        private MathValue _bandwidth;
        private MathValue _gain;
        #endregion

        #region Constructors
        public ParamEqSoundFx() : base(SoundFxType.ParamEq)
        {
            _centerFreq = new MathValue();
            _bandwidth = new MathValue();
            _gain = new MathValue();

            _centerFreq.Min = 80; // DSFXPARAMEQ_CENTER_MIN
            _centerFreq.Max = 16000; // DSFXPARAMEQ_CENTER_MAX
            _centerFreq.Default = 7350; 
            _centerFreq.Unit = MathUnitType.hz ;
            _centerFreq.FriendlyName = "Center Freq";
            _centerFreq.Step = 0.1f;

            _bandwidth.Min = 1; // DSFXPARAMEQ_BANDWIDTH_MIN
            _bandwidth.Max = 36; // DSFXPARAMEQ_BANDWIDTH_MAX
            _bandwidth.Default = 12; 
            _bandwidth.Unit = MathUnitType.hz ;
            _bandwidth.FriendlyName = "Bandwidth";
            _bandwidth.Step = 0.1f;

            _gain.Min = -15; // DSFXPARAMEQ_GAIN_MIN
            _gain.Max = 15; // DSFXPARAMEQ_GAIN_MAX
            _gain.Default = 0; 
            _gain.Unit = MathUnitType.db ;
            _gain.FriendlyName = "Gain";
            _gain.Step = 0.1f;
        }
        #endregion

        #region Properties

        public MathValue CenterFreq
        {
            get { return _centerFreq; }
            set { _centerFreq = value; }
        }
        public MathValue Bandwidth
        {
            get { return _bandwidth; }
            set { _bandwidth = value; }
        }
        public MathValue Gain
        {
            get { return _gain; }
            set { _gain = value; }
        }
        #endregion

        #region ASoundFx Members

        public override string ParseToString()
        {
            string result = string.Empty;

            try
            {
                result += base.ParseToString();

                string positiveNumericFormat = new string('0', (int)Protocol.Instance.LongNumericParameterLength);
                string negativeNumericFormat = new string('0', (int)Protocol.Instance.LongNumericParameterLength - 1);

                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _centerFreq.Precision(), _centerFreq.Value);
                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _bandwidth.Precision(), _bandwidth.Value);
                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _gain.Precision(), _gain.Value);

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
