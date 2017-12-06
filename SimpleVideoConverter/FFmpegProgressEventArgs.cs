using System;

namespace Alexantr.SimpleVideoConverter
{
    public class FFmpegProgressEventArgs : EventArgs
    {
        public TimeSpan TotalDuration { get; private set; }

        public TimeSpan Processed { get; private set; }

        public FFmpegProgressEventArgs(TimeSpan processed, TimeSpan totalDuration)
        {
            TotalDuration = totalDuration;
            Processed = processed;
        }
    }
}
