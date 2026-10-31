using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Function_Tokens
{
    public class Log_Token : Parser.Token.Function_Token
    {
        public Log_Token() 
        {
            this.Name = "Log";
            this.Aliases = new List<string>() { "log"};
            this.Value = "log";
        }
    }
}
