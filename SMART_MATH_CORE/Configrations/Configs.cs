using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 

    public class Number_Type // control Values if double or int in whole system
    {
        public double Value { get; set; } = default;
        public bool Set_String_Val(string val)
        {
          if(double.TryParse(val , out double num))
          {
            Value = num;
            return true;
          }
        return false;
        }
    }

