using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova
{
    internal class StringChecker
    {
        public static bool isNullOrEmpty(params string[] strs)
        {
            foreach (string str in strs)
            {
                if (string.IsNullOrEmpty(str))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
