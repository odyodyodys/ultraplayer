using System;
using System.Collections.Generic;
using System.Text;

namespace UltraPlayerController.Model.Communication
{
    public class VisibleObject
    {
        #region Fields
        uint _id;
        VisibleLayout _layout;
        #endregion

        #region Constructors
        public VisibleObject()
        {
            _layout = new VisibleLayout();
        }
        #endregion

        #region Properties
        public uint Id
        {
            set
            {
                _id = value;
            }
            get
            {
                return _id;
            }
        }
	    public VisibleLayout Layout
        {
            set
            {
                _layout = value;
            }
            get
            {
                return _layout;
            }
        }
        #endregion
    }
}
