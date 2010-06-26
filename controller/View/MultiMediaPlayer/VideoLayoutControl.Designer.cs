namespace UltraPlayerController.View.MultiMediaPlayer
{
    partial class VideoLayoutControl
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
            this.DrawingAreaPanel = new System.Windows.Forms.Panel();
            this.AlphaLabel = new System.Windows.Forms.Label();
            this.AlphaScrollBar = new System.Windows.Forms.HScrollBar();
            this.LocationYLabel = new System.Windows.Forms.Label();
            this.SizeYLabel = new System.Windows.Forms.Label();
            this.LocationXLabel = new System.Windows.Forms.Label();
            this.LocationYScrollBar = new System.Windows.Forms.HScrollBar();
            this.SizeXLabel = new System.Windows.Forms.Label();
            this.LocationXScrollBar = new System.Windows.Forms.HScrollBar();
            this.SizeYScrollBar = new System.Windows.Forms.HScrollBar();
            this.SizeXScrollBar = new System.Windows.Forms.HScrollBar();
            this.SizeXValueLabel = new System.Windows.Forms.Label();
            this.SizeYValueLabel = new System.Windows.Forms.Label();
            this.LocationYValueLabel = new System.Windows.Forms.Label();
            this.LocationXValueLabel = new System.Windows.Forms.Label();
            this.AlphaValueLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DrawingAreaPanel
            // 
            this.DrawingAreaPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawingAreaPanel.Location = new System.Drawing.Point(3, 3);
            this.DrawingAreaPanel.Name = "DrawingAreaPanel";
            this.DrawingAreaPanel.Size = new System.Drawing.Size(508, 167);
            this.DrawingAreaPanel.TabIndex = 24;
            this.DrawingAreaPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingAreaPanelPaint);
            // 
            // AlphaLabel
            // 
            this.AlphaLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AlphaLabel.AutoSize = true;
            this.AlphaLabel.Location = new System.Drawing.Point(345, 173);
            this.AlphaLabel.Name = "AlphaLabel";
            this.AlphaLabel.Size = new System.Drawing.Size(37, 13);
            this.AlphaLabel.TabIndex = 19;
            this.AlphaLabel.Text = "Alpha:";
            // 
            // AlphaScrollBar
            // 
            this.AlphaScrollBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AlphaScrollBar.LargeChange = 1;
            this.AlphaScrollBar.Location = new System.Drawing.Point(348, 186);
            this.AlphaScrollBar.Maximum = 255;
            this.AlphaScrollBar.Name = "AlphaScrollBar";
            this.AlphaScrollBar.Size = new System.Drawing.Size(163, 21);
            this.AlphaScrollBar.TabIndex = 18;
            this.AlphaScrollBar.Value = 128;
            this.AlphaScrollBar.ValueChanged += new System.EventHandler(this.AlphaScrollBarValueChanged);
            // 
            // LocationYLabel
            // 
            this.LocationYLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LocationYLabel.AutoSize = true;
            this.LocationYLabel.Location = new System.Drawing.Point(176, 214);
            this.LocationYLabel.Name = "LocationYLabel";
            this.LocationYLabel.Size = new System.Drawing.Size(47, 13);
            this.LocationYLabel.TabIndex = 17;
            this.LocationYLabel.Text = "Origin Y:";
            // 
            // SizeYLabel
            // 
            this.SizeYLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SizeYLabel.AutoSize = true;
            this.SizeYLabel.Location = new System.Drawing.Point(2, 214);
            this.SizeYLabel.Name = "SizeYLabel";
            this.SizeYLabel.Size = new System.Drawing.Size(41, 13);
            this.SizeYLabel.TabIndex = 14;
            this.SizeYLabel.Text = "Height:";
            // 
            // LocationXLabel
            // 
            this.LocationXLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LocationXLabel.AutoSize = true;
            this.LocationXLabel.Location = new System.Drawing.Point(176, 173);
            this.LocationXLabel.Name = "LocationXLabel";
            this.LocationXLabel.Size = new System.Drawing.Size(47, 13);
            this.LocationXLabel.TabIndex = 15;
            this.LocationXLabel.Text = "Origin X:";
            // 
            // LocationYScrollBar
            // 
            this.LocationYScrollBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LocationYScrollBar.LargeChange = 1;
            this.LocationYScrollBar.Location = new System.Drawing.Point(179, 230);
            this.LocationYScrollBar.Maximum = 1000;
            this.LocationYScrollBar.Name = "LocationYScrollBar";
            this.LocationYScrollBar.Size = new System.Drawing.Size(160, 21);
            this.LocationYScrollBar.TabIndex = 11;
            this.LocationYScrollBar.ValueChanged += new System.EventHandler(this.LocationYScrollBarValueChanged);
            // 
            // SizeXLabel
            // 
            this.SizeXLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SizeXLabel.AutoSize = true;
            this.SizeXLabel.Location = new System.Drawing.Point(2, 173);
            this.SizeXLabel.Name = "SizeXLabel";
            this.SizeXLabel.Size = new System.Drawing.Size(38, 13);
            this.SizeXLabel.TabIndex = 16;
            this.SizeXLabel.Text = "Width:";
            // 
            // LocationXScrollBar
            // 
            this.LocationXScrollBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LocationXScrollBar.LargeChange = 1;
            this.LocationXScrollBar.Location = new System.Drawing.Point(179, 186);
            this.LocationXScrollBar.Maximum = 1000;
            this.LocationXScrollBar.Name = "LocationXScrollBar";
            this.LocationXScrollBar.Size = new System.Drawing.Size(160, 21);
            this.LocationXScrollBar.TabIndex = 10;
            this.LocationXScrollBar.ValueChanged += new System.EventHandler(this.LocationXScrollBarValueChanged);
            // 
            // SizeYScrollBar
            // 
            this.SizeYScrollBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SizeYScrollBar.LargeChange = 1;
            this.SizeYScrollBar.Location = new System.Drawing.Point(5, 230);
            this.SizeYScrollBar.Maximum = 1000;
            this.SizeYScrollBar.Name = "SizeYScrollBar";
            this.SizeYScrollBar.Size = new System.Drawing.Size(160, 21);
            this.SizeYScrollBar.TabIndex = 13;
            this.SizeYScrollBar.ValueChanged += new System.EventHandler(this.SizeYScrollBarValueChanged);
            // 
            // SizeXScrollBar
            // 
            this.SizeXScrollBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SizeXScrollBar.LargeChange = 1;
            this.SizeXScrollBar.Location = new System.Drawing.Point(5, 186);
            this.SizeXScrollBar.Maximum = 1000;
            this.SizeXScrollBar.Name = "SizeXScrollBar";
            this.SizeXScrollBar.Size = new System.Drawing.Size(160, 21);
            this.SizeXScrollBar.TabIndex = 12;
            this.SizeXScrollBar.ValueChanged += new System.EventHandler(this.SizeXScrollBarValueChanged);
            // 
            // SizeXValueLabel
            // 
            this.SizeXValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SizeXValueLabel.AutoSize = true;
            this.SizeXValueLabel.Location = new System.Drawing.Point(140, 173);
            this.SizeXValueLabel.Name = "SizeXValueLabel";
            this.SizeXValueLabel.Size = new System.Drawing.Size(31, 13);
            this.SizeXValueLabel.TabIndex = 16;
            this.SizeXValueLabel.Text = "1000";
            // 
            // SizeYValueLabel
            // 
            this.SizeYValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SizeYValueLabel.AutoSize = true;
            this.SizeYValueLabel.Location = new System.Drawing.Point(140, 217);
            this.SizeYValueLabel.Name = "SizeYValueLabel";
            this.SizeYValueLabel.Size = new System.Drawing.Size(31, 13);
            this.SizeYValueLabel.TabIndex = 16;
            this.SizeYValueLabel.Text = "1000";
            // 
            // LocationYValueLabel
            // 
            this.LocationYValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LocationYValueLabel.AutoSize = true;
            this.LocationYValueLabel.Location = new System.Drawing.Point(326, 217);
            this.LocationYValueLabel.Name = "LocationYValueLabel";
            this.LocationYValueLabel.Size = new System.Drawing.Size(13, 13);
            this.LocationYValueLabel.TabIndex = 16;
            this.LocationYValueLabel.Text = "0";
            // 
            // LocationXValueLabel
            // 
            this.LocationXValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LocationXValueLabel.AutoSize = true;
            this.LocationXValueLabel.Location = new System.Drawing.Point(326, 173);
            this.LocationXValueLabel.Name = "LocationXValueLabel";
            this.LocationXValueLabel.Size = new System.Drawing.Size(13, 13);
            this.LocationXValueLabel.TabIndex = 16;
            this.LocationXValueLabel.Text = "0";
            // 
            // AlphaValueLabel
            // 
            this.AlphaValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AlphaValueLabel.AutoSize = true;
            this.AlphaValueLabel.Location = new System.Drawing.Point(486, 173);
            this.AlphaValueLabel.Name = "AlphaValueLabel";
            this.AlphaValueLabel.Size = new System.Drawing.Size(25, 13);
            this.AlphaValueLabel.TabIndex = 16;
            this.AlphaValueLabel.Text = "128";
            // 
            // VideoLayoutControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DrawingAreaPanel);
            this.Controls.Add(this.AlphaLabel);
            this.Controls.Add(this.AlphaScrollBar);
            this.Controls.Add(this.LocationYLabel);
            this.Controls.Add(this.SizeYLabel);
            this.Controls.Add(this.LocationXLabel);
            this.Controls.Add(this.LocationYScrollBar);
            this.Controls.Add(this.AlphaValueLabel);
            this.Controls.Add(this.LocationXValueLabel);
            this.Controls.Add(this.LocationYValueLabel);
            this.Controls.Add(this.SizeYValueLabel);
            this.Controls.Add(this.SizeXValueLabel);
            this.Controls.Add(this.SizeXLabel);
            this.Controls.Add(this.LocationXScrollBar);
            this.Controls.Add(this.SizeYScrollBar);
            this.Controls.Add(this.SizeXScrollBar);
            this.Name = "VideoLayoutControl";
            this.Size = new System.Drawing.Size(515, 259);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel DrawingAreaPanel;
        private System.Windows.Forms.Label AlphaLabel;
        private System.Windows.Forms.HScrollBar AlphaScrollBar;
        private System.Windows.Forms.Label LocationYLabel;
        private System.Windows.Forms.Label SizeYLabel;
        private System.Windows.Forms.Label LocationXLabel;
        private System.Windows.Forms.HScrollBar LocationYScrollBar;
        private System.Windows.Forms.Label SizeXLabel;
        private System.Windows.Forms.HScrollBar LocationXScrollBar;
        private System.Windows.Forms.HScrollBar SizeYScrollBar;
        private System.Windows.Forms.HScrollBar SizeXScrollBar;
        private System.Windows.Forms.Label SizeXValueLabel;
        private System.Windows.Forms.Label SizeYValueLabel;
        private System.Windows.Forms.Label LocationYValueLabel;
        private System.Windows.Forms.Label LocationXValueLabel;
        private System.Windows.Forms.Label AlphaValueLabel;
    }
}
