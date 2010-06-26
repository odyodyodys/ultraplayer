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
    public partial class PhasePropertiesControl : UserControl
    {
        #region Fields
        PhaseType _phase = PhaseType.Zero;
        public event Delegates.PhaseChangedEventHandler PhaseChangedEvent;
        #endregion

        #region Properties
        public PhaseType Phase
        {
            get
            {
                return _phase;
            }
            set
            {
                _phase = value;
                SetPhaseToUi();
            }
        }
        #endregion

        #region Constructors
        public PhasePropertiesControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void RadioButtonCheckedChanged(object sender, EventArgs e)
        {
            SetPhaseFromUi();

            if (PhaseChangedEvent != null)
            {
                PhaseChangedEvent(_phase);
            }
        }
        #endregion
        #region Methods

        private void SetPhaseToUi()
        {
            switch (_phase)
            {
                case PhaseType.Minus180:
                    Minus180RadioButton.Checked = true;
                    break;
                case PhaseType.Minus90:
                    Minus90RadioButton.Checked = true;
                    break;
                case PhaseType.Zero:
                    ZeroRadioButton.Checked = true;
                    break;
                case PhaseType.Plus90:
                    Plus90RadioButton.Checked = true;
                    break;
                case PhaseType.Plus180:
                    Plus180RadioButton.Checked = true;
                    break;
                default:
                    break;
            }
        }

        private void SetPhaseFromUi()
        {
            if (Minus180RadioButton.Checked)
            {
                _phase = PhaseType.Minus180;
            }
            else if (Minus90RadioButton.Checked)
            {
                _phase = PhaseType.Minus90;
            }
            else if (ZeroRadioButton.Checked)
            {
                _phase = PhaseType.Zero;
            }
            else if (Plus90RadioButton.Checked)
            {
                _phase = PhaseType.Plus90;
            }
            else if (Plus180RadioButton.Checked)
            {
                _phase = PhaseType.Plus180;
            }
        }
        #endregion
    }
}
