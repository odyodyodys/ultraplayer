namespace UltraPlayerController.View.MultiMediaPlayer
{
    partial class MultiMediaPlayerForm
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
            this.SettingsButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.PlaylistControlPanel = new System.Windows.Forms.Panel();
            this.VideoLayoutControlPanel = new System.Windows.Forms.Panel();
            this.PlayerCommunicatorPanel = new System.Windows.Forms.Panel();
            this.layoutTabControl = new System.Windows.Forms.TabControl();
            this.videoLayoutTabPage = new System.Windows.Forms.TabPage();
            this.videoWindowLayoutTabPage = new System.Windows.Forms.TabPage();
            this.WindowLayoutControlPanel = new System.Windows.Forms.Panel();
            this.layoutTabControl.SuspendLayout();
            this.videoLayoutTabPage.SuspendLayout();
            this.videoWindowLayoutTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlaybackControlsPanel
            // 
            this.PlaybackControlsPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PlaybackControlsPanel.Location = new System.Drawing.Point(131, 426);
            this.PlaybackControlsPanel.Name = "PlaybackControlsPanel";
            this.PlaybackControlsPanel.Size = new System.Drawing.Size(400, 68);
            this.PlaybackControlsPanel.TabIndex = 10;
            // 
            // SettingsButton
            // 
            this.SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsButton.Location = new System.Drawing.Point(667, 472);
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
            this.ExitButton.Location = new System.Drawing.Point(759, 472);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(86, 34);
            this.ExitButton.TabIndex = 17;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButtonClick);
            // 
            // PlaylistControlPanel
            // 
            this.PlaylistControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PlaylistControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlaylistControlPanel.Location = new System.Drawing.Point(610, 12);
            this.PlaylistControlPanel.Name = "PlaylistControlPanel";
            this.PlaylistControlPanel.Size = new System.Drawing.Size(223, 452);
            this.PlaylistControlPanel.TabIndex = 19;
            // 
            // VideoLayoutControlPanel
            // 
            this.VideoLayoutControlPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.VideoLayoutControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VideoLayoutControlPanel.Location = new System.Drawing.Point(3, 3);
            this.VideoLayoutControlPanel.Name = "VideoLayoutControlPanel";
            this.VideoLayoutControlPanel.Size = new System.Drawing.Size(578, 376);
            this.VideoLayoutControlPanel.TabIndex = 10;
            // 
            // PlayerCommunicatorPanel
            // 
            this.PlayerCommunicatorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PlayerCommunicatorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlayerCommunicatorPanel.Location = new System.Drawing.Point(12, 474);
            this.PlayerCommunicatorPanel.Name = "PlayerCommunicatorPanel";
            this.PlayerCommunicatorPanel.Size = new System.Drawing.Size(84, 24);
            this.PlayerCommunicatorPanel.TabIndex = 20;
            // 
            // layoutTabControl
            // 
            this.layoutTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutTabControl.Controls.Add(this.videoLayoutTabPage);
            this.layoutTabControl.Controls.Add(this.videoWindowLayoutTabPage);
            this.layoutTabControl.Location = new System.Drawing.Point(12, 12);
            this.layoutTabControl.Name = "layoutTabControl";
            this.layoutTabControl.SelectedIndex = 0;
            this.layoutTabControl.Size = new System.Drawing.Size(592, 408);
            this.layoutTabControl.TabIndex = 21;
            // 
            // videoLayoutTabPage
            // 
            this.videoLayoutTabPage.Controls.Add(this.VideoLayoutControlPanel);
            this.videoLayoutTabPage.Location = new System.Drawing.Point(4, 22);
            this.videoLayoutTabPage.Name = "videoLayoutTabPage";
            this.videoLayoutTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.videoLayoutTabPage.Size = new System.Drawing.Size(584, 382);
            this.videoLayoutTabPage.TabIndex = 0;
            this.videoLayoutTabPage.Text = "Video Layout";
            this.videoLayoutTabPage.UseVisualStyleBackColor = true;
            // 
            // videoWindowLayoutTabPage
            // 
            this.videoWindowLayoutTabPage.Controls.Add(this.WindowLayoutControlPanel);
            this.videoWindowLayoutTabPage.Location = new System.Drawing.Point(4, 22);
            this.videoWindowLayoutTabPage.Name = "videoWindowLayoutTabPage";
            this.videoWindowLayoutTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.videoWindowLayoutTabPage.Size = new System.Drawing.Size(584, 382);
            this.videoWindowLayoutTabPage.TabIndex = 1;
            this.videoWindowLayoutTabPage.Text = "Window Layout";
            this.videoWindowLayoutTabPage.UseVisualStyleBackColor = true;
            // 
            // WindowLayoutControlPanel
            // 
            this.WindowLayoutControlPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.WindowLayoutControlPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowLayoutControlPanel.Location = new System.Drawing.Point(3, 3);
            this.WindowLayoutControlPanel.Name = "WindowLayoutControlPanel";
            this.WindowLayoutControlPanel.Size = new System.Drawing.Size(578, 376);
            this.WindowLayoutControlPanel.TabIndex = 0;
            // 
            // MultiMediaPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 502);
            this.Controls.Add(this.layoutTabControl);
            this.Controls.Add(this.PlayerCommunicatorPanel);
            this.Controls.Add(this.PlaylistControlPanel);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.PlaybackControlsPanel);
            this.MinimumSize = new System.Drawing.Size(849, 363);
            this.Name = "MultiMediaPlayerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ultra Player: Multi Video mode";
            this.VisibleChanged += new System.EventHandler(this.MultiMediaPlayerFormVisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MultiMediaPlayerForm_FormClosing);
            this.layoutTabControl.ResumeLayout(false);
            this.videoLayoutTabPage.ResumeLayout(false);
            this.videoWindowLayoutTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PlaybackControlsPanel;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Panel PlaylistControlPanel;
        private System.Windows.Forms.Panel VideoLayoutControlPanel;
        private System.Windows.Forms.Panel PlayerCommunicatorPanel;
        private System.Windows.Forms.TabControl layoutTabControl;
        private System.Windows.Forms.TabPage videoLayoutTabPage;
        private System.Windows.Forms.TabPage videoWindowLayoutTabPage;
        private System.Windows.Forms.Panel WindowLayoutControlPanel;
    }
}