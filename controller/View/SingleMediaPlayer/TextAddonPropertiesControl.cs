using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using UltraPlayerController.Model.Addon;
using UltraPlayerController.Model;
using UltraPlayerController.View.Events;
using System.Threading;

namespace UltraPlayerController.View.SingleMediaPlayer
{
    public partial class TextAddonPropertiesControl : UserControl
    {
        #region Fields
        private VisibleLayout _layout;// Note: zOrder field is not used
        private string _text;

        private SortedList<TimeSpan, Subtitle> _subtitles;

        public event Delegates.VisibleLayoutChangedEventHandler LayoutChangedEvent;
        public event Delegates.TextChangedEventHandler TextChangedEvent;

        #endregion

        #region Constructors

        public TextAddonPropertiesControl()
        {
            InitializeComponent();

            //initialize list
            _subtitles = new SortedList<TimeSpan, Subtitle>();

            _layout = new VisibleLayout(0, 700, 1000, 300, 0, 128);
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
        void LayoutChanged()
        {
            if (LayoutChangedEvent != null)
            {
                LayoutChangedEvent(_layout);
            }
        }
        void TextFieldChanged()
        {
            if (TextChangedEvent != null)
            {
                TextChangedEvent(_text);
            }
        }

        public void StartSubtitles()
        {
            try
            {
	            if (_subtitles.Count.Equals(0))
	            {
	                return;
	            }
	
	            SubtitleBackgroundWorker.RunWorkerAsync();
            }
            catch (System.Exception)
            {
            	// didnt wait much time. 
            }
        }
        public void StopSubtitles()
        {
            SubtitleBackgroundWorker.CancelAsync();
        }
        #endregion

        #region Events
        private void FileButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (SelectSubtitleOpenFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                SubRipSubtitleParser parser = new SubRipSubtitleParser();
                _subtitles = parser.ParseSubtitleFile(SelectSubtitleOpenFileDialog.FileName);

                FileTextBox.Text = SelectSubtitleOpenFileDialog.FileName;
                SubtitlesCountTextBox.Text = _subtitles.Count.ToString();
                DurationTextBox.Text = _subtitles.Values[_subtitles.Count - 1].EndTime.ToString();

            }
            catch (System.Exception)
            {

            }
        }
        private void DrawingAreaPanelPaint(object sender, PaintEventArgs e)
        {
            DrawLayout();
        }
        private void SizeYScrollBarValueChanged(object sender, EventArgs e)
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
        private void AlphaScrollBarScroll(object sender, ScrollEventArgs e)
        {
            AlphaValueLabel.Text = AlphaScrollBar.Value.ToString();
            _layout.AlphaValue = AlphaScrollBar.Value;
            DrawLayout();
            LayoutChanged();
        }
        private void SubtitleBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            TimeSpan delta = new TimeSpan();

            foreach (Subtitle subtitle in _subtitles.Values)
            {
                // wait for next text to appear
                Thread.Sleep(subtitle.StartTime - delta);

                // update delta
                delta = subtitle.StartTime;

                // set text
                _text = subtitle.Text;
                
                // fake report just to force main thread to send new text
                SubtitleBackgroundWorker.ReportProgress(0);

                // wait for text exit
                Thread.Sleep(subtitle.EndTime - delta);

                // update delta
                delta = subtitle.EndTime;

                // remove text
                _text = string.Empty;

                // fake report just to force main thread to send new text
                SubtitleBackgroundWorker.ReportProgress(0);

                // if cancel, leave
                if (SubtitleBackgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void SubtitleBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _text = string.Empty;

            TextFieldChanged();
        }

        private void SubtitleBackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (TextChangedEvent != null)
            {
                TextChangedEvent(_text);
            }
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
                SizeYScrollBar.Value = _layout.SizeY;
                LocationYScrollBar.Value = _layout.OriginY;
                AlphaScrollBar.Value = _layout.AlphaValue;
            }
        }
        #endregion
    }
}
