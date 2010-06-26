namespace UltraPlayerController.View.Settings
{
    partial class PlayerSettingsControl
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
            this.PortTextbox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.PlayerIpTextBox = new System.Windows.Forms.TextBox();
            this.PlayerIpLabel = new System.Windows.Forms.Label();
            this.CommunicationGroupBox = new System.Windows.Forms.GroupBox();
            this.AppearanceGroupBox = new System.Windows.Forms.GroupBox();
            this.skinLabel = new System.Windows.Forms.Label();
            this.SkinComboBox = new System.Windows.Forms.ComboBox();
            this.CommunicationGroupBox.SuspendLayout();
            this.AppearanceGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PortTextbox
            // 
            this.PortTextbox.Location = new System.Drawing.Point(135, 32);
            this.PortTextbox.Name = "PortTextbox";
            this.PortTextbox.Size = new System.Drawing.Size(100, 20);
            this.PortTextbox.TabIndex = 0;
            this.PortTextbox.Leave += new System.EventHandler(this.PortTextboxLeave);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(132, 16);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(26, 13);
            this.portLabel.TabIndex = 1;
            this.portLabel.Text = "Port";
            // 
            // PlayerIpTextBox
            // 
            this.PlayerIpTextBox.Location = new System.Drawing.Point(9, 32);
            this.PlayerIpTextBox.Name = "PlayerIpTextBox";
            this.PlayerIpTextBox.Size = new System.Drawing.Size(100, 20);
            this.PlayerIpTextBox.TabIndex = 0;
            this.PlayerIpTextBox.Leave += new System.EventHandler(this.PlayerIpTextBoxLeave);
            // 
            // PlayerIpLabel
            // 
            this.PlayerIpLabel.AutoSize = true;
            this.PlayerIpLabel.Location = new System.Drawing.Point(6, 16);
            this.PlayerIpLabel.Name = "PlayerIpLabel";
            this.PlayerIpLabel.Size = new System.Drawing.Size(47, 13);
            this.PlayerIpLabel.TabIndex = 1;
            this.PlayerIpLabel.Text = "Player ip";
            // 
            // CommunicationGroupBox
            // 
            this.CommunicationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CommunicationGroupBox.Controls.Add(this.PlayerIpLabel);
            this.CommunicationGroupBox.Controls.Add(this.PortTextbox);
            this.CommunicationGroupBox.Controls.Add(this.portLabel);
            this.CommunicationGroupBox.Controls.Add(this.PlayerIpTextBox);
            this.CommunicationGroupBox.Location = new System.Drawing.Point(9, 3);
            this.CommunicationGroupBox.Name = "CommunicationGroupBox";
            this.CommunicationGroupBox.Size = new System.Drawing.Size(350, 71);
            this.CommunicationGroupBox.TabIndex = 14;
            this.CommunicationGroupBox.TabStop = false;
            this.CommunicationGroupBox.Text = "Communication";
            // 
            // AppearanceGroupBox
            // 
            this.AppearanceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AppearanceGroupBox.Controls.Add(this.skinLabel);
            this.AppearanceGroupBox.Controls.Add(this.SkinComboBox);
            this.AppearanceGroupBox.Location = new System.Drawing.Point(9, 80);
            this.AppearanceGroupBox.Name = "AppearanceGroupBox";
            this.AppearanceGroupBox.Size = new System.Drawing.Size(350, 77);
            this.AppearanceGroupBox.TabIndex = 15;
            this.AppearanceGroupBox.TabStop = false;
            this.AppearanceGroupBox.Text = "Appearance";
            // 
            // skinLabel
            // 
            this.skinLabel.AutoSize = true;
            this.skinLabel.Location = new System.Drawing.Point(6, 16);
            this.skinLabel.Name = "skinLabel";
            this.skinLabel.Size = new System.Drawing.Size(28, 13);
            this.skinLabel.TabIndex = 1;
            this.skinLabel.Text = "Skin";
            // 
            // SkinComboBox
            // 
            this.SkinComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SkinComboBox.FormattingEnabled = true;
            this.SkinComboBox.Location = new System.Drawing.Point(9, 32);
            this.SkinComboBox.Name = "SkinComboBox";
            this.SkinComboBox.Size = new System.Drawing.Size(121, 21);
            this.SkinComboBox.TabIndex = 0;
            this.SkinComboBox.SelectionChangeCommitted += new System.EventHandler(this.SkinComboBoxSelectionChangeCommitted);
            // 
            // PlayerSettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AppearanceGroupBox);
            this.Controls.Add(this.CommunicationGroupBox);
            this.Name = "PlayerSettingsControl";
            this.Size = new System.Drawing.Size(367, 167);
            this.Enter += new System.EventHandler(this.PlayerSettingsControl_Enter);
            this.CommunicationGroupBox.ResumeLayout(false);
            this.CommunicationGroupBox.PerformLayout();
            this.AppearanceGroupBox.ResumeLayout(false);
            this.AppearanceGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox PortTextbox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox PlayerIpTextBox;
        private System.Windows.Forms.Label PlayerIpLabel;
        private System.Windows.Forms.GroupBox CommunicationGroupBox;
        private System.Windows.Forms.GroupBox AppearanceGroupBox;
        private System.Windows.Forms.Label skinLabel;
        private System.Windows.Forms.ComboBox SkinComboBox;
    }
}
