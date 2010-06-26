namespace UltraPlayerController.View.AudioPlayer
{
    partial class LabeledExtendedSliderControl
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
            this.ParamTrackBar = new System.Windows.Forms.TrackBar();
            this.ParamValueLabel = new System.Windows.Forms.Label();
            this.ParamMaxLabel = new System.Windows.Forms.Label();
            this.ParamMinLabel = new System.Windows.Forms.Label();
            this.ParamNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ParamTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // ParamTrackBar
            // 
            this.ParamTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ParamTrackBar.Location = new System.Drawing.Point(52, 3);
            this.ParamTrackBar.Name = "ParamTrackBar";
            this.ParamTrackBar.Size = new System.Drawing.Size(173, 45);
            this.ParamTrackBar.TabIndex = 10;
            this.ParamTrackBar.TickFrequency = 10;
            this.ParamTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.ParamTrackBar.Scroll += new System.EventHandler(this.ParamTrackBar_Scroll);
            // 
            // ParamValueLabel
            // 
            this.ParamValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ParamValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ParamValueLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.ParamValueLabel.Location = new System.Drawing.Point(7, 21);
            this.ParamValueLabel.Name = "ParamValueLabel";
            this.ParamValueLabel.Size = new System.Drawing.Size(41, 17);
            this.ParamValueLabel.TabIndex = 9;
            this.ParamValueLabel.Text = "55555";
            // 
            // ParamMaxLabel
            // 
            this.ParamMaxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ParamMaxLabel.AutoSize = true;
            this.ParamMaxLabel.BackColor = System.Drawing.Color.Transparent;
            this.ParamMaxLabel.ForeColor = System.Drawing.Color.Green;
            this.ParamMaxLabel.Location = new System.Drawing.Point(188, 35);
            this.ParamMaxLabel.Name = "ParamMaxLabel";
            this.ParamMaxLabel.Size = new System.Drawing.Size(37, 13);
            this.ParamMaxLabel.TabIndex = 8;
            this.ParamMaxLabel.Text = "99999";
            // 
            // ParamMinLabel
            // 
            this.ParamMinLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ParamMinLabel.AutoSize = true;
            this.ParamMinLabel.ForeColor = System.Drawing.Color.Firebrick;
            this.ParamMinLabel.Location = new System.Drawing.Point(59, 35);
            this.ParamMinLabel.Name = "ParamMinLabel";
            this.ParamMinLabel.Size = new System.Drawing.Size(37, 13);
            this.ParamMinLabel.TabIndex = 7;
            this.ParamMinLabel.Text = "00000";
            // 
            // ParamNameLabel
            // 
            this.ParamNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ParamNameLabel.Location = new System.Drawing.Point(3, 3);
            this.ParamNameLabel.Name = "ParamNameLabel";
            this.ParamNameLabel.Size = new System.Drawing.Size(52, 13);
            this.ParamNameLabel.TabIndex = 6;
            this.ParamNameLabel.Text = "ParamName";
            this.ParamNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EffectParameterValueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ParamMinLabel);
            this.Controls.Add(this.ParamValueLabel);
            this.Controls.Add(this.ParamMaxLabel);
            this.Controls.Add(this.ParamNameLabel);
            this.Controls.Add(this.ParamTrackBar);
            this.MinimumSize = new System.Drawing.Size(231, 51);
            this.Name = "EffectParameterValueControl";
            this.Size = new System.Drawing.Size(231, 51);
            ((System.ComponentModel.ISupportInitialize)(this.ParamTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar ParamTrackBar;
        private System.Windows.Forms.Label ParamValueLabel;
        private System.Windows.Forms.Label ParamMaxLabel;
        private System.Windows.Forms.Label ParamMinLabel;
        private System.Windows.Forms.Label ParamNameLabel;
    }
}
