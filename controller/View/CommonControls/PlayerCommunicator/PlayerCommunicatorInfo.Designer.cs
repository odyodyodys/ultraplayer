namespace UltraPlayerController.View.CommonControls.PlayerCommunicator
{
    partial class PlayerCommunicatorInfo
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
            this.HistoryListbox = new System.Windows.Forms.ListBox();
            this.ListboxOptionsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ListboxOptionsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // HistoryListbox
            // 
            this.HistoryListbox.BackColor = System.Drawing.SystemColors.InfoText;
            this.HistoryListbox.ContextMenuStrip = this.ListboxOptionsMenu;
            this.HistoryListbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HistoryListbox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.HistoryListbox.FormattingEnabled = true;
            this.HistoryListbox.HorizontalScrollbar = true;
            this.HistoryListbox.Location = new System.Drawing.Point(0, 0);
            this.HistoryListbox.Name = "HistoryListbox";
            this.HistoryListbox.ScrollAlwaysVisible = true;
            this.HistoryListbox.Size = new System.Drawing.Size(284, 186);
            this.HistoryListbox.TabIndex = 0;
            this.HistoryListbox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.HistoryListboxDrawItem);
            // 
            // ListboxOptionsMenu
            // 
            this.ListboxOptionsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.ListboxOptionsMenu.Name = "ListboxOptionsMenu";
            this.ListboxOptionsMenu.Size = new System.Drawing.Size(111, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItem1.Text = "Clear";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.ClearMenuItemClick);
            // 
            // PlayerCommunicatorInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 187);
            this.ControlBox = false;
            this.Controls.Add(this.HistoryListbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(223, 98);
            this.Name = "PlayerCommunicatorInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Info Console";
            this.ListboxOptionsMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox HistoryListbox;
        private System.Windows.Forms.ContextMenuStrip ListboxOptionsMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}