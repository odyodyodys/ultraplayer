using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UltraPlayerController.Model.SoundFx;
using UltraPlayerController.View.Events;

namespace UltraPlayerController.View.AudioPlayer
{
    public partial class EffectsForm : Form
    {
        #region Fields
        public event Delegates.SoundFxEventHandler SoundFxChanged;
        public event Delegates.IntegerValueActionEventHandler FrequencyChanged;
        #endregion

        #region Constructors
        public EffectsForm()
        {
            InitializeComponent();

            SoundFxPropertiesControl.SoundFxChanged +=new Delegates.SoundFxEventHandler(OnSoundFxChanged);
            SoundFxPropertiesControl.FrequencyChanged += new Delegates.IntegerValueActionEventHandler(OnFrequencyChanged);
        }
        #endregion
        #region Events

        private void EffectsFormFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void OnFrequencyChanged(int frequency)
        {
            if (FrequencyChanged != null)
            {
                FrequencyChanged(frequency);
            }
        }
        private void OnSoundFxChanged(ASoundFx soundFx)
        {
            if (SoundFxChanged != null)
            {
                SoundFxChanged(soundFx);
            }
        }
        #endregion

        #region Methods
        public List<ASoundFx> GetEnabledEffects()
        {
            return SoundFxPropertiesControl.GetEnabledEffects();
        }
        public void LockEffects()
        {
            SoundFxPropertiesControl.LockEffects();
        }
        public void UnlockEffects()
        {
            SoundFxPropertiesControl.UnlockEffects();
        }
        #endregion
    }
}
