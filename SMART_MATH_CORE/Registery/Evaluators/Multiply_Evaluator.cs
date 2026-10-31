using SMART_MATH_CORE.Registery.Primary_Values.List_Primary_Value;
using SMART_MATH_CORE.Registery.Primary_Values.Matrix_Primary_VaLue;
using SMART_MATH_CORE.Registery.Primary_Values.Number_Primary_VaLue;
using SMART_MATH_CORE.Registery.Tokens.Operators_Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Evaluators
{
    public class Multiply_Evaluator : General_Evaluator
    {
        bool Valid_Right_Value (Primary.Primary_Value.Primary_Value right)
        {
            if(right is Number_Primary_Value)
            {
                Number_Primary_Value NotValid = new Number_Primary_Value
                {
                    Value = new Number_Type { Value = 0}
                };

                if( ((Number_Primary_Value)right).Value.Value == NotValid.Value.Value )
                {
                    throw new Exception("\nDIVIDE ON ZERO");
                }
                return true;
            }
            else if ( right is List_Primary_Value)
            {
                Number_Primary_Value NotValid = new Number_Primary_Value
                {
                    Value = new Number_Type { Value = 0 }
                };

                foreach (Number_Type num in ((List_Primary_Value)right).Value)
                {
                    if (num.Value == NotValid.Value.Value)
                    {
                        throw new Exception("\nDIVIDE ON ZERO");
                    }
                }
                return true;
            }
            else if (right is Matrix_Primary_Value)
            {
                // Implemented in Executer
                return true;
            }
            else
            {
                throw new Exception("\nNOT VALID INPUT");
            }
        }
        public override Primary.Primary_Value.Primary_Value Evaluate
          (Primary.Primary_Value.Primary_Value Left, Parser.Token.Token Operator,
            Primary.Primary_Value.Primary_Value Right)
        {
            Primary.Primary_Value.Primary_Value Result =
                new Primary.Primary_Value.Primary_Value();

            Registery.Functions_Executers.Function_Executer executer =
               new Functions_Executers.Function_Executer();

            if (Left is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value
                && Right is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)
            {
                executer = Registery.Functions_Executers.Functions_Executers_Dictionary.Get_Function_Executer
                      (Operator, Primary.Primary_Value.Primary_Value_Type.Number);
                List<Primary.Primary_Value.Primary_Value> Inputs =
                    new List<Primary.Primary_Value.Primary_Value>();
                Inputs.Add(Left);
                Inputs.Add(Right);

                if(Operator is Divide_Token && Valid_Right_Value(Right))
                  return executer.Execute(Inputs);

                else if (Operator is not Divide_Token)
                    return executer.Execute(Inputs);
                else
                    return new Primary.Primary_Value.Primary_Value();
            }
            else if (Left is Registery.Primary_Values.List_Primary_Value.List_Primary_Value
                    || Right is Registery.Primary_Values.List_Primary_Value.List_Primary_Value)
            {
                executer = Registery.Functions_Executers.Functions_Executers_Dictionary.Get_Function_Executer
                    (Operator, Primary.Primary_Value.Primary_Value_Type.List);
                List<Primary.Primary_Value.Primary_Value> Inputs =
                    new List<Primary.Primary_Value.Primary_Value>();
                Inputs.Add(Right);
                Inputs.Add(Left);

                if (Operator is Divide_Token && Valid_Right_Value(Right))
                    return executer.Execute(Inputs);

                else if (Operator is not Divide_Token)
                    return executer.Execute(Inputs);
                else
                    return new Primary.Primary_Value.Primary_Value();
            }
            else if (Left is Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value
                || Right is Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)
            {
                executer = Registery.Functions_Executers.Functions_Executers_Dictionary.Get_Function_Executer
                    (Operator, Primary.Primary_Value.Primary_Value_Type.Matrix);
                List<Primary.Primary_Value.Primary_Value> Inputs =
                    new List<Primary.Primary_Value.Primary_Value>();
                Inputs.Add(Left);
                Inputs.Add(Right);
                if (Operator is Divide_Token && Valid_Right_Value(Right))
                    return executer.Execute(Inputs);

                else if (Operator is not Divide_Token)
                    return executer.Execute(Inputs);
                else
                    return new Primary.Primary_Value.Primary_Value();
            }
            else
            {
                throw new Exception("\n UNKNOWN BEHAVIOR FOR POWER FOR NOW");
            }
        }
    }
}
