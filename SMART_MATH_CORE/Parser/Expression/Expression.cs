using SMART_MATH_CORE.Parser.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Parser.Expression
{
    internal class Memorization_IF_Stucked_In_Same_Expression
    {
        private static Dictionary<List<Parser.Token.Token>, int> Expression_Count = 
            new Dictionary<List<Parser.Token.Token>, int>();
        public static int Count (ref List<Parser.Token.Token> Expr )
        {
            if(Expression_Count.ContainsKey(Expr))
            {
                Expression_Count[Expr]++;
                return Expression_Count[Expr];
            }
            else
            {
                Expression_Count.Add(Expr, 1);
                return Expression_Count[Expr];
            }
        }
    }
    public class Expression : IExpression
    {

        public Primary.Primary_Value.Primary_Value? Process(ref List<Token.Token> tokens )
        {
            Registery.Expressions.Addition_Expression addition_Expression = 
                new Registery.Expressions.Addition_Expression();

            if(Memorization_IF_Stucked_In_Same_Expression.Count(ref tokens)> 20)//JUST IN CASE STUCK
                                                                                //IN INFINITY RECURSION
            {
                return null;
            }

            return addition_Expression.Process(ref tokens );
        }

        public Primary.Primary_Value.Primary_Value? Process(ref List<Primary.Primary_Value.Primary_Value> Inputs)
        {
            return new Primary.Primary_Value.Primary_Value();
        }

        
    }
}
