using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Parser.Tokenizer
{
    public class Tokenizer
    {
        public List<Parser.Token.Token>? Tonenizes(string expression)
        {
            SMART_MATH_CORE.Registery.Tokens.
            Tokens_Recognizers_Registery.Tokens_Recognizers_Registery Token_Recognizers =
            new SMART_MATH_CORE.Registery.Tokens.
            Tokens_Recognizers_Registery.Tokens_Recognizers_Registery();

            List<SMART_MATH_CORE.Parser.Token.Token>? Toks = new List<SMART_MATH_CORE.Parser.Token.Token>();

            SMART_MATH_CORE.Parser.Token.Token? currentTok = null;

            int position = 0;

            for (int i = 0; i < expression.Length; i++)
            {
                foreach (SMART_MATH_CORE.Parser.Token_Recognizer.Token_Recognizer Recognizer
                    in Token_Recognizers.Get_Recognizers())
                {
                    currentTok = Recognizer.Recognize(expression, position, out position);
                    if (currentTok != null)
                        break;
                }
                if (currentTok != null)
                {
                    if(Toks == null)
                    {
                        Toks = new List<SMART_MATH_CORE.Parser.Token.Token>();
                    }
                    Toks.Add(currentTok);
                    i = position-1;
                }
                else
                {
                    i=position++;
                    
                }
                if (position == expression.Length)
                    break;
            }
            if(Toks.Count == 0)
            {
                return null;
            }
            else
            {
                return Toks;
            }
        }
    }
}
