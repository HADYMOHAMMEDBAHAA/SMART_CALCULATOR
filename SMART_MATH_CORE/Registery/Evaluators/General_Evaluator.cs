using SMART_MATH_CORE.Evaluator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Evaluators
{

    public class General_Evaluator : Evaluator.IEvaluator
    {
        public virtual Primary.Primary_Value.Primary_Value Evaluate
           (List<Primary.Primary_Value.Primary_Value> Inputs, Parser.Token.Token Operator)
        {
            Registery.Functions_Executers.Function_Executer executer =
                new Functions_Executers.Function_Executer();



            if (Inputs.Count <= 0)
            {
                throw new Exception("No inputs provided for evaluation.");
            }
            else if (Inputs.Count == 1)
            {
                executer = Registery.Functions_Executers.Functions_Executers_Dictionary.Get_Function_Executer
                    (Operator, Return_Type_Of_Operation.Get_Return_Type(Inputs));

                return executer.Execute(Inputs);
            }
            else if (Inputs.Count == 2)
            {
                executer = Registery.Functions_Executers.Functions_Executers_Dictionary.Get_Function_Executer
                     (Operator, Return_Type_Of_Operation.Get_Return_Type(Inputs));

                return executer.Execute(Inputs);
            }
            else
            {
                Primary.Primary_Value.Primary_Value Result =
                    Inputs[0];

                for (int i = 1; i < Inputs.Count; i++)
                {
                    List<Primary.Primary_Value.Primary_Value> Pair_Inputs =
                       new List<Primary.Primary_Value.Primary_Value>
                   {
                        Result,
                        Inputs[i]
                   };
                    executer = Registery.Functions_Executers.Functions_Executers_Dictionary.Get_Function_Executer
                        (Operator, Return_Type_Of_Operation.Get_Return_Type(Pair_Inputs));
                    Result = executer.Execute(Pair_Inputs);
                }
                return Result;
            }
        }

        public virtual Primary.Primary_Value.Primary_Value Evaluate
            (Primary.Primary_Value.Primary_Value A, Parser.Token.Token Operator)
        {
            Registery.Functions_Executers.Function_Executer executer =
            new Functions_Executers.Function_Executer();

            List<Primary.Primary_Value.Primary_Value> Inputs = new List<Primary.Primary_Value.Primary_Value>
            {
                A
            };
            return Evaluate(Inputs, Operator);
        }

        public virtual Primary.Primary_Value.Primary_Value Evaluate
           (Primary.Primary_Value.Primary_Value A, Parser.Token.Token Operator, Primary.Primary_Value.Primary_Value B)
        {
            Registery.Functions_Executers.Function_Executer executer =
            new Functions_Executers.Function_Executer();
            List<Primary.Primary_Value.Primary_Value> Inputs = new List<Primary.Primary_Value.Primary_Value>
            {
                A,
                B
            };
            return Evaluate(Inputs, Operator);
        }

        public virtual Primary.Primary_Value.Primary_Value Evaluate
        (Primary.Primary_Value.Primary_Value A)
        {
            return A;
        }


    }
}


