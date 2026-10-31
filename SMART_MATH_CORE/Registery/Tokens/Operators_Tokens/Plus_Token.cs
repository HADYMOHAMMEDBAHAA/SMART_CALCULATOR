using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Operators_Tokens
{
    public class Plus_Token : Parser.Token.Operator_Token
    {
        public Plus_Token()
        {
            this.Type = Parser.Token.TokenType.Operator;
            this.Aliases = new List<string>() { "+", "plus","sum","Add" };
            this.Name="+";
            this.Value="+";
        }
    }
}
