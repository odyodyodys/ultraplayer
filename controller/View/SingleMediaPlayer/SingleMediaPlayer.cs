using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using UltraPlayerController.View.Events;
using UltraPlayerController.View.Settings;
using UltraPlayerController.Model.Utilities.MediaInfo;
using UltraPlayerController.View.CommonControls;
using UltraPlayerController.View.CommonControls.PlayerCommunicator;
using UltraPlayerController.View.CommonControls.PlaybackWindow;
using UltraPlayerController.Model.Addon;
using UltraPlayerController.Model;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.Model.Communication;
using UltraPlayerController.Communication;
using UltraPlayerController.Model.Communication.Response;
using UltraPlayerController.Model.Communication.Request;
using System.IO;
using UltraPlayerController.Model.Settings;

namespace UltraPlayerController.View.SingleMediaPlayer
{
    public partial class SingleMediaPlayerForm : Form
    {
        #region Fields
        private Form _currentForm;
        private PlaylistForm _playlistForm;
        private SettingsForm _settingsForm;
        private AddonsForm _addonsForm;
        private PlaybackWindowPropertiesForm _playbackWindowForm;
        private PlayerCommunicatorControl _playerCommunicatorControl;
        private PlaybackControl _playbackControl;
        private PlaybackPropertiesControl _playbackPropertiesControl;
        private MediaInfo _mediaInfo;
        private PlayerSkinForm _skinForm;

        private bool _isRepeatOn;
        private bool _isSuffleOn;
        #endregion

        #region Constructors
        public SingleMediaPlayerForm()
        {
            InitializeComponent();

            InitializePlaybackControl();

            InitializePlaybackPropertiesControl();

            InitializePlaylistForm();

            InitializeSettingsForm();

            InitializeAddonsForm();

            InitializePlaybackWindowForm();

            InitializePlaybackCommunicatorControl();

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

            // set playback control events
            _playbackControl.PlayEvent += new Delegates.ActionEventHandler(OnPlaybackPlay);
            _playbackControl.PauseEvent += new Delegates.ActionEventHandler(OnPlaybackPause);
            _playbackControl.ResumeEvent += new Delegates.ActionEventHandler(OnPlaybackResume);
            _playbackControl.StopEvent += new Delegates.ActionEventHandler(OnPlaybackStop);
            _playbackControl.PreviousTrackEvent += new Delegates.ActionEventHandler(OnPlaybackPrevious);
            _playbackControl.NextTrackEvent += new Delegates.ActionEventHandler(OnPlaybackNext);
            _playbackControl.VolumeEvent += new Delegates.IntegerValueActionEventHandler(OnPlaybackVolume);
            _playbackControl.SeekEvent += new Delegates.IntegerValueActionEventHandler(OnPlaybackSeek);
            _playbackControl.PlaybackEndedEvent += new Delegates.ActionEventHandler(OnPlaybackEndedEvent);
        }
        private void InitializePlaybackCommunicatorControl()
        {
            // add player communicator control
            _playerCommunicatorControl = new PlayerCommunicatorControl();
            _playerCommunicatorControl.Dock = DockStyle.Fill;
            PlayerCommunicatorPanel.Controls.Add(_playerCommunicatorControl);
        }
        private void InitializePlaybackWindowForm()
        {
            // Initialize PlaybackWindow form
            _playbackWindowForm = new PlaybackWindowPropertiesForm();
            _playbackWindowForm.Visible = false;
            UpdatePlaybackWindowFormPosition();

            _playbackWindowForm.PlaybackWindowLayoutChangedEvent += new Delegates.LayoutChangedEventHandler(OnPlaybackWindowLayoutChanged);
            _playbackWindowForm.UpdateDisplayDeviceListEvent += new Delegates.ActionEventHandler(OnUpdateDisplayDeviceListEvent);
            _playbackWindowForm.SkinInfoChangedEvent += new Delegates.SetSkinInfo(OnSkinInfoChangedEvent);
        }
        private void InitializeAddonsForm()
        {
            //Initialize Addons form
            _addonsForm = new AddonsForm();
            _addonsForm.Visible = false;
            UpdateAddonsFormPosition();

            _addonsForm.AddonRemovedEvent += new Delegates.IntegerValueActionEventHandler(OnAddonRemovedEvent);
            _addonsForm.AddonSetEvent += new Delegates.AddonEventHandler(OnAddonSetEvent);

        }
        private void InitializeSettingsForm()
        {
            // initialize settings form
            _settingsForm = new SettingsForm();
        }
        private void InitializePlaylistForm()
        {
            // create playlist component
            _playlistForm = new PlaylistForm();
            _playlistForm.Visible = false;
            _playlistForm.AllowMulti(false);
            UpdatePlaylistFormPosition();

            // set playlist events
            _playlistForm.ItemDoubleClickedEvent += new PlaylistControl.PlaylistActionEventHandler(OnPlaylistDoubleClickedItem);
        }
        private void InitializePlaybackPropertiesControl()
        {
            // create playback properties control
            _playbackPropertiesControl = new PlaybackPropertiesControl();
            _playbackPropertiesControl.Dock = DockStyle.Fill;
            PlaybackPropertiesPanel.Controls.Add(_playbackPropertiesControl);

            // set events
            _playbackPropertiesControl.RepeatStateChangedEvent += new Delegates.SwitchOptionChangedEventHandler(OnRepeatStateChangedEvent);
            _playbackPropertiesControl.ShuffleStateChangedEvent += new Delegates.SwitchOptionChangedEventHandler(OnShuffleStateChangedEvent);
            _playbackPropertiesControl.RateChangedEvent += new Delegates.ParameterValueActionEventHandler(OnRateChangedEvent);
        }
        private void InitializeSkins()
        {
            _playbackWindowForm.Skins = (List<SkinInfo>)SkinLoader.Instance.Load();

            _skinForm = new PlayerSkinForm();

            // call form load indirectly
            _skinForm.Show();
            _skinForm.Hide();

            // set current skin
            _playbackWindowForm.SetCurrentSkin(SettingsManager.Instance.PlayerSettings.SkinFilename);
        }

