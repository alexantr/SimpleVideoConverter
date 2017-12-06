using System;

namespace Alexantr.SimpleVideoConverter
{
    class FFmpegLogEventArgs : EventArgs
    {
        public string Data { get; private set; }

        public FFmpegLogEventArgs(string logData)
        {
            Data = logData;
        }
    }
}
