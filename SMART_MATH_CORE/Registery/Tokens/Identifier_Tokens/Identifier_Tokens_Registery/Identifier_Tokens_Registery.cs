using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Identifier_Tokens.Identifier_Tokens_Registery
{
    public class Identifier_Tokens_Registery 
    {
        private static List<Parser.Token.Identifires_Token>? _identifierTokens;
        private static Dictionary<string, Parser.Token.Identifires_Token>? _identifierTokensDictionary;
        private static void InitializeIdentifierTokens()
        {
            if (_identifierTokens == null)
            {
                _identifierTokens = new List<Parser.Token.Identifires_Token>()
                {
                    new Identifier_Tokens.Open_Parnthises_Token(),
                    new Identifier_Tokens.Close_Parnthises_Token(),
                    new Identifier_Tokens.Bi_Token(),
                    new Identifier_Tokens.Open_Bracket_Token(),
                    new Identifier_Tokens.Close_Bracket_Token(),
                    new Identifier_Tokens.Open_Curly_Bracket_Token(),
                    new Identifier_Tokens.Close_Curly_Bracket_Token(),
                    new Identifier_Tokens.Comma_Token(),
                };
                _identifierTokensDictionary = _identifierTokens.ToDictionary(token => token.Name, token => token);
            }
            if (_identifierTokensDictionary == null)
            {

                if (_identifierTokensDictionary == null)
                    _identifierTokensDictionary = new Dictionary<string, Parser.Token.Identifires_Token>();

                foreach (Parser.Token.Identifires_Token token in _identifierTokens)
                {
                    if (token.Aliases != null)
                    {
                        foreach (string alias in token.Aliases)
                        {
                            if (!_identifierTokensDictionary!.ContainsKey(alias))
                            {
                                _identifierTokensDictionary.Add(alias, token);
                            }
                        }
                    }
                }
            }
        }

        public static Parser.Token.Identifires_Token? GetIdentifierTokenByName(string name)
        {
            InitializeIdentifierTokens();
            if (_identifierTokens != null && _identifierTokensDictionary != null && name != null && name.Length > 0)
            {
                if (_identifierTokensDictionary.TryGetValue(name, out Parser.Token.Identifires_Token? token))
                {
                    return token;
                }
            }
            return null;
        }

        public static List<Parser.Token.Identifires_Token> GetAllIdentifierTokens()
        {
            InitializeIdentifierTokens();
            return _identifierTokens ?? new List<Parser.Token.Identifires_Token>();
        }
    }
}

