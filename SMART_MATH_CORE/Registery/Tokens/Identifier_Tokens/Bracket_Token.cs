using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Identifier_Tokens
{
    public class Open_Bracket_Token : Parser.Token.Identifires_Token
    {
        public Open_Bracket_Token()
        {
            this.Name = "Open_Bracket";
            this.Aliases = new List<string>() { "[", "Open_Bracket" };
            this.Value = "[";
        }
    }

    public class Close_Bracket_Token : Parser.Token.Identifires_Token
    {
        public Close_Bracket_Token()
        {
            this.Name = "Close_Bracket";
            this.Aliases = new List<string>() { "]", "Close_Bracket" };
            this.Value = "]";
        }
    }



}
