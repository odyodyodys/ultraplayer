using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UltraPlayerController.View.Events;
using UltraPlayerController.Model;

namespace UltraPlayerController.View.AudioPlayer
{
    public partial class SpatializationForm : Form
    {
        #region Fields
        public event Delegates.Sound3dEventHandler Sound3dChanged;
        #endregion

        #region Constructors
        public SpatializationForm()
        {
            InitializeComponent();

            // forward event from control
            SpatializationProperties.Sound3dChanged += new Delegates.Sound3dEventHandler(OnSound3dChanged);
        }
        #endregion

        #region Events
        private void OnSound3dChanged(Sound3d sound3d)
        {
            if (Sound3dChanged != null)
            {
                Sound3dChanged(sound3d);
            }
        }
        #endregion
    }
}
