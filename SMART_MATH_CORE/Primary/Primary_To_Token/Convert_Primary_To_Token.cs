using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Primary.Primary_To_Token
{
    public interface IConvert_Primary_To_Token
    {
        public Parser.Token.Token Convert_Primary_To_Token_Method(Primary.Primary_Value.Primary_Value primary);
    }

     class Convert_Primary_Number_To_Token : IConvert_Primary_To_Token
    {
        public Parser.Token.Token Convert_Primary_To_Token_Method(Primary.Primary_Value.Primary_Value primary)
        {
            Registery.Tokens.Input_Tokens.Number_Token numberToken = 
                new Registery.Tokens.Input_Tokens.Number_Token();


            if (primary is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)
            {
                Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value primaryNumber =
                (Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)primary;

                numberToken.Value = primaryNumber.Value.Value.ToString();
                return numberToken;
            }
            else
            {
                throw new ArgumentException("Invalid primary value type for conversion to token.");
            }
        }
    }

     class Convert_Primary_List_To_Token : IConvert_Primary_To_Token
    {
        public Parser.Token.Token Convert_Primary_To_Token_Method(Primary.Primary_Value.Primary_Value primary)
        {
            Registery.Tokens.Input_Tokens.List_Token ListToken =
                new Registery.Tokens.Input_Tokens.List_Token();


            if (primary is Registery.Primary_Values.List_Primary_Value.List_Primary_Value)
            {
                Registery.Primary_Values.List_Primary_Value.List_Primary_Value primaryNumber =
                (Registery.Primary_Values.List_Primary_Value.List_Primary_Value)primary;

                ListToken.Values = new List<string>();
                foreach (Number_Type item in primaryNumber.Value)
                {
                    ListToken.Values.Add(item.Value.ToString());
                }
                return ListToken;
            }
            else
            {
                throw new ArgumentException("Invalid primary value type for conversion to token.");
            }
        }
    }


     class Convert_Primary_Matrix_To_Token : IConvert_Primary_To_Token
    {
        public Parser.Token.Token Convert_Primary_To_Token_Method(Primary.Primary_Value.Primary_Value primary)
        {
            Registery.Tokens.Input_Tokens.Matrix_Token MatrixToken =
                new Registery.Tokens.Input_Tokens.Matrix_Token();


            if (primary is Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)
            {
                Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value matrix =
                (Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)primary;

                MatrixToken.Values = new List<List<string>>();
                foreach (List<Number_Type> item in matrix.Value)
                {
                    foreach (Number_Type number in item)
                    {
                        List<string> row = new List<string>();
                        row.Add(number.Value.ToString());
                        MatrixToken.Values.Add(row);
                    }
                }
                return MatrixToken;
            }
            else
            {
                throw new ArgumentException("Invalid primary value type for conversion to token.");
            }
        }
    }


    public class Convert_Primary_To_Token : IConvert_Primary_To_Token
    {
        public Parser.Token.Token Convert_Primary_To_Token_Method(Primary.Primary_Value.Primary_Value primary)
        {
            if (primary is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)
            {
                Convert_Primary_Number_To_Token converter = new Convert_Primary_Number_To_Token();
                return converter.Convert_Primary_To_Token_Method(primary);
            }
            else if (primary is Registery.Primary_Values.List_Primary_Value.List_Primary_Value)
            {
                Convert_Primary_List_To_Token converter = new Convert_Primary_List_To_Token();
                return converter.Convert_Primary_To_Token_Method(primary);
            }
            else if (primary is Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)
            {
                Convert_Primary_Matrix_To_Token converter = new Convert_Primary_Matrix_To_Token();
                return converter.Convert_Primary_To_Token_Method(primary);
            }
            else
            {
                throw new ArgumentException("Invalid primary value type for conversion to token.");
            }
        }
    }
}
