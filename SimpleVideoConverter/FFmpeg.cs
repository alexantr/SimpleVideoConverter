using System;
using System.Diagnostics;
using System.IO;

namespace SimpleVideoConverter
{
    class FFmpeg
    {
        public string FFmpegPath;

        public Process Process;

        public FFmpeg(string argument)
        {
            Process = new Process();

            FFmpegPath = Path.Combine(Environment.CurrentDirectory, "ffmpeg", "ffmpeg.exe");

            if (!File.Exists(FFmpegPath))
            {
                throw new FileNotFoundException();
            }

            ProcessStartInfo info = new ProcessStartInfo(FFmpegPath);
            info.Arguments = "-hide_banner " + argument;
            info.RedirectStandardInput = true;
            info.RedirectStandardOutput = true;
            info.RedirectStandardError = true;
            info.UseShellExecute = false; // Required to redirect IO streams
            info.CreateNoWindow = true; // Hide console

            Process.StartInfo = info;
            Process.EnableRaisingEvents = true;
        }

        public void Start()
        {
            Process.Start();
            Process.BeginErrorReadLine();
            Process.BeginOutputReadLine();
        }
    }
}
