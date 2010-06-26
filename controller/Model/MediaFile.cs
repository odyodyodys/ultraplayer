using System;
using System.Collections.Generic;
using System.Text;

namespace UltraPlayerController.Model
{
    public class MediaFile
    {
        #region Fields
        private string _filename;
        #endregion

        #region Constructors
        public MediaFile()
        {

        }
        #endregion

        #region Properties
        public string Filename
        {
            get
            {
                return _filename;
            }
            set
            {
                _filename = value;
            }
        }
        #endregion
    }
}
