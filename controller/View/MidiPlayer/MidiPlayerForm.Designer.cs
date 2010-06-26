namespace UltraPlayerController.View.MidiPlayer
{
    partial class MidiPlayerForm
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
            this.PlayerCommunicatorPanel = new System.Windows.Forms.Panel();
            this.PlaylistButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.PlaybackControlsPanel = new System.Windows.Forms.Panel();
            this.MusicPropertiesVisibilityButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlayerCommunicatorPanel
            // 
            this.PlayerCommunicatorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PlayerCommunicatorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlayerCommunicatorPanel.Location = new System.Drawing.Point(12, 102);
            this.PlayerCommunicatorPanel.Name = "PlayerCommunicatorPanel";
            this.PlayerCommunicatorPanel.Size = new System.Drawing.Size(84, 24);
            this.PlayerCommunicatorPanel.TabIndex = 23;
            // 
            // PlaylistButton
            // 
            this.PlaylistButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PlaylistButton.Location = new System.Drawing.Point(296, 103);
            this.PlaylistButton.Name = "PlaylistButton";
            this.PlaylistButton.Size = new System.Drawing.Size(86, 34);
            this.PlaylistButton.TabIndex = 22;
            this.PlaylistButton.Text = "Playlist";
            this.PlaylistButton.UseVisualStyleBackColor = true;
            this.PlaylistButton.Click += new System.EventHandler(this.PlaylistButtonClick);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsButton.Location = new System.Drawing.Point(388, 103);
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
            this.ExitButton.Location = new System.Drawing.Point(480, 103);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(86, 34);
            this.ExitButton.TabIndex = 21;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // PlaybackControlsPanel
            // 
            this.PlaybackControlsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PlaybackControlsPanel.Location = new System.Drawing.Point(12, 12);
            this.PlaybackControlsPanel.Name = "PlaybackControlsPanel";
            this.PlaybackControlsPanel.Size = new System.Drawing.Size(539, 68);
            this.PlaybackControlsPanel.TabIndex = 19;
            // 
            // MusicPropertiesVisibilityButton
            // 
            this.MusicPropertiesVisibilityButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MusicPropertiesVisibilityButton.Location = new System.Drawing.Point(204, 103);
            this.MusicPropertiesVisibilityButton.Name = "MusicPropertiesVisibilityButton";
            this.MusicPropertiesVisibilityButton.Size = new System.Drawing.Size(86, 34);
            this.MusicPropertiesVisibilityButton.TabIndex = 22;
            this.MusicPropertiesVisibilityButton.Text = "Music";
            this.MusicPropertiesVisibilityButton.UseVisualStyleBackColor = true;
            this.MusicPropertiesVisibilityButton.Click += new System.EventHandler(this.MusicPropertiesVisibilityButton_Click);
            // 
            // MidiPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 132);
            this.Controls.Add(this.PlayerCommunicatorPanel);
            this.Controls.Add(this.MusicPropertiesVisibilityButton);
            this.Controls.Add(this.PlaylistButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.PlaybackControlsPanel);
            this.MinimumSize = new System.Drawing.Size(571, 166);
            this.Name = "MidiPlayerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ultra Player: Midi mode";
            this.Move += new System.EventHandler(this.MidiPlayerFormMove);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MidiPlayerFormFormClosing);
            this.Resize += new System.EventHandler(this.MidiPlayerFormResize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PlayerCommunicatorPanel;
        private System.Windows.Forms.Button PlaylistButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Panel PlaybackControlsPanel;
        private System.Windows.Forms.Button MusicPropertiesVisibilityButton;
    }
}