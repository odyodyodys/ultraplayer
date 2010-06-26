namespace UltraPlayerController.View.SingleMediaPlayer
{
    partial class AddonsForm
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
            this.components = new System.ComponentModel.Container();
            this.AddonsListBox = new System.Windows.Forms.ListBox();
            this.RemoveAddonMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddonsLabel = new System.Windows.Forms.Label();
            this.AddonPropertiesPanel = new System.Windows.Forms.Panel();
            this.AddonPropertiesLabel = new System.Windows.Forms.Label();
            this.SelectNewAddonTypeComboBox = new System.Windows.Forms.ComboBox();
            this.AddNewAddonButton = new System.Windows.Forms.Button();
            this.RemoveAddonMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddonsListBox
            // 
            this.AddonsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.AddonsListBox.ContextMenuStrip = this.RemoveAddonMenuStrip;
            this.AddonsListBox.FormattingEnabled = true;
            this.AddonsListBox.Location = new System.Drawing.Point(12, 64);
            this.AddonsListBox.Name = "AddonsListBox";
            this.AddonsListBox.Size = new System.Drawing.Size(110, 303);
            this.AddonsListBox.TabIndex = 0;
            this.AddonsListBox.SelectedIndexChanged += new System.EventHandler(this.AddonsListBoxSelectedIndexChanged);
            // 
            // RemoveAddonMenuStrip
            // 
            this.RemoveAddonMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.RemoveAddonMenuStrip.Name = "RemoveAddonMenuStrip";
            this.RemoveAddonMenuStrip.Size = new System.Drawing.Size(125, 26);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItemClick);
            // 
            // AddonsLabel
            // 
            this.AddonsLabel.AutoSize = true;
            this.AddonsLabel.Location = new System.Drawing.Point(12, 22);
            this.AddonsLabel.Name = "AddonsLabel";
            this.AddonsLabel.Size = new System.Drawing.Size(46, 13);
            this.AddonsLabel.TabIndex = 1;
            this.AddonsLabel.Text = "Addons:";
            // 
            // AddonPropertiesPanel
            // 
            this.AddonPropertiesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AddonPropertiesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AddonPropertiesPanel.Location = new System.Drawing.Point(128, 38);
            this.AddonPropertiesPanel.Name = "AddonPropertiesPanel";
            this.AddonPropertiesPanel.Size = new System.Drawing.Size(526, 345);
            this.AddonPropertiesPanel.TabIndex = 2;
            // 
            // AddonPropertiesLabel
            // 
            this.AddonPropertiesLabel.AutoSize = true;
            this.AddonPropertiesLabel.Location = new System.Drawing.Point(125, 22);
            this.AddonPropertiesLabel.Name = "AddonPropertiesLabel";
            this.AddonPropertiesLabel.Size = new System.Drawing.Size(91, 13);
            this.AddonPropertiesLabel.TabIndex = 1;
            this.AddonPropertiesLabel.Text = "Addon Properties:";
            // 
            // SelectNewAddonTypeComboBox
            // 
            this.SelectNewAddonTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectNewAddonTypeComboBox.FormattingEnabled = true;
            this.SelectNewAddonTypeComboBox.Location = new System.Drawing.Point(12, 38);
            this.SelectNewAddonTypeComboBox.Name = "SelectNewAddonTypeComboBox";
            this.SelectNewAddonTypeComboBox.Size = new System.Drawing.Size(88, 21);
            this.SelectNewAddonTypeComboBox.TabIndex = 3;
            // 
            // AddNewAddonButton
            // 
            this.AddNewAddonButton.Location = new System.Drawing.Point(101, 38);
            this.AddNewAddonButton.Name = "AddNewAddonButton";
            this.AddNewAddonButton.Size = new System.Drawing.Size(21, 21);
            this.AddNewAddonButton.TabIndex = 4;
            this.AddNewAddonButton.Text = "+";
            this.AddNewAddonButton.UseVisualStyleBackColor = true;
            this.AddNewAddonButton.Click += new System.EventHandler(this.AddNewAddonButtonClick);
            // 
            // AddonsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 397);
            this.ControlBox = false;
            this.Controls.Add(this.AddNewAddonButton);
            this.Controls.Add(this.SelectNewAddonTypeComboBox);
            this.Controls.Add(this.AddonPropertiesPanel);
            this.Controls.Add(this.AddonPropertiesLabel);
            this.Controls.Add(this.AddonsLabel);
            this.Controls.Add(this.AddonsListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddonsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Addons";
            this.RemoveAddonMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AddonsListBox;
        private System.Windows.Forms.Label AddonsLabel;
        private System.Windows.Forms.Panel AddonPropertiesPanel;
        private System.Windows.Forms.Label AddonPropertiesLabel;
        private System.Windows.Forms.ComboBox SelectNewAddonTypeComboBox;
        private System.Windows.Forms.Button AddNewAddonButton;
        private System.Windows.Forms.ContextMenuStrip RemoveAddonMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;

    }
}