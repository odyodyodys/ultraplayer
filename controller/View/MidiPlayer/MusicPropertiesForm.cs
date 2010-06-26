using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UltraPlayerController.View.Events;
using UltraPlayerController.Model;

namespace UltraPlayerController.View.MidiPlayer
{
    public partial class MusicPropertiesForm : Form
    {
        #region Fields
        private float _tempo;
        private bool _isReverbEnabled;
        private bool _isChorusEnabled;
        private Sound3d _soundSourcePosition;
        private List<string> _midiOutputPortList;
        private string _dlsFile;
        public event Delegates.ActionEventHandler UpdateMidiOutputPortsEvent;
        public event Delegates.TextChangedEventHandler SelectedMidiOutputPortChangedEvent;
        public event Delegates.ActionEventHandler MidiPropertiesChangedEvent;
        public event Delegates.Sound3dEventHandler Sound3dChangedEvent;
        public event Delegates.TextChangedEventHandler DlsFileChangedEvent;
        #endregion

        #region Constructors
        public MusicPropertiesForm()
        {
            InitializeComponent();

            _soundSourcePosition = new Sound3d();

            // Sound position
            TempoParameterValueControl.UpdateParameter(0.1f, 10, "Tempo", 1, 0.1f);
            SourceXParameterValueControl.UpdateParameter(-5, 5, "Source X", 5, 0.1f);
            SourceYParameterValueControl.UpdateParameter(-5, 5, "Source Y", 0, 0.1f);
            SourceZParameterValueControl.UpdateParameter(-5, 5, "Source Z", 5, 0.1f);
            TempoParameterValueControl.ValueChangedEvent += new Delegates.ParameterValueActionEventHandler(TempoValueChangedEvent);
            SourceXParameterValueControl.ValueChangedEvent += new Delegates.ParameterValueActionEventHandler(SourceXValueChangedEvent);
            SourceYParameterValueControl.ValueChangedEvent += new Delegates.ParameterValueActionEventHandler(SourceYValueChangedEvent);
            SourceZParameterValueControl.ValueChangedEvent += new Delegates.ParameterValueActionEventHandler(SourceZValueChangedEvent);
            
        }
        #endregion

        #region Events
        private void TempoValueChangedEvent(int paramId, float value)
        {
            _tempo = value;

            if (MidiPropertiesChangedEvent != null)
            {
                MidiPropertiesChangedEvent();
            }
        }
        private void MusicPropertiesFormFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
        private void SourceXValueChangedEvent(int paramId, float value)
        {
            _soundSourcePosition.SourceX = value;
            OnSoundPositionChanged();
        }

        private void OnSoundPositionChanged()
        {
            if (Sound3dChangedEvent != null)
            {
                Sound3dChangedEvent(_soundSourcePosition);
            }
        }
        private void SourceYValueChangedEvent(int paramId, float value)
        {
            _soundSourcePosition.SourceY = value;
            OnSoundPositionChanged();
        }
        private void SourceZValueChangedEvent(int paramId, float value)
        {
            _soundSourcePosition.SourceZ = value;
            OnSoundPositionChanged();
        }
        private void OutputPortUpdateButtonClick(object sender, EventArgs e)
        {
            if (UpdateMidiOutputPortsEvent != null)
            {
                UpdateMidiOutputPortsEvent();
            }
        }

        private void ChorusEffectCheckboxCheckedChanged(object sender, EventArgs e)
        {
            _isChorusEnabled = ChorusEffectCheckbox.Checked;

            if (MidiPropertiesChangedEvent != null)
            {
                MidiPropertiesChangedEvent();
            }
        }

        private void ReverbEffectCheckboxCheckedChanged(object sender, EventArgs e)
        {
            _isReverbEnabled = ReverbEffectCheckbox.Checked;

            if (MidiPropertiesChangedEvent != null)
            {
                MidiPropertiesChangedEvent();
            }
        }

        private void OutputPortComboboxSelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedMidiOutputPortChangedEvent != null)
            {
                SelectedMidiOutputPortChangedEvent(OutputPortCombobox.Items[OutputPortCombobox.SelectedIndex].ToString());
            }
        }

        private void DlsBrowseButtonClick(object sender, EventArgs e)
        {
            if (DlsFileOpenFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            _dlsFile = DlsFileOpenFileDialog.FileName;
            
            DlsFileTextBox.Text = _dlsFile;
            if (DlsFileChangedEvent != null)
            {
                DlsFileChangedEvent(_dlsFile);
            }
        }
        #endregion

        #region Properties
        public float Tempo
        {
            get { return _tempo; }
        }
        public bool IsReverbEnabled
        {
            get { return _isReverbEnabled; }
        }
        public bool IsChorusEnabled
        {
            get { return _isChorusEnabled; }
        }
        public Sound3d SoundSourcePosition
        {
            get { return _soundSourcePosition; }
        }
        public List<string> MidiOutputPortList
        {
            set
            {
                _midiOutputPortList = value;
                OutputPortCombobox.Items.Clear();
                foreach (string portDescription in _midiOutputPortList)
                {
                    OutputPortCombobox.Items.Add(portDescription);
                }
            }
        }
        public string DlsFile
        {
            get { return _dlsFile; }
            set
            {
                _dlsFile = value;
                DlsFileTextBox.Text = _dlsFile;
            }
        }
        #endregion
    }
}
