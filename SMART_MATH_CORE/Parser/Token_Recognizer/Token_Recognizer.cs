using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Parser.Token_Recognizer
{
    public class Token_Recognizer
    {
        public virtual Parser.Token.Token? Recognize(string text ,int start ,out int end)
        {
            end= start;
            return null;
        }
    }
}
