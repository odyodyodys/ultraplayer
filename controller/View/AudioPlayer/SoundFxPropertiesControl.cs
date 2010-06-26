using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using UltraPlayerController.Model.SoundFx;
using UltraPlayerController.View.Events;

namespace UltraPlayerController.View.AudioPlayer
{
    public partial class SoundFxPropertiesControl : UserControl
    {
        #region Fields
        private ChorusSoundFx _chorus;
        private CompressorSoundFx _compressor;
        private DistortionSoundFx _distortion;
        private EchoSoundFx _echo;
        private FlangerSoundFx _flanger;
        private GargleSoundFx _gargle;
        private ParamEqSoundFx _paramEq;
        private ReverbSoundFx _reverb;

        public event Delegates.SoundFxEventHandler SoundFxChanged;
        public event Delegates.IntegerValueActionEventHandler FrequencyChanged;
        #endregion

        #region Constructors
        public SoundFxPropertiesControl()
        {
            InitializeComponent();

            try
            {
                _chorus = new ChorusSoundFx(); ;
                _compressor = new CompressorSoundFx();
                _distortion = new DistortionSoundFx();
                _echo = new EchoSoundFx();
                _flanger = new FlangerSoundFx();
                _gargle = new GargleSoundFx();
                _paramEq = new ParamEqSoundFx();
                _reverb = new ReverbSoundFx();

                FxPropertiesControl.EffectChanged += new Delegates.SoundFxEventHandler(FxPropertiesControlEffectChanged);

                FrequencyParameterValueControl.UpdateParameter(100, 100000, "Frequency", 50000, 1);
                FrequencyParameterValueControl.ValueChangedEvent += new Delegates.ParameterValueActionEventHandler(OnFrequencyValueChangedEvent);
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion

        #region Methods
        private void ShowSoundFxProperties(SoundFxType soundFxType)
        {
            switch (soundFxType)
            {
                case SoundFxType.Chorus:
                    FxPropertiesControl.SoundFx = _chorus;
                    break;
                case SoundFxType.Compressor:
                    FxPropertiesControl.SoundFx = _compressor;
                    break;
                case SoundFxType.Distortion:
                    FxPropertiesControl.SoundFx = _distortion;
                    break;
                case SoundFxType.Echo:
                    FxPropertiesControl.SoundFx = _echo;
                    break;
                case SoundFxType.Flanger:
                    FxPropertiesControl.SoundFx = _flanger;
                    break;
                case SoundFxType.Gargle:
                    FxPropertiesControl.SoundFx = _gargle;
                    break;
                case SoundFxType.ParamEq:
                    FxPropertiesControl.SoundFx = _paramEq;
                    break;
                case SoundFxType.Reverb:
                    FxPropertiesControl.SoundFx = _reverb;
                    break;
                default:
                    break;
            }
        }

        public List<ASoundFx> GetEnabledEffects()
        {
            List<ASoundFx> effects = new List<ASoundFx>();
            if (EnableChorusCheckbox.Checked)
            {
                effects.Add(_chorus);
            }
            if (EnableCompressorCheckbox.Checked)
            {
                effects.Add(_compressor);
            }
            if (EnableDistortionCheckbox.Checked)
            {
                effects.Add(_distortion);
            }
            if (EnableEchoCheckbox.Checked)
            {
                effects.Add(_echo);
            }
            if (EnableFlangerCheckbox.Checked)
            {
                effects.Add(_flanger);
            }
            if (EnableGargleCheckbox.Checked)
            {
                effects.Add(_gargle);
            }
            if (EnableParamEqCheckbox.Checked)
            {
                effects.Add(_paramEq);
            }
            if (EnableReverbCheckbox.Checked)
            {
                effects.Add(_reverb);
            }

            return effects;
        }

        public void LockEffects()
        {
            // Disable checkboxes
            EnableChorusCheckbox.Enabled = false;
            EnableCompressorCheckbox.Enabled = false;
            EnableDistortionCheckbox.Enabled = false;
            EnableEchoCheckbox.Enabled = false;
            EnableFlangerCheckbox.Enabled = false;
            EnableGargleCheckbox.Enabled = false;
            EnableParamEqCheckbox.Enabled = false;
            EnableReverbCheckbox.Enabled = false;
        }
        public void UnlockEffects()
        {
            //Enable checkboxes
            EnableChorusCheckbox.Enabled = true;
            EnableCompressorCheckbox.Enabled = true;
            EnableDistortionCheckbox.Enabled = true;
            EnableEchoCheckbox.Enabled = true;
            EnableFlangerCheckbox.Enabled = true;
            EnableGargleCheckbox.Enabled = true;
            EnableParamEqCheckbox.Enabled = true;
            EnableReverbCheckbox.Enabled = true;
        }
        #endregion


        #region Events
        private void OnFrequencyValueChangedEvent(int paramId, float newValue)
        {
            if (FrequencyChanged != null)
            {
                FrequencyChanged((int)newValue);
            }
        }
        private void AdjustChorusRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            ShowSoundFxProperties(SoundFxType.Chorus);
        }
        private void AdjustCompressorRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            ShowSoundFxProperties(SoundFxType.Compressor);
        }

        private void AdjustDistortionRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            ShowSoundFxProperties(SoundFxType.Distortion);
        }

        private void AdjustEchoRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            ShowSoundFxProperties(SoundFxType.Echo);
        }

        private void AdjustFlangerRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            ShowSoundFxProperties(SoundFxType.Flanger);
        }

        private void AdjustGargleRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            ShowSoundFxProperties(SoundFxType.Gargle);
        }

        private void AdjustRadioButtonParamEqCheckedChanged(object sender, EventArgs e)
        {
            ShowSoundFxProperties(SoundFxType.ParamEq);
        }

        private void AdjustReverbRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            ShowSoundFxProperties(SoundFxType.Reverb);
        }

        private void FxPropertiesControlEffectChanged(ASoundFx soundFx)
        {
            // forward event
            if (SoundFxChanged != null)
            {
                SoundFxChanged(soundFx);
            }
        }
        #endregion

    }
}
