using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;

namespace UltraPlayerController.Model.Addon
{
    public abstract class AVisibleAddon: AAddon
    {
        protected VisibleLayout _layout;

        public VisibleLayout Layout
        {
            get { return _layout; }
            set { _layout = value; }
        }

        public AVisibleAddon(uint id, AddonType type, VisibleLayout layout):base(id, type)
        {
            _layout = layout;
        }
    }
}
