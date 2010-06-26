using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UltraPlayerController.View.Events;
using UltraPlayerController.Model;

namespace UltraPlayerController.View.CommonControls.PlaybackWindow
{
    public partial class PlaybackWindowPropertiesForm : Form
    {
        #region Fields
        private PlaybackWindowPropertiesControl _playbackWindowControl;

        public event Delegates.LayoutChangedEventHandler PlaybackWindowLayoutChangedEvent;
        public event Delegates.ActionEventHandler UpdateDisplayDeviceListEvent;
        public event Delegates.SetSkinInfo SkinInfoChangedEvent;
        #endregion

        #region Constructors
        public PlaybackWindowPropertiesForm()
        {
            InitializeComponent();

            _playbackWindowControl = new PlaybackWindowPropertiesControl();
            _playbackWindowControl.Dock = DockStyle.Fill;
            PlaybackWindowPanel.Controls.Add(_playbackWindowControl);

            _playbackWindowControl.LayoutChangedEvent += new Delegates.LayoutChangedEventHandler(OnPlaybackWindowLayoutChanged);
            _playbackWindowControl.UpdateDisplayDevicesEvent += new Delegates.ActionEventHandler(OnUpdateDisplayDevicesEvent);
            _playbackWindowControl.SkinInfoChanged += new Delegates.SetSkinInfo(OnSkinInfoChanged);
        }
        #endregion

        #region Methods
        public void SetCurrentSkin(SkinInfo skin)
        {
            _playbackWindowControl.SetCurrentSkin(skin);
        }
        #endregion

        #region Events
        private void OnPlaybackWindowLayoutChanged(Layout newLayout)
        {
            if (PlaybackWindowLayoutChangedEvent != null)
            {
                PlaybackWindowLayoutChangedEvent(newLayout);
            }
        }

        private void OnUpdateDisplayDevicesEvent()
        {
            if (UpdateDisplayDeviceListEvent != null)
            {
                UpdateDisplayDeviceListEvent();
            }
        }
        private void OnSkinInfoChanged(SkinInfo skin, Point position)
        {
            if (SkinInfoChangedEvent != null)
            {
                SkinInfoChangedEvent(skin, position);
            }
        }
        #endregion

        #region Properties
        public List<DisplayDevice> DisplayDevices
        {
            set
            {
                _playbackWindowControl.DisplayDevices = value;
            }
            get
            {
                return _playbackWindowControl.DisplayDevices;
            }
        }
        public uint MonitorId
        {
            get
            {
                return _playbackWindowControl.MonitorId;
            }
        }
        public List<SkinInfo> Skins
        {
            set
            {
                _playbackWindowControl.Skins = value;
            }
            get
            {
                return _playbackWindowControl.Skins;
            }
        }

        public new Layout Layout
        {
            get
            {
                return _playbackWindowControl.Layout;
            }
            set
            {
                _playbackWindowControl.Layout = value;
            }
        }
        #endregion
    }
}
