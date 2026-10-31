using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Identifier_Tokens
{
    public class Comma_Token : Parser.Token.Identifires_Token
    {
        public Comma_Token()
        {
            this.Name = "Comma";
            this.Aliases = new List<string>() { ",", "Comma" };
            this.Value = ",";
        }
    }
}
