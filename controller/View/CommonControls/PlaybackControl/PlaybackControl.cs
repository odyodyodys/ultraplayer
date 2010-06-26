using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using UltraPlayerController.Model.Enumerations;
using UltraPlayerController.View.Events;

namespace UltraPlayerController.View
{
    public partial class PlaybackControl : UserControl
    {
        #region Fields
        private bool _isSeekEnabled;
        private PlaybackState _playbackState;
        private DateTime _timePlaybackStarted;
        private float _rate;
        public event Delegates.ActionEventHandler PlayEvent;
        public event Delegates.ActionEventHandler PauseEvent;
        public event Delegates.ActionEventHandler ResumeEvent;
        public event Delegates.ActionEventHandler StopEvent;
        public event Delegates.ActionEventHandler PreviousTrackEvent;
        public event Delegates.ActionEventHandler NextTrackEvent;
        public event Delegates.IntegerValueActionEventHandler VolumeEvent;
        public event Delegates.IntegerValueActionEventHandler SeekEvent;
        public event Delegates.ActionEventHandler PlaybackEndedEvent;

        #endregion

        #region Constructors
        public PlaybackControl()
        {
            InitializeComponent();

            _isSeekEnabled = true;
            _playbackState = PlaybackState.Stopped;
            _timePlaybackStarted = new DateTime();
            _rate = 1;
        }
        #endregion

        #region Methods
        public void DisableNextPrevious()
        {
            PreviousTrackButton.Enabled = false;
            NextTrackButton.Enabled = false;
        }

        public void DisablePause()
        {
            PauseButton.Enabled = false;
        }
        public void DisableSeeking()
        {
            _isSeekEnabled = false;
        }

        public void PlaybackStarted(int durationMilliseconds)
        {
            if (_isSeekEnabled)
            {
	            DurationProgressBar.Value = 0;
	            DurationProgressBar.MaxValue = ((int)(durationMilliseconds / (float)1000));
	            PlaybackTimer.Enabled = true;
	
	            _timePlaybackStarted = DateTime.Now;
	            
	            // compute full time in minutes/seconds
	            int minutes = (int)(durationMilliseconds / 1000) / 60;
                int seconds = (int)(durationMilliseconds / 1000) % 60;
	            FullTimeLabel.Text = minutes.ToString() + ":" + seconds.ToString();
            }

            _playbackState = PlaybackState.Playing;
        }

        public void PlaybackPaused()
        {
            PlaybackTimer.Enabled = false;
            _playbackState = PlaybackState.Paused;
        }

        public void PlaybackStopped()
        {
            PlaybackTimer.Enabled = false;
            DurationProgressBar.Value = 0;
            _playbackState = PlaybackState.Stopped;
        }

        public void PlaybackResumed()
        {
            if (_isSeekEnabled)
            {
            	PlaybackTimer.Enabled = true;
            }

            _playbackState = PlaybackState.Playing;
        }

        public void PlaybackSeeked(int milliseconds)
        {
            if (_isSeekEnabled)
            {
	            DateTime now = DateTime.Now;
	            TimeSpan dif = new TimeSpan(0, 0, 0, 0, milliseconds);
	            _timePlaybackStarted = now - dif;
            }
        }

        #endregion

        #region Properties
        public PlaybackState PlaybackState
        {
            get
            {
                return _playbackState;
            }
        }

        public int Volume
        {
            set
            {
                VolumeScrollBar.Value = value;
            }
            get
            {
                return VolumeScrollBar.Value;
            }
        }

        public float Rate
        {
            get { return _rate; }
            set {_rate = value; }
        }
        #endregion

        #region Events
        private void PlayPauseButtonClick(object sender, EventArgs e)
        {
            if (_playbackState == PlaybackState.Paused)
            {
                if (ResumeEvent != null)
                {
                    ResumeEvent();
                }
            }
            else
            {
                if (PlayEvent != null)
                {
                    PlayEvent();
                }
            }
        }
        private void PreviousTrackButtonClick(object sender, EventArgs e)
        {
            if (PreviousTrackEvent != null)
            {
                PreviousTrackEvent();
            }
        }

        private void StopButtonClick(object sender, EventArgs e)
        {
            if (_playbackState == PlaybackState.Playing || _playbackState == PlaybackState.Paused)
            {
                if (StopEvent != null)
                {
                    StopEvent();
                }
            }
        }

        private void NextTrackButtonClick(object sender, EventArgs e)
        {
            if (NextTrackEvent != null)
            {
                NextTrackEvent();
            }
        }

        private void VolumeScrollBarValueChanged(object sender, EventArgs e)
        {
            VolumeValueLabel.Text = VolumeScrollBar.Value.ToString();

            if (VolumeEvent != null)
            {
                VolumeEvent(VolumeScrollBar.Value);
            }
        }

        private void VolumeMuteButtonClick(object sender, EventArgs e)
        {
            VolumeScrollBar.Value = 1;
            VolumeScrollBarValueChanged(sender, e);
        }

        private void PauseButtonClick(object sender, EventArgs e)
        {
            if (_playbackState == PlaybackState.Paused)
            {
                if (ResumeEvent != null)
                {
                    ResumeEvent();
                }
            }
            else if (_playbackState == PlaybackState.Playing)
            {
                if (PauseEvent != null)
                {
                    PauseEvent();
                }
            }
        }

        private void PlaybackTimerTick(object sender, EventArgs e)
        {
            if (DurationProgressBar.Value != DurationProgressBar.MaxValue)
            {
                TimeSpan timeElapsed = DateTime.Now - _timePlaybackStarted;

                // compute where it should have been
                DurationProgressBar.Value = (int)(timeElapsed.TotalMilliseconds /1000.0f);

                PlayingTimeLabel.Text = string.Format("{0:00}:{1:00}", timeElapsed.Minutes, timeElapsed.Seconds);
            }
            else
            {
                // playback ended
                if (PlaybackEndedEvent != null)
                {
                    PlaybackEndedEvent();
                }
            }
        }

        private void DurationProgressBarMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DurationProgressBarMouseUp(sender, e);
            }

        }

        private void DurationProgressBarMouseUp(object sender, MouseEventArgs e)
        {
            // determine the position on the control and get milliseconds to seek to.
            // Note: e.X is the X coordinate on top of the progressBar control

            int value = (int)(Math.Round(1.0 * e.X / DurationProgressBar.Width, 3) * DurationProgressBar.MaxValue * 1000);

            if (SeekEvent != null && _isSeekEnabled)
            {
                SeekEvent(value);
            }

        }
        #endregion

    }
}
