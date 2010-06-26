namespace UltraPlayerController.View.MidiPlayer
{
    partial class MusicPropertiesForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DlsFileTextBox = new System.Windows.Forms.TextBox();
            this.DlsBrowseButton = new System.Windows.Forms.Button();
            this.OutputPortUpdateButton = new System.Windows.Forms.Button();
            this.OutputPortCombobox = new System.Windows.Forms.ComboBox();
            this.DlsFileLabel = new System.Windows.Forms.Label();
            this.OutputPortLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TempoParameterValueControl = new UltraPlayerController.View.AudioPlayer.LabeledExtendedSliderControl();
            this.ReverbEffectCheckbox = new System.Windows.Forms.CheckBox();
            this.ChorusEffectCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SourceZParameterValueControl = new UltraPlayerController.View.AudioPlayer.LabeledExtendedSliderControl();
            this.SourceYParameterValueControl = new UltraPlayerController.View.AudioPlayer.LabeledExtendedSliderControl();
            this.SourceXParameterValueControl = new UltraPlayerController.View.AudioPlayer.LabeledExtendedSliderControl();
            this.DlsFileOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.DlsFileTextBox);
            this.groupBox1.Controls.Add(this.DlsBrowseButton);
            this.groupBox1.Controls.Add(this.OutputPortUpdateButton);
            this.groupBox1.Controls.Add(this.OutputPortCombobox);
            this.groupBox1.Controls.Add(this.DlsFileLabel);
            this.groupBox1.Controls.Add(this.OutputPortLabel);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Midi Configuration";
            // 
            // DlsFileTextBox
            // 
            this.DlsFileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DlsFileTextBox.Location = new System.Drawing.Point(9, 72);
            this.DlsFileTextBox.Name = "DlsFileTextBox";
            this.DlsFileTextBox.ReadOnly = true;
            this.DlsFileTextBox.Size = new System.Drawing.Size(246, 20);
            this.DlsFileTextBox.TabIndex = 38;
            // 
            // DlsBrowseButton
            // 
            this.DlsBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DlsBrowseButton.Location = new System.Drawing.Point(258, 71);
            this.DlsBrowseButton.Name = "DlsBrowseButton";
            this.DlsBrowseButton.Size = new System.Drawing.Size(25, 23);
            this.DlsBrowseButton.TabIndex = 37;
            this.DlsBrowseButton.Text = "...";
            this.DlsBrowseButton.UseVisualStyleBackColor = true;
            this.DlsBrowseButton.Click += new System.EventHandler(this.DlsBrowseButtonClick);
            // 
            // OutputPortUpdateButton
            // 
            this.OutputPortUpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputPortUpdateButton.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.OutputPortUpdateButton.Location = new System.Drawing.Point(258, 29);
            this.OutputPortUpdateButton.Name = "OutputPortUpdateButton";
            this.OutputPortUpdateButton.Size = new System.Drawing.Size(25, 27);
            this.OutputPortUpdateButton.TabIndex = 36;
            this.OutputPortUpdateButton.Text = "P";
            this.OutputPortUpdateButton.UseVisualStyleBackColor = true;
            this.OutputPortUpdateButton.Click += new System.EventHandler(this.OutputPortUpdateButtonClick);
            // 
            // OutputPortCombobox
            // 
            this.OutputPortCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputPortCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OutputPortCombobox.FormattingEnabled = true;
            this.OutputPortCombobox.Location = new System.Drawing.Point(9, 32);
            this.OutputPortCombobox.Name = "OutputPortCombobox";
            this.OutputPortCombobox.Size = new System.Drawing.Size(246, 21);
            this.OutputPortCombobox.TabIndex = 35;
            this.OutputPortCombobox.SelectedIndexChanged += new System.EventHandler(this.OutputPortComboboxSelectedIndexChanged);
            // 
            // DlsFileLabel
            // 
            this.DlsFileLabel.AutoSize = true;
            this.DlsFileLabel.Location = new System.Drawing.Point(6, 56);
            this.DlsFileLabel.Name = "DlsFileLabel";
            this.DlsFileLabel.Size = new System.Drawing.Size(41, 13);
            this.DlsFileLabel.TabIndex = 34;
            this.DlsFileLabel.Text = "Dls file:";
            // 
            // OutputPortLabel
            // 
            this.OutputPortLabel.AutoSize = true;
            this.OutputPortLabel.Location = new System.Drawing.Point(6, 16);
            this.OutputPortLabel.Name = "OutputPortLabel";
            this.OutputPortLabel.Size = new System.Drawing.Size(63, 13);
            this.OutputPortLabel.TabIndex = 34;
            this.OutputPortLabel.Text = "Output port:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.TempoParameterValueControl);
            this.groupBox2.Controls.Add(this.ReverbEffectCheckbox);
            this.groupBox2.Controls.Add(this.ChorusEffectCheckbox);
            this.groupBox2.Location = new System.Drawing.Point(3, 122);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 124);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Midi Properties";
            // 
            // TempoParameterValueControl
            // 
            this.TempoParameterValueControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TempoParameterValueControl.Location = new System.Drawing.Point(9, 65);
            this.TempoParameterValueControl.MinimumSize = new System.Drawing.Size(231, 51);
            this.TempoParameterValueControl.Name = "TempoParameterValueControl";
            this.TempoParameterValueControl.ParamId = -1;
            this.TempoParameterValueControl.Size = new System.Drawing.Size(274, 51);
            this.TempoParameterValueControl.TabIndex = 1;
            this.TempoParameterValueControl.Value = 0F;
            // 
            // ReverbEffectCheckbox
            // 
            this.ReverbEffectCheckbox.AutoSize = true;
            this.ReverbEffectCheckbox.Location = new System.Drawing.Point(9, 42);
            this.ReverbEffectCheckbox.Name = "ReverbEffectCheckbox";
            this.ReverbEffectCheckbox.Size = new System.Drawing.Size(91, 17);
            this.ReverbEffectCheckbox.TabIndex = 0;
            this.ReverbEffectCheckbox.Text = "Reverb effect";
            this.ReverbEffectCheckbox.UseVisualStyleBackColor = true;
            this.ReverbEffectCheckbox.CheckedChanged += new System.EventHandler(this.ReverbEffectCheckboxCheckedChanged);
            // 
            // ChorusEffectCheckbox
            // 
            this.ChorusEffectCheckbox.AutoSize = true;
            this.ChorusEffectCheckbox.Location = new System.Drawing.Point(9, 19);
            this.ChorusEffectCheckbox.Name = "ChorusEffectCheckbox";
            this.ChorusEffectCheckbox.Size = new System.Drawing.Size(89, 17);
            this.ChorusEffectCheckbox.TabIndex = 0;
            this.ChorusEffectCheckbox.Text = "Chorus effect";
            this.ChorusEffectCheckbox.UseVisualStyleBackColor = true;
            this.ChorusEffectCheckbox.CheckedChanged += new System.EventHandler(this.ChorusEffectCheckboxCheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.SourceZParameterValueControl);
            this.groupBox3.Controls.Add(this.SourceYParameterValueControl);
            this.groupBox3.Controls.Add(this.SourceXParameterValueControl);
            this.groupBox3.Location = new System.Drawing.Point(300, 3);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(259, 243);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sound position";
            // 
            // SourceZParameterValueControl
            // 
            this.SourceZParameterValueControl.Location = new System.Drawing.Point(6, 130);
            this.SourceZParameterValueControl.MinimumSize = new System.Drawing.Size(231, 51);
            this.SourceZParameterValueControl.Name = "SourceZParameterValueControl";
            this.SourceZParameterValueControl.ParamId = -1;
            this.SourceZParameterValueControl.Size = new System.Drawing.Size(246, 51);
            this.SourceZParameterValueControl.TabIndex = 3;
            this.SourceZParameterValueControl.Value = 0F;
            // 
            // SourceYParameterValueControl
            // 
            this.SourceYParameterValueControl.Location = new System.Drawing.Point(6, 73);
            this.SourceYParameterValueControl.MinimumSize = new System.Drawing.Size(231, 51);
            this.SourceYParameterValueControl.Name = "SourceYParameterValueControl";
            this.SourceYParameterValueControl.ParamId = -1;
            this.SourceYParameterValueControl.Size = new System.Drawing.Size(246, 51);
            this.SourceYParameterValueControl.TabIndex = 2;
            this.SourceYParameterValueControl.Value = 0F;
            // 
            // SourceXParameterValueControl
            // 
            this.SourceXParameterValueControl.Location = new System.Drawing.Point(6, 16);
            this.SourceXParameterValueControl.MinimumSize = new System.Drawing.Size(231, 51);
            this.SourceXParameterValueControl.Name = "SourceXParameterValueControl";
            this.SourceXParameterValueControl.ParamId = -1;
            this.SourceXParameterValueControl.Size = new System.Drawing.Size(246, 51);
            this.SourceXParameterValueControl.TabIndex = 1;
            this.SourceXParameterValueControl.Value = 0F;
            // 
            // DlsFileOpenFileDialog
            // 
            this.DlsFileOpenFileDialog.Filter = "Dls files|*.dls|All files|*.*";
            this.DlsFileOpenFileDialog.SupportMultiDottedExtensions = true;
            // 
            // MusicPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 248);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(569, 274);
            this.Name = "MusicPropertiesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Music Properties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MusicPropertiesFormFormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button OutputPortUpdateButton;
        private System.Windows.Forms.ComboBox OutputPortCombobox;
        private System.Windows.Forms.Label OutputPortLabel;
        private System.Windows.Forms.CheckBox ReverbEffectCheckbox;
        private System.Windows.Forms.CheckBox ChorusEffectCheckbox;
        private UltraPlayerController.View.AudioPlayer.LabeledExtendedSliderControl SourceZParameterValueControl;
        private UltraPlayerController.View.AudioPlayer.LabeledExtendedSliderControl SourceYParameterValueControl;
        private UltraPlayerController.View.AudioPlayer.LabeledExtendedSliderControl SourceXParameterValueControl;
        private System.Windows.Forms.TextBox DlsFileTextBox;
        private System.Windows.Forms.Button DlsBrowseButton;
        private System.Windows.Forms.Label DlsFileLabel;
        private System.Windows.Forms.OpenFileDialog DlsFileOpenFileDialog;
        private UltraPlayerController.View.AudioPlayer.LabeledExtendedSliderControl TempoParameterValueControl;
    }
}