using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using UltraPlayerController.Model.SoundFx;
using UltraPlayerController.View.Events;
using UltraPlayerController.Model.Utilities;
using Utilities.Math;
using Utilities.Convert;

namespace UltraPlayerController.View.AudioPlayer
{
    public partial class SingleFxPropertiesControl : UserControl
    {
        #region Fields
        private ASoundFx _soundFx;
        public event Delegates.SoundFxEventHandler EffectChanged;
        #endregion

        #region Constructors
        public SingleFxPropertiesControl()
        {
            InitializeComponent();

            SetParamDetails(1, null);
            SetParamDetails(2, null);
            SetParamDetails(3, null);
            SetParamDetails(4, null);
            SetParamDetails(5, null);
            SetParamDetails(6, null);

            Param1EffectParameterValueControl.ValueChangedEvent += new Delegates.ParameterValueActionEventHandler(ParameterValueValueChangedEvent);
            Param2EffectParameterValueControl.ValueChangedEvent += new Delegates.ParameterValueActionEventHandler(ParameterValueValueChangedEvent);
            Param3EffectParameterValueControl.ValueChangedEvent += new Delegates.ParameterValueActionEventHandler(ParameterValueValueChangedEvent);
            Param4EffectParameterValueControl.ValueChangedEvent += new Delegates.ParameterValueActionEventHandler(ParameterValueValueChangedEvent);
            Param5EffectParameterValueControl.ValueChangedEvent += new Delegates.ParameterValueActionEventHandler(ParameterValueValueChangedEvent);
            Param6EffectParameterValueControl.ValueChangedEvent += new Delegates.ParameterValueActionEventHandler(ParameterValueValueChangedEvent);

            WaveformPropertiesControl.WaveformChangedEvent += new Delegates.WaveformChangedEventHandler(WaveformChangedEvent);
            PhasePropertiesControl.PhaseChangedEvent += new Delegates.PhaseChangedEventHandler(PhaseChangedEvent);
        }
        #endregion

