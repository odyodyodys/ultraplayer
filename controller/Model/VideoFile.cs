using System;
using System.Collections.Generic;
using System.Text;

namespace UltraPlayerController.Model
{
    public class VideoFile: MediaFile
    {
        #region Fields
        private VisibleLayout _layout;
        #endregion

        #region Constructors
        public VideoFile()
        {
            _layout = new VisibleLayout();
        }
        #endregion

        #region Properties
        public VisibleLayout Layout
        {
            get
            {
                return _layout;
            }
            set
            {
                _layout = value;
            }
        }
        #endregion
    }
}
