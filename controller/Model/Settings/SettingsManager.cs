using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Net;
using Utilities.Pattern;

namespace UltraPlayerController.Model.Settings
{
    public class SettingsManager // is singleton
    {
        #region Fields
        private PlayerSettings _playerSettings;
        #endregion

        #region Constructors
        private SettingsManager()
        {
            _playerSettings = new PlayerSettings();
        }

        public static SettingsManager Instance
        {
            get
            {
                return Singleton<SettingsManager>.Instance;
            }
        }
        #endregion

        #region Properties
        public PlayerSettings PlayerSettings
        {
            set
            {
                _playerSettings = value;
            }
            get
            {
                return _playerSettings;
            }
        }
        #endregion

        #region Methods
        public void Save()
        {
            try
            {
                string settingsFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), Properties.Settings.Default.SettingsFilename);

                List<string> serializedSettingsList = new List<string>();
                serializedSettingsList.InsertRange(0, _playerSettings.SerializeSettings());

                StreamWriter file = new StreamWriter(settingsFile);
                foreach (string setting in serializedSettingsList)
                {
                    file.WriteLine(setting);
                }

                file.Close();
    
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error while saving settings.\n" + e.Message,"Error");
            }

        }

        public void Load()
        {
            try
            {
                StreamReader file = new StreamReader(Properties.Settings.Default.SettingsFilename);
                string line = file.ReadLine();
                while (line != null)
                {
                    _playerSettings.ParseSettingsFromString(line);

                    line = file.ReadLine();
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                // setting file does not exist, load defaults
                _playerSettings.Ip = IPAddress.Loopback;
                _playerSettings.Port = 32000;

                SkinInfo skinNone = new SkinInfo();
                skinNone.ImageFilename = "None";
                _playerSettings.SkinFilename = skinNone; 
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error while loading settings.\n" +e.Message, "Error");            	
            }
            
        }
        #endregion

    }
}
