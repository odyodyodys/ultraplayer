using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UltraPlayerController.View.CommonControls;
using UltraPlayerController.View.Settings;
using UltraPlayerController.View.CommonControls.PlayerCommunicator;
using UltraPlayerController.Model.Utilities.MediaInfo;
using UltraPlayerController.Communication;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.View.Events;
using UltraPlayerController.Model.Communication.Request;
using UltraPlayerController.Model;
using UltraPlayerController.Model.Communication.Response;

namespace UltraPlayerController.View.MidiPlayer
{
    public partial class MidiPlayerForm : Form
    {
        #region Fields
        private Form _currentForm;
        private PlaylistForm _playlistForm;
        private SettingsForm _settingsForm;
        private PlayerCommunicatorControl _playerCommunicatorControl;
        private PlaybackControl _playbackControl;
        private MusicPropertiesForm _musicPropertiesForm;
        #endregion

        #region Constructors
        public MidiPlayerForm()
        {
            InitializeComponent();
            InitializePlaylistForm();
            InitializePlaybackControl();
            InitializeSettingsForm();
            InitializePlaybackCommunicatorControl();
            InitializeMusicPropertiesForm();
        }


        #endregion

        #region Methods
        private void InitializePlaybackCommunicatorControl()
        {
            // add player communicator control
            _playerCommunicatorControl = new PlayerCommunicatorControl();
            _playerCommunicatorControl.Dock = DockStyle.Fill;
            PlayerCommunicatorPanel.Controls.Add(_playerCommunicatorControl);
        }
        private void InitializeSettingsForm()
        {
            // initialize settings form
            _settingsForm = new SettingsForm();
        }
        private void InitializeMusicPropertiesForm()
        {
            _musicPropertiesForm = new MusicPropertiesForm();
            _musicPropertiesForm.Visible = false;
            UpdateMusicPropertiesFormPosition();
        }
        private void UpdateMusicPropertiesFormPosition()
        {
            _musicPropertiesForm.Left = this.Left + this.Width;
            _musicPropertiesForm.Top = this.Top;

            _musicPropertiesForm.MidiPropertiesChangedEvent += new Delegates.ActionEventHandler(OnMidiPropertiesChangedEvent);
            _musicPropertiesForm.Sound3dChangedEvent += new Delegates.Sound3dEventHandler(OnSoundPositionChangedEvent);
            _musicPropertiesForm.UpdateMidiOutputPortsEvent += new Delegates.ActionEventHandler(OnUpdateMidiOutputPortsEvent);
            _musicPropertiesForm.SelectedMidiOutputPortChangedEvent += new Delegates.TextChangedEventHandler(OnSelectedMidiOutputPortChangedEvent);
            _musicPropertiesForm.DlsFileChangedEvent += new Delegates.TextChangedEventHandler(OnDlsFileChangedEvent);
        }
        private void InitializePlaybackControl()
        {
            // add playback controls control
            _playbackControl = new PlaybackControl();
            _playbackControl.Dock = DockStyle.Fill;
            PlaybackControlsPanel.Controls.Add(_playbackControl);

            _playbackControl.PlayEvent += new UltraPlayerController.View.Events.Delegates.ActionEventHandler(OnPlaybackPlay);
            _playbackControl.PauseEvent += new UltraPlayerController.View.Events.Delegates.ActionEventHandler(OnPlaybackPause);
            _playbackControl.ResumeEvent += new UltraPlayerController.View.Events.Delegates.ActionEventHandler(OnPlaybackResume);
            _playbackControl.PreviousTrackEvent += new UltraPlayerController.View.Events.Delegates.ActionEventHandler(OnPlaybackPrevious);
            _playbackControl.NextTrackEvent += new UltraPlayerController.View.Events.Delegates.ActionEventHandler(OnPlaybackNext);
            _playbackControl.StopEvent += new UltraPlayerController.View.Events.Delegates.ActionEventHandler(OnPlaybackStop);
            _playbackControl.SeekEvent += new UltraPlayerController.View.Events.Delegates.IntegerValueActionEventHandler(OnPlaybackSeek);
            _playbackControl.VolumeEvent += new UltraPlayerController.View.Events.Delegates.IntegerValueActionEventHandler(OnPlaybackVolume);
        }
        private void InitializePlaylistForm()
        {
            // create playlist component
            _playlistForm = new PlaylistForm();
            _playlistForm.Visible = false;
            _playlistForm.AllowMulti(false);
            UpdatePlaylistFormPosition();
        }
        private void UpdatePlaylistFormPosition()
        {
            _playlistForm.Left = this.Left + this.Width;
            _playlistForm.Top = this.Top;
        }
        private void SwitchTo(Form newForm)
        {
            // if same, inverse visibility
            if (_currentForm == newForm)
            {
                _currentForm.Visible = !_currentForm.Visible;
                return;
            }

            if (_currentForm != null)
            {
                _currentForm.Visible = false;
            }

            _currentForm = newForm;
            _currentForm.Visible = !_currentForm.Visible;

            UpdateCurrentForm();
        }
        private void UpdateCurrentForm()
        {
            if (_currentForm != null)
            {
                _currentForm.Left = this.Left + this.Width;
                _currentForm.Top = this.Top;

            }
        }
        private void MusicPropertiesVisibilityButton_Click(object sender, EventArgs e)
        {
            SwitchTo(_musicPropertiesForm);
        }
        #endregion

