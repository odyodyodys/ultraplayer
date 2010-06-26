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
    public partial class WaveformPropertiesControl : UserControl
    {
        #region Fields
        WaveformType _waveform;

        public event Delegates.WaveformChangedEventHandler WaveformChangedEvent;

        #endregion

        #region Properties
        public WaveformType Waveform
        {
            get
            {
                return _waveform;
            }
            set
            {
                _waveform = value;
                SetWaveformToUi();
            }
        }
        #endregion

        #region Constructors
        public WaveformPropertiesControl()
        {
            InitializeComponent();
            _waveform = WaveformType.Sine;
        }
        #endregion

        #region Events
        private void RadioButtonCheckedChanged(object sender, EventArgs e)
        {
            SetWaveformFromUi();

            if (WaveformChangedEvent != null)
            {
                WaveformChangedEvent(_waveform);
            }
        }


        #endregion

        #region Methods
        private void SetWaveformFromUi()
        {
            if (SineRadioButton.Checked)
            {
                _waveform = WaveformType.Sine;
            }
            else if (SquareRadioButton.Checked)
            {
                _waveform = WaveformType.Square;
            }
            else if (TriangleRadioButton.Checked)
            {
                _waveform = WaveformType.Triangle;
            }
        }
        private void SetWaveformToUi()
        {
            switch (_waveform)
            {
                case WaveformType.Sine:
                    SineRadioButton.Checked = true;
                    break;
                case WaveformType.Square:
                    SquareRadioButton.Checked = true;
                    break;
                case WaveformType.Triangle:
                    TriangleRadioButton.Checked = true;
                    break;
                default:
                    break;
            }

            ResetDisabledTypes();
        }
        public void DisableType(WaveformType type)
        {
            switch (type)
            {
                case WaveformType.Sine:
                    SineRadioButton.Enabled = false;
                    break;
                case WaveformType.Square:
                    SquareRadioButton.Enabled = false;
                    break;
                case WaveformType.Triangle:
                    TriangleRadioButton.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void ResetDisabledTypes()
        {
            SineRadioButton.Enabled = true;
            SquareRadioButton.Enabled = true;
            TriangleRadioButton.Enabled = true;
        }
        #endregion
    }
}
