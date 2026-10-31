using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Identifier_Tokens.Identifier_Tokens_Recognizer
{
    class Parenthises_Identity
    {
        public class Parenthises_Id
        {
            public int Id { get; set; }
            public Parser.Token.Identifires_Token? Open_Parenthises { get; set; }
            public Parser.Token.Identifires_Token? Close_Parenthises { get; set; }
                
        }


        public static Dictionary<string,List<Parenthises_Id>> Parenthises_Tokens = 
            new Dictionary<string, List<Parenthises_Id>>();

        public static void Add_Open(
     ref string text,
     ref Parser.Token.Identifires_Token tok)
        {
            Registery.Tokens.Identifier_Tokens.Open_Parnthises_Token open = new();

            int nextId = Parenthises_Tokens
                .Values
                .SelectMany(list => list)
                .Select(p => p.Id)
                .DefaultIfEmpty(0)
                .Max() + 1;

            open.Id = nextId;

            Parenthises_Id newParenthesis = new()
            {
                Id = open.Id,
                Open_Parenthises = open
            };

            if (!Parenthises_Tokens.ContainsKey(text))
                Parenthises_Tokens.Add(text, new List<Parenthises_Id>());

            Parenthises_Tokens[text].Add(newParenthesis);

            tok = open;
        }

        public static void Add_Close(
    ref string text,
    ref Parser.Token.Identifires_Token tok)
        {
            if (!Parenthises_Tokens.ContainsKey(text))
                throw new Exception("TOKENIZER ERROR NO OPEN PARENTHESIS");

            Parenthises_Id? IdForThisClose = Parenthises_Tokens
                .Values
                .SelectMany(list => list)
                .Where(p => p.Close_Parenthises == null)
                .MaxBy(p => p.Id);

            if (IdForThisClose == null)
                throw new Exception("TOKENIZER ERROR NO OPEN PARENTHESIS");

            Registery.Tokens.Identifier_Tokens.Close_Parnthises_Token close = new();

            close.Id = IdForThisClose.Id;

            IdForThisClose.Close_Parenthises = close;

            tok = close;
        }
    }


    class Indentifier_Tokens_Recognizer : Parser.Token_Recognizer.Token_Recognizer
     {
        

        Parser.Token.Identifires_Token? Iden;
        public override Parser.Token.Identifires_Token? Recognize(string text, int start, out int end)
        {
            end = start;
            string? NameFound;
            SMART_MATH_CORE.My_Lib.Search_Algorithm.Search_Name.Search_Name search =
                       new My_Lib.Search_Algorithm.Search_Name.Search_Name();
            if (text != null && text.Length > 0 && start < text.Length)
            {
                foreach (Parser.Token.Identifires_Token identifire in
                   Registery.Tokens.Identifier_Tokens.Identifier_Tokens_Registery.
                   Identifier_Tokens_Registery.GetAllIdentifierTokens())
                {
                    NameFound = search.Search(text, identifire.Aliases!, start, out end);
                    if (NameFound != null)
                    {
                        Iden = identifire;

                        if(Iden is Registery.Tokens.Identifier_Tokens.Open_Parnthises_Token)
                        {
                            
                            Parenthises_Identity.Add_Open(ref text,ref Iden);
                        }
                        if (Iden is Registery.Tokens.Identifier_Tokens.Close_Parnthises_Token)
                        {
                            Parenthises_Identity.Add_Close(ref text,ref Iden);
                        }
                        return Iden;
                    }
                }

            }
            return null;
        }
    }
}
