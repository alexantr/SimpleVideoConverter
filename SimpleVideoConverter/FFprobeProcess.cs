﻿using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Alexantr.SimpleVideoConverter
{
    class FFprobeProcess : Process
    {
        public FFprobeProcess(string arguments)
        {
            string directoryPath = Path.Combine(Environment.CurrentDirectory, "ffmpeg");
            string exePath = Path.Combine(directoryPath, "ffprobe.exe");
            if (!File.Exists(exePath))
            {
                throw new FileNotFoundException("Cannot find ffprobe.exe");
            }

            StartInfo.FileName = exePath;
            StartInfo.Arguments = arguments;
            StartInfo.WorkingDirectory = Path.GetDirectoryName(directoryPath);
            StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
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

        public string Probe()
        {
            StringBuilder output = new StringBuilder();
            OutputDataReceived += (sender, args) => output.AppendLine(args.Data);

            Start();
            WaitForExit();

            return output.ToString();
        }
    }
}
