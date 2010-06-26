using System;
using System.Collections.Generic;
using System.Text;

namespace UltraPlayerController.Model.Addon
{
    public class Subtitle
    {
        #region Fields
        private TimeSpan _startTime;
        private TimeSpan _endTime;
        private string _text;
        #endregion
        #region Constructors
        public Subtitle()
        {
            _startTime = new TimeSpan();
            _endTime = new TimeSpan();

        }
        #endregion

        #region Properties
        public TimeSpan StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }
        public TimeSpan EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        #endregion
    }
}
