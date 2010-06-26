using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace UltraPlayerController.Model.Addon
{
    public class SubRipSubtitleParser : ISubtitleParser
    {
        #region Fields
        private Regex unit = new Regex(
            @"(?<sequence>\d+)\r\n(?<start>\d{2}\:\d{2}\:\d{2},\d{3}) --\> (?<end>\d{2}\:\d{2}\:\d{2},\d{3})\r\n(?<text>[\s\S]*?)\r\n\r\n",
            RegexOptions.Compiled | RegexOptions.ECMAScript);
        #endregion


        #region ISubtitleParser Members

        public SortedList<TimeSpan, Subtitle> ParseSubtitleFile(string subtitleFilename)
        {
            SortedList<TimeSpan, Subtitle> subs = new SortedList<TimeSpan, Subtitle>();
            try
            {
                // open file
                StreamReader file = new StreamReader(subtitleFilename, Encoding.Default);

                // split using regex to subtitle parts
                string[] parts = unit.Split(file.ReadToEnd());

                for (int i = 0; i < parts.Length; i += 5)
                {
                    Subtitle tmpSub = new Subtitle();
                    tmpSub.StartTime = TimeSpan.Parse(parts[i + 2].Replace(',', '.'));
                    tmpSub.EndTime = TimeSpan.Parse(parts[i + 3].Replace(',', '.'));
                    tmpSub.Text = parts[i + 4];
                    subs.Add(tmpSub.StartTime, tmpSub);
                }
            }
            catch (System.Exception)
            {

            }
            return subs;
        }

        #endregion
    }
}
