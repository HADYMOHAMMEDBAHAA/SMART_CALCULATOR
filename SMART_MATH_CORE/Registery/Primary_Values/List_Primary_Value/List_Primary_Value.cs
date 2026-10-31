using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Primary_Values.List_Primary_Value
{
    public class List_Primary_Value : SMART_MATH_CORE.Primary.Primary_Value.Primary_Value
     
    {
        public List_Primary_Value()
        {
            this.PrimaryValue_Type = Primary.Primary_Value.Primary_Value_Type.List;
        }
        public List<Number_Type > Value= new List<Number_Type>();

        public override void Show()
        {
            Console.WriteLine("\nList_Primary_Value: " + PrimaryValue_Type.ToString());
            Console.WriteLine("Values: ");
            foreach (Number_Type item in Value)
            {
                Console.WriteLine(item.Value);
            }
        }

        public override List<string>? ConvertPrimaryToString()
        {
            List<string> result = new List<string>();
            foreach (Number_Type item in Value)
            {
                result.Add(" ");
                result.Add(item.Value.ToString());
                result.Add(" ");
            }
            result.Add("\n");
            return result;
        }

        public override Primary.Primary_Value.Primary_Value? Is_Primary(Parser.Token.Token token)
        {
            if (token is Registery.Tokens.Input_Tokens.List_Token listToken)
            {
                List_Primary_Value value = new List_Primary_Value();
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
           if(this.Value.Count > 0)
            {
                Primary.Primary_To_Token.Convert_Primary_To_Token Convert =
                new Primary.Primary_To_Token.Convert_Primary_To_Token();
                return Convert.Convert_Primary_To_Token_Method(this);
            }
            else
            {
                return null;
            }
        }

    }

  
}
