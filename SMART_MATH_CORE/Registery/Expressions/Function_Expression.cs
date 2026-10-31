using Microsoft.Win32;
using SMART_MATH_CORE.Parser.Expression;
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
   

    public class Function_Expression : Parser.Expression.IExpression
    {
        bool GetOutif_Function_Found(int index , ref List<Token> tokens)
        {
            if(tokens[index] is Parser.Token.Function_Token )
            {
                return true; 
            }
            return false;
        }

      

        bool IF_Function_Name_Exist (int index , ref List<Token> tokens , out Token? func)
        {
            func = null;
            if (index < tokens.Count)
            {
                if (tokens[index] is Parser.Token.Function_Token)
                {
                    func = tokens[index];
                    return true;
                }
            }
            return false;
        }


        Primary.Primary_Value.Primary_Value? GetLeftValue(ref List<Token> tokens, int start, out int end)
        {
            Primary.Primary_Value.Primary_Value? Left = null;
            Primary_Expression Left_Primary_expression = new Primary_Expression();
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
                Left = Left_Primary_expression.Process(ref Left_Tokens);
            }

            return Left;
        }

        Parser.Token.Token? GetOperator(ref List<Token> tokens, int start, out int end)
        {
            end = start;
            int startRead = start;
            Token? Op = null;
            if (tokens != null && tokens.Count > 0 && IF_Function_Name_Exist(startRead, ref tokens, out Op))
            {
                end++;
            }
            return Op;
        }

        Primary.Primary_Value.Primary_Value? Get_RightValue(ref List<Token> tokens, int start, out int end)
        {
            end = start;
            int startRead = start;
            Primary_Expression Right_Primary_expression = new Primary_Expression();
            Primary.Primary_Value.Primary_Value? Right = null;
            if (tokens != null && tokens.Count > 0 && startRead < tokens.Count)
            {
                List<Token> Righttokens = new List<Token>();
                end = startRead;
                while (startRead < tokens.Count)
                {
                    if (startRead == start)
                    {
                        if (tokens[startRead] is Open_Parnthises_Token)
                        {
                            Read_Parenthises read_Parenthises = new Read_Parenthises();
                            Righttokens.AddRange(read_Parenthises.Read(ref tokens, startRead, out startRead)!);
                            break;
                        }
                    }
                    Righttokens.Add(tokens[startRead++]);
                }
                Right = Right_Primary_expression.Process(ref Righttokens);
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

            Primary.Primary_Value.Primary_Value? Left = GetLeftValue(ref tokens, startRead, out end);

            Primary.Primary_Value.Primary_Value? Right = null;

            startRead = end;

            Token? Op = GetOperator(ref tokens, startRead, out end) ?? null;

            if (Op != null)
            {
                startRead = end;
                Right = Get_RightValue(ref tokens, startRead, out end);
            }

            if (Left != null && Op == null && Right == null)
            {
                return Left;
            }
            else if (Left == null && Op != null && Right != null)
            {

                General_Evaluator _Evaluator = new General_Evaluator();
                return _Evaluator.Evaluate(Right, Op);
            }
            else if (Left != null && Op != null && Right != null)
            {
                General_Evaluator _Evaluator = new General_Evaluator();
                Primary.Primary_Value.Primary_Value? R_Value = null;

                R_Value = _Evaluator.Evaluate(Right, Op);

                if (R_Value != null)
                {
                    return _Evaluator.Evaluate(R_Value, new Registery.Tokens.Operators_Tokens.Multiply_Token()
                        , Left);
                }
                else
                {
                    throw new InvalidOperationException("\nSOME THING GOES WRONG IN FUNCTION EXPRESSION\n");
                }
            }
            else
            {
                throw new Exception("\nSOME THING GOES WRONG IN FUNCTION EXPRESSION\n");
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
                    CurrentProcessResult= Process_One_Operation(ref tokens, startprocess - 1, out startprocess);

                    List<Primary.Primary_Value.Primary_Value> Inputs =
                    new List<Primary.Primary_Value.Primary_Value>();

                    if (Result != null && CurrentProcessResult != null)
                    {
                        Inputs.Add(Result);
                        Inputs.Add(CurrentProcessResult);

                        Registery.Evaluators.General_Evaluator evaluator =
                         new Evaluators.General_Evaluator();

                          Result =
                          evaluator.Evaluate(Inputs, new Registery.Tokens.Operators_Tokens.Multiply_Token());
                    }
                }
                startprocess++;
            }

            return Result;
        }

        public Primary.Primary_Value.Primary_Value? Process(ref List<Primary.Primary_Value.Primary_Value> Inputs)
        {
            return new Primary.Primary_Value.Primary_Value();
        }

    }
}
