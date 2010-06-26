using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;

namespace UltraPlayerController.Model.Addon
{
    public class ImageD3dVisibleAddon : D3dVisibleAddon
    {
        #region Fields

        private string _imageFilename;

        #endregion

        #region Constructors

        public ImageD3dVisibleAddon(uint id, AddonType type, VisibleLayout layout) : base(id, type, layout)
        {

        }
        #endregion

        #region Properties

        public string ImageFilename
        {
            get { return _imageFilename; }
            set { _imageFilename = value; }
        }
        #endregion
    }
}
