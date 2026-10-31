using SMART_MATH_CORE.Parser.Expression;
using SMART_MATH_CORE.Parser.Token;
using SMART_MATH_CORE.Registery.Tokens.Identifier_Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Expressions
{
    public class Primary_Expression : IExpression
    {
        public Primary.Primary_Value.Primary_Value? Process(ref List<Token> tokens)
        {
            if (tokens.Count > 0)
            {
                int ReadOneToken = 0;

                Primary.Primary_Value.Primary_Value? primary_ = null;

                primary_ = Registery.Primary_Values.Primary_Values_Registry.Primary_Values_Registery.
                    IsPrimary(tokens[ReadOneToken]);

                if(tokens.Count < 2)
                    if (primary_ != null)
                    {
                        return primary_;
                    }

                Parser.Expression.Expression expression = new Expression();

                if (tokens[ReadOneToken] is Open_Parnthises_Token)
                {
                    List<Token> removedParenthises = new List<Token>();
                    Remove_Parenthises remove_Parenthises = new Remove_Parenthises();
                    int end = 0;
                    removedParenthises = remove_Parenthises.Remove(ref tokens, end, out end)!;

                    return expression.Process(ref removedParenthises);
                }
                

                return expression.Process(ref tokens);
            }
            return null;
        }

        public Primary.Primary_Value.Primary_Value? Process(ref List<Primary.Primary_Value.Primary_Value> Inputs)
        {
            return null;
        }

        
    }
}
