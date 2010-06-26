using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UltraPlayerController.View.MultiMediaPlayer;
using UltraPlayerController.View.SingleMediaPlayer;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.View.AudioPlayer;
using UltraPlayerController.View.MidiPlayer;
using UltraPlayerController.View.Settings;
using System.Diagnostics;
using UltraPlayerController.View.CommonControls.PlayerCommunicator;
using UltraPlayerController.Communication;
using UltraPlayerController.Model.Settings;
using UltraPlayerController.Model.Communication.Request;

namespace UltraPlayerController.View
{
    public partial class PlayerSelectionForm : Form
    {
        #region Fields
        private Form _currentPlayerForm;
        private Dictionary<PlayerType, Form> _playerForms;
        private SettingsForm _settingsForm;
        private Process _playerProcess;
        #endregion

        #region Constructors
        public PlayerSelectionForm()
        {
            InitializeComponent();

            // initialize playerForms list
            _playerForms = new Dictionary<PlayerType, Form>();

            // create all player forms
            _playerForms.Add(PlayerType.SingleMedia, new SingleMediaPlayerForm());
            _playerForms.Add(PlayerType.MultiMedia, new MultiMediaPlayerForm());
            _playerForms.Add(PlayerType.Audio, new AudioPlayerForm());
            _playerForms.Add(PlayerType.Midi, new MidiPlayerForm());

            // create the settings form
            _settingsForm = new SettingsForm();

            // set player process info
            _playerProcess = new Process();
            _playerProcess.StartInfo.FileName = Properties.Settings.Default.PlayerExecutable;
        }
        #endregion

        #region Methods
        private void SetPlayerEnvironment(PlayerType playerType)
        {
            SetPlayerType(playerType, RunLocalPlayerCheckbox.Checked);

            _currentPlayerForm = _playerForms[playerType];
            this.Hide();
            _currentPlayerForm.ShowDialog();

            // after current player is closed, show this form again
            this.Show();
        }

        private void SetPlayerType(PlayerType playerType, bool shouldRunLocal)
        {
            try
            {
                // start player if it's not already running
                if (shouldRunLocal)
                {
                    bool isRunning = true;
                    try
                    {
                        if (_playerProcess.Id == 0)
                        {
                            isRunning = false;
                        }
                    }
                    catch (Exception)
                    {
                        isRunning = false;
                    }

                    if (!isRunning)
                    {
                        string arguments = SettingsManager.Instance.PlayerSettings.Port.ToString();
                        _playerProcess.StartInfo.Arguments = arguments;

                        // start process
                        _playerProcess.Start();

                    }
                }

                SetPlayerTypeRequest request = new SetPlayerTypeRequest();
                request.PlayerType = playerType;
                PlayerCommunicatorControl.SendRequest(request);

            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void KillPlayerProcess()
        {
            try
            {
                if (_playerProcess.Id != 0)
	            {
	                PlayerCommunicatorControl communicator = new PlayerCommunicatorControl();
	                communicator.SendRequest(RequestFactory.CreateRequest(MessageType.Termination));
	            }
            }
            catch (System.Exception)
            {
            	
            }
            // TODO. wait until exits or force it.
        }
        #endregion

        #region Events
        private void SingleVideoButtonClick(object sender, EventArgs e)
        {
            SetPlayerEnvironment(PlayerType.SingleMedia);
        }

        private void ExitButtonClick(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void SettingsButtonClick(object sender, EventArgs e)
        {
            this.Hide();
            _settingsForm.ShowDialog();

            // after settings form is closed, show the this form
            this.Show();
        }

        private void MultiVideoButtonClick(object sender, EventArgs e)
        {
            SetPlayerEnvironment(PlayerType.MultiMedia);
        }

        private void AudioButtonClick(object sender, EventArgs e)
        {
            SetPlayerEnvironment(PlayerType.Audio);
        }

        private void MidiButtonClick(object sender, EventArgs e)
        {
            SetPlayerEnvironment(PlayerType.Midi);
        }
        #endregion

        private void PlayerSelectionFormFormClosing(object sender, FormClosingEventArgs e)
        {
            // Kill player process
            KillPlayerProcess();
        }

    }
}