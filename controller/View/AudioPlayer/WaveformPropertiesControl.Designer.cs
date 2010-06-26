namespace UltraPlayerController.View.AudioPlayer
{
    partial class WaveformPropertiesControl
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
            this.TriangleRadioButton = new System.Windows.Forms.RadioButton();
            this.SquareRadioButton = new System.Windows.Forms.RadioButton();
            this.SineRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // TriangleRadioButton
            // 
            this.TriangleRadioButton.AutoSize = true;
            this.TriangleRadioButton.Location = new System.Drawing.Point(3, 3);
            this.TriangleRadioButton.Name = "TriangleRadioButton";
            this.TriangleRadioButton.Size = new System.Drawing.Size(63, 17);
            this.TriangleRadioButton.TabIndex = 0;
            this.TriangleRadioButton.TabStop = true;
            this.TriangleRadioButton.Text = "Triangle";
            this.TriangleRadioButton.UseVisualStyleBackColor = true;
            this.TriangleRadioButton.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // SquareRadioButton
            // 
            this.SquareRadioButton.AutoSize = true;
            this.SquareRadioButton.Location = new System.Drawing.Point(72, 3);
            this.SquareRadioButton.Name = "SquareRadioButton";
            this.SquareRadioButton.Size = new System.Drawing.Size(59, 17);
            this.SquareRadioButton.TabIndex = 0;
            this.SquareRadioButton.TabStop = true;
            this.SquareRadioButton.Text = "Square";
            this.SquareRadioButton.UseVisualStyleBackColor = true;
            this.SquareRadioButton.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // SineRadioButton
            // 
            this.SineRadioButton.AutoSize = true;
            this.SineRadioButton.Location = new System.Drawing.Point(137, 3);
            this.SineRadioButton.Name = "SineRadioButton";
            this.SineRadioButton.Size = new System.Drawing.Size(46, 17);
            this.SineRadioButton.TabIndex = 0;
            this.SineRadioButton.TabStop = true;
            this.SineRadioButton.Text = "Sine";
            this.SineRadioButton.UseVisualStyleBackColor = true;
            this.SineRadioButton.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // WaveformPropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SineRadioButton);
            this.Controls.Add(this.SquareRadioButton);
            this.Controls.Add(this.TriangleRadioButton);
            this.Name = "WaveformPropertiesControl";
            this.Size = new System.Drawing.Size(189, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton TriangleRadioButton;
        private System.Windows.Forms.RadioButton SquareRadioButton;
        private System.Windows.Forms.RadioButton SineRadioButton;
    }
}
