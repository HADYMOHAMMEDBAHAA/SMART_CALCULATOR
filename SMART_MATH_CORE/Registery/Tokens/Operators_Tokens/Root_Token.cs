using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Operators_Tokens
{
    public class Root_Token : Parser.Token.Operator_Token
    {
        public Root_Token()
        {
            this.Type = Parser.Token.TokenType.Operator;
            this.Aliases = new List<string>() { "root", "sqrt" , "√" };
            this.Name = "root";
            this.Value = "root";
        }
    }
}
