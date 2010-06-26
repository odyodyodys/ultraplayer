using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UltraPlayerController.Model;
using UltraPlayerController.View;
using UltraPlayerController.View.Settings;
using UltraPlayerController.View.CommonControls.PlayerCommunicator;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Communication;
using UltraPlayerController.View.CommonControls;
using UltraPlayerController.View.Events;
using UltraPlayerController.Model.Communication.Response;
using UltraPlayerController.Model.Utilities.MediaInfo;
using System.IO;

namespace UltraPlayerController.View.MultiMediaPlayer
{
    public partial class MultiMediaPlayerForm : Form
    {
        #region Fields
        private SettingsForm _settingsForm;
        private PlaylistControl _playlistControl;
        private PlaybackControl _playbackControl;
        private VideoLayoutControl _videoLayoutControl;
        private PlaybackWindowPropertiesControl _playbackWindowControl;
        private PlayerCommunicatorControl _playerCommunicatorControl;
        private List<VideoFile> _files;
        private MediaInfo _mediaInfo;
        private PlayerSkinForm _skinForm;
        #endregion

        #region Constructors
        public MultiMediaPlayerForm()
        {
            InitializeComponent();

            InitializePlaylistControl();

            InitializePlaybackControl();

            InitializeVideoLayoutControl();

            InitializePlaybackWindowPropertiesControl();

            InitializeSettingsForm();

            InitializePlayerCommunicatorControl();

            // initialize files list
            _files = new List<VideoFile>();

            _mediaInfo = new MediaInfo();

            InitializeSkins();
        }

        #endregion

        #region Methods
        private void InitializePlaybackControl()
        {
            // add playback controls control
            _playbackControl = new PlaybackControl();
            _playbackControl.Dock = DockStyle.Fill;
            PlaybackControlsPanel.Controls.Add(_playbackControl);

            _playbackControl.PlayEvent += new Delegates.ActionEventHandler(OnPlaybackPlay);
            _playbackControl.PauseEvent += new Delegates.ActionEventHandler(OnPlaybackPause);
            _playbackControl.ResumeEvent += new Delegates.ActionEventHandler(OnPlaybackResume);
            _playbackControl.StopEvent += new Delegates.ActionEventHandler(OnPlaybackStop);
            _playbackControl.VolumeEvent += new Delegates.IntegerValueActionEventHandler(OnPlaybackVolume);
            _playbackControl.SeekEvent += new Delegates.IntegerValueActionEventHandler(OnPlaybackSeek);

            // disable next/previous controls
            _playbackControl.DisableNextPrevious();
        }
        private void InitializePlaylistControl()
        {
            // add playlist control
            _playlistControl = new PlaylistControl();
            _playlistControl.Dock = DockStyle.Fill;
            PlaylistControlPanel.Controls.Add(_playlistControl);

            // attach to its events
            _playlistControl.SelectionChangedEvent += new PlaylistControl.PlaylistSelectionActionEventHandler(OnPlaylistSelectionChangedEvent);

        }
        private void InitializeSettingsForm()
        {
            // initialize settings form
            _settingsForm = new SettingsForm();
        }
        private void InitializeVideoLayoutControl()
        {
            // add video layout control
            _videoLayoutControl = new VideoLayoutControl();
            _videoLayoutControl.Dock = DockStyle.Fill;
            VideoLayoutControlPanel.Controls.Add(_videoLayoutControl);

            _videoLayoutControl.LayoutChangedEvent += new Delegates.VisibleLayoutChangedEventHandler(OnVideoLayoutChangedEvent);
        }

        private void InitializePlaybackWindowPropertiesControl()
        {
            // add video layout control
            _playbackWindowControl = new PlaybackWindowPropertiesControl();
            _playbackWindowControl.Dock = DockStyle.Fill;
            WindowLayoutControlPanel.Controls.Add(_playbackWindowControl);

            _playbackWindowControl.LayoutChangedEvent += new Delegates.LayoutChangedEventHandler(OnPlaybackWindowLayoutChangedEvent);
            _playbackWindowControl.UpdateDisplayDevicesEvent += new Delegates.ActionEventHandler(OnUpdateDisplayDevicesEvent);
            _playbackWindowControl.SkinInfoChanged += new Delegates.SetSkinInfo(OnSkinInfoChangedEvent);
        }

