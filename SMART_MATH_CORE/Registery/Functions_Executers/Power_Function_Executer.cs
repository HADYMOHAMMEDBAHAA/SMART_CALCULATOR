using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Functions_Executers
{
    public class Power_Function_Executer_Number : Function_Executer
    {
        public override Primary.Primary_Value.Primary_Value Execute(List<Primary.Primary_Value.Primary_Value> input)
        {
            if (input.Count != 2)
            {
                throw new Exception("Power function requires exactly two arguments.");
            }
            Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value baseValue = 
                ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)input[0]);
            Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value exponentValue = 
                ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)input[1]);
            Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value result = 
                new Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value();

            result.Value.Value =Math.Pow(baseValue.Value.Value, exponentValue.Value.Value);
            return result;
        }
    }

    public class Power_Function_Executer_List : Function_Executer
    {
        public override Primary.Primary_Value.Primary_Value Execute(List<Primary.Primary_Value.Primary_Value> input)
        {
            if (input.Count != 2)
            {
                throw new Exception("Power function requires exactly two arguments.");
            }
            Registery.Primary_Values.List_Primary_Value.List_Primary_Value baseList = 
                ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)input[0]);
            Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value exponentValue = 
                ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)input[1]);
            foreach (Number_Type ele in baseList.Value)
            {
                ele.Value = Math.Pow(ele.Value, exponentValue.Value.Value);
            }
            return baseList;
        }
    }

    public class Power_Function_Executer_Matrix : Function_Executer
    {
        public override Primary.Primary_Value.Primary_Value Execute(List<Primary.Primary_Value.Primary_Value> input)
        {
            if (input.Count != 2)
            {
                throw new Exception("Power function requires exactly two arguments.");
            }
            Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value baseMatrix = 
                ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)input[0]);
            Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value exponentValue = 
                ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)input[1]);
            foreach (List<Number_Type> row in baseMatrix.Value)
            {
                foreach (Number_Type ele in row)
                {
                    ele.Value = Math.Pow(ele.Value, exponentValue.Value.Value);
                }
            }
            return baseMatrix;
        }
    }

    
}
