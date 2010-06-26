using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Resources.Communication;
using Utilities.Math;
using UltraPlayerController.Model.Utilities;
using Utilities.Serialize;

namespace UltraPlayerController.Model.SoundFx
{
    public class ReverbSoundFx : ASoundFx
    {
        #region Fields
        private MathValue _inGain;
        private MathValue _reverbMix;
        private MathValue _reverbTime;
        private MathValue _highFreqRtRatio;
        #endregion

        #region Constructors
        public ReverbSoundFx()
            : base(SoundFxType.Reverb)
        {
            _inGain = new MathValue();
            _reverbMix = new MathValue();
            _reverbTime = new MathValue();
            _highFreqRtRatio = new MathValue();

            _inGain.Min = -96; // DSFX_WAVESREVERB_INGAIN_MIN
            _inGain.Max = 0; // DSFX_WAVESREVERB_INGAIN_MAX
            _inGain.Default = 0; 
            _inGain.Unit = MathUnitType.db ;
            _inGain.FriendlyName = "In Gain";
            _inGain.Step = 0.1f;

            _reverbMix.Min = -96; // DSFX_WAVESREVERB_REVERBMIX_MIN
            _reverbMix.Max = 0; // DSFX_WAVESREVERB_REVERBMIX_MAX
            _reverbMix.Default = 0; 
            _reverbMix.Unit = MathUnitType.db ;
            _reverbMix.FriendlyName = "Reverb Mix";
            _reverbMix.Step = 0.1f;

            _reverbTime.Min = 0; // DSFX_WAVESREVERB_REVERBTIME_MIN
            _reverbTime.Max = 3000; // DSFX_WAVESREVERB_REVERBTIME_MAX
            _reverbTime.Default = 1000; 
            _reverbTime.Unit = MathUnitType.ms ;
            _reverbTime.FriendlyName = "Reverb Time";
            _reverbTime.Step = 0.1f;

            _highFreqRtRatio.Min = 0; // DSFX_WAVESREVERB_HIGHFREQRTRATIO_MIN
            _highFreqRtRatio.Max = 1; // DSFX_WAVESREVERB_HIGHFREQRTRATIO_MAX
            _highFreqRtRatio.Default = 0; 
            _highFreqRtRatio.Unit = MathUnitType.ratio ;
            _highFreqRtRatio.FriendlyName = "HighFreq RT Ratio";
            _highFreqRtRatio.Step = 0.1f;

        }
        #endregion

        #region Properties

        public MathValue InGain
        {
            get { return _inGain; }
            set { _inGain = value; }
        }
        public MathValue ReverbMix
        {
            get { return _reverbMix; }
            set { _reverbMix = value; }
        }
        public MathValue ReverbTime
        {
            get { return _reverbTime; }
            set { _reverbTime = value; }
        }
        public MathValue HighFreqRtRatio
        {
            get { return _highFreqRtRatio; }
            set { _highFreqRtRatio = value; }
        }
        #endregion

        #region ASoundFx Members

        public override string ParseToString()
        {
            string result = string.Empty;

            try
            {
                result += base.ParseToString();

                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _inGain.Precision(), _inGain.Value);
                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _reverbMix.Precision(), _reverbMix.Value);
                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _reverbTime.Precision(), _reverbTime.Value);
                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _highFreqRtRatio.Precision(), _highFreqRtRatio.Value);
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
