using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;

namespace UltraPlayerController.Model.Addon
{
    public abstract class AAddon
    {
        #region Fields
        protected uint _id;
        protected AddonType _type;
        #endregion

        #region Constructors
        public AAddon(uint id, AddonType type)
        {
            _id = id;
            _type = type;
        }
        #endregion

        #region Properties
        public uint Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public AddonType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        #endregion
    }
}
