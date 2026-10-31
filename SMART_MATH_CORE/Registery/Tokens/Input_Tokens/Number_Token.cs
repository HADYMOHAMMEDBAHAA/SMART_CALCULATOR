using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Input_Tokens
{
    public class Number_Token : Parser.Token.Input_Token
    {
        public Number_Token()
        {
           this.Type = Parser.Token.TokenType.Input;
           this.InputType = Parser.Token.InputType.Number;
        }
        
    }
}
