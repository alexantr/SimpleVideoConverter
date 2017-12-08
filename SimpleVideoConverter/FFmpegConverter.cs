using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Alexantr.SimpleVideoConverter
{
    class FFmpegConverter
    {
        public ProcessPriorityClass ProcessPriority { get; set; }

        public string LogLevel { get; set; }

        public TimeSpan? ExecutionTimeout { get; set; }

        public event EventHandler<FFmpegProgressEventArgs> ConvertProgress;

        public event EventHandler<FFmpegLogEventArgs> LogReceived;

        private FFmpegProcess ffmpegProcess;

        public FFmpegConverter()
        {
            ProcessPriority = ProcessPriorityClass.Normal;
            LogLevel = "info";
        }

        public void Convert(string inputFile, string outputFile, string arguments)
        {
            try
            {
                string outputFileArgs = outputFile != null ? string.Format("\"{0}\"", outputFile) : "NUL";
                string fullArgs = string.Format("-hide_banner -y -loglevel {3} -i \"{0}\" {2} {1}", inputFile, outputFileArgs, arguments, LogLevel);

#if DEBUG
                Console.WriteLine(fullArgs);
#endif

                if (ffmpegProcess != null)
                {
                    throw new InvalidOperationException("FFmpeg process is already started");
                }

                ffmpegProcess = new FFmpegProcess(fullArgs);
                if (ProcessPriority != ProcessPriorityClass.Normal)
                {
                    ffmpegProcess.PriorityClass = ProcessPriority;
                }

                string lastErrorLine = string.Empty;

                ffmpegProcess.ErrorDataReceived += (o, args) =>
                {
                    if (args.Data != null)
                    {
                        lastErrorLine = args.Data;
                        FFmpegConvertProgressHandler(args.Data);
                        FFmpegLogHandler(args.Data);
                    }
                };

                ffmpegProcess.OutputDataReceived += (o, args) => { };

                ffmpegProcess.Start();

                WaitFFmpegProcessForExit();
                if (ffmpegProcess.ExitCode != 0)
                {
                    throw new FFmpegException(ffmpegProcess.ExitCode, lastErrorLine);
                }
                ffmpegProcess.Close();
                ffmpegProcess = null;
            }
            catch (Exception)
            {
                EnsureFFmpegProcessStopped();
                throw;
            }
        }

        public void Abort()
        {
            EnsureFFmpegProcessStopped();
        }

        public bool Stop()
        {
            if (ffmpegProcess == null || ffmpegProcess.HasExited || !ffmpegProcess.StartInfo.RedirectStandardInput)
            {
                return false;
            }
            ffmpegProcess.StandardInput.WriteLine("q\n");
            ffmpegProcess.StandardInput.Close();
            WaitFFmpegProcessForExit();
            return true;
        }

        private void WaitFFmpegProcessForExit()
        {
            if (ffmpegProcess == null)
            {
                throw new FFmpegException(-1, "FFmpeg process was aborted");
            }
            if (!ffmpegProcess.HasExited && !ffmpegProcess.WaitForExit(ExecutionTimeout.HasValue ? (int)ExecutionTimeout.Value.TotalMilliseconds : int.MaxValue))
            {
                EnsureFFmpegProcessStopped();
                throw new FFmpegException(-2, string.Format("FFmpeg process exceeded execution timeout ({0}) and was aborted", ExecutionTimeout));
            }
        }

        private void EnsureFFmpegProcessStopped()
        {
            if (ffmpegProcess == null || ffmpegProcess.HasExited)
                return;
            try
            {
                ffmpegProcess.Kill();
                ffmpegProcess = null;
            }
            catch (Exception) { }
        }

        /// <summary>
        /// ConvertProgress Handler
        /// </summary>
        /// <param name="line">Line from ffmpeg</param>
        private void FFmpegConvertProgressHandler(string line)
        {
            TimeSpan processed = TimeSpan.Zero;
            if (line.StartsWith("frame="))
            {
                Regex progressRegex = new Regex("time=(?<progress>[0-9:.]+)\\s", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
                Match progressMatch = progressRegex.Match(line);
                if (progressMatch.Success)
                {
                    try
                    {
                        processed = TimeSpan.Parse(progressMatch.Groups["progress"].Value);
                    }
                    catch { }
                }
            }
            ConvertProgress?.Invoke(this, new FFmpegProgressEventArgs(processed));
        }

        /// <summary>
        /// LogReceived Handler
        /// </summary>
        /// <param name="line">Line from ffmpeg</param>
        private void FFmpegLogHandler(string line)
        {
            LogReceived?.Invoke(this, new FFmpegLogEventArgs(line));
        }
    }
}
