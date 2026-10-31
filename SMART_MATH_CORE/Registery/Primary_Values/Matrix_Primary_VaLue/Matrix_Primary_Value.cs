using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Primary_Values.Matrix_Primary_VaLue
{
    public class Matrix_Primary_Value : SMART_MATH_CORE.Primary.Primary_Value.Primary_Value
    {
        public Matrix_Primary_Value()
        {
            this.PrimaryValue_Type = Primary.Primary_Value.Primary_Value_Type.Matrix;
        }
        public List<List<Number_Type>> Value = new List<List<Number_Type>>();

        public override void Show()
        {
            Console.WriteLine("\nMatrix_Primary_Value: ");
            foreach (var row in Value)
            {
                Console.Write("[ ");
                foreach (var item in row)
                {
                    Console.Write(item.Value + " ");
                }
                Console.WriteLine("]");
            }
        }

        public override List<string>? ConvertPrimaryToString()
        {
            List<string> result = new List<string>();
            foreach (var row in Value)
            {
                result.Add("[ ");
                foreach (var item in row)
                {
                    result.Add(item.Value.ToString());
                    result.Add(" ");
                }
                result.Add("]\n");
            }
            return result;
        }

        public override Primary.Primary_Value.Primary_Value? Is_Primary(Parser.Token.Token token)
        {
            if (token is Registery.Tokens.Input_Tokens.Matrix_Token matrixToken)
            {
                Matrix_Primary_Value value = new Matrix_Primary_Value();
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
            if (this.Value.Count > 0)
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
