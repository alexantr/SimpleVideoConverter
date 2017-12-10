using System;
using System.Diagnostics;
using System.IO;

namespace Alexantr.SimpleVideoConverter
{
    class FFmpegProcess : Process
    {
        public FFmpegProcess(string arguments)
        {
            string directoryPath = Path.Combine(Environment.CurrentDirectory, "ffmpeg");
            string exePath = Path.Combine(directoryPath, "ffmpeg.exe");
            if (!File.Exists(exePath))
            {
                throw new FileNotFoundException("Cannot find ffmpeg.exe");
            }

            StartInfo.FileName = exePath;
            StartInfo.Arguments = "-hide_banner -y " + arguments;
            StartInfo.CreateNoWindow = true;
            StartInfo.UseShellExecute = false;
            StartInfo.RedirectStandardInput = true;
            StartInfo.RedirectStandardOutput = true;
            StartInfo.RedirectStandardError = true;

            EnableRaisingEvents = true;
        }

        public new void Start()
        {
            base.Start();
            BeginErrorReadLine();
            BeginOutputReadLine();
        }
    }
}
