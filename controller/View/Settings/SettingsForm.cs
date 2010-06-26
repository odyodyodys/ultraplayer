using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UltraPlayerController.Model.Settings;

namespace UltraPlayerController.View.Settings
{
    public partial class SettingsForm : Form
    {
        #region Fields
        private PlayerSettingsControl _playerSettings;
        #endregion

        #region Constructors
        public SettingsForm()
        {
            InitializeComponent();

            // Initialize settings controls
            _playerSettings = new PlayerSettingsControl(SettingsManager.Instance.PlayerSettings);
            _playerSettings.Dock = DockStyle.Fill;
            _playerSettings.Visible = true;
            SettingsPanel.Controls.Add(_playerSettings);

            // Load settings
            SettingsManager.Instance.Load();
        }
        #endregion

        #region Events

        private void SaveButtonClick(object sender, EventArgs e)
        {
            SettingsManager.Instance.PlayerSettings = _playerSettings.Settings;
            SettingsManager.Instance.Save();
        }
        #endregion

    }
}