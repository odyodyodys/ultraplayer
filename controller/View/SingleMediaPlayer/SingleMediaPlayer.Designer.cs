namespace UltraPlayerController.View.SingleMediaPlayer
{
    partial class SingleMediaPlayerForm
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
            this.PlaybackControlsPanel = new System.Windows.Forms.Panel();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.PlaylistButton = new System.Windows.Forms.Button();
            this.PlayerCommunicatorPanel = new System.Windows.Forms.Panel();
            this.PlaybackPropertiesPanel = new System.Windows.Forms.Panel();
            this.AddonsButton = new System.Windows.Forms.Button();
            this.WindowLayoutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlaybackControlsPanel
            // 
            this.PlaybackControlsPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PlaybackControlsPanel.Location = new System.Drawing.Point(12, 12);
            this.PlaybackControlsPanel.Name = "PlaybackControlsPanel";
            this.PlaybackControlsPanel.Size = new System.Drawing.Size(400, 68);
            this.PlaybackControlsPanel.TabIndex = 13;
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Location = new System.Drawing.Point(480, 103);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(86, 34);
            this.ExitButton.TabIndex = 16;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsButton.Location = new System.Drawing.Point(388, 103);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(86, 34);
            this.SettingsButton.TabIndex = 16;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButtonClick);
            // 
            // PlaylistButton
            // 
            this.PlaylistButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PlaylistButton.Location = new System.Drawing.Point(296, 103);
            this.PlaylistButton.Name = "PlaylistButton";
            this.PlaylistButton.Size = new System.Drawing.Size(86, 34);
            this.PlaylistButton.TabIndex = 16;
            this.PlaylistButton.Text = "Playlist";
            this.PlaylistButton.UseVisualStyleBackColor = true;
            this.PlaylistButton.Click += new System.EventHandler(this.PlaylistVisibilityButtonClick);
            // 
            // PlayerCommunicatorPanel
            // 
            this.PlayerCommunicatorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PlayerCommunicatorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlayerCommunicatorPanel.Location = new System.Drawing.Point(12, 102);
            this.PlayerCommunicatorPanel.Name = "PlayerCommunicatorPanel";
            this.PlayerCommunicatorPanel.Size = new System.Drawing.Size(84, 24);
            this.PlayerCommunicatorPanel.TabIndex = 17;
            // 
            // PlaybackPropertiesPanel
            // 
            this.PlaybackPropertiesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PlaybackPropertiesPanel.Location = new System.Drawing.Point(418, 12);
            this.PlaybackPropertiesPanel.Name = "PlaybackPropertiesPanel";
            this.PlaybackPropertiesPanel.Size = new System.Drawing.Size(133, 85);
            this.PlaybackPropertiesPanel.TabIndex = 18;
            // 
            // AddonsButton
            // 
            this.AddonsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddonsButton.Location = new System.Drawing.Point(204, 103);
            this.AddonsButton.Name = "AddonsButton";
            this.AddonsButton.Size = new System.Drawing.Size(86, 34);
            this.AddonsButton.TabIndex = 16;
            this.AddonsButton.Text = "Addons";
            this.AddonsButton.UseVisualStyleBackColor = true;
            this.AddonsButton.Click += new System.EventHandler(this.AddonsButtonClick);
            // 
            // WindowLayoutButton
            // 
            this.WindowLayoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.WindowLayoutButton.Location = new System.Drawing.Point(112, 103);
            this.WindowLayoutButton.Name = "WindowLayoutButton";
            this.WindowLayoutButton.Size = new System.Drawing.Size(86, 34);
            this.WindowLayoutButton.TabIndex = 19;
            this.WindowLayoutButton.Text = "Window";
            this.WindowLayoutButton.UseVisualStyleBackColor = true;
            this.WindowLayoutButton.Click += new System.EventHandler(this.WindowLayoutButtonClick);
            // 
            // SingleMediaPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 132);
            this.Controls.Add(this.WindowLayoutButton);
            this.Controls.Add(this.PlaybackPropertiesPanel);
            this.Controls.Add(this.PlayerCommunicatorPanel);
            this.Controls.Add(this.AddonsButton);
            this.Controls.Add(this.PlaylistButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.PlaybackControlsPanel);
            this.MinimumSize = new System.Drawing.Size(571, 166);
            this.Name = "SingleMediaPlayerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ultra Player: Single Video mode";
            this.VisibleChanged += new System.EventHandler(this.SingleMediaPlayerFormVisibleChanged);
            this.Move += new System.EventHandler(this.SingleMediaPlayerFormMove);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SingleMediaPlayerForm_FormClosing);
            this.Resize += new System.EventHandler(this.SingleMediaPlayerFormResize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PlaybackControlsPanel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button PlaylistButton;
        private System.Windows.Forms.Panel PlayerCommunicatorPanel;
        private System.Windows.Forms.Panel PlaybackPropertiesPanel;
        private System.Windows.Forms.Button AddonsButton;
        private System.Windows.Forms.Button WindowLayoutButton;
    }
}