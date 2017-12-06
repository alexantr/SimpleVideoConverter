using System;

namespace Alexantr.SimpleVideoConverter
{
    public class FFmpegException : Exception
    {
        public int ErrorCode { get; private set; }

        public FFmpegException(int errCode, string message) : base(string.Format("{0} (exit code: {1})", message, errCode))
        {
            ErrorCode = errCode;
        }
    }
}
