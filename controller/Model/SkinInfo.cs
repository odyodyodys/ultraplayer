using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace UltraPlayerController.Model
{
    public class SkinInfo
    {
        #region Fields
        private Layout _formLayout;
        private string _imageFilename;
        private Layout _videoArea;
        #endregion

        #region Constructors
        public SkinInfo()
        {
            // creates new empty skin
            _formLayout = new Layout();
            _videoArea = new Layout();
            _imageFilename = string.Empty;
        }
        #endregion

        #region Methods
        public string GetName()
        {
            string name = string.Empty;

            // returns skin name
            FileInfo imageFile = new FileInfo(_imageFilename);

            if (!imageFile.Extension.Equals(string.Empty))
            {
                name = imageFile.Name.Replace(imageFile.Extension, string.Empty);
            }
            else
            {
                name = imageFile.Name;
            }

            return name;
        }
        #endregion

        #region Properties
        public Layout FormLayout
        {
            set
            {
                _formLayout = value;
            }
            get
            {
                return _formLayout;
            }
        }
        public string ImageFilename
        {
            set
            {
                _imageFilename = value;
            }
            get
            {
                return _imageFilename;
            }
        }
        public Layout VideoArea
        {
            set
            {
                _videoArea = value;
            }
            get
            {
                return _videoArea;
            }
        }
        #endregion
    }
}
