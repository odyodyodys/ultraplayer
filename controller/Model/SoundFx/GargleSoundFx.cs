using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Resources.Communication;
using Utilities.Math;
using UltraPlayerController.Model.Utilities;
using Utilities.Serialize;

namespace UltraPlayerController.Model.SoundFx
{
    public class GargleSoundFx : ASoundFx
    {
        #region Fields
        private WaveformType _waveform;

        private MathValue _rate;
        #endregion

        #region Constructors
        public GargleSoundFx() : base(SoundFxType.Gargle)
        {
            _rate = new MathValue();

            _rate.Min = 0; // DSFXGARGLE_RATEHZ_MIN
            _rate.Max = 1000; // DSFXGARGLE_RATEHZ_MAX
            _rate .Default = 20; 
            _rate .Unit = MathUnitType.hz ;
            _rate.FriendlyName = "Rate";
            _rate.Step = 0.1f;

            _waveform = WaveformType.Triangle;

        }
        #endregion

        #region Properties
        public MathValue Rate
        {
            get { return _rate; }
        }

        public WaveformType Waveform
        {
            set
            {
                if (value == WaveformType.Sine)
                {
                    throw new ArgumentException("Cannot accept sine waveform");
                }

                _waveform = value;
            }
            get
            {
                return _waveform;
            }
        }

        #endregion

        #region ASoundFx Members

        public override string ParseToString()
        {
            string result = string.Empty;

            try
            {
                result += base.ParseToString();

                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _rate.Precision(), _rate.Value);

                WaveformToStringConverter waveConverter = new WaveformToStringConverter();
                result += waveConverter.Convert(_waveform);

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
