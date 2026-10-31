using SMART_MATH_CORE.My_Lib.Search_Algorithm.Search_Name;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Function_Tokens.Function_Token_Registery
{
    public class Function_Token_Registery
    {
        private static List<Parser.Token.Function_Token>? _functionTokens;
        private static Dictionary<string, Parser.Token.Function_Token>? _functionTokensDictionary;
        private static void InitializeFunctionTokens()
        {
            if (_functionTokens == null)
            {
                _functionTokens = new List<Parser.Token.Function_Token>()
                {
                    new Cos_Token(),
                    new Sin_Token(),
                    new Tan_Token(),
                    new Log_Token(),
                };
                _functionTokensDictionary = _functionTokens.ToDictionary(token => token.Name, token => token);
            }

            if (_functionTokensDictionary == null)
            {
                _functionTokensDictionary = _functionTokens.ToDictionary(token => token.Name, token => token);
            }
        }

        public static Parser.Token.Function_Token? GetFunctionTokenByName(string name)
        {
            InitializeFunctionTokens();
            if (_functionTokens != null && _functionTokensDictionary != null && name != null && name.Length > 0)
            {

                foreach ( Parser.Token.Function_Token func in _functionTokensDictionary.Values)
                {
                   foreach (string funcName in func.Aliases!)
                    {
                        if (funcName.Equals(name, StringComparison.OrdinalIgnoreCase))
                        {
                            return func;
                        }
                    }
                }
            }
            return null;
        }

        public static List<Parser.Token.Function_Token> GetAllFunctionTokens()
        {
            InitializeFunctionTokens();
            return _functionTokens ?? new List<Parser.Token.Function_Token>();
        }
    }
}
