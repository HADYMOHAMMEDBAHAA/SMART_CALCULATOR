using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Evaluator
{
    public interface IEvaluator
    {
       public  Primary.Primary_Value.Primary_Value Evaluate
            (List<Primary.Primary_Value.Primary_Value> Inputs , Parser.Token.Token Operator);
        public  Primary.Primary_Value.Primary_Value Evaluate
            (Primary.Primary_Value.Primary_Value A , Parser.Token.Token Operator);

        public  Primary.Primary_Value.Primary_Value Evaluate
           (Primary.Primary_Value.Primary_Value A, Parser.Token.Token Operator , Primary.Primary_Value.Primary_Value B);

        public  Primary.Primary_Value.Primary_Value Evaluate
           (Primary.Primary_Value.Primary_Value A);
    }
}
