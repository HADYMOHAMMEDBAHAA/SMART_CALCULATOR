using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Primary.Token_To_Primary
{
    public interface IConvert_Token_To_Primary
    {
        public Primary.Primary_Value.Primary_Value? Convert_Token_To_Primary_Method(Parser.Token.Token token);
    }

    class Convert_Token_Number_To_Primary : IConvert_Token_To_Primary
    {
        public Primary.Primary_Value.Primary_Value? Convert_Token_To_Primary_Method(Parser.Token.Token token)
        {
            if (token is Registery.Tokens.Input_Tokens.Number_Token numberToken)
            {
                Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value value = 
                    new Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value();
                if (value.Value.Set_String_Val(token.Value))
                {
                    return value;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }


    class Convert_Token_To_List : IConvert_Token_To_Primary
    {
        public Primary.Primary_Value.Primary_Value? Convert_Token_To_Primary_Method(Parser.Token.Token token)
        {
            if (token is Registery.Tokens.Input_Tokens.List_Token numberToken)
            {
                Registery.Tokens.Input_Tokens.List_Token list_ = 
                    (Registery.Tokens.Input_Tokens.List_Token )token;

                Registery.Primary_Values.List_Primary_Value.List_Primary_Value value =
                    new Registery.Primary_Values.List_Primary_Value.List_Primary_Value();

                value.Value = new List<Number_Type>();

        
                foreach (string ele in list_.Values!)
                {
                    Number_Type number = new Number_Type();
                    if (number.Set_String_Val(ele))
                    {
                        value.Value.Add(number);
                    }
                    else
                    {
                        return null;
                    }
                }
                return value;
            }
            else
            {
                return null;
            }
        }
    }


    class Convert_Matrix_To_List : IConvert_Token_To_Primary
    {
        public Primary.Primary_Value.Primary_Value? Convert_Token_To_Primary_Method(Parser.Token.Token token)
        {
            if (token is Registery.Tokens.Input_Tokens.Matrix_Token numberToken)
            {
                Registery.Tokens.Input_Tokens.Matrix_Token list_ =
                    (Registery.Tokens.Input_Tokens.Matrix_Token)token;

                Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value value =
                    new Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value();

                value.Value = new List<List<Number_Type>>();

               
                int row = 0;
                foreach (List<string> ele in list_.Values!)
                {
                    value.Value.Add(new List<Number_Type>());

                    foreach (string ele2 in ele)
                    {
                        Number_Type number = new Number_Type();
                        if (number.Set_String_Val(ele2))
                        {
                            value.Value[row].Add(number);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    row++;
                }
                return value;
            }
            else
            {
                return null;
            }
        }
    }

    public class Convert_Token_To_Primary
    {
        public Primary.Primary_Value.Primary_Value? Convert_Token_To_Primary_Method(Parser.Token.Token token)
        {
            IConvert_Token_To_Primary converter;
            if (token is Registery.Tokens.Input_Tokens.Number_Token)
            {
                converter = new Convert_Token_Number_To_Primary();
            }
            else if (token is Registery.Tokens.Input_Tokens.List_Token)
            {
                converter = new Convert_Token_To_List();
            }
            else if (token is Registery.Tokens.Input_Tokens.Matrix_Token)
            {
                converter = new Convert_Matrix_To_List();
            }
            else
            {
                return null;
            }
            return converter.Convert_Token_To_Primary_Method(token);
        }
    }
}
