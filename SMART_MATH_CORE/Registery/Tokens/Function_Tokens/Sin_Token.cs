using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Function_Tokens
{
    public class Sin_Token : Parser.Token.Function_Token
    {
        public Sin_Token()
        {
            this.Name = "Sin";
            this.Aliases = new List<string>() { "sin" };
            this.Value = "sin";
        }
    }
    
}
