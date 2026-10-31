using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Identifier_Tokens
{
    public class Open_Curly_Bracket_Token : Parser.Token.Identifires_Token
    {
        public Open_Curly_Bracket_Token()
        {
            this.Name = "Open_Curly_Bracket";
            this.Aliases = new List<string>() { "{", "Open_Curly_Bracket" };
            this.Value = "{";
        }
    }

    public class Close_Curly_Bracket_Token : Parser.Token.Identifires_Token
    {
        public Close_Curly_Bracket_Token()
        {
            this.Name = "Close_Curly_Bracket";
            this.Aliases = new List<string>() { "}", "Close_Curly_Bracket" };
            this.Value = "}";
        }

    }
}