        #region Events
        void ParameterValueValueChangedEvent(int paramId, float newValue)
        {
            switch (_soundFx.Type)
            {
                case SoundFxType.Chorus:
                    switch (paramId)
                    {
                        case 1:
                            ((ChorusSoundFx)_soundFx).WetDryMix.Value = newValue;
                            break;
                        case 2:
                            ((ChorusSoundFx)_soundFx).Depth.Value = newValue;
                            break;
                        case 3:
                            ((ChorusSoundFx)_soundFx).Feedback.Value = newValue;
                            break;
                        case 4:
                            ((ChorusSoundFx)_soundFx).Frequency.Value = newValue;
                            break;
                        case 5:
                            ((ChorusSoundFx)_soundFx).Delay.Value = newValue;
                            break;
                        default:
                            break;
                    }
                    break;
                case SoundFxType.Compressor:
                    switch (paramId)
                    {
                        case 1:
                            ((CompressorSoundFx)_soundFx).Gain.Value = newValue;
                            break;
                        case 2:
                            ((CompressorSoundFx)_soundFx).Attack.Value = newValue;
                            break;
                        case 3:
                            ((CompressorSoundFx)_soundFx).Release.Value = newValue;
                            break;
                        case 4:
                            ((CompressorSoundFx)_soundFx).Threshold.Value = newValue;
                            break;
                        case 5:
                            ((CompressorSoundFx)_soundFx).Ratio.Value = newValue;
                            break;
                        case 6:
                            ((CompressorSoundFx)_soundFx).Predelay.Value = newValue;
                            break;
                        default:
                            break;
                    }
                    break;
                case SoundFxType.Distortion:
                    switch (paramId)
                    {
                        case 1:
                            ((DistortionSoundFx)_soundFx).Gain.Value = newValue;
                            break;
                        case 2:
                            ((DistortionSoundFx)_soundFx).Edge.Value = newValue;
                            break;
                        case 3:
                            ((DistortionSoundFx)_soundFx).PostEqCenterFreq.Value = newValue;
                            break;
                        case 4:
                            ((DistortionSoundFx)_soundFx).PostEqBandwidth.Value = newValue;
                            break;
                        case 5:
                            ((DistortionSoundFx)_soundFx).PreLowpassCutoff.Value = newValue;
                            break;
                        default:
                            break;
                    }
                    break;
                case SoundFxType.Echo:
                    switch (paramId)
                    {
                        case 1:
                            ((EchoSoundFx)_soundFx).WetDryMix.Value = newValue;
                            break;
                        case 2:
                            ((EchoSoundFx)_soundFx).Feedback.Value = newValue;
                            break;
                        case 3:
                            ((EchoSoundFx)_soundFx).LeftDelay.Value = newValue;
                            break;
                        case 4:
                            ((EchoSoundFx)_soundFx).RightDelay.Value = newValue;
                            break;
                        case 5:
                            ((EchoSoundFx)_soundFx).PanDelay.Value = newValue;
                            break;
                        default:
                            break;
                    }
                    break;
                case SoundFxType.Flanger:
                    switch (paramId)
                    {
                        case 1:
                            ((FlangerSoundFx)_soundFx).WetDryMix.Value = newValue;
                            break;
                        case 2:
                            ((FlangerSoundFx)_soundFx).Depth.Value = newValue;
                            break;
                        case 3:
                            ((FlangerSoundFx)_soundFx).Feedback.Value = newValue;
                            break;
                        case 4:
                            ((FlangerSoundFx)_soundFx).Frequency.Value = newValue;
                            break;
                        case 5:
                            ((FlangerSoundFx)_soundFx).Delay.Value = newValue;
                            break;
                        default:
                            break;
                    }
                    break;
                case SoundFxType.Gargle:
                    switch (paramId)
                    {
                        case 1:
                            ((GargleSoundFx)_soundFx).Rate.Value = newValue;
                            break;
                        default:
                            break;
                    }
                    break;
                case SoundFxType.ParamEq:
                    switch (paramId)
                    {
                        case 1:
                            ((ParamEqSoundFx)_soundFx).CenterFreq.Value = newValue;
                            break;
                        case 2:
                            ((ParamEqSoundFx)_soundFx).Bandwidth.Value = newValue;
                            break;
                        case 3:
                            ((ParamEqSoundFx)_soundFx).Gain.Value = newValue;
                            break;
                        default:
                            break;
                    }
                    break;
                case SoundFxType.Reverb:
                    switch (paramId)
                    {
                        case 1:
                            ((ReverbSoundFx)_soundFx).InGain.Value = newValue;
                            break;
                        case 2:
                            ((ReverbSoundFx)_soundFx).ReverbMix.Value = newValue;
                            break;
                        case 3:
                            ((ReverbSoundFx)_soundFx).ReverbTime.Value = newValue;
                            break;
                        case 4:
                            ((ReverbSoundFx)_soundFx).HighFreqRtRatio.Value = newValue;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            // notify
            NotifySoundFxChanged();
        }

        void NotifySoundFxChanged()
        {
            if (EffectChanged != null)
            {
                EffectChanged(_soundFx);
            }
        }

        void WaveformChangedEvent(WaveformType waveform)
        {
            switch (_soundFx.Type)
            {
                case SoundFxType.Flanger:
                    ((FlangerSoundFx)_soundFx).Waveform = waveform;
                    break;
                case SoundFxType.Gargle:
                    ((GargleSoundFx)_soundFx).Waveform = waveform;
                    break;
                case SoundFxType.Chorus:
                    ((ChorusSoundFx)_soundFx).Waveform = waveform;
                    break;
                default:
                    break;
            }

            NotifySoundFxChanged();
        }

        void PhaseChangedEvent(PhaseType phase)
        {
            switch (_soundFx.Type)
            {
                case SoundFxType.Chorus:
                    ((ChorusSoundFx)_soundFx).Phase = phase;
                    break;
                case SoundFxType.Flanger:
                    ((FlangerSoundFx)_soundFx).Phase = phase;
                    break;
                default:
                    break;
            }

            NotifySoundFxChanged();
        }
        #endregion

        #region Properties
        public ASoundFx SoundFx
        {
            get
            {
                return _soundFx;
            }
            set
            {
                _soundFx = value;
                SetToUi();
            }
        }
        #endregion

        #region Methods

        private void SetToUi()
        {
            try
            {
                if (_soundFx == null)
                {
                    return;
                }

                // enable helper controls
                PhasePropertiesControl.Enabled = true;
                WaveformPropertiesControl.Enabled = true;

                switch (_soundFx.Type)
                {
                    case SoundFxType.Chorus:
                        SetChorusFxToUi();
                        break;
                    case SoundFxType.Compressor:
                        SetCompressorFxToUi();
                        break;
                    case SoundFxType.Distortion:
                        SetDistortionFxToUi();
                        break;
                    case SoundFxType.Echo:
                        SetEchoFxToUi();
                        break;
                    case SoundFxType.Flanger:
                        SetFlangerFxToUi();
                        break;
                    case SoundFxType.Gargle:
                        SetGargleFxToUi();
                        break;
                    case SoundFxType.ParamEq:
                        SetParamEqFxToUi();
                        break;
                    case SoundFxType.Reverb:
                        SetReverbFxToUi();
                        break;
                    default:
                        break;
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Cound not set to ui");
            }
        }

        private void SetReverbFxToUi()
        {
            if (_soundFx.Type != SoundFxType.Reverb)
            {
                throw new Exception("Cannot set Reverb effect details, effect is of different type");
            }

            ReverbSoundFx effect = (ReverbSoundFx)_soundFx;

            SetParamDetails(1, effect.InGain);
            SetParamDetails(2, effect.ReverbMix);
            SetParamDetails(3, effect.ReverbTime);
            SetParamDetails(4, effect.HighFreqRtRatio);
            SetParamDetails(5, null);
            SetParamDetails(6, null);

            WaveformPropertiesControl.Enabled = false;
            PhasePropertiesControl.Enabled = false;
        }

        private void SetParamEqFxToUi()
        {
            if (_soundFx.Type != SoundFxType.ParamEq)
            {
                throw new Exception("Cannot set ParamEq effect details, effect is of different type");
            }

            ParamEqSoundFx effect = (ParamEqSoundFx)_soundFx;

            SetParamDetails(1, effect.CenterFreq);
            SetParamDetails(2, effect.Bandwidth);
            SetParamDetails(3, effect.Gain);
            SetParamDetails(4, null);
            SetParamDetails(5, null);
            SetParamDetails(6, null);

            WaveformPropertiesControl.Enabled = false;
            PhasePropertiesControl.Enabled = false;
        }

        private void SetGargleFxToUi()
        {
            if (_soundFx.Type != SoundFxType.Gargle)
            {
                throw new Exception("Cannot set Gargle effect details, effect is of different type");
            }

            GargleSoundFx effect = (GargleSoundFx)_soundFx;

            SetParamDetails(1, effect.Rate);
            SetParamDetails(2, null);
            SetParamDetails(3, null);
            SetParamDetails(4, null);
            SetParamDetails(5, null);
            SetParamDetails(6, null);

            WaveformPropertiesControl.Enabled = true;
            WaveformPropertiesControl.Waveform = effect.Waveform;
            WaveformPropertiesControl.DisableType(WaveformType.Sine);

            PhasePropertiesControl.Enabled = false;

        }

        private void SetFlangerFxToUi()
        {
            if (_soundFx.Type != SoundFxType.Flanger)
            {
                throw new Exception("Cannot set Flanger effect details, effect is of different type");
            }

            FlangerSoundFx effect = (FlangerSoundFx)_soundFx;

            SetParamDetails(1, effect.WetDryMix);
            SetParamDetails(2, effect.Depth);
            SetParamDetails(3, effect.Feedback);
            SetParamDetails(4, effect.Frequency);
            SetParamDetails(5, effect.Delay);
            SetParamDetails(6, null);

            WaveformPropertiesControl.Enabled = true;
            WaveformPropertiesControl.Waveform = effect.Waveform;
            WaveformPropertiesControl.DisableType(WaveformType.Square);

            PhasePropertiesControl.Enabled = true;
            PhasePropertiesControl.Phase = effect.Phase;
        }

        private void SetEchoFxToUi()
        {
            if (_soundFx.Type != SoundFxType.Echo)
            {
                throw new Exception("Cannot set Echo effect details, effect is of different type");
            }

            EchoSoundFx effect = (EchoSoundFx)_soundFx;

            SetParamDetails(1, effect.WetDryMix);
            SetParamDetails(2, effect.Feedback);
            SetParamDetails(3, effect.LeftDelay);
            SetParamDetails(4, effect.RightDelay);
            SetParamDetails(5, effect.PanDelay);
            SetParamDetails(6, null);

            WaveformPropertiesControl.Enabled = false;
            PhasePropertiesControl.Enabled = false;
        }

        private void SetDistortionFxToUi()
        {
            if (_soundFx.Type != SoundFxType.Distortion)
            {
                throw new Exception("Cannot set Distortion effect details, effect is of different type");
            }

            DistortionSoundFx effect = (DistortionSoundFx)_soundFx;

            SetParamDetails(1, effect.Gain);
            SetParamDetails(2, effect.Edge);
            SetParamDetails(3, effect.PostEqCenterFreq);
            SetParamDetails(4, effect.PostEqBandwidth);
            SetParamDetails(5, effect.PreLowpassCutoff);
            SetParamDetails(6, null);

            WaveformPropertiesControl.Enabled = false;
            PhasePropertiesControl.Enabled = false;

        }

        private void SetCompressorFxToUi()
        {
            if (_soundFx.Type != SoundFxType.Compressor)
            {
                throw new Exception("Cannot set Compressor effect details, effect is of different type");
            }

            CompressorSoundFx effect = (CompressorSoundFx)_soundFx;

            SetParamDetails(1, effect.Gain);
            SetParamDetails(2, effect.Attack);
            SetParamDetails(3, effect.Release);
            SetParamDetails(4, effect.Threshold);
            SetParamDetails(5, effect.Ratio);
            SetParamDetails(6, effect.Predelay);
            
            WaveformPropertiesControl.Enabled = false;
            PhasePropertiesControl.Enabled = false;
        }

        private void SetChorusFxToUi()
        {
            if (_soundFx.Type != SoundFxType.Chorus)
            {
                throw new Exception("Cannot set chorus effect details, effect is of different type");
            }

            ChorusSoundFx effect = (ChorusSoundFx)_soundFx;

            SetParamDetails(1, effect.WetDryMix);
            SetParamDetails(2, effect.Depth);
            SetParamDetails(3, effect.Feedback);
            SetParamDetails(4, effect.Frequency);
            SetParamDetails(5, effect.Delay);
            SetParamDetails(6, null);

            WaveformPropertiesControl.Enabled = true;
            WaveformPropertiesControl.Waveform = effect.Waveform;
            WaveformPropertiesControl.DisableType(WaveformType.Square);

            PhasePropertiesControl.Enabled = true;
            PhasePropertiesControl.Phase = effect.Phase;

        }

        private void SetParamDetails(int paramNo, MathValue value)
        {
            try
            {
                // check if controls exist (ParamXEffectParameterValueControl)
                LabeledExtendedSliderControl control = null;
                switch (paramNo)
                {
                    case 1:
                        control = Param1EffectParameterValueControl;
                        break;
                    case 2:
                        control = Param2EffectParameterValueControl;
                        break;
                    case 3:
                        control = Param3EffectParameterValueControl;
                        break;
                    case 4:
                        control = Param4EffectParameterValueControl;
                        break;
                    case 5:
                        control = Param5EffectParameterValueControl;
                        break;
                    case 6:
                        control = Param6EffectParameterValueControl;
                        break;
                    default:
                        break;
                }

                if (value != null)
                {
                    control.ParamId = paramNo;
                    control.UpdateParameter(value.Min, value.Max, value.FriendlyName + " (" + MathUnitToStringConverter.Instance.Convert(value.Unit) + ")", value.Value, value.Step);
                }
                else
                {
                    control.ResetParameter();
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show("Cound not set param details " + e.Message);
            }

        }

        #endregion
    }
}
