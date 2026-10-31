using SMART_MATH_CORE.Parser.Token;
using SMART_MATH_CORE.Primary.Primary_Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Parser
{
    public class Parsing
    {
        public static List<string>? Parse(string Meth_Expression)
        {
            List<Token.Token>? tokens = null;

            Tokenizer.Tokenizer tokenizer = new Tokenizer.Tokenizer();

            tokens = tokenizer.Tonenizes(Meth_Expression);

            Expression.Expression expression = new Expression.Expression();

            Primary_Value? result = null;

            if (tokens != null)
            {
                try
                {
                    result = expression.Process(ref tokens);
                }
                catch
                {
                }
                
            }

            List<string>? result_string = null;

            if (result != null)
            {
                result_string = result.ConvertPrimaryToString();
            }
            else
            {
                string error_Massage = "ERROR";
                result_string = new List<string>();
                result_string.Add(error_Massage);
            }

            return result_string;
        }
    }
}
