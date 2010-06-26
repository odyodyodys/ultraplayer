using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;

namespace UltraPlayerController.Model.Addon
{
    public class TextD3dVisibleAddon : D3dVisibleAddon
    {
        #region Fields
        private string _text;
        #endregion

        #region Constructors
        public TextD3dVisibleAddon(uint id, AddonType type, VisibleLayout layout) : base(id, type, layout)
        {

        }
        #endregion

        #region Properties
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        #endregion
    }
}
