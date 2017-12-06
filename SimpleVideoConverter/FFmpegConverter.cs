using System;
using System.Diagnostics;
using System.IO;

namespace Alexantr.SimpleVideoConverter
{
    class FFmpegConverter
    {
        public string DirectoryPath { get; set; }

        public ProcessPriorityClass ProcessPriority { get; set; }

        public string LogLevel { get; set; }

        public TimeSpan? ExecutionTimeout { get; set; }

        public event EventHandler<FFmpegProgressEventArgs> ConvertProgress;

        public event EventHandler<FFmpegLogEventArgs> LogReceived;

        private Process ffmpegProcess;

        public FFmpegConverter()
        {
            if (string.IsNullOrEmpty(DirectoryPath))
            {
                DirectoryPath = Path.Combine(Environment.CurrentDirectory, "ffmpeg");
            }
            ProcessPriority = ProcessPriorityClass.Normal;
            LogLevel = "info";
        }

        public void Convert(string inputFile, string outputFile, string arguments)
        {
            try
            {
                string ffmpegExePath = Path.Combine(DirectoryPath, "ffmpeg.exe");
                if (!File.Exists(ffmpegExePath))
                {
                    throw new FileNotFoundException("Cannot find FFmpeg: " + ffmpegExePath);
                }

                string outputFileArgs = outputFile != null ? string.Format("\"{0}\"", outputFile) : "NUL";
                string fullArgs = string.Format("-hide_banner -y -loglevel {3} -i \"{0}\" {2} {1}", inputFile, outputFileArgs, arguments, LogLevel);

#if DEBUG
                Console.WriteLine(fullArgs);
#endif

                ProcessStartInfo startInfo = new ProcessStartInfo(ffmpegExePath, fullArgs)
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WorkingDirectory = Path.GetDirectoryName(DirectoryPath),
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                if (ffmpegProcess != null)
                {
                    throw new InvalidOperationException("FFmpeg process is already started");
                }

                ffmpegProcess = Process.Start(startInfo);
                if (ProcessPriority != ProcessPriorityClass.Normal)
                {
                    ffmpegProcess.PriorityClass = ProcessPriority;
                }

                string lastErrorLine = string.Empty;

                FFmpegProgress ffmpegProgress = new FFmpegProgress(new Action<FFmpegProgressEventArgs>(OnConvertProgress), ConvertProgress != null);
                //ffmpegProgress.Seek = seek;
                //ffmpegProgress.MaxDuration = maxDuration;

                ffmpegProcess.ErrorDataReceived += (o, args) =>
                {
                    if (args.Data == null)
                        return;
                    lastErrorLine = args.Data;
                    ffmpegProgress.ParseLine(args.Data);
                    FFmpegLogHandler(args.Data);
                };

                ffmpegProcess.OutputDataReceived += (o, args) => { };
                ffmpegProcess.BeginOutputReadLine();
                ffmpegProcess.BeginErrorReadLine();

                WaitFFmpegProcessForExit();
                if (ffmpegProcess.ExitCode != 0)
                {
                    throw new FFmpegException(ffmpegProcess.ExitCode, lastErrorLine);
                }
                ffmpegProcess.Close();
                ffmpegProcess = null;
                ffmpegProgress.Complete();
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

        private void OnConvertProgress(FFmpegProgressEventArgs args)
        {
            ConvertProgress?.Invoke(this, args);
        }

        private void FFmpegLogHandler(string line)
        {
            LogReceived?.Invoke(this, new FFmpegLogEventArgs(line));
        }
    }
}
