using SMART_MATH_CORE.Parser.Token;
using SMART_MATH_CORE.Registery.Tokens.Identifier_Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Expressions
{
    internal class Remove_Parenthises
    {
        Open_Parnthises_Token? FirstOpen = null;
        bool First = true;
        List<Parser.Token.Token>? Ret = null;
        bool everything = false;
        public List<Parser.Token.Token>? Remove(ref List<Parser.Token.Token> Exp, int start, out int end)
        {
            end = start;
            if (Exp[start] is not Open_Parnthises_Token)
            {
                return null;
            }
            else
            {
                if (Exp[start] is Open_Parnthises_Token)
                {
                    if (First)
                    {
                        First = false;
                        FirstOpen = ((Open_Parnthises_Token)Exp[start]);
                    }
                }
                else
                {
                    return null;
                }
                if (FirstOpen != null)
                {
                    Ret = new List<Token>();
                    while (Exp != null && start < Exp.Count
                        && !(Exp[start] is Close_Parnthises_Token &&
                        ((Close_Parnthises_Token)Exp[start]).Id == FirstOpen.Id))
                    {
                        if(Exp[start] is Open_Parnthises_Token && 
                            ((Open_Parnthises_Token)Exp[start]).Id == FirstOpen.Id)
                        {
                            start++;
                            continue;
                        }
                        Ret.Add(Exp[start++]);

                        if (Exp != null && start < Exp.Count && (Exp[start] is Close_Parnthises_Token &&
                        ((Close_Parnthises_Token)Exp[start]).Id == FirstOpen.Id))
                        {
                            everything = true;
                            break;
                        }
                    }
                    if (!everything)
                    {
                        throw new Exception("\nFORGETTEN PARENTHISES\n");
                    }
                    end = start;
                }
            }
            return Ret;
        }
    }
}
