using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Identifier_Tokens
{
    public class Open_Parnthises_Token : Parser.Token.Identifires_Token
    {
        public int Id { get; set; }
        public Open_Parnthises_Token()
        {
            this.Id = 0;
            this.Name = "Open_Parnthises";
            this.Aliases = new List<string>() { "(", "Open_Parnthises" };
            this.Value = "(";
        }

        public override void Show()
        {
            string output =
                $"Token Type : {Type} , Token Name : {Name} , Token Value : {Value} , Token Id : {Id}\n";
            Console.WriteLine(output);
        }
    }

    public class Close_Parnthises_Token : Parser.Token.Identifires_Token
    {
        public int Id { get; set; }
        public Close_Parnthises_Token()
        {
            this.Id = 0;
            this.Name = "Close_Parnthises";
            this.Aliases = new List<string>() { ")", "Close_Parnthises" };
            this.Value = ")";
        }

        public override void Show()
        {
            string output =
                $"Token Type : {Type} , Token Name : {Name} , Token Value : {Value} , Token Id : {Id}\n";
            Console.WriteLine(output);
        }
    }

    
   
}
