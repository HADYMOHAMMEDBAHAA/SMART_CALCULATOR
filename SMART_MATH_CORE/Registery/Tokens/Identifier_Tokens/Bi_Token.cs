using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Identifier_Tokens
{
    public class Bi_Token : Parser.Token.Identifires_Token
    {
        public Bi_Token()
        {
            this.Name = "Bi";
            this.Aliases = new List<string>() { "bi" , "π"};
            this.Value= "3.14";
        }
    }
}
