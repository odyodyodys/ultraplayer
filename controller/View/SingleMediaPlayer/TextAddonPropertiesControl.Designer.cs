namespace UltraPlayerController.View.SingleMediaPlayer
{
    partial class TextAddonPropertiesControl
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
            this.SelectSubtitleOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.LayoutGroupBox = new System.Windows.Forms.GroupBox();
            this.DrawingAreaPanel = new System.Windows.Forms.Panel();
            this.SizeYScrollBar = new System.Windows.Forms.HScrollBar();
            this.AlphaLabel = new System.Windows.Forms.Label();
            this.AlphaScrollBar = new System.Windows.Forms.HScrollBar();
            this.SizeYValueLabel = new System.Windows.Forms.Label();
            this.LocationYValueLabel = new System.Windows.Forms.Label();
            this.SizeYLabel = new System.Windows.Forms.Label();
            this.AlphaValueLabel = new System.Windows.Forms.Label();
            this.LocationYScrollBar = new System.Windows.Forms.HScrollBar();
            this.LocationYLabel = new System.Windows.Forms.Label();
            this.SubtitlesGroupBox = new System.Windows.Forms.GroupBox();
            this.DurationLabel = new System.Windows.Forms.Label();
            this.SubtitlesCountLabel = new System.Windows.Forms.Label();
            this.FileLabel = new System.Windows.Forms.Label();
            this.DurationTextBox = new System.Windows.Forms.TextBox();
            this.FileButton = new System.Windows.Forms.Button();
            this.SubtitlesCountTextBox = new System.Windows.Forms.TextBox();
            this.FileTextBox = new System.Windows.Forms.TextBox();
            this.SubtitleBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.LayoutGroupBox.SuspendLayout();
            this.SubtitlesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectSubtitleOpenFileDialog
            // 
            this.SelectSubtitleOpenFileDialog.Filter = "SubRip subtitles|*.srt|All files|*.*";
            // 
            // LayoutGroupBox
            // 
            this.LayoutGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LayoutGroupBox.Controls.Add(this.DrawingAreaPanel);
            this.LayoutGroupBox.Controls.Add(this.SizeYScrollBar);
            this.LayoutGroupBox.Controls.Add(this.AlphaLabel);
            this.LayoutGroupBox.Controls.Add(this.AlphaScrollBar);
            this.LayoutGroupBox.Controls.Add(this.SizeYValueLabel);
            this.LayoutGroupBox.Controls.Add(this.LocationYValueLabel);
            this.LayoutGroupBox.Controls.Add(this.SizeYLabel);
            this.LayoutGroupBox.Controls.Add(this.AlphaValueLabel);
            this.LayoutGroupBox.Controls.Add(this.LocationYScrollBar);
            this.LayoutGroupBox.Controls.Add(this.LocationYLabel);
            this.LayoutGroupBox.Location = new System.Drawing.Point(3, 3);
            this.LayoutGroupBox.Name = "LayoutGroupBox";
            this.LayoutGroupBox.Size = new System.Drawing.Size(431, 207);
            this.LayoutGroupBox.TabIndex = 45;
            this.LayoutGroupBox.TabStop = false;
            this.LayoutGroupBox.Text = "Layout";
            // 
            // DrawingAreaPanel
            // 
            this.DrawingAreaPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawingAreaPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawingAreaPanel.Location = new System.Drawing.Point(178, 19);
            this.DrawingAreaPanel.Name = "DrawingAreaPanel";
            this.DrawingAreaPanel.Size = new System.Drawing.Size(245, 176);
            this.DrawingAreaPanel.TabIndex = 40;
            this.DrawingAreaPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingAreaPanelPaint);
            // 
            // SizeYScrollBar
            // 
            this.SizeYScrollBar.LargeChange = 1;
            this.SizeYScrollBar.Location = new System.Drawing.Point(9, 39);
            this.SizeYScrollBar.Maximum = 1000;
            this.SizeYScrollBar.Name = "SizeYScrollBar";
            this.SizeYScrollBar.Size = new System.Drawing.Size(160, 21);
            this.SizeYScrollBar.TabIndex = 28;
            this.SizeYScrollBar.ValueChanged += new System.EventHandler(this.SizeYScrollBarValueChanged);
            // 
            // AlphaLabel
            // 
            this.AlphaLabel.AutoSize = true;
            this.AlphaLabel.Location = new System.Drawing.Point(6, 100);
            this.AlphaLabel.Name = "AlphaLabel";
            this.AlphaLabel.Size = new System.Drawing.Size(37, 13);
            this.AlphaLabel.TabIndex = 39;
            this.AlphaLabel.Text = "Alpha:";
            // 
            // AlphaScrollBar
            // 
            this.AlphaScrollBar.LargeChange = 1;
            this.AlphaScrollBar.Location = new System.Drawing.Point(9, 113);
            this.AlphaScrollBar.Maximum = 255;
            this.AlphaScrollBar.Name = "AlphaScrollBar";
            this.AlphaScrollBar.Size = new System.Drawing.Size(163, 21);
            this.AlphaScrollBar.TabIndex = 38;
            this.AlphaScrollBar.Value = 128;
            this.AlphaScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.AlphaScrollBarScroll);
            // 
            // SizeYValueLabel
            // 
            this.SizeYValueLabel.AutoSize = true;
            this.SizeYValueLabel.Location = new System.Drawing.Point(144, 26);
            this.SizeYValueLabel.Name = "SizeYValueLabel";
            this.SizeYValueLabel.Size = new System.Drawing.Size(31, 13);
            this.SizeYValueLabel.TabIndex = 31;
            this.SizeYValueLabel.Text = "1000";
            // 
            // LocationYValueLabel
            // 
            this.LocationYValueLabel.AutoSize = true;
            this.LocationYValueLabel.Location = new System.Drawing.Point(156, 66);
            this.LocationYValueLabel.Name = "LocationYValueLabel";
            this.LocationYValueLabel.Size = new System.Drawing.Size(13, 13);
            this.LocationYValueLabel.TabIndex = 34;
            this.LocationYValueLabel.Text = "0";
            // 
            // SizeYLabel
            // 
            this.SizeYLabel.AutoSize = true;
            this.SizeYLabel.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.SizeYLabel.Location = new System.Drawing.Point(6, 19);
            this.SizeYLabel.Name = "SizeYLabel";
            this.SizeYLabel.Size = new System.Drawing.Size(22, 23);
            this.SizeYLabel.TabIndex = 29;
            this.SizeYLabel.Text = "2";
            // 
            // AlphaValueLabel
            // 
            this.AlphaValueLabel.AutoSize = true;
            this.AlphaValueLabel.Location = new System.Drawing.Point(147, 100);
            this.AlphaValueLabel.Name = "AlphaValueLabel";
            this.AlphaValueLabel.Size = new System.Drawing.Size(25, 13);
            this.AlphaValueLabel.TabIndex = 35;
            this.AlphaValueLabel.Text = "128";
            // 
            // LocationYScrollBar
            // 
            this.LocationYScrollBar.LargeChange = 1;
            this.LocationYScrollBar.Location = new System.Drawing.Point(9, 79);
            this.LocationYScrollBar.Maximum = 1000;
            this.LocationYScrollBar.Name = "LocationYScrollBar";
            this.LocationYScrollBar.Size = new System.Drawing.Size(160, 21);
            this.LocationYScrollBar.TabIndex = 26;
            this.LocationYScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.LocationYScrollBarScroll);
            // 
            // LocationYLabel
            // 
            this.LocationYLabel.AutoSize = true;
            this.LocationYLabel.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.LocationYLabel.Location = new System.Drawing.Point(6, 60);
            this.LocationYLabel.Name = "LocationYLabel";
            this.LocationYLabel.Size = new System.Drawing.Size(22, 23);
            this.LocationYLabel.TabIndex = 37;
            this.LocationYLabel.Text = "$";
            // 
            // SubtitlesGroupBox
            // 
            this.SubtitlesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SubtitlesGroupBox.Controls.Add(this.DurationLabel);
            this.SubtitlesGroupBox.Controls.Add(this.SubtitlesCountLabel);
            this.SubtitlesGroupBox.Controls.Add(this.FileLabel);
            this.SubtitlesGroupBox.Controls.Add(this.DurationTextBox);
            this.SubtitlesGroupBox.Controls.Add(this.FileButton);
            this.SubtitlesGroupBox.Controls.Add(this.SubtitlesCountTextBox);
            this.SubtitlesGroupBox.Controls.Add(this.FileTextBox);
            this.SubtitlesGroupBox.Location = new System.Drawing.Point(3, 216);
            this.SubtitlesGroupBox.Name = "SubtitlesGroupBox";
            this.SubtitlesGroupBox.Size = new System.Drawing.Size(431, 69);
            this.SubtitlesGroupBox.TabIndex = 46;
            this.SubtitlesGroupBox.TabStop = false;
            this.SubtitlesGroupBox.Text = "Subtitles file";
            // 
            // DurationLabel
            // 
            this.DurationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DurationLabel.AutoSize = true;
            this.DurationLabel.Location = new System.Drawing.Point(266, 42);
            this.DurationLabel.Name = "DurationLabel";
            this.DurationLabel.Size = new System.Drawing.Size(50, 13);
            this.DurationLabel.TabIndex = 29;
            this.DurationLabel.Text = "Duration:";
            // 
            // SubtitlesCountLabel
            // 
            this.SubtitlesCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SubtitlesCountLabel.AutoSize = true;
            this.SubtitlesCountLabel.Location = new System.Drawing.Point(266, 16);
            this.SubtitlesCountLabel.Name = "SubtitlesCountLabel";
            this.SubtitlesCountLabel.Size = new System.Drawing.Size(50, 13);
            this.SubtitlesCountLabel.TabIndex = 29;
            this.SubtitlesCountLabel.Text = "Subtitles:";
            // 
            // FileLabel
            // 
            this.FileLabel.AutoSize = true;
            this.FileLabel.Location = new System.Drawing.Point(4, 16);
            this.FileLabel.Name = "FileLabel";
            this.FileLabel.Size = new System.Drawing.Size(26, 13);
            this.FileLabel.TabIndex = 29;
            this.FileLabel.Text = "File:";
            // 
            // DurationTextBox
            // 
            this.DurationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DurationTextBox.Location = new System.Drawing.Point(322, 39);
            this.DurationTextBox.Name = "DurationTextBox";
            this.DurationTextBox.ReadOnly = true;
            this.DurationTextBox.Size = new System.Drawing.Size(101, 20);
            this.DurationTextBox.TabIndex = 42;
            // 
            // FileButton
            // 
            this.FileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FileButton.Location = new System.Drawing.Point(186, 31);
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(30, 21);
            this.FileButton.TabIndex = 43;
            this.FileButton.Text = "...";
            this.FileButton.UseVisualStyleBackColor = true;
            this.FileButton.Click += new System.EventHandler(this.FileButtonClick);
            // 
            // SubtitlesCountTextBox
            // 
            this.SubtitlesCountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SubtitlesCountTextBox.Location = new System.Drawing.Point(322, 13);
            this.SubtitlesCountTextBox.Name = "SubtitlesCountTextBox";
            this.SubtitlesCountTextBox.ReadOnly = true;
            this.SubtitlesCountTextBox.Size = new System.Drawing.Size(101, 20);
            this.SubtitlesCountTextBox.TabIndex = 42;
            // 
            // FileTextBox
            // 
            this.FileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FileTextBox.Location = new System.Drawing.Point(7, 32);
            this.FileTextBox.Name = "FileTextBox";
            this.FileTextBox.ReadOnly = true;
            this.FileTextBox.Size = new System.Drawing.Size(173, 20);
            this.FileTextBox.TabIndex = 42;
            // 
            // SubtitleBackgroundWorker
            // 
            this.SubtitleBackgroundWorker.WorkerReportsProgress = true;
            this.SubtitleBackgroundWorker.WorkerSupportsCancellation = true;
            this.SubtitleBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SubtitleBackgroundWorkerDoWork);
            this.SubtitleBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SubtitleBackgroundWorkerRunWorkerCompleted);
            this.SubtitleBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.SubtitleBackgroundWorkerProgressChanged);
            // 
            // TextAddonPropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SubtitlesGroupBox);
            this.Controls.Add(this.LayoutGroupBox);
            this.Name = "TextAddonPropertiesControl";
            this.Size = new System.Drawing.Size(439, 290);
            this.LayoutGroupBox.ResumeLayout(false);
            this.LayoutGroupBox.PerformLayout();
            this.SubtitlesGroupBox.ResumeLayout(false);
            this.SubtitlesGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog SelectSubtitleOpenFileDialog;
        private System.Windows.Forms.GroupBox LayoutGroupBox;
        private System.Windows.Forms.Panel DrawingAreaPanel;
        private System.Windows.Forms.HScrollBar SizeYScrollBar;
        private System.Windows.Forms.Label AlphaLabel;
        private System.Windows.Forms.HScrollBar AlphaScrollBar;
        private System.Windows.Forms.Label SizeYValueLabel;
        private System.Windows.Forms.Label LocationYValueLabel;
        private System.Windows.Forms.Label SizeYLabel;
        private System.Windows.Forms.Label AlphaValueLabel;
        private System.Windows.Forms.HScrollBar LocationYScrollBar;
        private System.Windows.Forms.Label LocationYLabel;
        private System.Windows.Forms.GroupBox SubtitlesGroupBox;
        private System.Windows.Forms.Label FileLabel;
        private System.Windows.Forms.Button FileButton;
        private System.Windows.Forms.TextBox FileTextBox;
        private System.Windows.Forms.Label SubtitlesCountLabel;
        private System.Windows.Forms.TextBox SubtitlesCountTextBox;
        private System.Windows.Forms.Label DurationLabel;
        private System.Windows.Forms.TextBox DurationTextBox;
        private System.ComponentModel.BackgroundWorker SubtitleBackgroundWorker;
    }
}