        #region Events
        private void OnPlaybackPlay()
        {
            // Send play request
            PlayRequest request = (PlayRequest)RequestFactory.CreateRequest(MessageType.Play);
            if (_playlistForm.GetCurrent().Count.Equals(0))
            {
                MessageBox.Show("Playlist is empty. Nothing to play", "Information");
                return;
            }
            request.Tracks = _playlistForm.GetCurrent();
            _playerCommunicatorControl.SendRequest(request);

            // TODO set state based on response
            // set controls state
            _playbackControl.DisableSeeking();
            _playbackControl.PlaybackStarted(0);
        }
        private void OnPlaybackVolume(int volume)
        {
            VolumeRequest request = (VolumeRequest)RequestFactory.CreateRequest(MessageType.Volume);
            request.Volume = volume;

            _playerCommunicatorControl.SendRequest(request);
        }
        private void OnPlaybackSeek(int milliseconds)
        {
            if (_playbackControl.PlaybackState != PlaybackState.Paused && _playbackControl.PlaybackState != PlaybackState.Playing)
            {
                return;
            }

            SeekRequest request = new SeekRequest();

            // Get track duration an compute seek time in milliseconds
            request.SeekTime = milliseconds;

            _playerCommunicatorControl.SendRequest(request);
        }
        private void OnPlaybackStop()
        {
            _playerCommunicatorControl.SendRequest(RequestFactory.CreateRequest(MessageType.Stop));

            // set controls state
            // TODO set state based on response
            _playbackControl.PlaybackStopped();
        }
        private void OnPlaybackNext()
        {
            PlayRequest request = (PlayRequest)RequestFactory.CreateRequest(MessageType.Play);

            if (string.IsNullOrEmpty(_playlistForm.GoToNext()))
            {
                MessageBox.Show("Playlist is empty. Nothing to play", "Information");
                return;
            }

            request.Tracks = _playlistForm.GetCurrent();

            _playerCommunicatorControl.SendRequest(request);

            // TODO set state based on response
            // set controls state
            _playbackControl.DisableSeeking();
            _playbackControl.PlaybackStarted(0);
        }
        private void OnPlaybackPrevious()
        {
            PlayRequest request = (PlayRequest)RequestFactory.CreateRequest(MessageType.Play);

            if (string.IsNullOrEmpty(_playlistForm.GoToPrevious()))
            {
                MessageBox.Show("Playlist is empty. Nothing to play", "Information");
                return;
            }

            request.Tracks = _playlistForm.GetCurrent();

            _playerCommunicatorControl.SendRequest(request);

            // TODO set state based on response
            // set controls state
            _playbackControl.DisableSeeking();
            _playbackControl.PlaybackStarted(0);
        }
        private void OnPlaybackResume()
        {
            _playerCommunicatorControl.SendRequest(RequestFactory.CreateRequest(MessageType.Resume));

            // set controls state
            // TODO set state based on response
            _playbackControl.PlaybackResumed();
        }
        private void OnPlaybackPause()
        {
            _playerCommunicatorControl.SendRequest(RequestFactory.CreateRequest(MessageType.Pause));

            // set controls state
            // TODO set state based on response

            _playbackControl.PlaybackPaused();
        }
        private void OnMidiPropertiesChangedEvent()
        {
            MidiPropertiesRequest request = (MidiPropertiesRequest)RequestFactory.CreateRequest(MessageType.MidiProperties);

            request.EnableChorus = _musicPropertiesForm.IsChorusEnabled;
            request.EnableReverb = _musicPropertiesForm.IsReverbEnabled;
            request.Tempo = _musicPropertiesForm.Tempo;

            _playerCommunicatorControl.SendRequest(request);
        }
        private void OnSoundPositionChangedEvent(Sound3d soundPosition)
        {
            Sound3dRequest request = (Sound3dRequest)RequestFactory.CreateRequest(MessageType.Sound3d);
            request.Sound3dProperties = _musicPropertiesForm.SoundSourcePosition;

            _playerCommunicatorControl.SendRequest(request);
        }
        private void OnUpdateMidiOutputPortsEvent()
        {
            MidiOutputPortInfoResponse response = (MidiOutputPortInfoResponse)_playerCommunicatorControl.SendRequest(RequestFactory.CreateRequest(MessageType.MidiOutputPortInfo));
            // TODO get response and add midi devices to control
            _musicPropertiesForm.MidiOutputPortList = response.PortInfoList;
        }
        private void OnSelectedMidiOutputPortChangedEvent(string portDescription)
        {
            SetMidiOutputPortRequest request = (SetMidiOutputPortRequest)RequestFactory.CreateRequest(MessageType.SetMidiOutputPort);
            request.PortDescription = portDescription;
            _playerCommunicatorControl.SendRequest(request);
        }
        private void OnDlsFileChangedEvent(string dlsFile)
        {
            SetDlsRequest request = (SetDlsRequest)RequestFactory.CreateRequest(MessageType.SetDls);
            request.DlsFile = dlsFile;
            _playerCommunicatorControl.SendRequest(request);
        }
        private void ExitButtonClick(object sender, EventArgs e)
        {
            this.Hide();

            // Send termination request to player
            //_playerCommunicatorControl.SendRequest(RequestFactory.CreateRequest(RequestType.Termination));
        }
        private void PlaylistButtonClick(object sender, EventArgs e)
        {
            SwitchTo(_playlistForm);
        }
        private void MidiPlayerFormFormClosing(object sender, FormClosingEventArgs e)
        {
            OnPlaybackStop();

            if (_currentForm != null)
            {
                _currentForm.Visible = false;
            }

            _playerCommunicatorControl.NotifyHide();
        }
        private void MidiPlayerFormMove(object sender, EventArgs e)
        {
            UpdateCurrentForm();
        }
        private void MidiPlayerFormResize(object sender, EventArgs e)
        {
            UpdateCurrentForm();
        }
        private void SettingsButtonClick(object sender, EventArgs e)
        {
            _settingsForm.ShowDialog();
        }
        #endregion

    }
}
