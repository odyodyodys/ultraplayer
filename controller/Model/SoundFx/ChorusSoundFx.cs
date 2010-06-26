using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Resources.Communication;
using Utilities.Math;
using UltraPlayerController.Model.Utilities;
using Utilities.Serialize;

namespace UltraPlayerController.Model.SoundFx
{
    public class ChorusSoundFx : ASoundFx
    {
        #region Fields
        private MathValue _wetDryMix;
        private MathValue _depth;
        private MathValue _feedback;
        private MathValue _frequency;
        private MathValue _delay;
        private WaveformType _waveform;
        private PhaseType _phase;
        #endregion

        #region Constructors
        public ChorusSoundFx() : base(SoundFxType.Chorus)
        {
            _wetDryMix = new MathValue();
            _depth = new MathValue();
            _feedback = new MathValue();
            _frequency = new MathValue();
            _delay = new MathValue();

            _wetDryMix.Min = 0; // DSFXCHORUS_WETDRYMIX_MIN
            _wetDryMix.Max = 100; // DSFXCHORUS_WETDRYMIX_MAX
            _wetDryMix.Default = 50;
            _wetDryMix.Unit = MathUnitType.percent;
            _wetDryMix.FriendlyName = "Wet/Dry mix";
            _wetDryMix.Step = 0.1f;

            _depth.Min = 0; // DSFXCHORUS_DEPTH_MIN
            _depth.Max = 100; // DSFXCHORUS_DEPTH_MAX
            _depth.Default = 10;
            _depth.Unit = MathUnitType.percent;
            _depth.FriendlyName = "Depth";
            _depth.Step = 0.1f;


            _feedback.Min = -99; // DSFXCHORUS_FEEDBACK_MIN
            _feedback.Max = 99; // DSFXCHORUS_FEEDBACK_MAX
            _feedback.Default = 25;
            _feedback.Unit = MathUnitType.percent;
            _feedback.FriendlyName = "Feedback";
            _feedback.Step = 0.1f;

            _frequency.Min = 0; // DSFXCHORUS_FREQUENCY_MIN
            _frequency.Max = 10; // DSFXCHORUS_FREQUENCY_MAX
            _frequency.Default = 1.1f;
            _frequency.Unit = MathUnitType.hz;
            _frequency.FriendlyName = "Frequency";
            _frequency.Step = 0.1f;

            _delay.Min = 0; // DSFXCHORUS_DELAY_MIN
            _delay.Max = 20; // DSFXCHORUS_DELAY_MAX
            _delay.Default = 16;
            _delay.Unit = MathUnitType.ms;
            _delay.FriendlyName = "Delay";
            _delay.Step = 0.1f;

            _waveform = WaveformType.Sine;
            _phase = PhaseType.Plus90;
        }
        #endregion

        #region Properties
        public WaveformType Waveform
        {
            get { return _waveform; }
            set
            {
                // validate
                if (value == WaveformType.Square)
                {
                    throw new ArgumentException("Cannot accept square waveform");
                }
                _waveform = value; 
            }
        }
        public PhaseType Phase
        {
            get { return _phase; }
            set { _phase = value; }
        }
        public MathValue WetDryMix
        {
            get { return _wetDryMix; }
        }
        public MathValue Depth
        {
            get { return _depth; }
        }
        public MathValue Feedback
        {
            get { return _feedback; }
        }
        public MathValue Frequency
        {
            get { return _frequency; }
        }
        public MathValue Delay
        {
            get { return _delay; }
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
                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _depth.Precision(), _depth.Value);
                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _feedback.Precision(), _feedback.Value);
                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _frequency.Precision(), _frequency.Value);
                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _delay.Precision(), _delay.Value);
                
                WaveformToStringConverter waveConverter = new WaveformToStringConverter();
                result += waveConverter.Convert(_waveform);

                PhaseTypeToStringConverter phaseConverter = new PhaseTypeToStringConverter();
                result += phaseConverter.Convert(_phase);

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
