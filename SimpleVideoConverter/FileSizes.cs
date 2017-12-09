using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Alexantr.SimpleVideoConverter
{
    public static class FileSizes
    {
        [DllImport("Shlwapi.dll", CharSet = CharSet.Auto)]
        public static extern int StrFormatByteSize(long fileSize, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder buffer, int bufferSize);

        public static string ToFileSizeApi(this long size)
        {
            StringBuilder buffer = new StringBuilder(20);
            StrFormatByteSize(size, buffer, 20);
            return buffer.ToString();
        }

        public static string ToFileSize(this double value)
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
}
