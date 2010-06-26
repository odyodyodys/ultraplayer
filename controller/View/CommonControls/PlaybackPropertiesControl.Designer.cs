namespace UltraPlayerController.View.CommonControls
{
    partial class PlaybackPropertiesControl
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
            this.RepeatCheckBox = new System.Windows.Forms.CheckBox();
            this.ShuffleCheckBox = new System.Windows.Forms.CheckBox();
            this.RateSliderControl = new UltraPlayerController.View.CommonControls.ExtendedSliderControl();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RepeatCheckBox
            // 
            this.RepeatCheckBox.AutoSize = true;
            this.RepeatCheckBox.Location = new System.Drawing.Point(68, 3);
            this.RepeatCheckBox.Name = "RepeatCheckBox";
            this.RepeatCheckBox.Size = new System.Drawing.Size(61, 17);
            this.RepeatCheckBox.TabIndex = 14;
            this.RepeatCheckBox.Text = "Repeat";
            this.RepeatCheckBox.UseVisualStyleBackColor = true;
            this.RepeatCheckBox.CheckedChanged += new System.EventHandler(this.RepeatCheckBoxCheckedChanged);
            // 
            // ShuffleCheckBox
            // 
            this.ShuffleCheckBox.AutoSize = true;
            this.ShuffleCheckBox.Location = new System.Drawing.Point(3, 3);
            this.ShuffleCheckBox.Name = "ShuffleCheckBox";
            this.ShuffleCheckBox.Size = new System.Drawing.Size(59, 17);
            this.ShuffleCheckBox.TabIndex = 13;
            this.ShuffleCheckBox.Text = "Shuffle";
            this.ShuffleCheckBox.UseVisualStyleBackColor = true;
            this.ShuffleCheckBox.CheckedChanged += new System.EventHandler(this.ShuffleCheckBoxCheckedChanged);
            // 
            // RateSliderControl
            // 
            this.RateSliderControl.Location = new System.Drawing.Point(3, 23);
            this.RateSliderControl.Name = "RateSliderControl";
            this.RateSliderControl.ParamId = -1;
            this.RateSliderControl.Size = new System.Drawing.Size(134, 52);
            this.RateSliderControl.TabIndex = 15;
            this.RateSliderControl.Value = 0F;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Rate";
            // 
            // PlaybackPropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RateSliderControl);
            this.Controls.Add(this.RepeatCheckBox);
            this.Controls.Add(this.ShuffleCheckBox);
            this.MaximumSize = new System.Drawing.Size(140, 78);
            this.MinimumSize = new System.Drawing.Size(140, 78);
            this.Name = "PlaybackPropertiesControl";
            this.Size = new System.Drawing.Size(140, 78);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox RepeatCheckBox;
        private System.Windows.Forms.CheckBox ShuffleCheckBox;
        private ExtendedSliderControl RateSliderControl;
        private System.Windows.Forms.Label label1;
    }
}
