using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Operators_Tokens.Operators_Registry_Token
{
    public class Operators_Registery_Token 
    {
        private static List<Parser.Token.Operator_Token>? _OperatorTokens;
        private static Dictionary<string, Parser.Token.Operator_Token>? _OperatorTokensDictionary;
        private static void InitializeOperatorTokens()
        {
            if (_OperatorTokens == null)
            {
                _OperatorTokens = new List<Parser.Token.Operator_Token>()
                {
                    new Plus_Token(),
                    new Minus_Token(),
                    new Divide_Token(),
                    new Multiply_Token(),
                    new Power_Token(),
                    new Reminder_Token(),
                    new Root_Token()
                };
                _OperatorTokensDictionary = _OperatorTokens.ToDictionary(token => token.Name, token => token);
            }

            if (_OperatorTokensDictionary == null)
            {
                _OperatorTokensDictionary = _OperatorTokens.ToDictionary(token => token.Name, token => token);
            }
        }

        public static Parser.Token.Operator_Token? GetOperaterTokenByName(string name)
        {
            InitializeOperatorTokens();
            if (_OperatorTokens != null && _OperatorTokensDictionary != null && name != null && name.Length > 0)
            {

                foreach (Parser.Token.Operator_Token Operator in _OperatorTokensDictionary.Values)
                {
                    foreach (string OperatorName in Operator.Aliases!)
                    {
                        if (OperatorName.Equals(name, StringComparison.OrdinalIgnoreCase))
                        {
                            return Operator;
                        }
                    }
                }
            }
            return null;
        }

        public static List<Parser.Token.Operator_Token> GetAllOperatorsTokens()
        {
            InitializeOperatorTokens();
            return _OperatorTokens ?? new List<Parser.Token.Operator_Token>();
        }
    }
}
