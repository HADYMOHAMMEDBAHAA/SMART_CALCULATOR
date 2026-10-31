using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Parser.Token
{
    public class Operator_Token : Token
    {
        public Operator_Token()
        {
           this.Type  = TokenType.Operator;
        }
       
        
    }
}
