using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using UltraPlayerController.Model;
using UltraPlayerController.View.Events;
using System.Windows;
using System.IO;

namespace UltraPlayerController.View.CommonControls
{
    public partial class PlaybackWindowPropertiesControl : UserControl
    {
        #region Fields
        private uint _monitorId;
        private Layout _layout;
        private List<DisplayDevice> _devices;
        private List<SkinInfo> _skins;

        public event Delegates.LayoutChangedEventHandler LayoutChangedEvent;
        public event Delegates.ActionEventHandler UpdateDisplayDevicesEvent;
        public event Delegates.SetSkinInfo SkinInfoChanged;
        #endregion

        #region Constructors
        public PlaybackWindowPropertiesControl()
        {
            InitializeComponent();

            _layout = new Layout(200, 200, 600, 600);
        }
        #endregion

        #region Properties
        public new Layout Layout
        {
            get
            {
                return _layout;
            }
            set
            {
                _layout = value;
                SizeXScrollBar.Value = _layout.SizeX;
                SizeYScrollBar.Value = _layout.SizeY;
                LocationXScrollBar.Value = _layout.OriginX;
                LocationYScrollBar.Value = _layout.OriginY;
            }
        }
        public uint MonitorId
        {
            get
            {
                return _monitorId;
            }
        }

        public List<DisplayDevice> DisplayDevices
        {
            set
            {
                _devices = value;
                ApplyDevicesToUi();
            }
            get
            {
                return _devices;
            }
        }

        public List<SkinInfo> Skins
        {
            set
            {
                _skins = value;

                SkinsListBox.Items.Clear();
                foreach (SkinInfo skin in _skins)
                {
                    // special treatment for None skin.
                    if (skin.GetName().Equals("None"))
                    {
                        SkinsListBox.Items.Add(skin.GetName());
                        continue;
                    }

                    // extract only skin name
                    FileInfo imageInfo = new FileInfo(skin.ImageFilename);
                    SkinsListBox.Items.Add(imageInfo.Name.Replace(imageInfo.Extension, ""));
                }
            }
            get
            {
                return _skins;
            }
        }

        #endregion

        #region Events

        private void DrawingAreaPanelPaint(object sender, PaintEventArgs e)
        {
            DrawLayout();
        }

        private void SizeXScrollBarValueChanged(object sender, EventArgs e)
        {
            SizeXValueLabel.Text = SizeXScrollBar.Value.ToString();
            _layout.SizeX = SizeXScrollBar.Value;
            LayoutChanged();
        }

        private void LocationXScrollBarValueChanged(object sender, EventArgs e)
        {
            LocationXValueLabel.Text = LocationXScrollBar.Value.ToString();
            _layout.OriginX = LocationXScrollBar.Value;
            LayoutChanged();
        }

        private void SizeYScrollBarValueChanged(object sender, EventArgs e)
        {
            SizeYValueLabel.Text = SizeYScrollBar.Value.ToString();
            _layout.SizeY = SizeYScrollBar.Value;
            LayoutChanged();
        }

        private void LocationYScrollBarValueChanged(object sender, EventArgs e)
        {
            LocationYValueLabel.Text = LocationYScrollBar.Value.ToString();
            _layout.OriginY = LocationYScrollBar.Value;
            LayoutChanged();
        }

        private void FullScreenButtonClick(object sender, EventArgs e)
        {
            this.Layout = new VisibleLayout(0, 0, 1000, 1000, 0, 255);
        }

        private void monitorUpdateButtonClick(object sender, EventArgs e)
        {
            if (UpdateDisplayDevicesEvent != null)
            {
                UpdateDisplayDevicesEvent();
            }
        }
        private void MonitorComboboxSelectedIndexChanged(object sender, EventArgs e)
        {
            if (monitorCombobox.SelectedIndex.Equals(-1))
            {
                return;
            }

            _monitorId = (uint)(monitorCombobox.SelectedIndex + 1);

            LayoutChanged();
        }



