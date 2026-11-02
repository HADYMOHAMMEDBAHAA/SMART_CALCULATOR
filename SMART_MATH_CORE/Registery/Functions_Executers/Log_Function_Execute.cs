using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Functions_Executers
{
    public class Log_Function_Execute_Number : Function_Executer
    {
        public override Primary.Primary_Value.Primary_Value Execute(Primary.Primary_Value.Primary_Value input)
        {
            ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)input).Value.Value
             = Math.Log10
              ((
              ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)input).Value.Value));
            return ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)input);
        }

        public override Primary.Primary_Value.Primary_Value Execute(List<Primary.Primary_Value.Primary_Value> input)
        {
            if (input.Count == 1)
            {
                Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value value =
                    (Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)input[0];
                Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value result =
                    new Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value();

                result.Value.Value = Math.Log10(value.Value.Value);
                return result;
            }
            if (input.Count == 2)
            {
                Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value baseValue = 
                    (Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)input[0];

                Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value value =
                    (Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)input[1];
                Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value result =
                    new Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value();

                result.Value.Value = Math.Log(value.Value.Value, baseValue.Value.Value);

                return result;
            }
            else
            {
                throw new Exception("Log function requires exactly two arguments: base and value.");
            }

        }
    }

    public class Log_Function_Execute_List : Function_Executer
    {
        public override Primary.Primary_Value.Primary_Value Execute(Primary.Primary_Value.Primary_Value input)
        {

            Registery.Primary_Values.List_Primary_Value.List_Primary_Value result =
               new Registery.Primary_Values.List_Primary_Value.List_Primary_Value();

            if (((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)input).Value.Count > 1)
            {
                bool firsttime = true;
               Number_Type baseValue =
              ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)input).Value[0];

                result.Value = new List<Number_Type>();

                foreach (Number_Type num in
                    ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)input).Value)
                {
                    if (firsttime)
                    {
                        firsttime = false;
                        continue;
                    }

                    result.Value.Add(new Number_Type { Value = Math.Log(num.Value, baseValue.Value)});
                }
            }
            return result;
        }

        public override Primary.Primary_Value.Primary_Value Execute(List<Primary.Primary_Value.Primary_Value> input)
        {
            Primary.Primary_Value.Primary_Value result =
               new Primary.Primary_Value.Primary_Value();
            if (input.Count > 0)
            {
                foreach (Primary.Primary_Value.Primary_Value list in input)
                {
                    result = this.Execute(list);
                }
                return result;
            }
            else
            {
                throw new Exception("Log function requires exactly two arguments: base and value.");
            }
        }
    }

    public class Log_Function_Execute_Matrix : Function_Executer
    {
        public override Primary.Primary_Value.Primary_Value Execute(Primary.Primary_Value.Primary_Value input)
        {
            foreach (List<Number_Type> row in ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)input).Value)
            {
                foreach (Number_Type ele in row)
                {
                    ele.Value = Math.Log10(ele.Value);
                }
            }
            return ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)input);
        }

        public override Primary.Primary_Value.Primary_Value Execute(List<Primary.Primary_Value.Primary_Value> input)
        {
            if (input.Count == 2)
            {
                Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value baseValue =
                    (Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)input[0];
                Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value value =
                    (Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)input[1];
                Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value result =
                    new Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value();
                foreach (List<Number_Type> row in value.Value)
                {
                    List<Number_Type> newRow = new List<Number_Type>();
                    foreach (Number_Type ele in row)
                    {
                        Number_Type newEle = new Number_Type();
                        newEle.Value = Math.Log(ele.Value, baseValue.Value.Value);
                        newRow.Add(newEle);
                    }
                    result.Value.Add(newRow);
                }
                return result;
            }
            else
            {
                throw new Exception("Log function requires exactly two arguments: base and value.");
            }
        }
    }
}
