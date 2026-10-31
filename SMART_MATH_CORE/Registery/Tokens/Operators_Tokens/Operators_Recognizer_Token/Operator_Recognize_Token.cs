using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Operators_Tokens.Operators_Recognizer_Token
{
    public class Operator_Recognize_Token : Parser.Token_Recognizer.Token_Recognizer
    {
        Parser.Token.Operator_Token? Operator;
        public override Parser.Token.Operator_Token? Recognize(string text, int start, out int end)
        {
            end = start;
            string? NameFound;
            SMART_MATH_CORE.My_Lib.Search_Algorithm.Search_Name.Search_Name search =
                       new My_Lib.Search_Algorithm.Search_Name.Search_Name();
            if (text != null && text.Length > 0 && start < text.Length)
            {
                foreach (Parser.Token.Operator_Token Op in
                   Registery.Tokens.Operators_Tokens.Operators_Registry_Token
                   .Operators_Registery_Token.GetAllOperatorsTokens()
                  )
                {
                    NameFound = search.Search(text, Op.Aliases!, start, out end);
                    if (NameFound != null)
                    {
                        Operator = Op;
                        return Operator;
                    }
                }

            }
            return null;
        }
    }
}
