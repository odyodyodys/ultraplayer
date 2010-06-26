using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using UltraPlayerController.Model;
using UltraPlayerController.View.Events;
using System.IO;

namespace UltraPlayerController.View.SingleMediaPlayer
{
    public partial class ImageAddonPropertiesControl : UserControl
    {

        #region Fields
        private VisibleLayout _layout;// Note: zOrder field is not used
        private FileInfo _imageFile;

        public event Delegates.VisibleLayoutChangedEventHandler LayoutChangedEvent;
        public event Delegates.FileChangedEventHandler ImageFileChangedEvent;
        #endregion

        #region Constructors
        public ImageAddonPropertiesControl()
        {
            InitializeComponent();

            _layout = new VisibleLayout(20, 20, 60, 60, 0, 128);
        }
        #endregion

        #region Properties
        public new VisibleLayout Layout
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
                AlphaScrollBar.Value = _layout.AlphaValue;
            }
        }
        public string ImageFilename
        {
            set
            {
                if (value != null)
                {
                    _imageFile = new FileInfo(value);
                    ApplyImage();
                }
                else
                {
                    RemoveImage();
                }
            }
            get
            {
                return _imageFile.Name;
            }
        }

        #endregion

        #region Methods
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
                SolidBrush backgroundBrush = new SolidBrush(Color.FromArgb(_layout.AlphaValue, Color.Black));

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
        #endregion

        #region Events
        private void LayoutChanged()
        {
            if (LayoutChangedEvent != null)
            {
                LayoutChangedEvent(_layout);
            }
        }

        private void DrawingAreaPanelPaint(object sender, PaintEventArgs e)
        {
            DrawLayout();
        }
        private void SizeXScrollBarValueChanged(object sender, EventArgs e)
        {
            SizeXValueLabel.Text = SizeXScrollBar.Value.ToString();
            _layout.SizeX = SizeXScrollBar.Value;
            DrawLayout();
            LayoutChanged();
        }

        private void LocationXScrollBarScroll(object sender, ScrollEventArgs e)
        {
            LocationXValueLabel.Text = LocationXScrollBar.Value.ToString();
            _layout.OriginX = LocationXScrollBar.Value;
            DrawLayout();
            LayoutChanged();
        }

        private void AlphaScrollBarScroll(object sender, ScrollEventArgs e)
        {
            AlphaValueLabel.Text = AlphaScrollBar.Value.ToString();
            _layout.AlphaValue = AlphaScrollBar.Value;
            DrawLayout();
            LayoutChanged();
        }

        private void SizeYScrollBarScroll(object sender, ScrollEventArgs e)
        {
            SizeYValueLabel.Text = SizeYScrollBar.Value.ToString();
            _layout.SizeY = SizeYScrollBar.Value;
            DrawLayout();
            LayoutChanged();
        }

        private void LocationYScrollBarScroll(object sender, ScrollEventArgs e)
        {
            LocationYValueLabel.Text = LocationYScrollBar.Value.ToString();
            _layout.OriginY = LocationYScrollBar.Value;
            DrawLayout();
            LayoutChanged();
        }
        private void FileButtonClick(object sender, EventArgs e)
        {
            if (SelectImageOpenFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                // open file
                _imageFile = new FileInfo(SelectImageOpenFileDialog.FileName);

                ApplyImage();

                if (ImageFileChangedEvent != null)
                {
                    ImageFileChangedEvent(_imageFile);
                }
            }
            catch (System.Exception)
            {

            }

        }

        private void ApplyImage()
        {
            // preview image
            ImagePreviewPanel.BackgroundImage = Image.FromFile(_imageFile.FullName);

            // textbox
            FileTextBox.Text = _imageFile.FullName;

            if (ImageFileChangedEvent != null)
            {
                ImageFileChangedEvent(_imageFile);
            }
        }
        private void RemoveImage()
        {
            // preview image
            ImagePreviewPanel.BackgroundImage = null;

            // textbox
            FileTextBox.Text = string.Empty;
        }
        #endregion
    }
}
