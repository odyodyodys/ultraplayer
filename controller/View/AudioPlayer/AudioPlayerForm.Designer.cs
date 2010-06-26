namespace UltraPlayerController.View.AudioPlayer
{
    partial class AudioPlayerForm
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
            this.PlaylistVisibilityButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.PlaybackControlsPanel = new System.Windows.Forms.Panel();
            this.EffectsVisibilityButton = new System.Windows.Forms.Button();
            this.SpatializationParamsVisibilityButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlayerCommunicatorPanel
            // 
            this.PlayerCommunicatorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PlayerCommunicatorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlayerCommunicatorPanel.Location = new System.Drawing.Point(12, 102);
            this.PlayerCommunicatorPanel.Name = "PlayerCommunicatorPanel";
            this.PlayerCommunicatorPanel.Size = new System.Drawing.Size(84, 24);
            this.PlayerCommunicatorPanel.TabIndex = 21;
            // 
            // PlaylistVisibilityButton
            // 
            this.PlaylistVisibilityButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PlaylistVisibilityButton.Location = new System.Drawing.Point(296, 103);
            this.PlaylistVisibilityButton.Name = "PlaylistVisibilityButton";
            this.PlaylistVisibilityButton.Size = new System.Drawing.Size(86, 34);
            this.PlaylistVisibilityButton.TabIndex = 20;
            this.PlaylistVisibilityButton.Text = "Playlist";
            this.PlaylistVisibilityButton.UseVisualStyleBackColor = true;
            this.PlaylistVisibilityButton.Click += new System.EventHandler(this.PlaylistVisibilityButtonClick);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsButton.Location = new System.Drawing.Point(388, 103);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(86, 34);
            this.SettingsButton.TabIndex = 18;
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
            this.ExitButton.TabIndex = 19;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // PlaybackControlsPanel
            // 
            this.PlaybackControlsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PlaybackControlsPanel.Location = new System.Drawing.Point(12, 12);
            this.PlaybackControlsPanel.Name = "PlaybackControlsPanel";
            this.PlaybackControlsPanel.Size = new System.Drawing.Size(539, 68);
            this.PlaybackControlsPanel.TabIndex = 22;
            // 
            // EffectsVisibilityButton
            // 
            this.EffectsVisibilityButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EffectsVisibilityButton.Location = new System.Drawing.Point(204, 103);
            this.EffectsVisibilityButton.Name = "EffectsVisibilityButton";
            this.EffectsVisibilityButton.Size = new System.Drawing.Size(86, 34);
            this.EffectsVisibilityButton.TabIndex = 20;
            this.EffectsVisibilityButton.Text = "Effects";
            this.EffectsVisibilityButton.UseVisualStyleBackColor = true;
            this.EffectsVisibilityButton.Click += new System.EventHandler(this.EffectsVisibilityButtonClick);
            // 
            // SpatializationParamsVisibilityButton
            // 
            this.SpatializationParamsVisibilityButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SpatializationParamsVisibilityButton.Location = new System.Drawing.Point(112, 103);
            this.SpatializationParamsVisibilityButton.Name = "SpatializationParamsVisibilityButton";
            this.SpatializationParamsVisibilityButton.Size = new System.Drawing.Size(86, 34);
            this.SpatializationParamsVisibilityButton.TabIndex = 20;
            this.SpatializationParamsVisibilityButton.Text = "3d Sound";
            this.SpatializationParamsVisibilityButton.UseVisualStyleBackColor = true;
            this.SpatializationParamsVisibilityButton.Click += new System.EventHandler(this.SpatializationParamsVisibilityButtonClick);
            // 
            // AudioPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 132);
            this.Controls.Add(this.PlaybackControlsPanel);
            this.Controls.Add(this.PlayerCommunicatorPanel);
            this.Controls.Add(this.SpatializationParamsVisibilityButton);
            this.Controls.Add(this.EffectsVisibilityButton);
            this.Controls.Add(this.PlaylistVisibilityButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.ExitButton);
            this.MinimumSize = new System.Drawing.Size(571, 166);
            this.Name = "AudioPlayerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ultra Player: Audio mode";
            this.Move += new System.EventHandler(this.AudioPlayerFormMove);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AudioPlayerFormFormClosing);
            this.Resize += new System.EventHandler(this.AudioPlayerFormResize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PlayerCommunicatorPanel;
        private System.Windows.Forms.Button PlaylistVisibilityButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Panel PlaybackControlsPanel;
        private System.Windows.Forms.Button EffectsVisibilityButton;
        private System.Windows.Forms.Button SpatializationParamsVisibilityButton;
    }
}