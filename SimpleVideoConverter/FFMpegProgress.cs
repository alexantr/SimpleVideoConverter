using System;
using System.Text.RegularExpressions;

namespace Alexantr.SimpleVideoConverter
{
    class FFmpegProgress
    {
        private static Regex DurationRegex = new Regex("Duration:\\s(?<duration>[0-9:.]+)([,]|$)", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
        private static Regex ProgressRegex = new Regex("time=(?<progress>[0-9:.]+)\\s", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);

        public float? Seek = new float?();
        public float? MaxDuration = new float?();

        private bool enabled = true;

        private Action<FFmpegProgressEventArgs> progressCallback;
        private FFmpegProgressEventArgs lastProgressArgs;

        private int progressEventCount;

        public FFmpegProgress(Action<FFmpegProgressEventArgs> progCallback, bool progEnabled)
        {
            progressCallback = progCallback;
            enabled = progEnabled;
        }

        public void ParseLine(string line)
        {
            if (enabled)
            {
                TimeSpan totalDuration1 = lastProgressArgs != null ? lastProgressArgs.TotalDuration : TimeSpan.Zero;
                Match durationMatch = DurationRegex.Match(line);

                if (durationMatch.Success)
                {
                    TimeSpan durationResult = TimeSpan.Zero;
                    if (TimeSpan.TryParse(durationMatch.Groups["duration"].Value, out durationResult))
                    {
                        TimeSpan totalDuration2 = totalDuration1.Add(durationResult);
                        lastProgressArgs = new FFmpegProgressEventArgs(TimeSpan.Zero, totalDuration2);
                    }
                }
                Match progressMatch = ProgressRegex.Match(line);
                if (progressMatch.Success)
                {
                    TimeSpan progressResult = TimeSpan.Zero;
                    if (TimeSpan.TryParse(progressMatch.Groups["progress"].Value, out progressResult))
                    {
                        if (progressEventCount == 0)
                        {
                            totalDuration1 = CorrectDuration(totalDuration1);
                        }
                        lastProgressArgs = new FFmpegProgressEventArgs(progressResult, totalDuration1 != TimeSpan.Zero ? totalDuration1 : progressResult);
                        progressCallback(lastProgressArgs);
                        progressEventCount++;
                    }
                }
            }
        }

        public void Complete()
        {
            if (enabled && lastProgressArgs != null && lastProgressArgs.Processed < lastProgressArgs.TotalDuration)
            {
                progressCallback(new FFmpegProgressEventArgs(lastProgressArgs.TotalDuration, lastProgressArgs.TotalDuration));
            }
        }

        public void Reset()
        {
            progressEventCount = 0;
            lastProgressArgs = null;
        }

        private TimeSpan CorrectDuration(TimeSpan totalDuration)
        {
            if (totalDuration != TimeSpan.Zero)
            {
                if (Seek.HasValue)
                {
                    TimeSpan ts = TimeSpan.FromSeconds(Seek.Value);
                    totalDuration = totalDuration > ts ? totalDuration.Subtract(ts) : TimeSpan.Zero;
                }
                if (MaxDuration.HasValue)
                {
                    TimeSpan timeSpan = TimeSpan.FromSeconds(MaxDuration.Value);
                    if (totalDuration > timeSpan)
                    {
                        totalDuration = timeSpan;
                    }
                }
            }
            return totalDuration;
        }
    }
}
