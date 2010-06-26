using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Resources.Communication;
using Utilities.Math;
using UltraPlayerController.Model.Utilities;
using Utilities.Serialize;

namespace UltraPlayerController.Model.SoundFx
{
    public class CompressorSoundFx : ASoundFx
    {
        #region Fields
        private MathValue _gain;
        private MathValue _attack;
        private MathValue _release;
        private MathValue _threshold;
        private MathValue _ratio;
        private MathValue _predelay;
        #endregion

        #region Constructors
        public CompressorSoundFx() : base(SoundFxType.Compressor)
        {
         _gain = new MathValue();
         _attack = new MathValue();
         _release = new MathValue();
         _threshold = new MathValue();
         _ratio = new MathValue();
         _predelay = new MathValue();

            _gain.Min = -60; // DSFXCOMPRESSOR_GAIN_MIN
            _gain.Max = 60; // DSFXCOMPRESSOR_GAIN_MAX
            _gain.Default = 0; 
            _gain.Unit = MathUnitType.db ;
            _gain.FriendlyName = "Gain";
            _gain.Step = 0.1f;

            _attack.Min = 0; // DSFXCOMPRESSOR_ATTACK_MIN
            _attack.Max = 500; // DSFXCOMPRESSOR_ATTACK_MAX
            _attack.Default = 10; 
            _attack.Unit = MathUnitType.ms ;
            _attack.FriendlyName = "Attack";
            _attack.Step = 0.1f;

            _release.Min = 50; // DSFXCOMPRESSOR_RELEASE_MIN
            _release.Max = 3000; // DSFXCOMPRESSOR_RELEASE_MAX
            _release.Default = 200; 
            _release.Unit = MathUnitType.ms ;
            _release.FriendlyName = "Release";
            _release.Step = 0.1f;

            _threshold.Min = -60; // DSFXCOMPRESSOR_THRESHOLD_MIN
            _threshold.Max = 0; // DSFXCOMPRESSOR_THRESHOLD_MAX
            _threshold.Default = -20; 
            _threshold.Unit = MathUnitType.db ;
            _threshold.FriendlyName = "Threshold";
            _threshold.Step = 0.1f;

            _ratio.Min = 1; // DSFXCOMPRESSOR_RATIO_MIN
            _ratio.Max = 100; // DSFXCOMPRESSOR_RATIO_MAX
            _ratio.Default = 3; 
            _ratio.Unit = MathUnitType.ratio ;
            _ratio.FriendlyName = "Ratio";
            _ratio.Step = 0.1f;

            _predelay.Min = 0; // DSFXCOMPRESSOR_PREDELAY_MIN
            _predelay.Max = 4; // DSFXCOMPRESSOR_PREDELAY_MAX
            _predelay.Default = 4; 
            _predelay.Unit = MathUnitType.ms ;
            _predelay.FriendlyName = "Predelay";
            _predelay.Step = 0.01f;
        }
        #endregion

        #region Properties
        public MathValue Gain
        {
            get { return _gain; }
        }
        public MathValue Attack
        {
            get { return _attack; }
        }
        public MathValue Release
        {
            get { return _release; }
        }
        public MathValue Threshold
        {
            get { return _threshold; }
        }
        public MathValue Ratio
        {
            get { return _ratio; }
        }
        public MathValue Predelay
        {
            get { return _predelay; }
        }
        #endregion

        #region ASoundFx Members

        public override string ParseToString()
        {
            string result = string.Empty;

            try
            {
                result += base.ParseToString();

                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _gain.Precision(), _gain.Value);
                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _attack.Precision(), _attack.Value);
                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _release.Precision(), _release.Value);
                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _threshold.Precision(), _threshold.Value);
                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _ratio.Precision(), _ratio.Value);
                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _predelay.Precision(), _predelay.Value);

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
