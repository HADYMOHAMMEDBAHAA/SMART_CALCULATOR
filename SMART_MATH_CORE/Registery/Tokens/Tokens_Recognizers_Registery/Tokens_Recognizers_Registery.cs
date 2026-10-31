using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Tokens_Recognizers_Registery
{
    public class Tokens_Recognizers_Registery
    {
        private List<Parser.Token_Recognizer.Token_Recognizer> Recoginzers_list =
            new List<Parser.Token_Recognizer.Token_Recognizer>();
        private bool initialized = false;
        private void Initailize_Recognizers()
        {
            Recoginzers_list.Add(new Registery.Tokens.Input_Tokens.Matrix_Recognizer_Token.Matrix_Token_Recognizer());
            Recoginzers_list.Add(new Registery.Tokens.Input_Tokens.List_Recognizer_Token.List_Recognizer_Token());
            Recoginzers_list.Add(new Registery.Tokens.Input_Tokens.Number_Recognizer_Token.Number_Recognizer_Token());
            Recoginzers_list.Add(new Registery.Tokens.Identifier_Tokens.Identifier_Tokens_Recognizer.Indentifier_Tokens_Recognizer());
            Recoginzers_list.Add(new Registery.Tokens.Function_Tokens.Function_Token_Recognizer.Function_Token_Recognize());
            Recoginzers_list.Add(new Registery.Tokens.Operators_Tokens.Operators_Recognizer_Token.Operator_Recognize_Token());
        }

        public List<Parser.Token_Recognizer.Token_Recognizer> Get_Recognizers()
        {
            if (!initialized) { Initailize_Recognizers(); initialized = true; }
            return Recoginzers_list;
        }


    }
}
