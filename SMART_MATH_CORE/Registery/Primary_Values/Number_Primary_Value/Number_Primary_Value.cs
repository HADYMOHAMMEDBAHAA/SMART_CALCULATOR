using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Primary_Values.Number_Primary_VaLue
{
    public class Number_Primary_Value : SMART_MATH_CORE.Primary.Primary_Value.Primary_Value
    {
        public Number_Primary_Value()
        {
            this.PrimaryValue_Type = Primary.Primary_Value.Primary_Value_Type.Number;
        }
        public Number_Type Value = new Number_Type();

        public override void Show()
        {
            Console.WriteLine($"\nType :{this.PrimaryValue_Type} VaLue: {this.Value.Value}");
        }

        public override List<string>? ConvertPrimaryToString()
        {
            List<string> result = new List<string>();
            result.Add(" ");
            result.Add(Value.Value.ToString());
            result.Add(" ");
            return result;
        }

        public override Primary.Primary_Value.Primary_Value? Is_Primary(Parser.Token.Token token)
        {
            if (token is Registery.Tokens.Input_Tokens.Number_Token numberToken)
            {
                Number_Primary_Value value = new Number_Primary_Value();
                Primary.Token_To_Primary.Convert_Token_To_Primary Convert =
                    new Primary.Token_To_Primary.Convert_Token_To_Primary();
                return Convert.Convert_Token_To_Primary_Method(token);
            }
            else
            {
                return null;
            }
        }

        public override Parser.Token.Token? Convert_Primary_To_Token_Method()
        {
            Registery.Tokens.Input_Tokens.Number_Token token = new Registery.Tokens.Input_Tokens.Number_Token();
            token.Value = Value.Value.ToString();
            return token;
        }
    }
}
