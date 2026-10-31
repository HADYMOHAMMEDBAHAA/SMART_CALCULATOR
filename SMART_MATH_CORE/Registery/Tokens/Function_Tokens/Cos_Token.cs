using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Function_Tokens
{
    public class Cos_Token : Parser.Token.Function_Token
    {
        public Cos_Token()
        {
            this.Name = "Cos";
            this.Aliases = new List<string>() { "cos" };
            this.Value = "cos";
        }
    }
    
}
