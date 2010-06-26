using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UltraPlayerController.View.Settings;
using UltraPlayerController.View.CommonControls.PlayerCommunicator;
using System.Runtime.InteropServices;
using UltraPlayerController.View.CommonControls;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Communication;
using UltraPlayerController.View.Events;
using UltraPlayerController.Model.Utilities.MediaInfo;
using UltraPlayerController.Model.Communication.Request;
using UltraPlayerController.Model.SoundFx;
using UltraPlayerController.Model;

namespace UltraPlayerController.View.AudioPlayer
{
    public partial class AudioPlayerForm : Form
    {
        #region Fields
        private SettingsForm _settingsForm;
        private PlaylistForm _playlistForm;
        private PlayerCommunicatorControl _playerCommunicatorControl;
        private PlaybackControl _playbackControl;
        private EffectsForm _effectsForm;
        private MediaInfo _mediaInfo;
        private SpatializationForm _3dSoundForm;
        #endregion

        #region Contructors
        public AudioPlayerForm()
        {
            InitializeComponent();

            // Initialize custom components
            InitializePlaylistFrom();
            InitializePlaybackControl();
            InitializeSettingsForm();
            InitializeEffectsForm();
            Initialize3dSoundForm();
            InitializePlayerCommunicatorControl();

            _mediaInfo = new MediaInfo();
        }

        #endregion

        #region Methods
        private void InitializePlayerCommunicatorControl()
        {
            // add player communicator control
            _playerCommunicatorControl = new PlayerCommunicatorControl();
            _playerCommunicatorControl.Dock = DockStyle.Fill;
            PlayerCommunicatorPanel.Controls.Add(_playerCommunicatorControl);
        }
        private void Initialize3dSoundForm()
        {
            // Initialize 3d sound form
            _3dSoundForm = new SpatializationForm();
            _3dSoundForm.Visible = false;
            _3dSoundForm.Sound3dChanged += new Delegates.Sound3dEventHandler(OnSound3dChanged);
            Update3dSoundFormPosition();
        }
        private void InitializeEffectsForm()
        {
            //Initialize effects form
            _effectsForm = new EffectsForm();
            _effectsForm.Visible = false;
            _effectsForm.SoundFxChanged += new Delegates.SoundFxEventHandler(OnSoundFxChanged);
            _effectsForm.FrequencyChanged += new Delegates.IntegerValueActionEventHandler(OnFrequencyChanged);
            UpdateEffectsFormPosition();
        }
        private void InitializeSettingsForm()
        {
            // initialize settings form
            _settingsForm = new SettingsForm();
        }
        private void InitializePlaylistFrom()
        {
            // create playlist component
            _playlistForm = new PlaylistForm();
            _playlistForm.Visible = false;
            _playlistForm.AllowMulti(false);
            UpdatePlaylistFormPosition();
        }
        private void UpdateEffectsFormPosition()
        {
            _effectsForm.Left = this.Left + this.Width;
            _effectsForm.Top = this.Top;
        }
        private void Update3dSoundFormPosition()
        {
            _3dSoundForm.Left = this.Left + this.Width;
            _3dSoundForm.Top = this.Top;
        }
        private void UpdatePlaylistFormPosition()
        {
            _playlistForm.Left = this.Left + this.Width;
            _playlistForm.Top = this.Top;
        }
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
            _playbackControl.PreviousTrackEvent += new Delegates.ActionEventHandler(OnPlaybackPrevious);
            _playbackControl.NextTrackEvent += new Delegates.ActionEventHandler(OnPlaybackNext);
            _playbackControl.VolumeEvent += new Delegates.IntegerValueActionEventHandler(OnPlaybackVolume);
            _playbackControl.SeekEvent += new Delegates.IntegerValueActionEventHandler(OnPlaybackSeek);

        }
        #endregion

