namespace UltraPlayerController.View.AudioPlayer
{
    partial class PhasePropertiesControl
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
            this.Minus180RadioButton = new System.Windows.Forms.RadioButton();
            this.Minus90RadioButton = new System.Windows.Forms.RadioButton();
            this.ZeroRadioButton = new System.Windows.Forms.RadioButton();
            this.Plus90RadioButton = new System.Windows.Forms.RadioButton();
            this.Plus180RadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // Minus180RadioButton
            // 
            this.Minus180RadioButton.AutoSize = true;
            this.Minus180RadioButton.Location = new System.Drawing.Point(3, 3);
            this.Minus180RadioButton.Name = "Minus180RadioButton";
            this.Minus180RadioButton.Size = new System.Drawing.Size(46, 17);
            this.Minus180RadioButton.TabIndex = 4;
            this.Minus180RadioButton.Text = "-180";
            this.Minus180RadioButton.UseVisualStyleBackColor = true;
            this.Minus180RadioButton.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // Minus90RadioButton
            // 
            this.Minus90RadioButton.AutoSize = true;
            this.Minus90RadioButton.Location = new System.Drawing.Point(55, 3);
            this.Minus90RadioButton.Name = "Minus90RadioButton";
            this.Minus90RadioButton.Size = new System.Drawing.Size(40, 17);
            this.Minus90RadioButton.TabIndex = 5;
            this.Minus90RadioButton.Text = "-90";
            this.Minus90RadioButton.UseVisualStyleBackColor = true;
            this.Minus90RadioButton.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // ZeroRadioButton
            // 
            this.ZeroRadioButton.AutoSize = true;
            this.ZeroRadioButton.Checked = true;
            this.ZeroRadioButton.Location = new System.Drawing.Point(101, 3);
            this.ZeroRadioButton.Name = "ZeroRadioButton";
            this.ZeroRadioButton.Size = new System.Drawing.Size(31, 17);
            this.ZeroRadioButton.TabIndex = 3;
            this.ZeroRadioButton.TabStop = true;
            this.ZeroRadioButton.Text = "0";
            this.ZeroRadioButton.UseVisualStyleBackColor = true;
            this.ZeroRadioButton.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // Plus90RadioButton
            // 
            this.Plus90RadioButton.AutoSize = true;
            this.Plus90RadioButton.Location = new System.Drawing.Point(138, 3);
            this.Plus90RadioButton.Name = "Plus90RadioButton";
            this.Plus90RadioButton.Size = new System.Drawing.Size(37, 17);
            this.Plus90RadioButton.TabIndex = 1;
            this.Plus90RadioButton.Text = "90";
            this.Plus90RadioButton.UseVisualStyleBackColor = true;
            this.Plus90RadioButton.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // Plus180RadioButton
            // 
            this.Plus180RadioButton.AutoSize = true;
            this.Plus180RadioButton.Location = new System.Drawing.Point(181, 3);
            this.Plus180RadioButton.Name = "Plus180RadioButton";
            this.Plus180RadioButton.Size = new System.Drawing.Size(43, 17);
            this.Plus180RadioButton.TabIndex = 2;
            this.Plus180RadioButton.Text = "180";
            this.Plus180RadioButton.UseVisualStyleBackColor = true;
            this.Plus180RadioButton.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // PhasePropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Minus180RadioButton);
            this.Controls.Add(this.Minus90RadioButton);
            this.Controls.Add(this.ZeroRadioButton);
            this.Controls.Add(this.Plus90RadioButton);
            this.Controls.Add(this.Plus180RadioButton);
            this.Name = "PhasePropertiesControl";
            this.Size = new System.Drawing.Size(231, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton Minus180RadioButton;
        private System.Windows.Forms.RadioButton Minus90RadioButton;
        private System.Windows.Forms.RadioButton ZeroRadioButton;
        private System.Windows.Forms.RadioButton Plus90RadioButton;
        private System.Windows.Forms.RadioButton Plus180RadioButton;
    }
}
