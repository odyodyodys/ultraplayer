namespace UltraPlayerController.View.AudioPlayer
{
    partial class SingleFxPropertiesControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WaveformGroupBox = new System.Windows.Forms.GroupBox();
            this.WaveformPropertiesControl = new UltraPlayerController.View.AudioPlayer.WaveformPropertiesControl();
            this.PhaseGroupBox = new System.Windows.Forms.GroupBox();
            this.PhasePropertiesControl = new UltraPlayerController.View.AudioPlayer.PhasePropertiesControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Param6EffectParameterValueControl = new UltraPlayerController.View.AudioPlayer.LabeledExtendedSliderControl();
            this.Param4EffectParameterValueControl = new UltraPlayerController.View.AudioPlayer.LabeledExtendedSliderControl();
            this.Param2EffectParameterValueControl = new UltraPlayerController.View.AudioPlayer.LabeledExtendedSliderControl();
            this.Param5EffectParameterValueControl = new UltraPlayerController.View.AudioPlayer.LabeledExtendedSliderControl();
            this.Param3EffectParameterValueControl = new UltraPlayerController.View.AudioPlayer.LabeledExtendedSliderControl();
            this.Param1EffectParameterValueControl = new UltraPlayerController.View.AudioPlayer.LabeledExtendedSliderControl();
            this.WaveformGroupBox.SuspendLayout();
            this.PhaseGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // WaveformGroupBox
            // 
            this.WaveformGroupBox.Controls.Add(this.WaveformPropertiesControl);
            this.WaveformGroupBox.Location = new System.Drawing.Point(3, 371);
            this.WaveformGroupBox.Name = "WaveformGroupBox";
            this.WaveformGroupBox.Size = new System.Drawing.Size(189, 43);
            this.WaveformGroupBox.TabIndex = 2;
            this.WaveformGroupBox.TabStop = false;
            this.WaveformGroupBox.Text = "Waveform";
            // 
            // WaveformPropertiesControl
            // 
            this.WaveformPropertiesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WaveformPropertiesControl.Location = new System.Drawing.Point(3, 16);
            this.WaveformPropertiesControl.Name = "WaveformPropertiesControl";
            this.WaveformPropertiesControl.Size = new System.Drawing.Size(183, 24);
            this.WaveformPropertiesControl.TabIndex = 0;
            this.WaveformPropertiesControl.Waveform = UltraPlayerController.Model.SoundFx.WaveformType.Sine;
            // 
            // PhaseGroupBox
            // 
            this.PhaseGroupBox.Controls.Add(this.PhasePropertiesControl);
            this.PhaseGroupBox.Location = new System.Drawing.Point(198, 371);
            this.PhaseGroupBox.Name = "PhaseGroupBox";
            this.PhaseGroupBox.Size = new System.Drawing.Size(231, 43);
            this.PhaseGroupBox.TabIndex = 3;
            this.PhaseGroupBox.TabStop = false;
            this.PhaseGroupBox.Text = "Phase (Degrees)";
            // 
            // PhasePropertiesControl
            // 
            this.PhasePropertiesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PhasePropertiesControl.Location = new System.Drawing.Point(3, 16);
            this.PhasePropertiesControl.Name = "PhasePropertiesControl";
            this.PhasePropertiesControl.Phase = UltraPlayerController.Model.SoundFx.PhaseType.Minus180;
            this.PhasePropertiesControl.Size = new System.Drawing.Size(225, 24);
            this.PhasePropertiesControl.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(189, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Min";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(330, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Max";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Param6EffectParameterValueControl
            // 
            this.Param6EffectParameterValueControl.Location = new System.Drawing.Point(55, 314);
            this.Param6EffectParameterValueControl.MinimumSize = new System.Drawing.Size(231, 51);
            this.Param6EffectParameterValueControl.Name = "Param6EffectParameterValueControl";
            this.Param6EffectParameterValueControl.ParamId = -1;
            this.Param6EffectParameterValueControl.Size = new System.Drawing.Size(323, 51);
            this.Param6EffectParameterValueControl.TabIndex = 5;
            this.Param6EffectParameterValueControl.Value = 0F;
            // 
            // Param4EffectParameterValueControl
            // 
            this.Param4EffectParameterValueControl.Location = new System.Drawing.Point(55, 200);
            this.Param4EffectParameterValueControl.MinimumSize = new System.Drawing.Size(231, 51);
            this.Param4EffectParameterValueControl.Name = "Param4EffectParameterValueControl";
            this.Param4EffectParameterValueControl.ParamId = -1;
            this.Param4EffectParameterValueControl.Size = new System.Drawing.Size(323, 51);
            this.Param4EffectParameterValueControl.TabIndex = 5;
            this.Param4EffectParameterValueControl.Value = 0F;
            // 
            // Param2EffectParameterValueControl
            // 
            this.Param2EffectParameterValueControl.Location = new System.Drawing.Point(55, 86);
            this.Param2EffectParameterValueControl.MinimumSize = new System.Drawing.Size(231, 51);
            this.Param2EffectParameterValueControl.Name = "Param2EffectParameterValueControl";
            this.Param2EffectParameterValueControl.ParamId = -1;
            this.Param2EffectParameterValueControl.Size = new System.Drawing.Size(323, 51);
            this.Param2EffectParameterValueControl.TabIndex = 5;
            this.Param2EffectParameterValueControl.Value = 0F;
            // 
            // Param5EffectParameterValueControl
            // 
            this.Param5EffectParameterValueControl.Location = new System.Drawing.Point(55, 257);
            this.Param5EffectParameterValueControl.MinimumSize = new System.Drawing.Size(231, 51);
            this.Param5EffectParameterValueControl.Name = "Param5EffectParameterValueControl";
            this.Param5EffectParameterValueControl.ParamId = -1;
            this.Param5EffectParameterValueControl.Size = new System.Drawing.Size(323, 51);
            this.Param5EffectParameterValueControl.TabIndex = 5;
            this.Param5EffectParameterValueControl.Value = 0F;
            // 
            // Param3EffectParameterValueControl
            // 
            this.Param3EffectParameterValueControl.Location = new System.Drawing.Point(55, 143);
            this.Param3EffectParameterValueControl.MinimumSize = new System.Drawing.Size(231, 51);
            this.Param3EffectParameterValueControl.Name = "Param3EffectParameterValueControl";
            this.Param3EffectParameterValueControl.ParamId = -1;
            this.Param3EffectParameterValueControl.Size = new System.Drawing.Size(323, 51);
            this.Param3EffectParameterValueControl.TabIndex = 5;
            this.Param3EffectParameterValueControl.Value = 0F;
            // 
            // Param1EffectParameterValueControl
            // 
            this.Param1EffectParameterValueControl.Location = new System.Drawing.Point(55, 29);
            this.Param1EffectParameterValueControl.MinimumSize = new System.Drawing.Size(231, 51);
            this.Param1EffectParameterValueControl.Name = "Param1EffectParameterValueControl";
            this.Param1EffectParameterValueControl.ParamId = -1;
            this.Param1EffectParameterValueControl.Size = new System.Drawing.Size(323, 51);
            this.Param1EffectParameterValueControl.TabIndex = 5;
            this.Param1EffectParameterValueControl.Value = 0F;
            // 
            // SingleFxPropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Param6EffectParameterValueControl);
            this.Controls.Add(this.Param4EffectParameterValueControl);
            this.Controls.Add(this.Param2EffectParameterValueControl);
            this.Controls.Add(this.Param5EffectParameterValueControl);
            this.Controls.Add(this.Param3EffectParameterValueControl);
            this.Controls.Add(this.Param1EffectParameterValueControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PhaseGroupBox);
            this.Controls.Add(this.WaveformGroupBox);
            this.Name = "SingleFxPropertiesControl";
            this.Size = new System.Drawing.Size(432, 420);
            this.WaveformGroupBox.ResumeLayout(false);
            this.PhaseGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WaveformPropertiesControl WaveformPropertiesControl;
        private PhasePropertiesControl PhasePropertiesControl;
        private System.Windows.Forms.GroupBox WaveformGroupBox;
        private System.Windows.Forms.GroupBox PhaseGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private LabeledExtendedSliderControl Param1EffectParameterValueControl;
        private LabeledExtendedSliderControl Param2EffectParameterValueControl;
        private LabeledExtendedSliderControl Param3EffectParameterValueControl;
        private LabeledExtendedSliderControl Param4EffectParameterValueControl;
        private LabeledExtendedSliderControl Param5EffectParameterValueControl;
        private LabeledExtendedSliderControl Param6EffectParameterValueControl;
    }
}
