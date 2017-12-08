using System;

namespace Alexantr.SimpleVideoConverter
{
    public class FFmpegProgressEventArgs : EventArgs
    {
        public TimeSpan Processed { get; private set; }

        public FFmpegProgressEventArgs(TimeSpan processed)
        {
            Processed = processed;
        }
    }
}
