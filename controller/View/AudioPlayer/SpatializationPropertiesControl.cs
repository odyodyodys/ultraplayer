using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using UltraPlayerController.View.Events;
using UltraPlayerController.Model;

namespace UltraPlayerController.View.AudioPlayer
{
    public partial class SpatializationPropertiesControl : UserControl
    {
        #region Fields
        public event Delegates.Sound3dEventHandler Sound3dChanged;
        private Sound3d _sound3dProperties;
        #endregion

        #region Constructors
        public SpatializationPropertiesControl()
        {
            InitializeComponent();

            _sound3dProperties = new Sound3d();

            // Sound properties
            DopplerFactorParameterValueControl.UpdateParameter(0, 10, "Doppler Factor", _sound3dProperties.DoplerFactor, 0.1f);
            RolloffParameterValueControl.UpdateParameter(0, 10, "Rolloff Factor", _sound3dProperties.RolloffFactor, 0.1f);
            MinDistanceParameterValueControl.UpdateParameter(0, 100, "Min Distance", _sound3dProperties.MinDistance, 0.01f);
            MaxDistanceParameterValueControl.UpdateParameter(0, 100, "Min Distance", _sound3dProperties.MaxDistance, 0.01f);
            DopplerFactorParameterValueControl.ValueChangedEvent += new Delegates.ParameterValueActionEventHandler(DopplerFactorValueChangedEvent);
            RolloffParameterValueControl.ValueChangedEvent += new Delegates.ParameterValueActionEventHandler(RolloffValueChangedEvent);
            MinDistanceParameterValueControl.ValueChangedEvent += new Delegates.ParameterValueActionEventHandler(MinDistanceValueChangedEvent);
            MaxDistanceParameterValueControl.ValueChangedEvent += new Delegates.ParameterValueActionEventHandler(MaxDistanceValueChangedEvent);

            // Sound position
            SourceXParameterValueControl.UpdateParameter(-5, 5, "Source X", 5, 0.1f);
            SourceYParameterValueControl.UpdateParameter(-5, 5, "Source Y", 0, 0.1f);
            SourceZParameterValueControl.UpdateParameter(-5, 5, "Source Z", 5, 0.1f);
            SourceXParameterValueControl.ValueChangedEvent += new Delegates.ParameterValueActionEventHandler(SourceXValueChangedEvent);
            SourceYParameterValueControl.ValueChangedEvent += new Delegates.ParameterValueActionEventHandler(SourceYValueChangedEvent);
            SourceZParameterValueControl.ValueChangedEvent += new Delegates.ParameterValueActionEventHandler(SourceZValueChangedEvent);

        }
        #endregion

        #region Events
        private void DopplerFactorValueChangedEvent(int paramId, float value)
        {
            _sound3dProperties.DoplerFactor = value;
            OnSound3dValueChanged();
        }
        private void RolloffValueChangedEvent(int paramId, float value)
        {
            _sound3dProperties.RolloffFactor = value;
            OnSound3dValueChanged();
        }
        private void MinDistanceValueChangedEvent(int paramId, float value)
        {
            _sound3dProperties.MinDistance = value;
            OnSound3dValueChanged();
        }
        private void MaxDistanceValueChangedEvent(int paramId, float value)
        {
            _sound3dProperties.MaxDistance = value;
            OnSound3dValueChanged();
        }

        private void SourceXValueChangedEvent(int paramId, float value)
        {
            _sound3dProperties.SourceX = value;
            OnSound3dValueChanged();
        }
        private void SourceYValueChangedEvent(int paramId, float value)
        {
            _sound3dProperties.SourceY = value;
            OnSound3dValueChanged();
        }
        private void SourceZValueChangedEvent(int paramId, float value)
        {
            _sound3dProperties.SourceZ = value;
            OnSound3dValueChanged();
        }

        private void OnSound3dValueChanged()
        {
            // fire event
            if (Sound3dChanged != null)
            {
                Sound3dChanged(_sound3dProperties);
            }
        }

        #endregion
    }
}
