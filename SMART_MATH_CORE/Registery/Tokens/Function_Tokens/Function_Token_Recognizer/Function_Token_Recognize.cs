using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Function_Tokens.Function_Token_Recognizer
{
    public class Function_Token_Recognize : Parser.Token_Recognizer.Token_Recognizer
    {
        Parser.Token.Function_Token? Func;
        public override Parser.Token.Function_Token? Recognize(string text, int start, out int end)
        {
            end = start;
            string? NameFound;
            SMART_MATH_CORE.My_Lib.Search_Algorithm.Search_Name.Search_Name search =
                       new My_Lib.Search_Algorithm.Search_Name.Search_Name();
            if (text != null && text.Length > 0 && start < text.Length )
            {
                foreach(Parser.Token.Function_Token func in 
                   Registery.Tokens.Function_Tokens.Function_Token_Registery.
                   Function_Token_Registery.GetAllFunctionTokens())
                {
                  NameFound=search.Search(text, func.Aliases!, start, out end);
                    if (NameFound != null)
                    {
                        Func = func;
                        return Func;
                    }
                }
               
            }
            return null;
        }
    }
}
