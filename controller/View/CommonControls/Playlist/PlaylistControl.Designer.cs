namespace UltraPlayerController.View
{
    partial class PlaylistControl
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
            this.components = new System.ComponentModel.Container();
            this.ManageButton = new System.Windows.Forms.Button();
            this.SelButton = new System.Windows.Forms.Button();
            this.MiscButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.TracksListBox = new System.Windows.Forms.ListBox();
            this.MiscContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SortMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RandomizeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddFilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SelectAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectNoneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InvertSelectionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SaveListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RemoveSelectedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CropSelectedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.AddFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SavePlaylistSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenPlaylistFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.MiscContextMenu.SuspendLayout();
            this.AddContextMenu.SuspendLayout();
            this.SelectContextMenu.SuspendLayout();
            this.ManageContextMenu.SuspendLayout();
            this.RemoveContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ManageButton
            // 
            this.ManageButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ManageButton.Location = new System.Drawing.Point(179, 174);
            this.ManageButton.Name = "ManageButton";
            this.ManageButton.Size = new System.Drawing.Size(38, 23);
            this.ManageButton.TabIndex = 8;
            this.ManageButton.Text = "Mng";
            this.ManageButton.UseVisualStyleBackColor = true;
            this.ManageButton.Click += new System.EventHandler(this.ManageButtonClick);
            // 
            // SelButton
            // 
            this.SelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SelButton.Location = new System.Drawing.Point(91, 174);
            this.SelButton.Name = "SelButton";
            this.SelButton.Size = new System.Drawing.Size(38, 23);
            this.SelButton.TabIndex = 6;
            this.SelButton.Text = "Sel";
            this.SelButton.UseVisualStyleBackColor = true;
            this.SelButton.Click += new System.EventHandler(this.SelButtonClick);
            // 
            // MiscButton
            // 
            this.MiscButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.MiscButton.Location = new System.Drawing.Point(135, 174);
            this.MiscButton.Name = "MiscButton";
            this.MiscButton.Size = new System.Drawing.Size(38, 23);
            this.MiscButton.TabIndex = 7;
            this.MiscButton.Text = "Misc";
            this.MiscButton.UseVisualStyleBackColor = true;
            this.MiscButton.Click += new System.EventHandler(this.MiscButtonClick);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AddButton.Location = new System.Drawing.Point(3, 174);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(38, 23);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RemoveButton.Location = new System.Drawing.Point(47, 174);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(38, 23);
            this.RemoveButton.TabIndex = 5;
            this.RemoveButton.Text = "Rem";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButtonClick);
            // 
            // TracksListBox
            // 
            this.TracksListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TracksListBox.FormattingEnabled = true;
            this.TracksListBox.Location = new System.Drawing.Point(3, 3);
            this.TracksListBox.Name = "TracksListBox";
            this.TracksListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.TracksListBox.Size = new System.Drawing.Size(215, 160);
            this.TracksListBox.TabIndex = 3;
            this.TracksListBox.SelectedIndexChanged += new System.EventHandler(this.TracksListBoxSelectedIndexChanged);
            this.TracksListBox.DoubleClick += new System.EventHandler(this.TracksListBoxDoubleClick);
            // 
            // MiscContextMenu
            // 
            this.MiscContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SortMenuItem,
            this.RandomizeMenuItem});
            this.MiscContextMenu.Name = "contextMenuStrip1";
            this.MiscContextMenu.Size = new System.Drawing.Size(164, 48);
            // 
            // SortMenuItem
            // 
            this.SortMenuItem.Name = "SortMenuItem";
            this.SortMenuItem.Size = new System.Drawing.Size(163, 22);
            this.SortMenuItem.Text = "Sort by filename";
            this.SortMenuItem.Click += new System.EventHandler(this.SortMenuItemClick);
            // 
            // RandomizeMenuItem
            // 
            this.RandomizeMenuItem.Name = "RandomizeMenuItem";
            this.RandomizeMenuItem.Size = new System.Drawing.Size(163, 22);
            this.RandomizeMenuItem.Text = "Randomize";
            this.RandomizeMenuItem.Click += new System.EventHandler(this.RandomizeMenuItemClick);
            // 
            // AddContextMenu
            // 
            this.AddContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddFilesMenuItem,
            this.AddFolderMenuItem});
            this.AddContextMenu.Name = "tracklistAddContextMenuStrip";
            this.AddContextMenu.Size = new System.Drawing.Size(148, 48);
            // 
            // AddFilesMenuItem
            // 
            this.AddFilesMenuItem.Name = "AddFilesMenuItem";
            this.AddFilesMenuItem.Size = new System.Drawing.Size(147, 22);
            this.AddFilesMenuItem.Text = "Add files...";
            this.AddFilesMenuItem.Click += new System.EventHandler(this.AddFilesMenuItemClick);
            // 
            // AddFolderMenuItem
            // 
            this.AddFolderMenuItem.Name = "AddFolderMenuItem";
            this.AddFolderMenuItem.Size = new System.Drawing.Size(147, 22);
            this.AddFolderMenuItem.Text = "Add folder...";
            this.AddFolderMenuItem.Click += new System.EventHandler(this.AddFolderMenuItemClick);
            // 
            // SelectContextMenu
            // 
            this.SelectContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectAllMenuItem,
            this.SelectNoneMenuItem,
            this.InvertSelectionMenuItem});
            this.SelectContextMenu.Name = "contextMenuStrip1";
            this.SelectContextMenu.Size = new System.Drawing.Size(162, 70);
            // 
            // SelectAllMenuItem
            // 
            this.SelectAllMenuItem.Name = "SelectAllMenuItem";
            this.SelectAllMenuItem.Size = new System.Drawing.Size(161, 22);
            this.SelectAllMenuItem.Text = "Select All";
            this.SelectAllMenuItem.Click += new System.EventHandler(this.SelectAllMenuItemClick);
            // 
            // SelectNoneMenuItem
            // 
            this.SelectNoneMenuItem.Name = "SelectNoneMenuItem";
            this.SelectNoneMenuItem.Size = new System.Drawing.Size(161, 22);
            this.SelectNoneMenuItem.Text = "Select None";
            this.SelectNoneMenuItem.Click += new System.EventHandler(this.SelectNoneMenuItemClick);
            // 
            // InvertSelectionMenuItem
            // 
            this.InvertSelectionMenuItem.Name = "InvertSelectionMenuItem";
            this.InvertSelectionMenuItem.Size = new System.Drawing.Size(161, 22);
            this.InvertSelectionMenuItem.Text = "Invert Selection";
            this.InvertSelectionMenuItem.Click += new System.EventHandler(this.InvertSelectionMenuItemClick);
            // 
            // ManageContextMenu
            // 
            this.ManageContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveListMenuItem,
            this.LoadListMenuItem});
            this.ManageContextMenu.Name = "contextMenuStrip1";
            this.ManageContextMenu.Size = new System.Drawing.Size(138, 48);
            // 
            // SaveListMenuItem
            // 
            this.SaveListMenuItem.Name = "SaveListMenuItem";
            this.SaveListMenuItem.Size = new System.Drawing.Size(137, 22);
            this.SaveListMenuItem.Text = "Save list...";
            this.SaveListMenuItem.Click += new System.EventHandler(this.SaveListMenuItemClick);
            // 
            // LoadListMenuItem
            // 
            this.LoadListMenuItem.Name = "LoadListMenuItem";
            this.LoadListMenuItem.Size = new System.Drawing.Size(137, 22);
            this.LoadListMenuItem.Text = "Load list...";
            this.LoadListMenuItem.Click += new System.EventHandler(this.LoadListMenuItemClick);
            // 
            // RemoveContextMenu
            // 
            this.RemoveContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveSelectedMenuItem,
            this.CropSelectedMenuItem,
            this.ClearListMenuItem});
            this.RemoveContextMenu.Name = "contextMenuStrip1";
            this.RemoveContextMenu.Size = new System.Drawing.Size(169, 92);
            // 
            // RemoveSelectedMenuItem
            // 
            this.RemoveSelectedMenuItem.Name = "RemoveSelectedMenuItem";
            this.RemoveSelectedMenuItem.Size = new System.Drawing.Size(168, 22);
            this.RemoveSelectedMenuItem.Text = "Remove Selected";
            this.RemoveSelectedMenuItem.Click += new System.EventHandler(this.RemoveSelectedMenuItemClick);
            // 
            // CropSelectedMenuItem
            // 
            this.CropSelectedMenuItem.Name = "CropSelectedMenuItem";
            this.CropSelectedMenuItem.Size = new System.Drawing.Size(168, 22);
            this.CropSelectedMenuItem.Text = "Crop Selected";
            this.CropSelectedMenuItem.Click += new System.EventHandler(this.CropSelectedMenuItemClick);
            // 
            // ClearListMenuItem
            // 
            this.ClearListMenuItem.Name = "ClearListMenuItem";
            this.ClearListMenuItem.Size = new System.Drawing.Size(168, 22);
            this.ClearListMenuItem.Text = "Clear list";
            this.ClearListMenuItem.Click += new System.EventHandler(this.ClearListMenuItemClick);
            // 
            // AddOpenFileDialog
            // 
            this.AddOpenFileDialog.Filter = "Video files|*.avi; *.mpg; *.mpeg; *.xVid; *.divX; *.flv|Avi files|*.avi|Mpeg file" +
                "s|*.mpg; *.mpeg|xVid files|*.xVid|divX files|*.divX|All files|*.*";
            this.AddOpenFileDialog.Multiselect = true;
            this.AddOpenFileDialog.RestoreDirectory = true;
            // 
            // AddFolderBrowserDialog
            // 
            this.AddFolderBrowserDialog.ShowNewFolderButton = false;
            // 
            // SavePlaylistSaveDialog
            // 
            this.SavePlaylistSaveDialog.DefaultExt = "upls";
            this.SavePlaylistSaveDialog.Filter = "Ultra player playlists|*.upls|All files|*.*";
            this.SavePlaylistSaveDialog.Title = "Save UltraPlayer playlist";
            // 
            // OpenPlaylistFileDialog
            // 
            this.OpenPlaylistFileDialog.DefaultExt = "upls";
            this.OpenPlaylistFileDialog.Filter = "Ultra player playlists|*.upls|All files|*.*";
            this.OpenPlaylistFileDialog.ShowReadOnly = true;
            // 
            // PlaylistControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ManageButton);
            this.Controls.Add(this.SelButton);
            this.Controls.Add(this.MiscButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.TracksListBox);
            this.MinimumSize = new System.Drawing.Size(221, 157);
            this.Name = "PlaylistControl";
            this.Size = new System.Drawing.Size(221, 204);
            this.MiscContextMenu.ResumeLayout(false);
            this.AddContextMenu.ResumeLayout(false);
            this.SelectContextMenu.ResumeLayout(false);
            this.ManageContextMenu.ResumeLayout(false);
            this.RemoveContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ManageButton;
        private System.Windows.Forms.Button SelButton;
        private System.Windows.Forms.Button MiscButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.ListBox TracksListBox;
        private System.Windows.Forms.ContextMenuStrip MiscContextMenu;
        private System.Windows.Forms.ToolStripMenuItem SortMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RandomizeMenuItem;
        private System.Windows.Forms.ContextMenuStrip AddContextMenu;
        private System.Windows.Forms.ToolStripMenuItem AddFilesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddFolderMenuItem;
        private System.Windows.Forms.ContextMenuStrip SelectContextMenu;
        private System.Windows.Forms.ToolStripMenuItem SelectAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectNoneMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InvertSelectionMenuItem;
        private System.Windows.Forms.ContextMenuStrip ManageContextMenu;
        private System.Windows.Forms.ToolStripMenuItem SaveListMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadListMenuItem;
        private System.Windows.Forms.ContextMenuStrip RemoveContextMenu;
        private System.Windows.Forms.ToolStripMenuItem RemoveSelectedMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CropSelectedMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearListMenuItem;
        private System.Windows.Forms.OpenFileDialog AddOpenFileDialog;
        private System.Windows.Forms.FolderBrowserDialog AddFolderBrowserDialog;
        private System.Windows.Forms.SaveFileDialog SavePlaylistSaveDialog;
        private System.Windows.Forms.OpenFileDialog OpenPlaylistFileDialog;
    }
}
