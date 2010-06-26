using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Utilities;
using UltraPlayerController.Model.Enumerations;
using System.Windows.Forms;
using System.Net;

namespace UltraPlayerController.Model.Settings
{
    public class PlayerSettings : AApplicationSettings
    {
        #region Fields
        private IPAddress _ip;
        private uint _port;
        private SkinInfo _skin;
        #endregion

        #region Constructors
        public PlayerSettings()
        {
            // set defaults
            _ip = IPAddress.Loopback;
            _port = Properties.Settings.Default.DefaultCommunicationPort;
            
            // TODO, load proper skin
            _skin = new SkinInfo();
            
        }
        #endregion

        #region Properties
        public uint Port
        {
            set
            {
                _port = value;
            }
            get
            {
                return _port;
            }
        }
        public IPAddress Ip
        {
            set
            {
                _ip = value;
            }
            get
            {
                return _ip;
            }
        }
        public SkinInfo SkinFilename
        {
            set
            {
                _skin = value;
            }
            get
            {
                return _skin;
            }
        }
        #endregion

        #region AApplicationSettings
        public override List<string> SerializeSettings()
        {
            List<string> settings = new List<string>();

            try
            {
                settings.Add(SeriallizeSetting(Properties.Settings.Default.SettingNamePort, _port));
                settings.Add(SeriallizeSetting(Properties.Settings.Default.SettingNameSkinfilename, _skin.GetName()));
                settings.Add(SeriallizeSetting(Properties.Settings.Default.SettingNamePlayerIp, _ip));
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error while serializing Player Settings\n" + e.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);
            }

            return settings;
        }

        public override void ParseSettingsFromString(string settingsLine)
        {
            try
            {
                string name = ExtractSettingName(settingsLine);
                string value = ExtractSettingValue(settingsLine);

                if (name == Properties.Settings.Default.SettingNamePort)
                {
                    _port = uint.Parse(value);
                }
                else if (name == Properties.Settings.Default.SettingNameSkinfilename)
                {
                    _skin = SkinLoader.Instance.GetByName(value);
                }
                else if (name == Properties.Settings.Default.SettingNamePlayerIp)
                {
                    _ip = IPAddress.Parse(value);
                }

            }
            catch (System.Exception e)
            {
                MessageBox.Show("Error while loading settings\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion
    }
}
