namespace UltraPlayerController.View.SingleMediaPlayer
{
    partial class ImageAddonPropertiesControl
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
            this.AlphaValueLabel = new System.Windows.Forms.Label();
            this.LocationXValueLabel = new System.Windows.Forms.Label();
            this.LocationYValueLabel = new System.Windows.Forms.Label();
            this.SizeYValueLabel = new System.Windows.Forms.Label();
            this.SizeXValueLabel = new System.Windows.Forms.Label();
            this.SizeXLabel = new System.Windows.Forms.Label();
            this.LocationXScrollBar = new System.Windows.Forms.HScrollBar();
            this.SizeYScrollBar = new System.Windows.Forms.HScrollBar();
            this.SizeXScrollBar = new System.Windows.Forms.HScrollBar();
            this.ImagePreviewPanel = new System.Windows.Forms.Panel();
            this.FileTextBox = new System.Windows.Forms.TextBox();
            this.FileLabel = new System.Windows.Forms.Label();
            this.FileButton = new System.Windows.Forms.Button();
            this.LayoutGroupBox = new System.Windows.Forms.GroupBox();
            this.ImageGroupBox = new System.Windows.Forms.GroupBox();
            this.SelectImageOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.LayoutGroupBox.SuspendLayout();
            this.ImageGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DrawingAreaPanel
            // 
            this.DrawingAreaPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawingAreaPanel.Location = new System.Drawing.Point(178, 19);
            this.DrawingAreaPanel.Name = "DrawingAreaPanel";
            this.DrawingAreaPanel.Size = new System.Drawing.Size(307, 176);
            this.DrawingAreaPanel.TabIndex = 40;
            this.DrawingAreaPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingAreaPanelPaint);
            // 
            // AlphaLabel
            // 
            this.AlphaLabel.AutoSize = true;
            this.AlphaLabel.Location = new System.Drawing.Point(6, 161);
            this.AlphaLabel.Name = "AlphaLabel";
            this.AlphaLabel.Size = new System.Drawing.Size(37, 13);
            this.AlphaLabel.TabIndex = 39;
            this.AlphaLabel.Text = "Alpha:";
            // 
            // AlphaScrollBar
            // 
            this.AlphaScrollBar.LargeChange = 1;
            this.AlphaScrollBar.Location = new System.Drawing.Point(9, 174);
            this.AlphaScrollBar.Maximum = 255;
            this.AlphaScrollBar.Name = "AlphaScrollBar";
            this.AlphaScrollBar.Size = new System.Drawing.Size(163, 21);
            this.AlphaScrollBar.TabIndex = 38;
            this.AlphaScrollBar.Value = 128;
            this.AlphaScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.AlphaScrollBarScroll);
            // 
            // LocationYLabel
            // 
            this.LocationYLabel.AutoSize = true;
            this.LocationYLabel.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.LocationYLabel.Location = new System.Drawing.Point(6, 121);
            this.LocationYLabel.Name = "LocationYLabel";
            this.LocationYLabel.Size = new System.Drawing.Size(22, 23);
            this.LocationYLabel.TabIndex = 37;
            this.LocationYLabel.Text = "$";
            // 
            // SizeYLabel
            // 
            this.SizeYLabel.AutoSize = true;
            this.SizeYLabel.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.SizeYLabel.Location = new System.Drawing.Point(6, 49);
            this.SizeYLabel.Name = "SizeYLabel";
            this.SizeYLabel.Size = new System.Drawing.Size(22, 23);
            this.SizeYLabel.TabIndex = 29;
            this.SizeYLabel.Text = "2";
            // 
            // LocationXLabel
            // 
            this.LocationXLabel.AutoSize = true;
            this.LocationXLabel.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.LocationXLabel.Location = new System.Drawing.Point(6, 87);
            this.LocationXLabel.Name = "LocationXLabel";
            this.LocationXLabel.Size = new System.Drawing.Size(28, 23);
            this.LocationXLabel.TabIndex = 30;
            this.LocationXLabel.Text = "\"";
            // 
            // LocationYScrollBar
            // 
            this.LocationYScrollBar.LargeChange = 1;
            this.LocationYScrollBar.Location = new System.Drawing.Point(9, 140);
            this.LocationYScrollBar.Maximum = 1000;
            this.LocationYScrollBar.Name = "LocationYScrollBar";
            this.LocationYScrollBar.Size = new System.Drawing.Size(160, 21);
            this.LocationYScrollBar.TabIndex = 26;
            this.LocationYScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.LocationYScrollBarScroll);
            // 
            // AlphaValueLabel
            // 
            this.AlphaValueLabel.AutoSize = true;
            this.AlphaValueLabel.Location = new System.Drawing.Point(147, 161);
            this.AlphaValueLabel.Name = "AlphaValueLabel";
            this.AlphaValueLabel.Size = new System.Drawing.Size(25, 13);
            this.AlphaValueLabel.TabIndex = 35;
            this.AlphaValueLabel.Text = "128";
            // 
            // LocationXValueLabel
            // 
            this.LocationXValueLabel.AutoSize = true;
            this.LocationXValueLabel.Location = new System.Drawing.Point(156, 90);
            this.LocationXValueLabel.Name = "LocationXValueLabel";
            this.LocationXValueLabel.Size = new System.Drawing.Size(13, 13);
            this.LocationXValueLabel.TabIndex = 36;
            this.LocationXValueLabel.Text = "0";
            // 
            // LocationYValueLabel
            // 
            this.LocationYValueLabel.AutoSize = true;
            this.LocationYValueLabel.Location = new System.Drawing.Point(156, 127);
            this.LocationYValueLabel.Name = "LocationYValueLabel";
            this.LocationYValueLabel.Size = new System.Drawing.Size(13, 13);
            this.LocationYValueLabel.TabIndex = 34;
            this.LocationYValueLabel.Text = "0";
            // 
            // SizeYValueLabel
            // 
            this.SizeYValueLabel.AutoSize = true;
            this.SizeYValueLabel.Location = new System.Drawing.Point(144, 56);
            this.SizeYValueLabel.Name = "SizeYValueLabel";
            this.SizeYValueLabel.Size = new System.Drawing.Size(31, 13);
            this.SizeYValueLabel.TabIndex = 31;
            this.SizeYValueLabel.Text = "1000";
            // 
            // SizeXValueLabel
            // 
            this.SizeXValueLabel.AutoSize = true;
            this.SizeXValueLabel.Location = new System.Drawing.Point(144, 16);
            this.SizeXValueLabel.Name = "SizeXValueLabel";
            this.SizeXValueLabel.Size = new System.Drawing.Size(31, 13);
            this.SizeXValueLabel.TabIndex = 32;
            this.SizeXValueLabel.Text = "1000";
            // 
            // SizeXLabel
            // 
            this.SizeXLabel.AutoSize = true;
            this.SizeXLabel.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.SizeXLabel.Location = new System.Drawing.Point(6, 14);
            this.SizeXLabel.Name = "SizeXLabel";
            this.SizeXLabel.Size = new System.Drawing.Size(28, 23);
            this.SizeXLabel.TabIndex = 33;
            this.SizeXLabel.Text = "1";
            // 
            // LocationXScrollBar
            // 
            this.LocationXScrollBar.LargeChange = 1;
            this.LocationXScrollBar.Location = new System.Drawing.Point(9, 103);
            this.LocationXScrollBar.Maximum = 1000;
            this.LocationXScrollBar.Name = "LocationXScrollBar";
            this.LocationXScrollBar.Size = new System.Drawing.Size(160, 21);
            this.LocationXScrollBar.TabIndex = 25;
            this.LocationXScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.LocationXScrollBarScroll);
            // 
            // SizeYScrollBar
            // 
            this.SizeYScrollBar.LargeChange = 1;
            this.SizeYScrollBar.Location = new System.Drawing.Point(9, 69);
            this.SizeYScrollBar.Maximum = 1000;
            this.SizeYScrollBar.Name = "SizeYScrollBar";
            this.SizeYScrollBar.Size = new System.Drawing.Size(160, 21);
            this.SizeYScrollBar.TabIndex = 28;
            this.SizeYScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SizeYScrollBarScroll);
            // 
            // SizeXScrollBar
            // 
            this.SizeXScrollBar.LargeChange = 1;
            this.SizeXScrollBar.Location = new System.Drawing.Point(9, 32);
            this.SizeXScrollBar.Maximum = 1000;
            this.SizeXScrollBar.Name = "SizeXScrollBar";
            this.SizeXScrollBar.Size = new System.Drawing.Size(160, 21);
            this.SizeXScrollBar.TabIndex = 27;
            this.SizeXScrollBar.ValueChanged += new System.EventHandler(this.SizeXScrollBarValueChanged);
            // 
            // ImagePreviewPanel
            // 
            this.ImagePreviewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ImagePreviewPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ImagePreviewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImagePreviewPanel.Location = new System.Drawing.Point(284, 16);
            this.ImagePreviewPanel.Name = "ImagePreviewPanel";
            this.ImagePreviewPanel.Size = new System.Drawing.Size(201, 112);
            this.ImagePreviewPanel.TabIndex = 41;
            // 
            // FileTextBox
            // 
            this.FileTextBox.Location = new System.Drawing.Point(7, 32);
            this.FileTextBox.Name = "FileTextBox";
            this.FileTextBox.ReadOnly = true;
            this.FileTextBox.Size = new System.Drawing.Size(235, 20);
            this.FileTextBox.TabIndex = 42;
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
            // FileButton
            // 
            this.FileButton.Location = new System.Drawing.Point(248, 31);
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(30, 21);
            this.FileButton.TabIndex = 43;
            this.FileButton.Text = "...";
            this.FileButton.UseVisualStyleBackColor = true;
            this.FileButton.Click += new System.EventHandler(this.FileButtonClick);
            // 
            // LayoutGroupBox
            // 
            this.LayoutGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LayoutGroupBox.Controls.Add(this.DrawingAreaPanel);
            this.LayoutGroupBox.Controls.Add(this.SizeXScrollBar);
            this.LayoutGroupBox.Controls.Add(this.SizeYScrollBar);
            this.LayoutGroupBox.Controls.Add(this.LocationXScrollBar);
            this.LayoutGroupBox.Controls.Add(this.SizeXLabel);
            this.LayoutGroupBox.Controls.Add(this.AlphaLabel);
            this.LayoutGroupBox.Controls.Add(this.SizeXValueLabel);
            this.LayoutGroupBox.Controls.Add(this.AlphaScrollBar);
            this.LayoutGroupBox.Controls.Add(this.SizeYValueLabel);
            this.LayoutGroupBox.Controls.Add(this.LocationYValueLabel);
            this.LayoutGroupBox.Controls.Add(this.LocationXValueLabel);
            this.LayoutGroupBox.Controls.Add(this.SizeYLabel);
            this.LayoutGroupBox.Controls.Add(this.AlphaValueLabel);
            this.LayoutGroupBox.Controls.Add(this.LocationXLabel);
            this.LayoutGroupBox.Controls.Add(this.LocationYScrollBar);
            this.LayoutGroupBox.Controls.Add(this.LocationYLabel);
            this.LayoutGroupBox.Location = new System.Drawing.Point(3, 3);
            this.LayoutGroupBox.Name = "LayoutGroupBox";
            this.LayoutGroupBox.Size = new System.Drawing.Size(493, 207);
            this.LayoutGroupBox.TabIndex = 44;
            this.LayoutGroupBox.TabStop = false;
            this.LayoutGroupBox.Text = "Layout";
            // 
            // ImageGroupBox
            // 
            this.ImageGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageGroupBox.Controls.Add(this.ImagePreviewPanel);
            this.ImageGroupBox.Controls.Add(this.FileLabel);
            this.ImageGroupBox.Controls.Add(this.FileButton);
            this.ImageGroupBox.Controls.Add(this.FileTextBox);
            this.ImageGroupBox.Location = new System.Drawing.Point(3, 216);
            this.ImageGroupBox.Name = "ImageGroupBox";
            this.ImageGroupBox.Size = new System.Drawing.Size(493, 137);
            this.ImageGroupBox.TabIndex = 45;
            this.ImageGroupBox.TabStop = false;
            this.ImageGroupBox.Text = "Image";
            // 
            // SelectImageOpenFileDialog
            // 
            this.SelectImageOpenFileDialog.Filter = "All files|*.*";
            // 
            // ImageAddonPropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ImageGroupBox);
            this.Controls.Add(this.LayoutGroupBox);
            this.Name = "ImageAddonPropertiesControl";
            this.Size = new System.Drawing.Size(505, 362);
            this.LayoutGroupBox.ResumeLayout(false);
            this.LayoutGroupBox.PerformLayout();
            this.ImageGroupBox.ResumeLayout(false);
            this.ImageGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DrawingAreaPanel;
        private System.Windows.Forms.Label AlphaLabel;
        private System.Windows.Forms.HScrollBar AlphaScrollBar;
        private System.Windows.Forms.Label LocationYLabel;
        private System.Windows.Forms.Label SizeYLabel;
        private System.Windows.Forms.Label LocationXLabel;
        private System.Windows.Forms.HScrollBar LocationYScrollBar;
        private System.Windows.Forms.Label AlphaValueLabel;
        private System.Windows.Forms.Label LocationXValueLabel;
        private System.Windows.Forms.Label LocationYValueLabel;
        private System.Windows.Forms.Label SizeYValueLabel;
        private System.Windows.Forms.Label SizeXValueLabel;
        private System.Windows.Forms.Label SizeXLabel;
        private System.Windows.Forms.HScrollBar LocationXScrollBar;
        private System.Windows.Forms.HScrollBar SizeYScrollBar;
        private System.Windows.Forms.HScrollBar SizeXScrollBar;
        private System.Windows.Forms.Panel ImagePreviewPanel;
        private System.Windows.Forms.TextBox FileTextBox;
        private System.Windows.Forms.Label FileLabel;
        private System.Windows.Forms.Button FileButton;
        private System.Windows.Forms.GroupBox LayoutGroupBox;
        private System.Windows.Forms.GroupBox ImageGroupBox;
        private System.Windows.Forms.OpenFileDialog SelectImageOpenFileDialog;
    }
}
