using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace UltraPlayerController.View
{
    public partial class PlaylistControl : UserControl
    {
        #region Fields
        private List<string> _files;

        public delegate void PlaylistActionEventHandler();
        public delegate void PlaylistSelectionActionEventHandler(List<string> selectedFiles);

        public event PlaylistActionEventHandler ItemDoubleClickedEvent;
        public event PlaylistSelectionActionEventHandler SelectionChangedEvent;
        #endregion

        #region Constructors
        public PlaylistControl()
        {
            InitializeComponent();

            // initialize _files list
            _files = new List<string>();

        }
        #endregion

        #region Methods
        public List<string> GetCurrent()
        {
            List<string> selectedTracks = new List<string>();

            // find the full path of each selected item
            for (int i = 0; i < TracksListBox.SelectedItems.Count; i++)
            {
                for (int j = 0; j < _files.Count; j++)
                {
                    if (_files[j].Contains(TracksListBox.SelectedItems[i].ToString()))
                    {
                        selectedTracks.Add(_files[j]);
                        break;
                    }
                }
            }

            return selectedTracks;
        }
        public List<string> GetAll()
        {
            return _files;
        }
        public string GoToNext()
        {
            int selected = -1;
            if (TracksListBox.SelectedIndex != -1 && TracksListBox.SelectedIndex < TracksListBox.Items.Count - 1)
            {
                selected = TracksListBox.SelectedIndex + 1;
                TracksListBox.ClearSelected();
                TracksListBox.SelectedIndex = selected;
            }

            if (GetCurrent().Count > 0)
            {
                return GetCurrent()[0];
            }
            else
            {
                return string.Empty;
            }
        }

        public string GoToPrevious()
        {
            int selected = -1;
            if (TracksListBox.Items.Count > 0 && TracksListBox.SelectedIndex > 0)
            {
                selected = TracksListBox.SelectedIndex - 1;
                TracksListBox.ClearSelected();
                TracksListBox.SelectedIndex = selected;
            }

            if (GetCurrent().Count > 0)
            {
                return GetCurrent()[0];
            }
            else
            {
                return string.Empty;
            }
        }

        public void CropSelected()
        {
            // create a list with all selected items
            List<string> selectedNames = new List<string>();
            for (int i = 0; i < TracksListBox.SelectedItems.Count; i++)
            {
                selectedNames.Add(TracksListBox.SelectedItems[i].ToString());
            }

            // create a list containing only the selected files
            List<string> newFileList = new List<string>();
            for (int i = 0; i < selectedNames.Count; i++)
            {
                for (int j = 0; j < _files.Count; j++)
                {
                    string tmpFilename = _files[j];
                    if (tmpFilename.Contains(selectedNames[i]))
                    {
                        newFileList.Add(tmpFilename);
                        break;
                    }

                }
            }

            // replace the old list with the new
            _files = newFileList;

            // update tracksListBox;
            UpdateTracksListBox();
        }

        private void UpdateTracksListBox()
        {
            // clear trackslistbox
            TracksListBox.Items.Clear();

            // add from the _files list
            for (int i = 0; i < _files.Count; i++)
            {
                FileInfo newFile = new FileInfo(_files[i]);
                TracksListBox.Items.Add(newFile.Name);
            }
        }

        public void LockListItems()
        {
            // disable adding/removing/arranging controls
            AddButton.Enabled = false;
            RemoveButton.Enabled = false;
            SelButton.Enabled = false;
        }

        public void UnlockListItems()
        {
            //enable adding/removing/arranging controls
            AddButton.Enabled = true;
            RemoveButton.Enabled = true;
            SelButton.Enabled = true;
        }

        public void AllowMulti(bool allow)
        {
            // set properties to controls
            if (allow)
            {
                TracksListBox.SelectionMode = SelectionMode.MultiExtended;
            }
            else
            {
                TracksListBox.SelectionMode = SelectionMode.One;
                SelectAllMenuItem.Enabled = false;
                InvertSelectionMenuItem.Enabled = false;
            }
        }

        public int GetTrackCount()
        {
            return _files.Count;
        }

        public void SetSelected(int value)
        {
            // Zero based value

            if (TracksListBox.Items.Count >= value)
            {
                TracksListBox.SelectedIndex = value;
            }
        }

        public bool IsLastSelected()
        {
            return TracksListBox.SelectedIndex == _files.Count - 1;
        }

        #endregion

        #region Events
        private void RemoveButtonClick(object sender, EventArgs e)
        {
            RemoveContextMenu.Show((Control)sender, new Point(0, 25));
        }

        private void SelButtonClick(object sender, EventArgs e)
        {
            SelectContextMenu.Show((Control)sender, new Point(0, 25));
        }

        private void MiscButtonClick(object sender, EventArgs e)
        {
            MiscContextMenu.Show((Control)sender, new Point(0, 25));
        }

        private void ManageButtonClick(object sender, EventArgs e)
        {
            ManageContextMenu.Show((Control)sender, new Point(0, 25));
        }

        private void AddFilesMenuItemClick(object sender, EventArgs e)
        {
            AddOpenFileDialog.ShowDialog();
            if (AddOpenFileDialog.FileNames.Length > 0)
            {
                // add files to _files list
                _files.AddRange(AddOpenFileDialog.FileNames);

                UpdateTracksListBox();
            }
        }

        private void AddFolderMenuItemClick(object sender, EventArgs e)
        {
            AddFolderBrowserDialog.ShowDialog();
            if (!string.IsNullOrEmpty(AddFolderBrowserDialog.SelectedPath))
            {
                // create a list with files to add
                // TODO add a file extension filter
                _files.AddRange(Directory.GetFiles(AddFolderBrowserDialog.SelectedPath));

                UpdateTracksListBox();
            }
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            AddContextMenu.Show((Control)sender, new Point(0, 25));
        }

        private void RandomizeMenuItemClick(object sender, EventArgs e)
        {
            /*The way it works is to mentally divide the list into two halves - the
            unshuffled half (in the range [0,i]) and the shuffled half (in the
            range [i+1, list.Count-1]).

            In each iteration, it picks a random element from the unshuffled half,
            and swaps it with the element at the end of the unshuffled half, then
            moves the boundary down.*/

            Random random = new Random();

            for (int i = _files.Count - 1; i > 0; i--)
            {
                int swapIndex = random.Next(i + 1);
                if (swapIndex != i)
                {
                    string tmp = _files[swapIndex];
                    _files[swapIndex] = _files[i];
                    _files[i] = tmp;
                }
            }

            UpdateTracksListBox();
        }

        private void SortMenuItemClick(object sender, EventArgs e)
        {
            _files.Sort(delegate(string track1, string track2)
            {
                FileInfo file1 = new FileInfo(track1);
                FileInfo file2 = new FileInfo(track2);
                String fileName1 = file1.Name;
                String fileName2 = file2.Name;
                return fileName1.CompareTo(fileName2);
            });

            UpdateTracksListBox();
        }

        private void SelectAllMenuItemClick(object sender, EventArgs e)
        {
            if (TracksListBox.SelectionMode != SelectionMode.One)
            {
                for (int i = 0; i < TracksListBox.Items.Count; i++)
                {
                    TracksListBox.SetSelected(i, true);
                }
            }
        }

        private void SelectNoneMenuItemClick(object sender, EventArgs e)
        {
            TracksListBox.ClearSelected();
        }

        private void InvertSelectionMenuItemClick(object sender, EventArgs e)
        {
            for (int i = 0; i < TracksListBox.Items.Count; i++)
            {
                TracksListBox.SetSelected(i, !TracksListBox.GetSelected(i));
            }
        }

        private void CropSelectedMenuItemClick(object sender, EventArgs e)
        {
            CropSelected();
        }
        private void RemoveSelectedMenuItemClick(object sender, EventArgs e)
        {
            // create a list with all selected items
            List<string> selectedNames = new List<string>();
            for (int i = 0; i < TracksListBox.SelectedItems.Count; i++)
            {
                selectedNames.Add(TracksListBox.SelectedItems[i].ToString());
            }

            // create a list containing only the selected files
            List<string> selectedFileList = new List<string>();
            for (int i = 0; i < selectedNames.Count; i++)
            {
                for (int j = 0; j < _files.Count; j++)
                {
                    string tmpFilename = _files[j];
                    if (tmpFilename.Contains(selectedNames[i]))
                    {
                        selectedFileList.Add(tmpFilename);
                        break;
                    }

                }
            }

            // remove all selected items from the _files list
            for (int i = 0; i < selectedFileList.Count; i++)
            {
                _files.Remove(selectedFileList[i]);
            }

            // update tracksListBox;
            UpdateTracksListBox();
        }

        private void ClearListMenuItemClick(object sender, EventArgs e)
        {
            _files.Clear();

            UpdateTracksListBox();
        }

        private void SaveListMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                if (SavePlaylistSaveDialog.ShowDialog() != DialogResult.OK)
                {
                    // user clicked cancel
                    return;
                }

                StreamWriter file = new StreamWriter(SavePlaylistSaveDialog.FileName);

                for (int i = 0; i < _files.Count; i++)
                {
                    file.WriteLine(_files[i]);
                }

                file.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Could not save playlist.\nReason: " + ex.Message, "Error");
            }

        }

        private void LoadListMenuItemClick(object sender, EventArgs e)
        {
            if (OpenPlaylistFileDialog.ShowDialog() != DialogResult.OK)
            {
                // user clicked cancel
                return;
            }

            try
            {
                StreamReader file = new StreamReader(OpenPlaylistFileDialog.FileName);

                // clear _files list
                _files.Clear();

                // add files from file
                string line = file.ReadLine();
                while (line != null)
                {
                    _files.Add(line);
                    line = file.ReadLine();
                }

                file.Close();

                UpdateTracksListBox();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Could not open playlist.\nReason: " + ex.Message, "Error");
            }

        }

        private void TracksListBoxDoubleClick(object sender, EventArgs e)
        {
            if (TracksListBox.SelectedIndex != -1)
            {
                if (ItemDoubleClickedEvent != null)
                {
                    ItemDoubleClickedEvent();
                }
            }
        }

        private void TracksListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            if (TracksListBox.SelectedIndex != -1)
            {
                if (SelectionChangedEvent != null)
                {
                    // create a list with all selected items
                    List<string> selectedNames = new List<string>();
                    for (int i = 0; i < TracksListBox.SelectedItems.Count; i++)
                    {
                        selectedNames.Add(TracksListBox.SelectedItems[i].ToString());
                    }

                    // create a list containing only the selected files
                    List<string> selectedFileList = new List<string>();
                    for (int i = 0; i < selectedNames.Count; i++)
                    {
                        for (int j = 0; j < _files.Count; j++)
                        {
                            string tmpFilename = _files[j];
                            if (tmpFilename.Contains(selectedNames[i]))
                            {
                                selectedFileList.Add(tmpFilename);
                                break;
                            }

                        }
                    }
                    SelectionChangedEvent(selectedFileList);
                }
            }
        }

        #endregion
    }

}
