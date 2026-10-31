using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Primary.Primary_Value
{
    public enum Primary_Value_Type
    { 
        None = 0,
        Number,
        List,
        Matrix
    }

    public class Primary_Value
    {
        public Primary_Value_Type PrimaryValue_Type= Primary_Value_Type.None;
        public virtual Primary_Value? Is_Primary (Parser.Token.Token token)
        {
            return null;
        }
        public virtual Parser.Token.Token? Convert_Primary_To_Token_Method()
        {
            return null;
        }

        public virtual List<string>? ConvertPrimaryToString()
        {
            return null;
        }

        public virtual void Show()
        {
            Console.WriteLine("Primary_Value: " + PrimaryValue_Type.ToString());
        }

        public virtual Primary.Primary_Value.Primary_Value? Convert_Token_To_Primary_Method(Parser.Token.Token token)
        {
            return null;
        }
    }
}
