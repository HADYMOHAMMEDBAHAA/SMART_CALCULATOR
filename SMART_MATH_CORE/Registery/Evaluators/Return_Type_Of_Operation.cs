using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Evaluators
{
    internal class Return_Type_Of_Operation
    {
        public static Primary.Primary_Value.Primary_Value_Type Get_Return_Type
            (List<Primary.Primary_Value.Primary_Value> Inputs)
        {
            if (Inputs.Count == 0)
            {
                throw new Exception("No inputs provided for evaluation.");
            }
            else if (Inputs.Count == 1)
            {
                return Inputs[0].PrimaryValue_Type;
            }
            else if (Inputs.Count == 2)
            {
                if (Inputs[0] is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value
                     && Inputs[1] is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)
                {
                    return Primary.Primary_Value.Primary_Value_Type.Number;
                }
                else if ((Inputs[0] is Registery.Primary_Values.List_Primary_Value.List_Primary_Value
                         || Inputs[1] is Registery.Primary_Values.List_Primary_Value.List_Primary_Value)
                         && (Inputs[1] is not Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)
                         && (Inputs[0] is not Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)
                         )
                {
                    return Primary.Primary_Value.Primary_Value_Type.List;
                }
                else if ((Inputs[0] is Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value
                             || Inputs[1] is Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value))
                {
                    return Primary.Primary_Value.Primary_Value_Type.Matrix;
                }
            }
            else
            {
                throw new Exception("Invalid number of inputs for evaluation.");
            }
            throw new Exception("Unable to determine return type for the given inputs and operator.");
        }
    }
}
