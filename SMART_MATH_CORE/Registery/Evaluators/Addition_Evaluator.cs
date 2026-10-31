using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Evaluators
{
    public class Addition_Evaluator : General_Evaluator
    {
        public override Primary.Primary_Value.Primary_Value Evaluate
         (Primary.Primary_Value.Primary_Value A, Parser.Token.Token Operator, 
            Primary.Primary_Value.Primary_Value B)
        {
            Primary.Primary_Value.Primary_Value Result =
                new Primary.Primary_Value.Primary_Value();

            Registery.Functions_Executers.Function_Executer executer =
               new Functions_Executers.Function_Executer();

            if (A is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value
                && B is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)
            {
                executer = Registery.Functions_Executers.Functions_Executers_Dictionary.Get_Function_Executer
                      (Operator, Primary.Primary_Value.Primary_Value_Type.Number);
                List<Primary.Primary_Value.Primary_Value> Inputs =
                    new List<Primary.Primary_Value.Primary_Value>();
                Inputs.Add(A);
                Inputs.Add(B);
                return executer.Execute(Inputs);

            }
            else if (A is Registery.Primary_Values.List_Primary_Value.List_Primary_Value
                || B is Registery.Primary_Values.List_Primary_Value.List_Primary_Value)
            {
                executer = Registery.Functions_Executers.Functions_Executers_Dictionary.Get_Function_Executer
                    (Operator, Primary.Primary_Value.Primary_Value_Type.List);
                List<Primary.Primary_Value.Primary_Value> Inputs =
                    new List<Primary.Primary_Value.Primary_Value>();
                Inputs.Add(A);
                Inputs.Add(B);
                return executer.Execute(Inputs);
            }
            else if (A is Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value
                || B is Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)
            {
                executer = Registery.Functions_Executers.Functions_Executers_Dictionary.Get_Function_Executer
                    (Operator, Primary.Primary_Value.Primary_Value_Type.Matrix);
                List<Primary.Primary_Value.Primary_Value> Inputs =
                    new List<Primary.Primary_Value.Primary_Value>();
                Inputs.Add(A);
                Inputs.Add(B);
                return executer.Execute(Inputs);
            }
            else
            {
                throw new Exception("\n UNKNOWN BEHAVIOR FOR POWER FOR NOW");
            }
        }

        public override Primary.Primary_Value.Primary_Value Evaluate
            (Primary.Primary_Value.Primary_Value A, Parser.Token.Token Operator)
        {
            Primary.Primary_Value.Primary_Value Result =
               new Primary.Primary_Value.Primary_Value();

            Registery.Functions_Executers.Function_Executer executer =
               new Functions_Executers.Function_Executer();
            if (A is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)
            {
                executer = Registery.Functions_Executers.Functions_Executers_Dictionary.Get_Function_Executer
                      (Operator, Primary.Primary_Value.Primary_Value_Type.Number);
                List<Primary.Primary_Value.Primary_Value> Inputs =
                    new List<Primary.Primary_Value.Primary_Value>();
                Inputs.Add(A);
                return executer.Execute(Inputs);

            }
            else if (A is Registery.Primary_Values.List_Primary_Value.List_Primary_Value)
            {
                executer = Registery.Functions_Executers.Functions_Executers_Dictionary.Get_Function_Executer
                    (Operator, Primary.Primary_Value.Primary_Value_Type.List);
                List<Primary.Primary_Value.Primary_Value> Inputs =
                    new List<Primary.Primary_Value.Primary_Value>();
                Inputs.Add(A);
                return executer.Execute(Inputs);
            }
            else if (A is Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)
            {
                executer = Registery.Functions_Executers.Functions_Executers_Dictionary.Get_Function_Executer
                    (Operator, Primary.Primary_Value.Primary_Value_Type.Matrix);
                List<Primary.Primary_Value.Primary_Value> Inputs =
                    new List<Primary.Primary_Value.Primary_Value>();
                Inputs.Add(A);
                return executer.Execute(Inputs);
            }
            else
            {
                throw new Exception("\n UNKNOWN BEHAVIOR FOR POWER FOR NOW");
            }
        }
    }
}

