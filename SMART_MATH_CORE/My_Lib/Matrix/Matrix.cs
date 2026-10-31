using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.My_Lib.Matrix
{
   
    public class Matrix
    {
        public Number_Type Rows = new Number_Type();
        public Number_Type Columns = new Number_Type();
    }
    
    public class Matrix_Values : Matrix
    {
        public List<List<Number_Type>>? Values;
    }
}