        private void InitializePlayerCommunicatorControl()
        {
            // add player communicator control
            _playerCommunicatorControl = new PlayerCommunicatorControl();
            _playerCommunicatorControl.Dock = DockStyle.Fill;
            PlayerCommunicatorPanel.Controls.Add(_playerCommunicatorControl);
        }

        private void InitializeSkins()
        {

            _playbackWindowControl.Skins = (List<SkinInfo>)SkinLoader.Instance.Load();

            _skinForm = new PlayerSkinForm();

            // call form load indirectly
            _skinForm.Show();
            _skinForm.Hide();
        }

        #endregion

        #region Events
        private void SettingsButtonClick(object sender, EventArgs e)
        {
            this.Hide();
            _settingsForm.ShowDialog();

            // after settings form is closed, show the this form
            this.Show();
        }

        private void ExitButtonClick(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void OnPlaybackPlay()
        {
            // Check if valid selection on playlist
            if (_playlistControl.GetCurrent().Count.Equals(0))
            {
                MessageBox.Show("Playlist is empty. Nothing to play", "Information");
                return;
            }

            // Crop selected on playlist
            _playlistControl.CropSelected();

            // Lock playlist
            _playlistControl.LockListItems();

            // create the files list
            _files.Clear();
            int index = 0;
            foreach (string filename in _playlistControl.GetAll())
            {
                VideoFile newEntry = new VideoFile();
                newEntry.Filename = filename;
                newEntry.Layout.ZOrder = index++;

                _files.Add(newEntry);
            }

            // Create and send Play playRequest
            PlayRequest playRequest = (PlayRequest)RequestFactory.CreateRequest(MessageType.Play);
            playRequest.Tracks = _playlistControl.GetAll();
            _playerCommunicatorControl.SendRequest(playRequest);

            // TODO set state based on response
            
            // set play state and compute maximum duration
            int maxDuration = 0;
            foreach (string track in _playlistControl.GetAll())
            {
                _mediaInfo.Open(track);
                int tmpDuration = _mediaInfo.GetDuration();
                _mediaInfo.Close();

                if (maxDuration < tmpDuration)
                {
                    maxDuration = tmpDuration;
                }
            }
            _playbackControl.PlaybackStarted(maxDuration);

            // Send Pause request
            _playerCommunicatorControl.SendRequest(RequestFactory.CreateRequest(MessageType.Pause));
            _playbackControl.PlaybackPaused();

            // Send layout request
            VideoLayoutRequest layoutRequest = new VideoLayoutRequest();
            foreach (VideoFile file in _files)
            {
                layoutRequest.TracksLayout.Add(file.Layout);
            }
            _playerCommunicatorControl.SendRequest(layoutRequest);

            // Send resume request
            _playerCommunicatorControl.SendRequest(RequestFactory.CreateRequest(MessageType.Resume));
            _playbackControl.PlaybackResumed();

            // Set volume
            OnPlaybackVolume(_playbackControl.Volume);
        }

        private void OnPlaybackPause()
        {
            _playerCommunicatorControl.SendRequest(RequestFactory.CreateRequest(MessageType.Pause));

            // set controls state
            // TODO set state based on response
            _playbackControl.PlaybackPaused();

        }

        private void OnPlaybackResume()
        {
            _playerCommunicatorControl.SendRequest(RequestFactory.CreateRequest(MessageType.Resume));

            // set controls state
            // TODO set state based on response
            _playbackControl.PlaybackResumed();
        }

        private void OnPlaybackStop()
        {
            _playerCommunicatorControl.SendRequest(RequestFactory.CreateRequest(MessageType.Stop));

            _playlistControl.UnlockListItems();

            // set controls state
            // TODO set state based on response
            _playbackControl.PlaybackStopped();
        }

        void OnPlaybackSeek(int milliseconds)
        {
            if (_playbackControl.PlaybackState != PlaybackState.Paused && _playbackControl.PlaybackState != PlaybackState.Playing)
            {
                return;
            }

            SeekRequest request = new SeekRequest();

            // Get track duration and compute seek time in milliseconds
            request.SeekTime = milliseconds;

            _playbackControl.PlaybackSeeked(milliseconds);

            _playerCommunicatorControl.SendRequest(request);
        }
        private void OnPlaybackVolume(int volume)
        {
            VolumeRequest request = (VolumeRequest)RequestFactory.CreateRequest(MessageType.Volume);
            request.Volume = volume;

            _playerCommunicatorControl.SendRequest(request);
        }

        void OnPlaylistSelectionChangedEvent(List<string> selectedFiles)
        {
            // if not stopped, set layout to layoutControl
            if (_playbackControl.PlaybackState == PlaybackState.Stopped)
            {
                return;
            }

            // make sure something is selected
            if (selectedFiles.Count == 0)
            {
                return;
            }

            // Get first videoFile
            VideoFile firstSelectedFile = null;
            foreach (VideoFile file in _files)
            {
                if (file.Filename.Equals(selectedFiles[0]))
                {
                    firstSelectedFile = file;
                    break;
                }
            }

            // Apply its layout to layoutControl
            _videoLayoutControl.Layout = firstSelectedFile.Layout;
        }

        private void OnVideoLayoutChangedEvent(VisibleLayout newLayout)
        {
            // Get selected from playlist
            List<string> files = _playlistControl.GetCurrent();
            if (files.Count.Equals(0))
            {
                // nothing to change
                return;
            }

            // Apply changes to videoLayout list (_files)
            foreach (VideoFile videoFile in _files)
            {
                foreach (string file in files)
                {
                    if (videoFile.Filename.Equals(file))
                    {
                        videoFile.Layout = newLayout;
                        break;
                    }
                }
            }

            // Send layout request
            VideoLayoutRequest layoutRequest = new VideoLayoutRequest();
            foreach (VideoFile file in _files)
            {
                layoutRequest.TracksLayout.Add(file.Layout);
            }
            _playerCommunicatorControl.SendRequest(layoutRequest);

        }

        private void OnPlaybackWindowLayoutChangedEvent(Layout newLayout)
        {
            WindowLayoutRequest request = new WindowLayoutRequest();

            request.MonitorId = _playbackWindowControl.MonitorId;
            request.Layout = newLayout;

            _playerCommunicatorControl.SendRequest(request);
        }
        private void OnUpdateDisplayDevicesEvent()
        {
            try
            {
                AResponse response = _playerCommunicatorControl.SendRequest(new DisplayDevicesInfoRequest());

                if (!response.Type.Equals(MessageType.DisplayDevicesInfo))
                {
                    throw new ApplicationException("Invalid response message");
                }

                _playbackWindowControl.DisplayDevices = ((DisplayDeviceInfoResponse)response).Devices;
            }
            catch (System.Exception e)
            {
                MessageBox.Show("Error. Could not retrieve monitor information\n" + e.Message);
            }
        }
        private void OnSkinInfoChangedEvent(SkinInfo skin, Point position)
        {
            if (!skin.GetName().Equals("None"))
            {
                _skinForm.Top = position.Y;
                _skinForm.Left = position.X;
            }

            _skinForm.SetSkin(skin);
        }
        private void MultiMediaPlayerFormVisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                _playerCommunicatorControl.NotifyHide();

                SkinInfo noneSkin = new SkinInfo();
                noneSkin.ImageFilename = "None";
                _skinForm.SetSkin(noneSkin);
            }
        }
      
        private void MultiMediaPlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnPlaybackStop();
        }

  #endregion
    }
}