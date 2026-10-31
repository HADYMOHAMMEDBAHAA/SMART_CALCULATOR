using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Operators_Tokens
{
    public class Multiply_Token : Parser.Token.Operator_Token
    {
        public Multiply_Token()
        {
            this.Type = Parser.Token.TokenType.Operator;
            this.Aliases = new List<string>() { "*", "multiply", "times" };
            this.Name = "*";
            this.Value = "*";
        }
    }
}