        private void UpdatePlaylistFormPosition()
        {
            _playlistForm.Left = this.Left + this.Width;
            _playlistForm.Top = this.Top;
        }
        private void UpdateAddonsFormPosition()
        {
            _addonsForm.Left = this.Left + this.Width;
            _addonsForm.Top = this.Top;
        }
        private void UpdatePlaybackWindowFormPosition()
        {
            _playbackWindowForm.Left = this.Left + this.Width;
            _playbackWindowForm.Top = this.Top;
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

        #endregion

        #region Events
        private void ExitButtonClick(object sender, EventArgs e)
        {
            this.Hide();

            // Send termination request to player
            //_playerCommunicatorControl.SendRequest(RequestFactory.CreateRequest(RequestType.Termination));
        }
        private void SingleMediaPlayerFormMove(object sender, EventArgs e)
        {
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
        private void PlaylistVisibilityButtonClick(object sender, EventArgs e)
        {
            SwitchTo(_playlistForm);
        }
        private void SingleMediaPlayerFormResize(object sender, EventArgs e)
        {
            UpdateCurrentForm();
        }

        private void SettingsButtonClick(object sender, EventArgs e)
        {
            _settingsForm.ShowDialog();
        }
        private void AddonsButtonClick(object sender, EventArgs e)
        {
            SwitchTo(_addonsForm);
        }
        private void WindowLayoutButtonClick(object sender, EventArgs e)
        {
            SwitchTo(_playbackWindowForm);
        }
        private void OnPlaybackPlay()
        {
            PlayRequest request = (PlayRequest)RequestFactory.CreateRequest(MessageType.Play);

            if (_playlistForm.GetCurrent().Count.Equals(0))
            {
                MessageBox.Show("Playlist is empty. Nothing to play", "Information");
                return;
            }

            request.Tracks = _playlistForm.GetCurrent();

            AResponse response = _playerCommunicatorControl.SendRequest(request);

            try
            {
	            // if success
	            if (response.ResponseType == ServerResponseType.Success)
	            {
	                // set controls state
	                _mediaInfo.Open(_playlistForm.GetCurrent()[0]);
	                _playbackControl.PlaybackStarted(_mediaInfo.GetDuration());
	                _mediaInfo.Close();
	
	                _addonsForm.PlaybackStarted();
	
	                // Set volume
	                OnPlaybackVolume(_playbackControl.Volume);                
	            }
            }
            catch (System.Exception)
            {
            	
            }
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

            // Set volume
            OnPlaybackVolume(_playbackControl.Volume);
        }
        private void OnPlaybackPrevious()
        {
            PlayRequest request = (PlayRequest)RequestFactory.CreateRequest(MessageType.Play);

            if (string.IsNullOrEmpty(_playlistForm.GoToPrevious()))
            {
                MessageBox.Show("Playlist is empty. Nothing to play", "Information");
                return;
            }

            OnPlaybackPlay();
        }
        private void OnPlaybackNext()
        {
            PlayRequest request = (PlayRequest)RequestFactory.CreateRequest(MessageType.Play);

            if (String.IsNullOrEmpty(_playlistForm.GoToNext()))
            {
                MessageBox.Show("Nothing to play. Check playlist", "Information");
                return;
            }

            OnPlaybackPlay();
        }
        private void OnPlaybackStop()
        {
            _playerCommunicatorControl.SendRequest(RequestFactory.CreateRequest(MessageType.Stop));

            // set controls state
            // TODO set state based on response
            _playbackControl.PlaybackStopped();

            _addonsForm.PlaybackStopped();
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

            // Get track duration and compute seek time in milliseconds
            request.SeekTime = milliseconds;

            _playerCommunicatorControl.SendRequest(request);

            _playbackControl.PlaybackSeeked(milliseconds);
        }
        private void OnPlaybackEndedEvent()
        {
            if (_isRepeatOn && _isSuffleOn)
            {
                int numOfTracks = _playlistForm.GetTrackCount();
                Random random = new Random();
                _playlistForm.SetSelected(random.Next(numOfTracks));

                // next has been selected, start playing it
                OnPlaybackPlay();
            }
            else if (_isRepeatOn)
            {
                if (_playlistForm.IsLastSelected())
                {
                    _playlistForm.SetSelected(0);
                    OnPlaybackPlay();
                }
                else
                {
                    OnPlaybackNext();
                }

            }
            else if (_isSuffleOn)
            {
                // select a random one
                int numOfTracks = _playlistForm.GetTrackCount();
                Random random = new Random();
                _playlistForm.SetSelected(random.Next(numOfTracks));

                // next has been selected, start playing it
                OnPlaybackPlay();

            }
            else
            {
                if (!_playlistForm.IsLastSelected())
                {
                    OnPlaybackNext();
                }
            }

        }
        private void OnRepeatStateChangedEvent(bool value)
        {
            _isRepeatOn = value;
        }
        private void OnShuffleStateChangedEvent(bool value)
        {
            _isSuffleOn = value;
        }
        private void OnRateChangedEvent(int paramId, float value)
        {

            if (_playbackControl.PlaybackState != PlaybackState.Playing)
            {
                return;
            }

            SetRateRequest request = (SetRateRequest)RequestFactory.CreateRequest(MessageType.SetRate);
            request.Rate = value;
            _playerCommunicatorControl.SendRequest(request);

        }
        private void OnPlaylistDoubleClickedItem()
        {
            // user double clicked item on playlist.
            // Play the item

            OnPlaybackPlay();
        }
        private void OnPlaybackWindowLayoutChanged(Layout newLayout)
        {
            WindowLayoutRequest request = new WindowLayoutRequest();

            request.MonitorId = _playbackWindowForm.MonitorId;
            request.Layout = newLayout;

            _playerCommunicatorControl.SendRequest(request);
        }
        private void OnUpdateDisplayDeviceListEvent()
        {
            try
            {
                AResponse response = _playerCommunicatorControl.SendRequest(new DisplayDevicesInfoRequest());

                if (!response.Type.Equals(MessageType.DisplayDevicesInfo))
                {
                    throw new ApplicationException("Invalid response message");
                }

                _playbackWindowForm.DisplayDevices = ((DisplayDeviceInfoResponse)response).Devices;
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

        private void OnAddonRemovedEvent(int addonId)
        {
            try
            {
                RemoveAddonRequest request = new RemoveAddonRequest();
                request.AddonId = (uint)addonId;
                _playerCommunicatorControl.SendRequest(request);
            }
            catch (System.Exception)
            {

            }
        }
        private void OnAddonSetEvent(AAddon addon)
        {
            try
            {
                ARequest request = null;
                VisibleObject objectProperties = new VisibleObject();

                switch (addon.Type)
                {
                    case AddonType.D3dImage:
                        request = new SetImageRequest();

                        ((SetImageRequest)request).Filename = ((ImageD3dVisibleAddon)addon).ImageFilename;
                        objectProperties.Id = addon.Id;
                        objectProperties.Layout = ((ImageD3dVisibleAddon)addon).Layout;
                        ((SetImageRequest)request).ImageProperties = objectProperties;
                        break;
                    case AddonType.D3dText:
                        request = new SetTextRequest();

                        ((SetTextRequest)request).Text = ((TextD3dVisibleAddon)addon).Text;
                        objectProperties.Id = addon.Id;
                        objectProperties.Layout = ((TextD3dVisibleAddon)addon).Layout;

                        ((SetTextRequest)request).ObjectProperties = objectProperties;
                        break;
                    default:
                        break;
                }
                _playerCommunicatorControl.SendRequest(request);
            }
            catch (System.Exception)
            {

            }
        }
        private void SingleMediaPlayerFormVisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                if (_currentForm != null)
                {
                    _currentForm.Visible = false;
                }

                _playerCommunicatorControl.NotifyHide();

                SkinInfo noneSkin = new SkinInfo();
                noneSkin.ImageFilename = "None";
                _skinForm.SetSkin(noneSkin);
            }
        }
        

        private void SingleMediaPlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnPlaybackStop();
        }
#endregion
    }
}
