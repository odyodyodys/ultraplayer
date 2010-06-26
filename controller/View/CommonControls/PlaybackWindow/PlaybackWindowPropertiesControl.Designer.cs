namespace UltraPlayerController.View.CommonControls
{
    partial class PlaybackWindowPropertiesControl
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
            this.LocationYLabel = new System.Windows.Forms.Label();
            this.SizeYLabel = new System.Windows.Forms.Label();
            this.LocationXLabel = new System.Windows.Forms.Label();
            this.LocationYScrollBar = new System.Windows.Forms.HScrollBar();
            this.LocationXValueLabel = new System.Windows.Forms.Label();
            this.LocationYValueLabel = new System.Windows.Forms.Label();
            this.SizeYValueLabel = new System.Windows.Forms.Label();
            this.SizeXValueLabel = new System.Windows.Forms.Label();
            this.SizeXLabel = new System.Windows.Forms.Label();
            this.LocationXScrollBar = new System.Windows.Forms.HScrollBar();
            this.SizeYScrollBar = new System.Windows.Forms.HScrollBar();
            this.SizeXScrollBar = new System.Windows.Forms.HScrollBar();
            this.DrawingAreaPanel = new System.Windows.Forms.Panel();
            this.fullScreenButton = new System.Windows.Forms.Button();
            this.monitorCombobox = new System.Windows.Forms.ComboBox();
            this.monitorUpdateButton = new System.Windows.Forms.Button();
            this.monitorLabel = new System.Windows.Forms.Label();
            this.SkinLabel = new System.Windows.Forms.Label();
            this.SkinsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LocationYLabel
            // 
            this.LocationYLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LocationYLabel.AutoSize = true;
            this.LocationYLabel.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.LocationYLabel.Location = new System.Drawing.Point(153, 217);
            this.LocationYLabel.Name = "LocationYLabel";
            this.LocationYLabel.Size = new System.Drawing.Size(22, 23);
            this.LocationYLabel.TabIndex = 29;
            this.LocationYLabel.Text = "$";
            // 
            // SizeYLabel
            // 
            this.SizeYLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SizeYLabel.AutoSize = true;
            this.SizeYLabel.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.SizeYLabel.Location = new System.Drawing.Point(3, 218);
            this.SizeYLabel.Name = "SizeYLabel";
            this.SizeYLabel.Size = new System.Drawing.Size(22, 23);
            this.SizeYLabel.TabIndex = 22;
            this.SizeYLabel.Text = "2";
            // 
            // LocationXLabel
            // 
            this.LocationXLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LocationXLabel.AutoSize = true;
            this.LocationXLabel.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.LocationXLabel.Location = new System.Drawing.Point(153, 177);
            this.LocationXLabel.Name = "LocationXLabel";
            this.LocationXLabel.Size = new System.Drawing.Size(28, 23);
            this.LocationXLabel.TabIndex = 23;
            this.LocationXLabel.Text = "\"";
            // 
            // LocationYScrollBar
            // 
            this.LocationYScrollBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LocationYScrollBar.LargeChange = 1;
            this.LocationYScrollBar.Location = new System.Drawing.Point(157, 239);
            this.LocationYScrollBar.Maximum = 1000;
            this.LocationYScrollBar.Name = "LocationYScrollBar";
            this.LocationYScrollBar.Size = new System.Drawing.Size(141, 21);
            this.LocationYScrollBar.TabIndex = 19;
            this.LocationYScrollBar.ValueChanged += new System.EventHandler(this.LocationYScrollBarValueChanged);
            // 
            // LocationXValueLabel
            // 
            this.LocationXValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LocationXValueLabel.AutoSize = true;
            this.LocationXValueLabel.Location = new System.Drawing.Point(285, 182);
            this.LocationXValueLabel.Name = "LocationXValueLabel";
            this.LocationXValueLabel.Size = new System.Drawing.Size(13, 13);
            this.LocationXValueLabel.TabIndex = 26;
            this.LocationXValueLabel.Text = "0";
            // 
            // LocationYValueLabel
            // 
            this.LocationYValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LocationYValueLabel.AutoSize = true;
            this.LocationYValueLabel.Location = new System.Drawing.Point(285, 226);
            this.LocationYValueLabel.Name = "LocationYValueLabel";
            this.LocationYValueLabel.Size = new System.Drawing.Size(13, 13);
            this.LocationYValueLabel.TabIndex = 27;
            this.LocationYValueLabel.Text = "0";
            // 
            // SizeYValueLabel
            // 
            this.SizeYValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SizeYValueLabel.AutoSize = true;
            this.SizeYValueLabel.Location = new System.Drawing.Point(122, 226);
            this.SizeYValueLabel.Name = "SizeYValueLabel";
            this.SizeYValueLabel.Size = new System.Drawing.Size(31, 13);
            this.SizeYValueLabel.TabIndex = 28;
            this.SizeYValueLabel.Text = "1000";
            // 
            // SizeXValueLabel
            // 
            this.SizeXValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SizeXValueLabel.AutoSize = true;
            this.SizeXValueLabel.Location = new System.Drawing.Point(122, 182);
            this.SizeXValueLabel.Name = "SizeXValueLabel";
            this.SizeXValueLabel.Size = new System.Drawing.Size(31, 13);
            this.SizeXValueLabel.TabIndex = 25;
            this.SizeXValueLabel.Text = "1000";
            // 
            // SizeXLabel
            // 
            this.SizeXLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SizeXLabel.AutoSize = true;
            this.SizeXLabel.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.SizeXLabel.Location = new System.Drawing.Point(3, 178);
            this.SizeXLabel.Name = "SizeXLabel";
            this.SizeXLabel.Size = new System.Drawing.Size(28, 23);
            this.SizeXLabel.TabIndex = 24;
            this.SizeXLabel.Text = "1";
            // 
            // LocationXScrollBar
            // 
            this.LocationXScrollBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LocationXScrollBar.LargeChange = 1;
            this.LocationXScrollBar.Location = new System.Drawing.Point(157, 195);
            this.LocationXScrollBar.Maximum = 1000;
            this.LocationXScrollBar.Name = "LocationXScrollBar";
            this.LocationXScrollBar.Size = new System.Drawing.Size(141, 21);
            this.LocationXScrollBar.TabIndex = 18;
            this.LocationXScrollBar.ValueChanged += new System.EventHandler(this.LocationXScrollBarValueChanged);
            // 
            // SizeYScrollBar
            // 
            this.SizeYScrollBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SizeYScrollBar.LargeChange = 1;
            this.SizeYScrollBar.Location = new System.Drawing.Point(6, 239);
            this.SizeYScrollBar.Maximum = 1000;
            this.SizeYScrollBar.Name = "SizeYScrollBar";
            this.SizeYScrollBar.Size = new System.Drawing.Size(141, 21);
            this.SizeYScrollBar.TabIndex = 21;
            this.SizeYScrollBar.ValueChanged += new System.EventHandler(this.SizeYScrollBarValueChanged);
            // 
            // SizeXScrollBar
            // 
            this.SizeXScrollBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SizeXScrollBar.LargeChange = 1;
            this.SizeXScrollBar.Location = new System.Drawing.Point(6, 195);
            this.SizeXScrollBar.Maximum = 1000;
            this.SizeXScrollBar.Name = "SizeXScrollBar";
            this.SizeXScrollBar.Size = new System.Drawing.Size(141, 21);
            this.SizeXScrollBar.TabIndex = 20;
            this.SizeXScrollBar.ValueChanged += new System.EventHandler(this.SizeXScrollBarValueChanged);
            // 
            // DrawingAreaPanel
            // 
            this.DrawingAreaPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DrawingAreaPanel.BackColor = System.Drawing.SystemColors.MenuBar;
            this.DrawingAreaPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DrawingAreaPanel.Location = new System.Drawing.Point(3, 3);
            this.DrawingAreaPanel.Name = "DrawingAreaPanel";
            this.DrawingAreaPanel.Size = new System.Drawing.Size(329, 176);
            this.DrawingAreaPanel.TabIndex = 30;
            this.DrawingAreaPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingAreaPanelPaint);
            // 
            // fullScreenButton
            // 
            this.fullScreenButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.fullScreenButton.Location = new System.Drawing.Point(346, 195);
            this.fullScreenButton.Name = "fullScreenButton";
            this.fullScreenButton.Size = new System.Drawing.Size(66, 21);
            this.fullScreenButton.TabIndex = 31;
            this.fullScreenButton.Text = "full screen";
            this.fullScreenButton.UseVisualStyleBackColor = true;
            this.fullScreenButton.Click += new System.EventHandler(this.FullScreenButtonClick);
            // 
            // monitorCombobox
            // 
            this.monitorCombobox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.monitorCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monitorCombobox.FormattingEnabled = true;
            this.monitorCombobox.Location = new System.Drawing.Point(310, 239);
            this.monitorCombobox.Name = "monitorCombobox";
            this.monitorCombobox.Size = new System.Drawing.Size(115, 21);
            this.monitorCombobox.TabIndex = 32;
            this.monitorCombobox.SelectedIndexChanged += new System.EventHandler(this.MonitorComboboxSelectedIndexChanged);
            // 
            // monitorUpdateButton
            // 
            this.monitorUpdateButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.monitorUpdateButton.Font = new System.Drawing.Font("Wingdings 3", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.monitorUpdateButton.Location = new System.Drawing.Point(425, 236);
            this.monitorUpdateButton.Name = "monitorUpdateButton";
            this.monitorUpdateButton.Size = new System.Drawing.Size(25, 27);
            this.monitorUpdateButton.TabIndex = 33;
            this.monitorUpdateButton.Text = "P";
            this.monitorUpdateButton.UseVisualStyleBackColor = true;
            this.monitorUpdateButton.Click += new System.EventHandler(this.monitorUpdateButtonClick);
            // 
            // monitorLabel
            // 
            this.monitorLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.monitorLabel.AutoSize = true;
            this.monitorLabel.Location = new System.Drawing.Point(307, 223);
            this.monitorLabel.Name = "monitorLabel";
            this.monitorLabel.Size = new System.Drawing.Size(45, 13);
            this.monitorLabel.TabIndex = 29;
            this.monitorLabel.Text = "Monitor:";
            // 
            // SkinLabel
            // 
            this.SkinLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SkinLabel.AutoSize = true;
            this.SkinLabel.Location = new System.Drawing.Point(332, 3);
            this.SkinLabel.Margin = new System.Windows.Forms.Padding(3);
            this.SkinLabel.Name = "SkinLabel";
            this.SkinLabel.Size = new System.Drawing.Size(31, 13);
            this.SkinLabel.TabIndex = 29;
            this.SkinLabel.Text = "Skin:";
            // 
            // SkinsListBox
            // 
            this.SkinsListBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SkinsListBox.FormattingEnabled = true;
            this.SkinsListBox.Location = new System.Drawing.Point(338, 22);
            this.SkinsListBox.Name = "SkinsListBox";
            this.SkinsListBox.Size = new System.Drawing.Size(112, 160);
            this.SkinsListBox.TabIndex = 0;
            this.SkinsListBox.SelectedIndexChanged += new System.EventHandler(this.SkinsListBox_SelectedIndexChanged);
            // 
            // PlaybackWindowPropertiesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SkinsListBox);
            this.Controls.Add(this.monitorUpdateButton);
            this.Controls.Add(this.monitorCombobox);
            this.Controls.Add(this.fullScreenButton);
            this.Controls.Add(this.DrawingAreaPanel);
            this.Controls.Add(this.SkinLabel);
            this.Controls.Add(this.monitorLabel);
            this.Controls.Add(this.LocationYScrollBar);
            this.Controls.Add(this.LocationXValueLabel);
            this.Controls.Add(this.LocationYValueLabel);
            this.Controls.Add(this.SizeYValueLabel);
            this.Controls.Add(this.SizeXValueLabel);
            this.Controls.Add(this.LocationXScrollBar);
            this.Controls.Add(this.SizeYScrollBar);
            this.Controls.Add(this.SizeXScrollBar);
            this.Controls.Add(this.LocationXLabel);
            this.Controls.Add(this.LocationYLabel);
            this.Controls.Add(this.SizeXLabel);
            this.Controls.Add(this.SizeYLabel);
            this.MinimumSize = new System.Drawing.Size(453, 272);
            this.Name = "PlaybackWindowPropertiesControl";
            this.Size = new System.Drawing.Size(453, 272);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LocationYLabel;
        private System.Windows.Forms.Label SizeYLabel;
        private System.Windows.Forms.Label LocationXLabel;
        private System.Windows.Forms.HScrollBar LocationYScrollBar;
        private System.Windows.Forms.Label LocationXValueLabel;
        private System.Windows.Forms.Label LocationYValueLabel;
        private System.Windows.Forms.Label SizeYValueLabel;
        private System.Windows.Forms.Label SizeXValueLabel;
        private System.Windows.Forms.Label SizeXLabel;
        private System.Windows.Forms.HScrollBar LocationXScrollBar;
        private System.Windows.Forms.HScrollBar SizeYScrollBar;
        private System.Windows.Forms.HScrollBar SizeXScrollBar;
        private System.Windows.Forms.Panel DrawingAreaPanel;
        private System.Windows.Forms.Button fullScreenButton;
        private System.Windows.Forms.ComboBox monitorCombobox;
        private System.Windows.Forms.Button monitorUpdateButton;
        private System.Windows.Forms.Label monitorLabel;
        private System.Windows.Forms.Label SkinLabel;
        private System.Windows.Forms.ListBox SkinsListBox;
    }
}
