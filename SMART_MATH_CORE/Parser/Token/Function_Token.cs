using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Parser.Token
{
    public class Function_Token : Token
    {
        public Function_Token()
        {
            this.Type = TokenType.Function;
        }
        
    }
}
