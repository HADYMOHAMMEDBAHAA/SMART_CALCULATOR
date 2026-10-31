using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.My_Lib.Read_Number
{
    public class Read_Number
    {
       
       
        public string? Read (string text , int start , out int end)
        {
            string number = string.Empty;
            end = start;
            while (text != null && start < text.Length &&
                (Char.IsDigit(text[start]) || text[start] == '.'))
            {
                number += text[start++];
            }
            if (double.TryParse(number, out double d))
            {
                end = start ;
                return number;
            }
            else
            {
                return null;
            }
        }
    }
}
