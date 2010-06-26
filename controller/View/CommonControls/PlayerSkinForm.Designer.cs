namespace UltraPlayerController.View.CommonControls
{
    partial class PlayerSkinForm
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
            this.AlphaFormTransformer = new AlphaForm.AlphaFormTransformer();
            this.SuspendLayout();
            // 
            // AlphaFormTransformer
            // 
            this.AlphaFormTransformer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlphaFormTransformer.DragSleep = ((uint)(30u));
            this.AlphaFormTransformer.Location = new System.Drawing.Point(0, 0);
            this.AlphaFormTransformer.Name = "AlphaFormTransformer";
            this.AlphaFormTransformer.Size = new System.Drawing.Size(165, 107);
            this.AlphaFormTransformer.TabIndex = 0;
            // 
            // PlayerSkinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(165, 107);
            this.Controls.Add(this.AlphaFormTransformer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlayerSkinForm";
            this.Text = "PlayerSkinForm";
            this.Load += new System.EventHandler(this.PlayerSkinFormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private AlphaForm.AlphaFormTransformer AlphaFormTransformer;
    }
}