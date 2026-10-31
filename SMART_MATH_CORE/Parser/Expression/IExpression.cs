using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Parser.Expression
{
    public interface IExpression
    {
        public Primary.Primary_Value.Primary_Value? Process(ref List<Token.Token> tokens );
        public Primary.Primary_Value.Primary_Value? Process(ref List<Primary.Primary_Value.Primary_Value> Inputs);

    }
}
