using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace UltraPlayerController.Model.Addon
{
    public interface ISubtitleParser
    {
        SortedList<TimeSpan, Subtitle> ParseSubtitleFile(string subtitleFilename);
    }
}
