namespace UltraPlayerController.View.AudioPlayer
{
    partial class SpatializationForm
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
            this.SpatializationProperties = new UltraPlayerController.View.AudioPlayer.SpatializationPropertiesControl();
            this.SuspendLayout();
            // 
            // SpatializationProperties
            // 
            this.SpatializationProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpatializationProperties.Location = new System.Drawing.Point(0, 0);
            this.SpatializationProperties.Name = "SpatializationProperties";
            this.SpatializationProperties.Size = new System.Drawing.Size(534, 258);
            this.SpatializationProperties.TabIndex = 0;
            // 
            // SpatializationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 258);
            this.Controls.Add(this.SpatializationProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SpatializationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "3d Sound Properties";
            this.ResumeLayout(false);

        }

        #endregion

        private SpatializationPropertiesControl SpatializationProperties;
    }
}