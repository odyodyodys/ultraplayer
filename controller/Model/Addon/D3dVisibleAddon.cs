using System;
using System.Collections.Generic;
using System.Text;
using UltraPlayerController.Model.Enumerations;

namespace UltraPlayerController.Model.Addon
{
    public abstract class D3dVisibleAddon:AVisibleAddon
    {
        public D3dVisibleAddon(uint id, AddonType type, VisibleLayout layout):base(id, type, layout)
        {

        }
    }
}
