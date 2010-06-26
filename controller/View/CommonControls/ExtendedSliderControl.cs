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
    public partial class ExtendedSliderControl : UserControl
    {

        #region Fields
        private float _min;
        private float _max;
        private string _friendlyName;
        private float _value;
        private float _step;
        private int _paramId;
        public event Delegates.ParameterValueActionEventHandler ValueChangedEvent;
        #endregion

        #region Constructors
        public ExtendedSliderControl()
        {
            InitializeComponent();
            _paramId = -1;

        }
        #endregion

        #region Methods
        public void UpdateParameter(float min, float max, string friendlyName, float value, float step)
        {
            _min = min;
            _max = max;
            _friendlyName = friendlyName;
            _value = value;
            _step = step;

            ApplyValuesToUi();

        }

        private void ApplyValuesToUi()
        {
            ParamValueLabel.Text = (_value).ToString();
            ParamTrackBar.Minimum = (int)(_min / _step);
            ParamTrackBar.Maximum = (int)(_max / _step);
            ParamTrackBar.Value = (int)(_value / _step);
        }
        internal void ResetParameter()
        {
            ParamValueLabel.Text = "---";
            ParamTrackBar.Minimum = 0;
            ParamTrackBar.Maximum = 0;
            ParamTrackBar.Value = 0;
        }

        #endregion

        #region Properties
        public float Value
        {
            get { return (_value*_step); }
            set { _value = value; }
        }
        public int ParamId
        {
            get { return _paramId; }
            set { _paramId = value; }
        }
        #endregion


        #region Events
	    private void ParamTrackBarScroll(object sender, EventArgs e)
        {
            ParamValueLabel.Text = (ParamTrackBar.Value * _step).ToString();
            _value = ParamTrackBar.Value;

            if (ValueChangedEvent != null)
            {
                ValueChangedEvent(_paramId, Value);
            }
        }
        #endregion
    }
}
