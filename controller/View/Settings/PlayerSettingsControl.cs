using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using UltraPlayerController.Model.Settings;
using UltraPlayerController.Model.Enumerations;
using System.IO;
using UltraPlayerController.View.Events;
using System.Net;
using UltraPlayerController.Model;

namespace UltraPlayerController.View.Settings
{
    public partial class PlayerSettingsControl : UserControl
    {
        #region Fields
        private PlayerSettings _settings;
        #endregion

        #region Constructors
        public PlayerSettingsControl(PlayerSettings settings)
        {
            InitializeComponent();

            // set skins to combobox
            foreach (var skin in SkinLoader.Instance.Load())
            {
                SkinComboBox.Items.Add(skin.GetName());
            }

            _settings = settings;

            ApplySettings();
        }

        private void ApplySettings()
        {
            // from settings to UI

            try
            {
                PlayerIpTextBox.Text = _settings.Ip.ToString();

                // port
                PortTextbox.Text = _settings.Port.ToString();

                // skin file
                try
                {
                    // select item having same name
                    foreach (var item in SkinComboBox.Items)
                    {
                        if (item.ToString().Equals(_settings.SkinFilename.GetName()))
                        {
                            SkinComboBox.SelectedItem = item;
                            break;
                        }
                    }
                }
                catch (System.Exception)
                {
                    // no need to do any actions                	
                }
            }
            catch (System.Exception)
            {

            }
        }
        #endregion

        #region Events
        private void PlayerIpTextBoxLeave(object sender, EventArgs e)
        {
            try
            {
                _settings.Ip = IPAddress.Parse(PlayerIpTextBox.Text);
            }
            catch (System.Exception)
            {

            }
            ApplySettings();
        }

        private void PortTextboxLeave(object sender, EventArgs e)
        {
            try
            {
                _settings.Port = uint.Parse(PortTextbox.Text);
            }
            catch (System.Exception)
            {

            }
            ApplySettings();
        }

        private void SkinComboBoxSelectionChangeCommitted(object sender, EventArgs e)
        {
            _settings.SkinFilename = ((List<SkinInfo>)SkinLoader.Instance.Load()).Find(delegate(SkinInfo skin)
                                                                                       {
                                                                                           return skin.GetName().Equals(SkinComboBox.SelectedItem.ToString());
                                                                                       });
            ApplySettings();
        }

        #endregion

        #region Properties
        public PlayerSettings Settings
        {
            get
            {
                return _settings;
            }
        }
        #endregion

        private void PlayerSettingsControl_Enter(object sender, EventArgs e)
        {
            ApplySettings();
        }

    }
}
