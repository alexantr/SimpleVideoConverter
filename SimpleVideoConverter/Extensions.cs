using System.ComponentModel;
using System.Windows.Forms;

namespace Alexantr.SimpleVideoConverter
{
    public static class Extensions
    {
        /// <summary>
        /// Automating the InvokeRequired
        /// http://stackoverflow.com/a/12179408/174466
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="action"></param>
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
