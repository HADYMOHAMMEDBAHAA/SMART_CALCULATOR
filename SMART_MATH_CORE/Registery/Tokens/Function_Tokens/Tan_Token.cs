using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Function_Tokens
{
    public class Tan_Token : Parser.Token.Function_Token
    {
        public Tan_Token()
        {
            this.Name = "Tan";
            this.Aliases = new List<string>() { "tan" };
            this.Value = "tan";
        }
    }
}
