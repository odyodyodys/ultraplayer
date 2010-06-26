using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace UltraPlayerController.Model.Utilities
{
    public abstract class AApplicationSettings
    {
        #region Fields
        private string _delimiter;
        #endregion

        #region Constructors
        protected AApplicationSettings()
        {
            _delimiter = "=";

        }
        #endregion

        #region Methods
        abstract public List<string> SerializeSettings();
        abstract public void ParseSettingsFromString(string settingsLine);

        protected string SeriallizeSetting<type>(string settingName, type settingData)
        {
            string serializedData = string.Empty;

            try
            {
                serializedData = settingName + _delimiter + settingData.ToString();

            }
            catch (System.Exception)
            {

            }
            return serializedData;
        }

        protected string ExtractSettingName(string serializedText)
        {
            string name = string.Empty;

            try
            {
                name = serializedText.Substring(0, serializedText.IndexOf(_delimiter));
            }
            catch (System.Exception)
            {
                //MessageBox.Show("Error while extracting setting name\n"+e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            return name;
        }

        protected string ExtractSettingValue(string serializedText)
        {
            string stringValue = string.Empty;

            try
            {
                stringValue = serializedText.Substring(serializedText.IndexOf(_delimiter) + _delimiter.Length);
            }
            catch (System.Exception)
            {
                //MessageBox.Show("Error while extracting setting value\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return stringValue;
        }
        #endregion

    }
}