        #endregion

        #region Methods


        private void LayoutChanged()
        {
            DrawLayout();
            ApplySkinSizeToWindow();
            if (LayoutChangedEvent != null)
            {
                LayoutChangedEvent(_layout);
            }
        }
        private SkinInfo GetCurrentSkin()
        {
            SkinInfo current = null;
            try
            {
	
	            if (SkinsListBox.SelectedIndex != -1)
	            {
                    foreach (SkinInfo skin in _skins)
                    {
                        if (skin.ImageFilename.Contains(SkinsListBox.SelectedItem.ToString()))
                        {
                            current = skin;
                            break;
                        }
                    }
	            }
            }
            catch (System.Exception)
            {
            	
            }

            return current;
        }
        public void SetCurrentSkin(SkinInfo skin)
        {
            foreach (var item in _skins)
            {
                if (item.GetName().Equals(skin.GetName()))
                {
                    // skin found, apply it
                    SkinsListBox.SelectedIndex = SkinsListBox.FindString(item.GetName());
                }
            }
        }
        private void ApplySkinSizeToWindow()
        {
            // in order to apply skin, player must be in the local machine

            try
            {
	            SkinInfo skin = GetCurrentSkin();
	            Point skinPos = new Point();
	
	            if (!skin.GetName().Equals("None"))
	            {
		            // move skin window to player window
		            Layout player = _layout;
                    Screen currentScreen = Screen.AllScreens[_monitorId - 1];

                    skinPos.X = (int)((currentScreen.Bounds.Width * player.OriginX) / 1000.0f) - skin.VideoArea.OriginX + currentScreen.Bounds.Left;
                    skinPos.Y = (int)((currentScreen.Bounds.Height * player.OriginY) / 1000.0f) - skin.VideoArea.OriginY + currentScreen.Bounds.Top;
		
		            // set player size to fit
                    _layout.SizeX = (int)((skin.VideoArea.SizeX * 1000.0f) / currentScreen.Bounds.Width);
                    _layout.SizeY = (int)((skin.VideoArea.SizeY * 1000.0f) / currentScreen.Bounds.Height);
	            }
	            
	            if (SkinInfoChanged != null)
	            {
	                SkinInfoChanged(skin, skinPos);
	            }
            }
            catch (System.Exception)
            {
            	
            }
        }

        private void DrawLayout()
        {
            try
            {
                Graphics graph = DrawingAreaPanel.CreateGraphics();

                // Clear
                graph.Clear(DrawingAreaPanel.BackColor);

                // create the foreground pen for the rect
                Pen foreGroundPen = new Pen(Color.Red);
                foreGroundPen.Width = 2;

                // Draw
                SolidBrush backgroundBrush = new SolidBrush(Color.FromArgb(255, Color.Black));

                Rectangle rect = _layout.GetRectangle();
                rect.X = (rect.X * DrawingAreaPanel.Width) / 1000;
                rect.Y = (rect.Y * DrawingAreaPanel.Height) / 1000;
                Size size = new Size((rect.Size.Width * DrawingAreaPanel.Width) / 1000, (rect.Size.Height * DrawingAreaPanel.Height) / 1000);
                rect.Size = size;

                graph.FillRectangle(backgroundBrush, rect);
                graph.DrawRectangle(foreGroundPen, rect);
            }
            catch (System.Exception)
            {

            }
        }

        private void ApplyDevicesToUi()
        {
            monitorCombobox.Items.Clear();

            foreach (DisplayDevice device in _devices)
            {
                monitorCombobox.Items.Add(device.UiFriendlyString());
            }

            // select the first in the combobox
            if (monitorCombobox.Items.Count > 0)
            {
                monitorCombobox.SelectedIndex = 0;
            }
            
        }
        #endregion

        private void SkinsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LayoutChanged();
        }

    }
}
