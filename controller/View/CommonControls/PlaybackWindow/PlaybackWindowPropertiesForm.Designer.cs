namespace UltraPlayerController.View.CommonControls.PlaybackWindow
{
    partial class PlaybackWindowPropertiesForm
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
            this.PlaybackWindowPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // PlaybackWindowPanel
            // 
            this.PlaybackWindowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlaybackWindowPanel.Location = new System.Drawing.Point(0, 0);
            this.PlaybackWindowPanel.Name = "PlaybackWindowPanel";
            this.PlaybackWindowPanel.Size = new System.Drawing.Size(483, 293);
            this.PlaybackWindowPanel.TabIndex = 0;
            // 
            // PlaybackWindowPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 293);
            this.ControlBox = false;
            this.Controls.Add(this.PlaybackWindowPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlaybackWindowPropertiesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Playback Window";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PlaybackWindowPanel;
    }
}