        #region Events
        private void OnPlaybackPlay()
        {
            // Send sound effects
            SoundFxRequest soundFxRequest = new SoundFxRequest();
            soundFxRequest.Effects = _effectsForm.GetEnabledEffects();
            _playerCommunicatorControl.SendRequest(soundFxRequest);

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
            _mediaInfo.Open(_playlistForm.GetCurrent()[0]);
            _playbackControl.PlaybackStarted(_mediaInfo.GetDuration());
            _mediaInfo.Close();
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
            _mediaInfo.Open(_playlistForm.GetCurrent()[0]);
            _playbackControl.PlaybackStarted(_mediaInfo.GetDuration());
            _mediaInfo.Close();
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
            _mediaInfo.Open(_playlistForm.GetCurrent()[0]);
            _playbackControl.PlaybackStarted(_mediaInfo.GetDuration());
            _mediaInfo.Close();

        }
        private void OnPlaybackStop()
        {
            _playerCommunicatorControl.SendRequest(RequestFactory.CreateRequest(MessageType.Stop));

            // set controls state
            // TODO set state based on response
            _playbackControl.PlaybackStopped();

            _effectsForm.UnlockEffects();

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
        private void OnPlaybackVolume(int volume)
        {
            VolumeRequest request = (VolumeRequest)RequestFactory.CreateRequest(MessageType.Volume);
            request.Volume = volume;

            _playerCommunicatorControl.SendRequest(request);
        }
        private void OnSoundFxChanged(ASoundFx soundFx)
        {
            if (_playbackControl.PlaybackState != PlaybackState.Playing)
            {
                return;
            }

            SoundFxRequest request = new SoundFxRequest();
            request.Effects.Add(soundFx);

            _playerCommunicatorControl.SendRequest(request);
        }
        private void OnFrequencyChanged(int frequency)
        {
            SetFrequencyRequest request = (SetFrequencyRequest)RequestFactory.CreateRequest(MessageType.SetFrequency);
            request.Frequency = frequency;
            _playerCommunicatorControl.SendRequest(request);
            
        }
        private void OnSound3dChanged(Sound3d sound3d)
        {
            if (_playbackControl.PlaybackState != PlaybackState.Playing)
            {
                return;
            }

            Sound3dRequest request = new Sound3dRequest();
            request.Sound3dProperties = sound3d;

            _playerCommunicatorControl.SendRequest(request);

        }
        private void ExitButtonClick(object sender, EventArgs e)
        {
            this.Hide();

            // Send termination request to player
            //_playerCommunicatorControl.SendRequest(RequestFactory.CreateRequest(RequestType.Termination));
        }
        private void SettingsButtonClick(object sender, EventArgs e)
        {
            this.Hide();
            _settingsForm.ShowDialog();

            // after settings form is closed, show the this form
            this.Show();
        }
        private void PlaylistVisibilityButtonClick(object sender, EventArgs e)
        {
            _effectsForm.Visible = false;
            _3dSoundForm.Visible = false;

            UpdatePlaylistFormPosition();
            _playlistForm.Visible = !_playlistForm.Visible;
        }
        private void AudioPlayerFormFormClosing(object sender, FormClosingEventArgs e)
        {
            OnPlaybackStop();

            _playlistForm.Visible = false;
            _effectsForm.Visible = false;
            _3dSoundForm.Visible = false;
            _playerCommunicatorControl.NotifyHide();
        }
        private void AudioPlayerFormMove(object sender, EventArgs e)
        {
            UpdatePlaylistFormPosition();
            UpdateEffectsFormPosition();
            Update3dSoundFormPosition();
        }
        private void AudioPlayerFormResize(object sender, EventArgs e)
        {
            UpdatePlaylistFormPosition();
            UpdateEffectsFormPosition();
            Update3dSoundFormPosition();
        }
        private void EffectsVisibilityButtonClick(object sender, EventArgs e)
        {
            _playlistForm.Visible = false;
            _3dSoundForm.Visible = false;

            UpdateEffectsFormPosition();
            _effectsForm.Visible = !_effectsForm.Visible;
        }
        private void SpatializationParamsVisibilityButtonClick(object sender, EventArgs e)
        {
            _playlistForm.Visible = false;
            _effectsForm.Visible = false;

            Update3dSoundFormPosition();
            _3dSoundForm.Visible = !_3dSoundForm.Visible;
        }
        #endregion
    }
}