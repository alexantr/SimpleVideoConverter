using System;
using System.Diagnostics;
using System.IO;

namespace Alexantr.SimpleVideoConverter
{
    class FFmpegProcess : Process
    {
        public FFmpegProcess(string arguments)
        {
            string exePath = Helper.GetFFmpegFullPath("ffmpeg.exe");
            if (string.IsNullOrEmpty(exePath))
            {
                throw new FileNotFoundException("Cannot find ffmpeg.exe");
            }

            StartInfo.EnvironmentVariables["FC_CONFIG_DIR"] = Environment.CurrentDirectory;
            StartInfo.EnvironmentVariables["FONTCONFIG_FILE"] = "fonts.conf";
            StartInfo.EnvironmentVariables["FONTCONFIG_PATH"] = Environment.CurrentDirectory;

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
