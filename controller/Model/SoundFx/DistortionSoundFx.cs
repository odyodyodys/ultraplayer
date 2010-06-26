using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Resources.Communication;
using Utilities.Math;
using UltraPlayerController.Model.Utilities;
using Utilities.Serialize;

namespace UltraPlayerController.Model.SoundFx
{
    public class DistortionSoundFx : ASoundFx
    {
        #region Fields
        private MathValue _gain;
        private MathValue _edge;
        private MathValue _postEqCenterFreq;
        private MathValue _postEqBandwidth;
        private MathValue _preLowpassCutoff;
        #endregion

        #region Constructors
        public DistortionSoundFx()
            : base(SoundFxType.Distortion)
        {
            _gain = new MathValue();
            _edge = new MathValue();
            _postEqCenterFreq = new MathValue();
            _postEqBandwidth = new MathValue();
            _preLowpassCutoff = new MathValue();

            _gain.Min = -60; // DSFXDISTORTION_GAIN_MIN
            _gain.Max = 0; // DSFXDISTORTION_GAIN_MAX
            _gain.Default = -18;
            _gain.Unit = MathUnitType.db;
            _gain.FriendlyName = "Gain";
            _gain.Step = 0.1f;

            _edge.Min = 0; // DSFXDISTORTION_EDGE_MIN
            _edge.Max = 100; // DSFXDISTORTION_EDGE_MAX
            _edge.Default = 15;
            _edge.Unit = MathUnitType.percent;
            _edge.FriendlyName = "Edge";
            _edge.Step = 0.1f;

            _postEqCenterFreq.Min = 100; // DSFXDISTORTION_POSTEQCENTERFREQUENCY_MIN
            _postEqCenterFreq.Max = 8000; // DSFXDISTORTION_POSTEQCENTERFREQUENCY_MAX
            _postEqCenterFreq.Default = 2400;
            _postEqCenterFreq.Unit = MathUnitType.hz;
            _postEqCenterFreq.FriendlyName = "PostEqCenterFreq";
            _postEqCenterFreq.Step = 1;

            _postEqBandwidth.Min = 100; // DSFXDISTORTION_POSTEQBANDWIDTH_MIN
            _postEqBandwidth.Max = 8000; // DSFXDISTORTION_POSTEQBANDWIDTH_MAX
            _postEqBandwidth.Default = 2400;
            _postEqBandwidth.Unit = MathUnitType.hz;
            _postEqBandwidth.FriendlyName = "PostEqBandwidth";
            _postEqBandwidth.Step = 1;

            _preLowpassCutoff.Min = 100; // DSFXDISTORTION_PRELOWPASSCUTOFF_MIN
            _preLowpassCutoff.Max = 8000; // DSFXDISTORTION_PRELOWPASSCUTOFF_MAX
            _preLowpassCutoff.Default = 7350;
            _preLowpassCutoff.Unit = MathUnitType.hz;
            _preLowpassCutoff.FriendlyName = "PreLowpassCutoff";
            _preLowpassCutoff.Step = 1;

        }
        #endregion

        #region Properties
        public MathValue Gain
        {
            get { return _gain; }
        }
        public MathValue Edge
        {
            get { return _edge; }
        }
        public MathValue PostEqCenterFreq
        {
            get { return _postEqCenterFreq; }
        }
        public MathValue PostEqBandwidth
        {
            get { return _postEqBandwidth; }
        }
        public MathValue PreLowpassCutoff
        {
            get { return _preLowpassCutoff; }
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
                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _edge.Precision(), _edge.Value);
                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _postEqCenterFreq.Precision(), _postEqCenterFreq.Value);
                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _postEqBandwidth.Precision(), _postEqBandwidth.Value);
                result += ValueSerializer.DoFloat(Protocol.Instance.LongNumericParameterLength, _postEqCenterFreq.Precision(), _postEqCenterFreq.Value);

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
