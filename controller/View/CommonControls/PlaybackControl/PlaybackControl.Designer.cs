namespace UltraPlayerController.View
{
    partial class PlaybackControl
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
            this.components = new System.ComponentModel.Container();
            this.VolumeLabel = new System.Windows.Forms.Label();
            this.VolumeScrollBar = new System.Windows.Forms.HScrollBar();
            this.NextTrackButton = new System.Windows.Forms.Button();
            this.PreviousTrackButton = new System.Windows.Forms.Button();
            this.PlayPauseButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.VolumeValueLabel = new System.Windows.Forms.Label();
            this.VolumeMuteButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.PlaybackTimer = new System.Windows.Forms.Timer(this.components);
            this.PlayingTimeLabel = new System.Windows.Forms.Label();
            this.TimeSeparatorLabel = new System.Windows.Forms.Label();
            this.FullTimeLabel = new System.Windows.Forms.Label();
            this.DurationProgressBar = new VistaStyleProgressBar.XpProgressBar();
            this.SuspendLayout();
            // 
            // VolumeLabel
            // 
            this.VolumeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeLabel.AutoSize = true;
            this.VolumeLabel.Location = new System.Drawing.Point(218, 27);
            this.VolumeLabel.Name = "VolumeLabel";
            this.VolumeLabel.Size = new System.Drawing.Size(45, 13);
            this.VolumeLabel.TabIndex = 18;
            this.VolumeLabel.Text = "Volume:";
            // 
            // VolumeScrollBar
            // 
            this.VolumeScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeScrollBar.LargeChange = 1;
            this.VolumeScrollBar.Location = new System.Drawing.Point(221, 41);
            this.VolumeScrollBar.Minimum = 1;
            this.VolumeScrollBar.Name = "VolumeScrollBar";
            this.VolumeScrollBar.Size = new System.Drawing.Size(115, 24);
            this.VolumeScrollBar.TabIndex = 19;
            this.VolumeScrollBar.Value = 75;
            this.VolumeScrollBar.ValueChanged += new System.EventHandler(this.VolumeScrollBarValueChanged);
            // 
            // NextTrackButton
            // 
            this.NextTrackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NextTrackButton.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.NextTrackButton.Location = new System.Drawing.Point(179, 41);
            this.NextTrackButton.Name = "NextTrackButton";
            this.NextTrackButton.Size = new System.Drawing.Size(39, 24);
            this.NextTrackButton.TabIndex = 16;
            this.NextTrackButton.Text = "uu";
            this.NextTrackButton.UseVisualStyleBackColor = true;
            this.NextTrackButton.Click += new System.EventHandler(this.NextTrackButtonClick);
            // 
            // PreviousTrackButton
            // 
            this.PreviousTrackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PreviousTrackButton.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.PreviousTrackButton.Location = new System.Drawing.Point(3, 41);
            this.PreviousTrackButton.Name = "PreviousTrackButton";
            this.PreviousTrackButton.Size = new System.Drawing.Size(39, 24);
            this.PreviousTrackButton.TabIndex = 12;
            this.PreviousTrackButton.Text = "tt";
            this.PreviousTrackButton.UseVisualStyleBackColor = true;
            this.PreviousTrackButton.Click += new System.EventHandler(this.PreviousTrackButtonClick);
            // 
            // PlayPauseButton
            // 
            this.PlayPauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PlayPauseButton.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.PlayPauseButton.Location = new System.Drawing.Point(47, 41);
            this.PlayPauseButton.Name = "PlayPauseButton";
            this.PlayPauseButton.Size = new System.Drawing.Size(39, 24);
            this.PlayPauseButton.TabIndex = 13;
            this.PlayPauseButton.Text = "u";
            this.PlayPauseButton.UseVisualStyleBackColor = true;
            this.PlayPauseButton.Click += new System.EventHandler(this.PlayPauseButtonClick);
            // 
            // StopButton
            // 
            this.StopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StopButton.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.StopButton.Location = new System.Drawing.Point(135, 41);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(38, 24);
            this.StopButton.TabIndex = 15;
            this.StopButton.Text = "n";
            this.StopButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButtonClick);
            // 
            // VolumeValueLabel
            // 
            this.VolumeValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeValueLabel.Location = new System.Drawing.Point(258, 27);
            this.VolumeValueLabel.Name = "VolumeValueLabel";
            this.VolumeValueLabel.Size = new System.Drawing.Size(32, 13);
            this.VolumeValueLabel.TabIndex = 18;
            this.VolumeValueLabel.Text = "75";
            // 
            // VolumeMuteButton
            // 
            this.VolumeMuteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.VolumeMuteButton.Location = new System.Drawing.Point(315, 24);
            this.VolumeMuteButton.Name = "VolumeMuteButton";
            this.VolumeMuteButton.Size = new System.Drawing.Size(21, 18);
            this.VolumeMuteButton.TabIndex = 20;
            this.VolumeMuteButton.Text = "M";
            this.VolumeMuteButton.UseVisualStyleBackColor = true;
            this.VolumeMuteButton.Click += new System.EventHandler(this.VolumeMuteButtonClick);
            // 
            // PauseButton
            // 
            this.PauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PauseButton.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.PauseButton.Location = new System.Drawing.Point(91, 41);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(39, 24);
            this.PauseButton.TabIndex = 16;
            this.PauseButton.Text = " ▌▌";
            this.PauseButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButtonClick);
            // 
            // PlaybackTimer
            // 
            this.PlaybackTimer.Tick += new System.EventHandler(this.PlaybackTimerTick);
            // 
            // PlayingTimeLabel
            // 
            this.PlayingTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.PlayingTimeLabel.Location = new System.Drawing.Point(3, 24);
            this.PlayingTimeLabel.Name = "PlayingTimeLabel";
            this.PlayingTimeLabel.Size = new System.Drawing.Size(34, 14);
            this.PlayingTimeLabel.TabIndex = 22;
            this.PlayingTimeLabel.Text = "00:00";
            // 
            // TimeSeparatorLabel
            // 
            this.TimeSeparatorLabel.AutoSize = true;
            this.TimeSeparatorLabel.BackColor = System.Drawing.Color.Transparent;
            this.TimeSeparatorLabel.Location = new System.Drawing.Point(33, 24);
            this.TimeSeparatorLabel.Name = "TimeSeparatorLabel";
            this.TimeSeparatorLabel.Size = new System.Drawing.Size(12, 13);
            this.TimeSeparatorLabel.TabIndex = 22;
            this.TimeSeparatorLabel.Text = "/";
            // 
            // FullTimeLabel
            // 
            this.FullTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.FullTimeLabel.Location = new System.Drawing.Point(41, 24);
            this.FullTimeLabel.Name = "FullTimeLabel";
            this.FullTimeLabel.Size = new System.Drawing.Size(34, 14);
            this.FullTimeLabel.TabIndex = 22;
            this.FullTimeLabel.Text = "00:00";
            // 
            // DurationProgressBar
            // 
            this.DurationProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DurationProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.DurationProgressBar.Location = new System.Drawing.Point(3, 3);
            this.DurationProgressBar.MaxValue = 1;
            this.DurationProgressBar.Name = "DurationProgressBar";
            this.DurationProgressBar.Size = new System.Drawing.Size(333, 20);
            this.DurationProgressBar.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(211)))), ((int)(((byte)(40)))));
            this.DurationProgressBar.TabIndex = 21;
            this.DurationProgressBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DurationProgressBarMouseUp);
            this.DurationProgressBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DurationProgressBarMouseMove);
            // 
            // PlaybackControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FullTimeLabel);
            this.Controls.Add(this.PlayingTimeLabel);
            this.Controls.Add(this.DurationProgressBar);
            this.Controls.Add(this.VolumeMuteButton);
            this.Controls.Add(this.VolumeValueLabel);
            this.Controls.Add(this.VolumeLabel);
            this.Controls.Add(this.VolumeScrollBar);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.NextTrackButton);
            this.Controls.Add(this.PreviousTrackButton);
            this.Controls.Add(this.PlayPauseButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.TimeSeparatorLabel);
            this.MinimumSize = new System.Drawing.Size(339, 68);
            this.Name = "PlaybackControl";
            this.Size = new System.Drawing.Size(339, 68);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label VolumeLabel;
        private System.Windows.Forms.HScrollBar VolumeScrollBar;
        private System.Windows.Forms.Button NextTrackButton;
        private System.Windows.Forms.Button PreviousTrackButton;
        private System.Windows.Forms.Button PlayPauseButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Label VolumeValueLabel;
        private System.Windows.Forms.Button VolumeMuteButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Timer PlaybackTimer;
        private VistaStyleProgressBar.XpProgressBar DurationProgressBar;
        private System.Windows.Forms.Label PlayingTimeLabel;
        private System.Windows.Forms.Label TimeSeparatorLabel;
        private System.Windows.Forms.Label FullTimeLabel;
    }
}
