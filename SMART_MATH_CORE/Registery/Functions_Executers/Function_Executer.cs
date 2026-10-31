using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Functions_Executers
{
    public class Function_Executer
    {
        public virtual Primary.Primary_Value.Primary_Value Execute(List<Primary.Primary_Value.Primary_Value> input)
        {
            return new Primary.Primary_Value.Primary_Value();
        }
        public virtual Primary.Primary_Value.Primary_Value Execute(Primary.Primary_Value.Primary_Value input)
        {
            return new Primary.Primary_Value.Primary_Value();
        }

        
    }
}
