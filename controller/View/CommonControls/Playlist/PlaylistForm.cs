using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UltraPlayerController.View;

namespace UltraPlayerController.View.CommonControls
{
    public partial class PlaylistForm : Form
    {

        #region Fields
        PlaylistControl _playlistControl;

        // just to forward the events from playlist control to the form
        public event PlaylistControl.PlaylistActionEventHandler ItemDoubleClickedEvent;
        public event PlaylistControl.PlaylistSelectionActionEventHandler SelectionChangedEvent;

        #endregion

        #region Constructors
        public PlaylistForm()
        {
            InitializeComponent();

            _playlistControl = new PlaylistControl();
            _playlistControl.Dock = DockStyle.Fill;
            PlaylistPanel.Controls.Add(_playlistControl);

            // forward events from control
            _playlistControl.ItemDoubleClickedEvent += new PlaylistControl.PlaylistActionEventHandler(OnPlaylistDoubleClick);
            _playlistControl.SelectionChangedEvent += new PlaylistControl.PlaylistSelectionActionEventHandler(OnPlaylistSelectionChanged);
        }
        #endregion

        #region Methods
        public List<string> GetCurrent()
        {
            return _playlistControl.GetCurrent();
        }
        public string GoToNext()
        {
            return _playlistControl.GoToNext();
        }

        public string GoToPrevious()
        {
            return _playlistControl.GoToPrevious();
        }

        public void CropSelected()
        {
            _playlistControl.CropSelected();
        }

        public void LockListItems()
        {
            _playlistControl.LockListItems();
        }

        public void UnlockListItems()
        {
            _playlistControl.UnlockListItems();
        }

        public void AllowMulti(bool allow)
        {
            _playlistControl.AllowMulti(allow);
        }

        public int GetTrackCount()
        {
            return _playlistControl.GetTrackCount();
        }

        public void SetSelected(int value)
        {
            _playlistControl.SetSelected(value);
        }

        public bool IsLastSelected()
        {
            return _playlistControl.IsLastSelected();
        }

        #endregion

        #region Events
        private void PlaylistFormFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        void OnPlaylistDoubleClick()
        {
            if (ItemDoubleClickedEvent != null)
            {
                ItemDoubleClickedEvent();
            }
        }

        void OnPlaylistSelectionChanged(List<string> selectedFiles)
        {
            if (SelectionChangedEvent != null)
            {
                SelectionChangedEvent(selectedFiles);
            }
        }
        #endregion
    }
}
