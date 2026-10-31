using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Functions_Executers
{
 

    public class Sin_Function_Execute_Number : Function_Executer 
    {
        public override Primary.Primary_Value.Primary_Value
            Execute(Primary.Primary_Value.Primary_Value input)
        {
            ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)input).Value.Value = 
                Math.Sin((
                ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)input).Value.Value
                * Math.PI / 180));
            return ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)input);
        }

        public override Primary.Primary_Value.Primary_Value Execute(List<Primary.Primary_Value.Primary_Value> input)
        {
            if (input.Count == 1)
            {
                return this.Execute(input[0]);
            }
            return new Primary.Primary_Value.Primary_Value();
        }
    }

    public class Sin_Function_Execute_List : Function_Executer

    {
        public override Primary.Primary_Value.Primary_Value
             Execute(Primary.Primary_Value.Primary_Value input)
        {
           foreach ( Number_Type ele in ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)input).Value)
            {
                ele.Value = Math.Sin((ele.Value * Math.PI / 180));
            }
            return ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)input);
        }

        public override Primary.Primary_Value.Primary_Value Execute(List<Primary.Primary_Value.Primary_Value> input)
        {
            Registery.Primary_Values.List_Primary_Value.List_Primary_Value Result =
                new Primary_Values.List_Primary_Value.List_Primary_Value();
            Result.Value = new List<Number_Type>();
            Registery.Primary_Values.List_Primary_Value.List_Primary_Value num =
                new Primary_Values.List_Primary_Value.List_Primary_Value();
            foreach (Primary.Primary_Value.Primary_Value ele in input)
            {
                num.Value =
                    ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)
                    this.Execute(ele)).Value;

                Result = num;
            }
            return Result;
        }
    }


    public class Sin_Function_Execute_Matrix : Function_Executer
       
    {
        public override Primary.Primary_Value.Primary_Value
             Execute(Primary.Primary_Value.Primary_Value input)
        {
            foreach (List<Number_Type> row in ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)input).Value)
            {
                foreach( Number_Type ele in row)
                {
                    ele.Value = Math.Sin((ele.Value * Math.PI / 180));
                }
                
            }
            return ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)input);
        }

        public override Primary.Primary_Value.Primary_Value Execute(List<Primary.Primary_Value.Primary_Value> input)
        {
            Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value Result =
                new Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value();
            Result.Value = new List<List<Number_Type>>();
            
            foreach (Primary.Primary_Value.Primary_Value ele in input)
            {
                Result.Value =
                     ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)this.Execute(ele)).Value;
            }
            return Result;
        }
    }


   


}
