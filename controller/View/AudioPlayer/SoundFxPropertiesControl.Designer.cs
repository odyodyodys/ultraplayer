namespace UltraPlayerController.View.AudioPlayer
{
    partial class SoundFxPropertiesControl
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
            this.FxPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.SoundFxListGroupBox = new System.Windows.Forms.GroupBox();
            this.AdjustReverbRadioButton = new System.Windows.Forms.RadioButton();
            this.AdjustGargleRadioButton = new System.Windows.Forms.RadioButton();
            this.AdjustEchoRadioButton = new System.Windows.Forms.RadioButton();
            this.AdjustCompressorRadioButton = new System.Windows.Forms.RadioButton();
            this.AdjustRadioButtonParamEq = new System.Windows.Forms.RadioButton();
            this.AdjustFlangerRadioButton = new System.Windows.Forms.RadioButton();
            this.AdjustDistortionRadioButton = new System.Windows.Forms.RadioButton();
            this.EnableReverbCheckbox = new System.Windows.Forms.CheckBox();
            this.AdjustChorusRadioButton = new System.Windows.Forms.RadioButton();
            this.EnableGargleCheckbox = new System.Windows.Forms.CheckBox();
            this.EnableEchoCheckbox = new System.Windows.Forms.CheckBox();
            this.EnableParamEqCheckbox = new System.Windows.Forms.CheckBox();
            this.EnableCompressorCheckbox = new System.Windows.Forms.CheckBox();
            this.EnableFlangerCheckbox = new System.Windows.Forms.CheckBox();
            this.EnableDistortionCheckbox = new System.Windows.Forms.CheckBox();
            this.EnableChorusCheckbox = new System.Windows.Forms.CheckBox();
            this.AdjustSoundFxLabel = new System.Windows.Forms.Label();
            this.EnableSoundFxLabel = new System.Windows.Forms.Label();
            this.PlaybackPropertiesGroupbox = new System.Windows.Forms.GroupBox();
            this.FrequencyParameterValueControl = new UltraPlayerController.View.AudioPlayer.LabeledExtendedSliderControl();
            this.FxPropertiesControl = new UltraPlayerController.View.AudioPlayer.SingleFxPropertiesControl();
            this.FxPropertiesGroupBox.SuspendLayout();
            this.SoundFxListGroupBox.SuspendLayout();
            this.PlaybackPropertiesGroupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // FxPropertiesGroupBox
            // 
            this.FxPropertiesGroupBox.Controls.Add(this.FxPropertiesControl);
            this.FxPropertiesGroupBox.Location = new System.Drawing.Point(260, 2);
            this.FxPropertiesGroupBox.Name = "FxPropertiesGroupBox";
            this.FxPropertiesGroupBox.Size = new System.Drawing.Size(437, 436);
            this.FxPropertiesGroupBox.TabIndex = 1;
            this.FxPropertiesGroupBox.TabStop = false;
            this.FxPropertiesGroupBox.Text = "Parameters for: ";
            // 
            // SoundFxListGroupBox
            // 
            this.SoundFxListGroupBox.Controls.Add(this.AdjustReverbRadioButton);
            this.SoundFxListGroupBox.Controls.Add(this.AdjustGargleRadioButton);
            this.SoundFxListGroupBox.Controls.Add(this.AdjustEchoRadioButton);
            this.SoundFxListGroupBox.Controls.Add(this.AdjustCompressorRadioButton);
            this.SoundFxListGroupBox.Controls.Add(this.AdjustRadioButtonParamEq);
            this.SoundFxListGroupBox.Controls.Add(this.AdjustFlangerRadioButton);
            this.SoundFxListGroupBox.Controls.Add(this.AdjustDistortionRadioButton);
            this.SoundFxListGroupBox.Controls.Add(this.EnableReverbCheckbox);
            this.SoundFxListGroupBox.Controls.Add(this.AdjustChorusRadioButton);
            this.SoundFxListGroupBox.Controls.Add(this.EnableGargleCheckbox);
            this.SoundFxListGroupBox.Controls.Add(this.EnableEchoCheckbox);
            this.SoundFxListGroupBox.Controls.Add(this.EnableParamEqCheckbox);
            this.SoundFxListGroupBox.Controls.Add(this.EnableCompressorCheckbox);
            this.SoundFxListGroupBox.Controls.Add(this.EnableFlangerCheckbox);
            this.SoundFxListGroupBox.Controls.Add(this.EnableDistortionCheckbox);
            this.SoundFxListGroupBox.Controls.Add(this.EnableChorusCheckbox);
            this.SoundFxListGroupBox.Controls.Add(this.AdjustSoundFxLabel);
            this.SoundFxListGroupBox.Controls.Add(this.EnableSoundFxLabel);
            this.SoundFxListGroupBox.Location = new System.Drawing.Point(3, 3);
            this.SoundFxListGroupBox.Name = "SoundFxListGroupBox";
            this.SoundFxListGroupBox.Size = new System.Drawing.Size(251, 261);
            this.SoundFxListGroupBox.TabIndex = 2;
            this.SoundFxListGroupBox.TabStop = false;
            this.SoundFxListGroupBox.Text = "Sound Effects";
            // 
            // AdjustReverbRadioButton
            // 
            this.AdjustReverbRadioButton.AutoSize = true;
            this.AdjustReverbRadioButton.Location = new System.Drawing.Point(121, 212);
            this.AdjustReverbRadioButton.Name = "AdjustReverbRadioButton";
            this.AdjustReverbRadioButton.Size = new System.Drawing.Size(60, 17);
            this.AdjustReverbRadioButton.TabIndex = 2;
            this.AdjustReverbRadioButton.Text = "Reverb";
            this.AdjustReverbRadioButton.UseVisualStyleBackColor = true;
            this.AdjustReverbRadioButton.CheckedChanged += new System.EventHandler(this.AdjustReverbRadioButtonCheckedChanged);
            // 
            // AdjustGargleRadioButton
            // 
            this.AdjustGargleRadioButton.AutoSize = true;
            this.AdjustGargleRadioButton.Location = new System.Drawing.Point(121, 168);
            this.AdjustGargleRadioButton.Name = "AdjustGargleRadioButton";
            this.AdjustGargleRadioButton.Size = new System.Drawing.Size(56, 17);
            this.AdjustGargleRadioButton.TabIndex = 2;
            this.AdjustGargleRadioButton.Text = "Gargle";
            this.AdjustGargleRadioButton.UseVisualStyleBackColor = true;
            this.AdjustGargleRadioButton.CheckedChanged += new System.EventHandler(this.AdjustGargleRadioButtonCheckedChanged);
            // 
            // AdjustEchoRadioButton
            // 
            this.AdjustEchoRadioButton.AutoSize = true;
            this.AdjustEchoRadioButton.Location = new System.Drawing.Point(121, 124);
            this.AdjustEchoRadioButton.Name = "AdjustEchoRadioButton";
            this.AdjustEchoRadioButton.Size = new System.Drawing.Size(50, 17);
            this.AdjustEchoRadioButton.TabIndex = 2;
            this.AdjustEchoRadioButton.Text = "Echo";
            this.AdjustEchoRadioButton.UseVisualStyleBackColor = true;
            this.AdjustEchoRadioButton.CheckedChanged += new System.EventHandler(this.AdjustEchoRadioButtonCheckedChanged);
            // 
            // AdjustCompressorRadioButton
            // 
            this.AdjustCompressorRadioButton.AutoSize = true;
            this.AdjustCompressorRadioButton.Location = new System.Drawing.Point(121, 80);
            this.AdjustCompressorRadioButton.Name = "AdjustCompressorRadioButton";
            this.AdjustCompressorRadioButton.Size = new System.Drawing.Size(80, 17);
            this.AdjustCompressorRadioButton.TabIndex = 2;
            this.AdjustCompressorRadioButton.Text = "Compressor";
            this.AdjustCompressorRadioButton.UseVisualStyleBackColor = true;
            this.AdjustCompressorRadioButton.CheckedChanged += new System.EventHandler(this.AdjustCompressorRadioButtonCheckedChanged);
            // 
            // AdjustRadioButtonParamEq
            // 
            this.AdjustRadioButtonParamEq.AutoSize = true;
            this.AdjustRadioButtonParamEq.Location = new System.Drawing.Point(121, 190);
            this.AdjustRadioButtonParamEq.Name = "AdjustRadioButtonParamEq";
            this.AdjustRadioButtonParamEq.Size = new System.Drawing.Size(68, 17);
            this.AdjustRadioButtonParamEq.TabIndex = 2;
            this.AdjustRadioButtonParamEq.Text = "ParamEq";
            this.AdjustRadioButtonParamEq.UseVisualStyleBackColor = true;
            this.AdjustRadioButtonParamEq.CheckedChanged += new System.EventHandler(this.AdjustRadioButtonParamEqCheckedChanged);
            // 
            // AdjustFlangerRadioButton
            // 
            this.AdjustFlangerRadioButton.AutoSize = true;
            this.AdjustFlangerRadioButton.Location = new System.Drawing.Point(121, 146);
            this.AdjustFlangerRadioButton.Name = "AdjustFlangerRadioButton";
            this.AdjustFlangerRadioButton.Size = new System.Drawing.Size(60, 17);
            this.AdjustFlangerRadioButton.TabIndex = 2;
            this.AdjustFlangerRadioButton.Text = "Flanger";
            this.AdjustFlangerRadioButton.UseVisualStyleBackColor = true;
            this.AdjustFlangerRadioButton.CheckedChanged += new System.EventHandler(this.AdjustFlangerRadioButtonCheckedChanged);
            // 
            // AdjustDistortionRadioButton
            // 
            this.AdjustDistortionRadioButton.AutoSize = true;
            this.AdjustDistortionRadioButton.Location = new System.Drawing.Point(121, 102);
            this.AdjustDistortionRadioButton.Name = "AdjustDistortionRadioButton";
            this.AdjustDistortionRadioButton.Size = new System.Drawing.Size(69, 17);
            this.AdjustDistortionRadioButton.TabIndex = 2;
            this.AdjustDistortionRadioButton.Text = "Distortion";
            this.AdjustDistortionRadioButton.UseVisualStyleBackColor = true;
            this.AdjustDistortionRadioButton.CheckedChanged += new System.EventHandler(this.AdjustDistortionRadioButtonCheckedChanged);
            // 
            // EnableReverbCheckbox
            // 
            this.EnableReverbCheckbox.AutoSize = true;
            this.EnableReverbCheckbox.Location = new System.Drawing.Point(41, 212);
            this.EnableReverbCheckbox.Name = "EnableReverbCheckbox";
            this.EnableReverbCheckbox.Size = new System.Drawing.Size(32, 17);
            this.EnableReverbCheckbox.TabIndex = 1;
            this.EnableReverbCheckbox.Text = "  ";
            this.EnableReverbCheckbox.UseVisualStyleBackColor = true;
            // 
            // AdjustChorusRadioButton
            // 
            this.AdjustChorusRadioButton.AutoSize = true;
            this.AdjustChorusRadioButton.Location = new System.Drawing.Point(121, 58);
            this.AdjustChorusRadioButton.Name = "AdjustChorusRadioButton";
            this.AdjustChorusRadioButton.Size = new System.Drawing.Size(58, 17);
            this.AdjustChorusRadioButton.TabIndex = 2;
            this.AdjustChorusRadioButton.Text = "Chorus";
            this.AdjustChorusRadioButton.CheckedChanged += new System.EventHandler(this.AdjustChorusRadioButtonCheckedChanged);
            // 
            // EnableGargleCheckbox
            // 
            this.EnableGargleCheckbox.AutoSize = true;
            this.EnableGargleCheckbox.Location = new System.Drawing.Point(41, 168);
            this.EnableGargleCheckbox.Name = "EnableGargleCheckbox";
            this.EnableGargleCheckbox.Size = new System.Drawing.Size(32, 17);
            this.EnableGargleCheckbox.TabIndex = 1;
            this.EnableGargleCheckbox.Text = "  ";
            this.EnableGargleCheckbox.UseVisualStyleBackColor = true;
            // 
            // EnableEchoCheckbox
            // 
            this.EnableEchoCheckbox.AutoSize = true;
            this.EnableEchoCheckbox.Location = new System.Drawing.Point(41, 124);
            this.EnableEchoCheckbox.Name = "EnableEchoCheckbox";
            this.EnableEchoCheckbox.Size = new System.Drawing.Size(32, 17);
            this.EnableEchoCheckbox.TabIndex = 1;
            this.EnableEchoCheckbox.Text = "  ";
            this.EnableEchoCheckbox.UseVisualStyleBackColor = true;
            // 
            // EnableParamEqCheckbox
            // 
            this.EnableParamEqCheckbox.AutoSize = true;
            this.EnableParamEqCheckbox.Location = new System.Drawing.Point(41, 190);
            this.EnableParamEqCheckbox.Name = "EnableParamEqCheckbox";
            this.EnableParamEqCheckbox.Size = new System.Drawing.Size(32, 17);
            this.EnableParamEqCheckbox.TabIndex = 1;
            this.EnableParamEqCheckbox.Text = "  ";
            this.EnableParamEqCheckbox.UseVisualStyleBackColor = true;
            // 
            // EnableCompressorCheckbox
            // 
            this.EnableCompressorCheckbox.AutoSize = true;
            this.EnableCompressorCheckbox.Location = new System.Drawing.Point(41, 80);
            this.EnableCompressorCheckbox.Name = "EnableCompressorCheckbox";
            this.EnableCompressorCheckbox.Size = new System.Drawing.Size(32, 17);
            this.EnableCompressorCheckbox.TabIndex = 1;
            this.EnableCompressorCheckbox.Text = "  ";
            this.EnableCompressorCheckbox.UseVisualStyleBackColor = true;
            // 
            // EnableFlangerCheckbox
            // 
            this.EnableFlangerCheckbox.AutoSize = true;
            this.EnableFlangerCheckbox.Location = new System.Drawing.Point(41, 146);
            this.EnableFlangerCheckbox.Name = "EnableFlangerCheckbox";
            this.EnableFlangerCheckbox.Size = new System.Drawing.Size(32, 17);
            this.EnableFlangerCheckbox.TabIndex = 1;
            this.EnableFlangerCheckbox.Text = "  ";
            this.EnableFlangerCheckbox.UseVisualStyleBackColor = true;
            // 
            // EnableDistortionCheckbox
            // 
            this.EnableDistortionCheckbox.AutoSize = true;
            this.EnableDistortionCheckbox.Location = new System.Drawing.Point(41, 102);
            this.EnableDistortionCheckbox.Name = "EnableDistortionCheckbox";
            this.EnableDistortionCheckbox.Size = new System.Drawing.Size(32, 17);
            this.EnableDistortionCheckbox.TabIndex = 1;
            this.EnableDistortionCheckbox.Text = "  ";
            this.EnableDistortionCheckbox.UseVisualStyleBackColor = true;
            // 
            // EnableChorusCheckbox
            // 
            this.EnableChorusCheckbox.AutoSize = true;
            this.EnableChorusCheckbox.Location = new System.Drawing.Point(41, 58);
            this.EnableChorusCheckbox.Name = "EnableChorusCheckbox";
            this.EnableChorusCheckbox.Size = new System.Drawing.Size(32, 17);
            this.EnableChorusCheckbox.TabIndex = 1;
            this.EnableChorusCheckbox.Text = "  ";
            this.EnableChorusCheckbox.UseVisualStyleBackColor = true;
            // 
            // AdjustSoundFxLabel
            // 
            this.AdjustSoundFxLabel.AutoSize = true;
            this.AdjustSoundFxLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AdjustSoundFxLabel.Location = new System.Drawing.Point(121, 22);
            this.AdjustSoundFxLabel.Name = "AdjustSoundFxLabel";
            this.AdjustSoundFxLabel.Size = new System.Drawing.Size(51, 15);
            this.AdjustSoundFxLabel.TabIndex = 0;
            this.AdjustSoundFxLabel.Text = "SoundFx";
            // 
            // EnableSoundFxLabel
            // 
            this.EnableSoundFxLabel.AutoSize = true;
            this.EnableSoundFxLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.EnableSoundFxLabel.Location = new System.Drawing.Point(28, 22);
            this.EnableSoundFxLabel.Name = "EnableSoundFxLabel";
            this.EnableSoundFxLabel.Size = new System.Drawing.Size(42, 15);
            this.EnableSoundFxLabel.TabIndex = 0;
            this.EnableSoundFxLabel.Text = "Enable";
            // 
            // PlaybackPropertiesGroupbox
            // 
            this.PlaybackPropertiesGroupbox.Controls.Add(this.FrequencyParameterValueControl);
            this.PlaybackPropertiesGroupbox.Location = new System.Drawing.Point(3, 270);
            this.PlaybackPropertiesGroupbox.Name = "PlaybackPropertiesGroupbox";
            this.PlaybackPropertiesGroupbox.Size = new System.Drawing.Size(251, 168);
            this.PlaybackPropertiesGroupbox.TabIndex = 3;
            this.PlaybackPropertiesGroupbox.TabStop = false;
            this.PlaybackPropertiesGroupbox.Text = "Playback properties";
            // 
            // FrequencyParameterValueControl
            // 
            this.FrequencyParameterValueControl.Location = new System.Drawing.Point(6, 19);
            this.FrequencyParameterValueControl.MinimumSize = new System.Drawing.Size(231, 51);
            this.FrequencyParameterValueControl.Name = "FrequencyParameterValueControl";
            this.FrequencyParameterValueControl.ParamId = -1;
            this.FrequencyParameterValueControl.Size = new System.Drawing.Size(240, 51);
            this.FrequencyParameterValueControl.TabIndex = 0;
            this.FrequencyParameterValueControl.Value = 0F;
            // 
            // FxPropertiesControl
            // 
            this.FxPropertiesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FxPropertiesControl.Location = new System.Drawing.Point(3, 16);
            this.FxPropertiesControl.Name = "FxPropertiesControl";
            this.FxPropertiesControl.Size = new System.Drawing.Size(431, 417);
            this.FxPropertiesControl.SoundFx = null;
            this.FxPropertiesControl.TabIndex = 0;
            // 
            // SoundFxPropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PlaybackPropertiesGroupbox);
            this.Controls.Add(this.SoundFxListGroupBox);
            this.Controls.Add(this.FxPropertiesGroupBox);
            this.Name = "SoundFxPropertiesControl";
            this.Size = new System.Drawing.Size(700, 441);
            this.FxPropertiesGroupBox.ResumeLayout(false);
            this.SoundFxListGroupBox.ResumeLayout(false);
            this.SoundFxListGroupBox.PerformLayout();
            this.PlaybackPropertiesGroupbox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox FxPropertiesGroupBox;
        private System.Windows.Forms.GroupBox SoundFxListGroupBox;
        private System.Windows.Forms.CheckBox EnableChorusCheckbox;
        private System.Windows.Forms.Label AdjustSoundFxLabel;
        private System.Windows.Forms.Label EnableSoundFxLabel;
        private System.Windows.Forms.RadioButton AdjustEchoRadioButton;
        private System.Windows.Forms.RadioButton AdjustCompressorRadioButton;
        private System.Windows.Forms.RadioButton AdjustDistortionRadioButton;
        private System.Windows.Forms.RadioButton AdjustChorusRadioButton;
        private System.Windows.Forms.CheckBox EnableGargleCheckbox;
        private System.Windows.Forms.CheckBox EnableEchoCheckbox;
        private System.Windows.Forms.CheckBox EnableCompressorCheckbox;
        private System.Windows.Forms.CheckBox EnableFlangerCheckbox;
        private System.Windows.Forms.CheckBox EnableDistortionCheckbox;
        private System.Windows.Forms.RadioButton AdjustGargleRadioButton;
        private System.Windows.Forms.RadioButton AdjustFlangerRadioButton;
        private System.Windows.Forms.RadioButton AdjustReverbRadioButton;
        private System.Windows.Forms.RadioButton AdjustRadioButtonParamEq;
        private System.Windows.Forms.CheckBox EnableReverbCheckbox;
        private System.Windows.Forms.CheckBox EnableParamEqCheckbox;
        private SingleFxPropertiesControl FxPropertiesControl;
        private System.Windows.Forms.GroupBox PlaybackPropertiesGroupbox;
        private LabeledExtendedSliderControl FrequencyParameterValueControl;
    }
}
