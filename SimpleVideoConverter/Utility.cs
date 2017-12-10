using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Alexantr.SimpleVideoConverter
{
    internal static class NativeMethods
    {
        [DllImport("user32.dll")]
        internal static extern IntPtr SendMessage(IntPtr window, int message, int wparam, int lparam);
    }

    public static class Utility
    {
        public static string FormatFileSize(this double value)
        {
            string[] strArray = new string[9]
            {
                "bytes",
                "KiB",
                "MiB",
                "GiB",
                "TiB",
                "PiB",
                "EiB",
                "ZiB",
                "YiB"
            };
            for (int index = 0; index < strArray.Length; ++index)
            {
                if (value <= Math.Pow(1024.0, (index + 1)))
                    return ThreeNonZeroDigits(value / Math.Pow(1024.0, index)) + " " + strArray[index];
            }
            return ThreeNonZeroDigits(value / Math.Pow(1024.0, (strArray.Length - 1))) + " " + strArray[strArray.Length - 1];
        }

        private static string ThreeNonZeroDigits(double value)
        {
            if (value >= 100.0)
                return value.ToString("0,0");
            if (value >= 10.0)
                return value.ToString("0.0");
            return value.ToString("0.00");
        }
    }

    public static class Extensions
    {
        // http://stackoverflow.com/a/12179408/174466
        public static void InvokeIfRequired(this ISynchronizeInvoke obj, MethodInvoker action)
        {
            if (obj.InvokeRequired)
            {
                var args = new object[0];
                obj.Invoke(action, args);
            }
            else
            {
                action();
            }
        }
    }
}
