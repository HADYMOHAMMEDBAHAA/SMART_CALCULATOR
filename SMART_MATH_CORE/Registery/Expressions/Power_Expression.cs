using SMART_MATH_CORE.Evaluator;
using SMART_MATH_CORE.Parser.Token;
using SMART_MATH_CORE.Registery.Evaluators;
using SMART_MATH_CORE.Registery.Tokens.Identifier_Tokens;
using SMART_MATH_CORE.Registery.Tokens.Operators_Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Expressions
{
    public class Power_Expression : Parser.Expression.IExpression
    {
        bool GetOutif_Function_Found(int index, ref List<Token> tokens)
        {
            if (tokens[index] is Registery.Tokens.Operators_Tokens.Power_Token
                || tokens[index] is Registery.Tokens.Operators_Tokens.Root_Token)
            {
                return true;
            }
            return false;
        }

        bool IF_Function_Name_Exist(int index, ref List<Token> tokens, out Token? Op)
        {
            Op = null;
            if (index < tokens.Count)
            {
                if (tokens[index] is Registery.Tokens.Operators_Tokens.Power_Token
                     || tokens[index] is Registery.Tokens.Operators_Tokens.Root_Token)
                {
                    Op = tokens[index];
                    return true;
                }
            }
            return false;
        }

        Primary.Primary_Value.Primary_Value? GetBaseValue(ref List<Token> tokens , int start ,out int end)
        {
            Primary.Primary_Value.Primary_Value? Left = null;
            Function_Expression Left_func_expression = new Function_Expression();
            List<Token>? Left_Tokens = null;
            end = start;
            int startRead = start;
            while (tokens != null && tokens.Count > 0
                && startRead < tokens.Count && !(GetOutif_Function_Found(startRead, ref tokens)))
            {

                if (tokens[startRead] is Registery.Tokens.Identifier_Tokens.Open_Parnthises_Token)
                {
                    if (Left_Tokens == null)
                    {
                        Left_Tokens = new List<Token>();
                    }
                    Read_Parenthises read_Parenthises = new Read_Parenthises();

                    Left_Tokens.AddRange(read_Parenthises.Read(ref tokens, startRead, out startRead)!);
                    continue;
                }

                if (Left_Tokens == null)
                {
                    Left_Tokens = new List<Token>();
                }
                if (startRead == tokens.Count ||
                   (GetOutif_Function_Found(startRead, ref tokens)))
                    break;
                Left_Tokens.Add(tokens[startRead++]);
            }

            if (Left_Tokens != null)
            {
                end = startRead++;
                Left = Left_func_expression.Process(ref Left_Tokens);
            }

            return Left;
        }

        Parser.Token.Token? GetOperator (ref List<Token> tokens, int start, out int end)
        {
            end = start;
            int startRead = start;
            Token? Op = null;
            if (tokens != null && tokens.Count > 0 && IF_Function_Name_Exist(startRead,ref tokens,out Op))
            {
                end++;
            }
            return Op;
        }

        Primary.Primary_Value.Primary_Value? Get_Power(ref List<Token> tokens, int start, out int end)
        {
            end = start;
            int startRead = start;
            Function_Expression  Right_func_expression = new Function_Expression();
            Primary.Primary_Value.Primary_Value? Right = null;
            if (tokens != null && tokens.Count > 0 && startRead < tokens.Count)
            {
                List<Token> Righttokens = new List<Token>();
                end = startRead;
                while (startRead < tokens.Count )
                {
                    Righttokens.Add(tokens[startRead++]);
                }
                Right = Right_func_expression.Process(ref Righttokens);
                end = startRead;
                return Right;



            }
            else
            {
                end = start;
                return null;
            }
        }


        Primary.Primary_Value.Primary_Value? Process_One_Operation(ref List<Token> tokens, int start, out int end)
        {
            end = start;
            int startRead = start;

            Primary.Primary_Value.Primary_Value? Base = GetBaseValue(ref tokens, startRead, out end);

            Primary.Primary_Value.Primary_Value? Power = null;

            startRead = end;

            Token? Op = GetOperator(ref tokens, startRead , out end) ?? null;

            if (Op != null)
            {
                startRead = end;
                Power = Get_Power(ref tokens, startRead, out end);
            }

            if (Base != null && Op == null && Power == null)
            {
                return Base;
            }
            else if (Base != null && Op is Power_Token && Power != null)
            {
                Power_Evaluator _Evaluator = new Power_Evaluator();
                return _Evaluator.Evaluate(Base , Op , Power);
            }
            else if (Base != null && Op is Root_Token && Power != null)
            {
                Power_Evaluator _Evaluator = new Power_Evaluator();
                return _Evaluator.Evaluate(Power, Op, Base);
            }
            else if (Op is Root_Token && Base==null && Power != null)
            {
                Base = new Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value
                { Value = new Number_Type { Value = 2 } }; // Base Root is
                
                Power_Evaluator _Evaluator = new Power_Evaluator();
                return _Evaluator.Evaluate(Power, Op, Base);
            }
            else 
            {
                throw new Exception("\nERROR IN POWER EXPRESSION\n");
            }

        }


        public Primary.Primary_Value.Primary_Value? Process(ref List<Token> tokens)
        {
            Primary.Primary_Value.Primary_Value? Result = null; // Saving Older Process Result

            Primary.Primary_Value.Primary_Value? CurrentProcessResult = null;

            int startprocess = 0; // First Time Read ever in Process 
            bool Firstprocess = true;
            while (tokens != null && startprocess < tokens.Count)
            {
                int orignalstart = startprocess;
                Token? Op=null;

                if (Firstprocess)
                {
                    CurrentProcessResult = Process_One_Operation(ref tokens, startprocess, out startprocess);
                    Result = CurrentProcessResult;
                    Firstprocess = false;
                    if (CurrentProcessResult == null ||
                        CurrentProcessResult.PrimaryValue_Type == Primary.Primary_Value.Primary_Value_Type.None)
                    {
                        throw new Exception("\nSOMETHIN GOES WRONG IN FUNCTION EXPRESSION\n");
                    }
                }
                else
                {

                    if (tokens[orignalstart] is Root_Token || tokens[orignalstart] is Power_Token)
                    {
                        Op = tokens[orignalstart];
                        startprocess++;
                        Process_One_Operation(ref tokens, startprocess, out startprocess);
                    }
                    else
                    {
                        Process_One_Operation(ref tokens, startprocess, out startprocess);
                    }

                    List<Primary.Primary_Value.Primary_Value> Inputs =
                    new List<Primary.Primary_Value.Primary_Value>();

                    if (Result != null && CurrentProcessResult != null)
                    {
                        if (Op != null && Op is Power_Token)
                        {
                            Inputs.Add(Result);
                            Inputs.Add(CurrentProcessResult);
                            Registery.Evaluators.General_Evaluator evaluator =
                           new Evaluators.General_Evaluator();

                            Result =
                          evaluator.Evaluate(Inputs, new Registery.Tokens.Operators_Tokens.Power_Token());
                        }
                        else if (Op != null && Op is Root_Token)
                        {
                            Inputs.Add(CurrentProcessResult);
                            Inputs.Add(Result);
                            Registery.Evaluators.General_Evaluator evaluator =
                           new Evaluators.General_Evaluator();

                            Result =
                          evaluator.Evaluate(Inputs, new Registery.Tokens.Operators_Tokens.Root_Token());
                        }
                        else
                        {
                            Inputs.Add(CurrentProcessResult);
                            Inputs.Add(Result);
                            Registery.Evaluators.General_Evaluator evaluator =
                           new Evaluators.General_Evaluator();

                            Result =
                          evaluator.Evaluate(Inputs, new Multiply_Token());
                        }

                    }
                }
                startprocess++;
            }

            return Result;
        }

        public Primary.Primary_Value.Primary_Value? Process(ref List<Primary.Primary_Value.Primary_Value> Inputs)
        {
            return null;
        }
    }
}
