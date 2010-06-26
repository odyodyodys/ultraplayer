namespace UltraPlayerController.View.CommonControls
{
    partial class ExtendedSliderControl
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
            this.ParamValueLabel = new System.Windows.Forms.Label();
            this.ParamTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.ParamTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // ParamValueLabel
            // 
            this.ParamValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ParamValueLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.ParamValueLabel.Location = new System.Drawing.Point(0, 35);
            this.ParamValueLabel.Name = "ParamValueLabel";
            this.ParamValueLabel.Size = new System.Drawing.Size(41, 17);
            this.ParamValueLabel.TabIndex = 14;
            this.ParamValueLabel.Text = "55555";
            // 
            // ParamTrackBar
            // 
            this.ParamTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ParamTrackBar.Location = new System.Drawing.Point(3, 3);
            this.ParamTrackBar.Name = "ParamTrackBar";
            this.ParamTrackBar.Size = new System.Drawing.Size(127, 45);
            this.ParamTrackBar.TabIndex = 15;
            this.ParamTrackBar.TickFrequency = 10;
            this.ParamTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.ParamTrackBar.Value = 5;
            this.ParamTrackBar.ValueChanged += new System.EventHandler(this.ParamTrackBarScroll);
            // 
            // ExtendedSliderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ParamValueLabel);
            this.Controls.Add(this.ParamTrackBar);
            this.Name = "ExtendedSliderControl";
            this.Size = new System.Drawing.Size(134, 52);
            ((System.ComponentModel.ISupportInitialize)(this.ParamTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ParamValueLabel;
        private System.Windows.Forms.TrackBar ParamTrackBar;
    }
}
