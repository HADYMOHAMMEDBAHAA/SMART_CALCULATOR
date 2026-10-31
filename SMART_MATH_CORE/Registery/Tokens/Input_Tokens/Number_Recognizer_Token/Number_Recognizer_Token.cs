using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Input_Tokens.Number_Recognizer_Token
{
    public class Number_Recognizer_Token : Parser.Token_Recognizer.Token_Recognizer
    {
        public override Registery.Tokens.Input_Tokens.Number_Token? Recognize
            (string text, int start, out int end)
        {
            int originalstart = start;
            end = start;
            Number_Token? number_ = null;

            SMART_MATH_CORE.My_Lib.Read_Number.Read_Number read = 
            new My_Lib.Read_Number.Read_Number();

           string? number = read.Read(text, start, out end) ;
            if (number != null)
            {
                number_ = new Number_Token();
                number_.Value = number;
            }
            else
            {
                end = originalstart;
            }

            return number_;
        }
    }
}
