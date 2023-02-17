using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_01
{
    public static class Helper
    {
        public static bool IsValidSelection(this string num) { 
            return num=="1" || num=="2";
        }

        public static bool IsValidYesOrNo(this string num)
        {
            return num.ToLower() == "y" || num.ToLower() == "n";
        }
    }
}
