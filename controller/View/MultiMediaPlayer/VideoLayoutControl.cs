using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using UltraPlayerController.Model;
using UltraPlayerController.View.Events;

namespace UltraPlayerController.View.MultiMediaPlayer
{
    public partial class VideoLayoutControl : UserControl
    {
        #region Fields
        private VisibleLayout _layout;

        public event Delegates.VisibleLayoutChangedEventHandler LayoutChangedEvent;

        #endregion

        #region Constructors
        public VideoLayoutControl()
        {
            InitializeComponent();

            _layout = new VisibleLayout(200,200,600,600,0,128);
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
                rect.X = (rect.X*DrawingAreaPanel.Width)/1000;
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

        private void LayoutChanged()
        {
            if (LayoutChangedEvent != null)
            {
                LayoutChangedEvent(_layout);
            }
        }
        #endregion

        #region Events
        private void SizeXScrollBarValueChanged(object sender, EventArgs e)
        {
            SizeXValueLabel.Text = SizeXScrollBar.Value.ToString();
            _layout.SizeX = SizeXScrollBar.Value;
            DrawLayout();
            LayoutChanged();
        }

        private void LocationXScrollBarValueChanged(object sender, EventArgs e)
        {
            LocationXValueLabel.Text = LocationXScrollBar.Value.ToString();
            _layout.OriginX = LocationXScrollBar.Value;
            DrawLayout();
            LayoutChanged();
        }

        private void AlphaScrollBarValueChanged(object sender, EventArgs e)
        {
            AlphaValueLabel.Text = AlphaScrollBar.Value.ToString();
            _layout.AlphaValue = AlphaScrollBar.Value;
            DrawLayout();
            LayoutChanged();
        }

        private void SizeYScrollBarValueChanged(object sender, EventArgs e)
        {
            SizeYValueLabel.Text = SizeYScrollBar.Value.ToString();
            _layout.SizeY = SizeYScrollBar.Value;
            DrawLayout();
            LayoutChanged();
        }

        private void LocationYScrollBarValueChanged(object sender, EventArgs e)
        {
            LocationYValueLabel.Text = LocationYScrollBar.Value.ToString();
            _layout.OriginY = LocationYScrollBar.Value;
            DrawLayout();
            LayoutChanged();
        }

        private void DrawingAreaPanelPaint(object sender, PaintEventArgs e)
        {
            DrawLayout();
        }
        #endregion

    }
}
