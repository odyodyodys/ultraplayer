using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using UltraPlayerController.View.Events;

namespace UltraPlayerController.View.CommonControls
{
    public partial class PlaybackPropertiesControl : UserControl
    {
        #region Fields
        public event Delegates.SwitchOptionChangedEventHandler RepeatStateChangedEvent;
        public event Delegates.SwitchOptionChangedEventHandler ShuffleStateChangedEvent;
        public event Delegates.ParameterValueActionEventHandler RateChangedEvent;
        #endregion

        #region Constructors
        public PlaybackPropertiesControl()
        {
            InitializeComponent();
            RateSliderControl.UpdateParameter(0.01f, 10.0f, "Tempo", 1.0f, 0.01f);
            RateSliderControl.ValueChangedEvent +=new Delegates.ParameterValueActionEventHandler(OnRateValueChangedEvent);
        }
        #endregion

        #region Events
        private void RepeatCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (RepeatStateChangedEvent != null)
            {
                RepeatStateChangedEvent(RepeatCheckBox.Checked);
            }
        }

        private void ShuffleCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (ShuffleStateChangedEvent != null)
            {
                ShuffleStateChangedEvent(ShuffleCheckBox.Checked);
            }
        }
        private void OnRateValueChangedEvent(int paramId, float value)
        {
            if (RateChangedEvent != null)
            {
                RateChangedEvent(paramId, value);
            }
        }
        #endregion
    }
}
