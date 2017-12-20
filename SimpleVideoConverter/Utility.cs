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

        /// <summary>
        /// Checks if value matches a value from a array.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="items"></param>       
        public static bool IsValid(string value, string[,] items)
        {
            bool valid = false;
            for (int i = 0; i < items.GetLength(0); i++)
            {
                if (value == items[i, 0])
                {
                    valid = true;
                    break;
                }
            }
            return valid;
        }

        public static bool IsValid(int x, int[] items)
        {
            bool valid = false;
            for (int i = 0; i < items.GetLength(0); i++)
            {
                if (x == items[i])
                {
                    valid = true;
                    break;
                }
            }
            return valid;
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
