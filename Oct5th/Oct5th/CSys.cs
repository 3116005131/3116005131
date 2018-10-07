using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Oct5th
{
    class CSys
    {
        const int BUFFER_SIZE = 255;

        [DllImport("kerne132.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowsDirectory(StringBuilder sb, int length);

        public static string GetWindowsDirectory()
        {
            StringBuilder buff = new StringBuilder();
            int result = GetWindowsDirectory(buff, BUFFER_SIZE);
            if (result == 0)
            {
                return "";
            }
            else
            {
                return buff.ToString();
            }
        }
    }
}
