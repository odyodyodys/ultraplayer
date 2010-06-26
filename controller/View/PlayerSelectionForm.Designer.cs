namespace UltraPlayerController.View
{
    partial class PlayerSelectionForm
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
            this.MultiVideoButton = new System.Windows.Forms.Button();
            this.AudioButton = new System.Windows.Forms.Button();
            this.MidiButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SingleVideoButton = new System.Windows.Forms.Button();
            this.SelectPlayerLabel = new System.Windows.Forms.Label();
            this.SingleVideoPicture = new System.Windows.Forms.PictureBox();
            this.MultiVideoPicture = new System.Windows.Forms.PictureBox();
            this.AudioPicture = new System.Windows.Forms.PictureBox();
            this.MidiPicture = new System.Windows.Forms.PictureBox();
            this.RunLocalPlayerCheckbox = new System.Windows.Forms.CheckBox();
            this.PlayerCommunicatorControl = new UltraPlayerController.View.CommonControls.PlayerCommunicator.PlayerCommunicatorControl();
            ((System.ComponentModel.ISupportInitialize)(this.SingleVideoPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiVideoPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AudioPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MidiPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // MultiVideoButton
            // 
            this.MultiVideoButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MultiVideoButton.Location = new System.Drawing.Point(135, 189);
            this.MultiVideoButton.Name = "MultiVideoButton";
            this.MultiVideoButton.Size = new System.Drawing.Size(122, 32);
            this.MultiVideoButton.TabIndex = 1;
            this.MultiVideoButton.Text = "Multi Video";
            this.MultiVideoButton.UseVisualStyleBackColor = true;
            this.MultiVideoButton.Click += new System.EventHandler(this.MultiVideoButtonClick);
            // 
            // AudioButton
            // 
            this.AudioButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AudioButton.Location = new System.Drawing.Point(259, 189);
            this.AudioButton.Name = "AudioButton";
            this.AudioButton.Size = new System.Drawing.Size(122, 32);
            this.AudioButton.TabIndex = 1;
            this.AudioButton.Text = "Audio";
            this.AudioButton.UseVisualStyleBackColor = true;
            this.AudioButton.Click += new System.EventHandler(this.AudioButtonClick);
            // 
            // MidiButton
            // 
            this.MidiButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MidiButton.Location = new System.Drawing.Point(383, 189);
            this.MidiButton.Name = "MidiButton";
            this.MidiButton.Size = new System.Drawing.Size(122, 32);
            this.MidiButton.TabIndex = 1;
            this.MidiButton.Text = "Midi";
            this.MidiButton.UseVisualStyleBackColor = true;
            this.MidiButton.Click += new System.EventHandler(this.MidiButtonClick);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsButton.Location = new System.Drawing.Point(341, 235);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(86, 34);
            this.SettingsButton.TabIndex = 20;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButtonClick);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Location = new System.Drawing.Point(433, 235);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(86, 34);
            this.ExitButton.TabIndex = 19;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // SingleVideoButton
            // 
            this.SingleVideoButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SingleVideoButton.Location = new System.Drawing.Point(11, 189);
            this.SingleVideoButton.Margin = new System.Windows.Forms.Padding(0);
            this.SingleVideoButton.Name = "SingleVideoButton";
            this.SingleVideoButton.Size = new System.Drawing.Size(122, 32);
            this.SingleVideoButton.TabIndex = 1;
            this.SingleVideoButton.Text = "Single Video";
            this.SingleVideoButton.UseVisualStyleBackColor = true;
            this.SingleVideoButton.Click += new System.EventHandler(this.SingleVideoButtonClick);
            // 
            // SelectPlayerLabel
            // 
            this.SelectPlayerLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SelectPlayerLabel.AutoSize = true;
            this.SelectPlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.SelectPlayerLabel.Location = new System.Drawing.Point(12, 9);
            this.SelectPlayerLabel.Name = "SelectPlayerLabel";
            this.SelectPlayerLabel.Size = new System.Drawing.Size(105, 20);
            this.SelectPlayerLabel.TabIndex = 21;
            this.SelectPlayerLabel.Text = "Select Player:";
            // 
            // SingleVideoPicture
            // 
            this.SingleVideoPicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SingleVideoPicture.BackgroundImage = global::UltraPlayerController.Properties.Resources.ultraPlayerCommanderSingleLogo;
            this.SingleVideoPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SingleVideoPicture.Location = new System.Drawing.Point(12, 32);
            this.SingleVideoPicture.Name = "SingleVideoPicture";
            this.SingleVideoPicture.Size = new System.Drawing.Size(120, 160);
            this.SingleVideoPicture.TabIndex = 22;
            this.SingleVideoPicture.TabStop = false;
            this.SingleVideoPicture.Click += new System.EventHandler(this.SingleVideoButtonClick);
            // 
            // MultiVideoPicture
            // 
            this.MultiVideoPicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MultiVideoPicture.BackgroundImage = global::UltraPlayerController.Properties.Resources.ultraPlayerCommanderMultiLogo;
            this.MultiVideoPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MultiVideoPicture.Location = new System.Drawing.Point(136, 32);
            this.MultiVideoPicture.Name = "MultiVideoPicture";
            this.MultiVideoPicture.Size = new System.Drawing.Size(120, 160);
            this.MultiVideoPicture.TabIndex = 22;
            this.MultiVideoPicture.TabStop = false;
            this.MultiVideoPicture.Click += new System.EventHandler(this.MultiVideoButtonClick);
            // 
            // AudioPicture
            // 
            this.AudioPicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AudioPicture.BackgroundImage = global::UltraPlayerController.Properties.Resources.ultraPlayerCommanderAudioLogo;
            this.AudioPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AudioPicture.Location = new System.Drawing.Point(260, 32);
            this.AudioPicture.Name = "AudioPicture";
            this.AudioPicture.Size = new System.Drawing.Size(120, 160);
            this.AudioPicture.TabIndex = 22;
            this.AudioPicture.TabStop = false;
            this.AudioPicture.Click += new System.EventHandler(this.AudioButtonClick);
            // 
            // MidiPicture
            // 
            this.MidiPicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MidiPicture.BackgroundImage = global::UltraPlayerController.Properties.Resources.ultraPlayerCommanderMidiLogo;
            this.MidiPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MidiPicture.Location = new System.Drawing.Point(384, 32);
            this.MidiPicture.Name = "MidiPicture";
            this.MidiPicture.Size = new System.Drawing.Size(120, 160);
            this.MidiPicture.TabIndex = 22;
            this.MidiPicture.TabStop = false;
            this.MidiPicture.Click += new System.EventHandler(this.MidiButtonClick);
            // 
            // RunLocalPlayerCheckbox
            // 
            this.RunLocalPlayerCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RunLocalPlayerCheckbox.AutoSize = true;
            this.RunLocalPlayerCheckbox.Location = new System.Drawing.Point(12, 245);
            this.RunLocalPlayerCheckbox.Name = "RunLocalPlayerCheckbox";
            this.RunLocalPlayerCheckbox.Size = new System.Drawing.Size(154, 17);
            this.RunLocalPlayerCheckbox.TabIndex = 23;
            this.RunLocalPlayerCheckbox.Text = "Run player on this machine";
            this.RunLocalPlayerCheckbox.UseVisualStyleBackColor = true;
            // 
            // PlayerCommunicatorControl
            // 
            this.PlayerCommunicatorControl.Location = new System.Drawing.Point(172, 238);
            this.PlayerCommunicatorControl.MinimumSize = new System.Drawing.Size(84, 24);
            this.PlayerCommunicatorControl.Name = "PlayerCommunicatorControl";
            this.PlayerCommunicatorControl.Size = new System.Drawing.Size(84, 24);
            this.PlayerCommunicatorControl.TabIndex = 24;
            this.PlayerCommunicatorControl.Visible = false;
            // 
            // PlayerSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 266);
            this.Controls.Add(this.PlayerCommunicatorControl);
            this.Controls.Add(this.RunLocalPlayerCheckbox);
            this.Controls.Add(this.SingleVideoPicture);
            this.Controls.Add(this.SingleVideoButton);
            this.Controls.Add(this.MidiPicture);
            this.Controls.Add(this.MultiVideoPicture);
            this.Controls.Add(this.AudioPicture);
            this.Controls.Add(this.SelectPlayerLabel);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.MidiButton);
            this.Controls.Add(this.AudioButton);
            this.Controls.Add(this.MultiVideoButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PlayerSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ultra Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerSelectionFormFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.SingleVideoPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MultiVideoPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AudioPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MidiPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MultiVideoButton;
        private System.Windows.Forms.Button AudioButton;
        private System.Windows.Forms.Button MidiButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button SingleVideoButton;
        private System.Windows.Forms.Label SelectPlayerLabel;
        private System.Windows.Forms.PictureBox SingleVideoPicture;
        private System.Windows.Forms.PictureBox MultiVideoPicture;
        private System.Windows.Forms.PictureBox AudioPicture;
        private System.Windows.Forms.PictureBox MidiPicture;
        private System.Windows.Forms.CheckBox RunLocalPlayerCheckbox;
        private UltraPlayerController.View.CommonControls.PlayerCommunicator.PlayerCommunicatorControl PlayerCommunicatorControl;
    }
}