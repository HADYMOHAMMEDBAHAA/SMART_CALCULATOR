using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Parser.Token
{
    public class Identifires_Token : Token
    {
        public Identifires_Token()
        {
            this.Type = TokenType.Identifier;
        }
        
        public virtual void ShowTwo()
        {
            string output =
                $"Token Type : {Type} , Token Name : {Name} , Token Value : {Value}\n";
            Console.WriteLine(output);
        }
        public override void Show()
        {
          ShowTwo();
        }
    }
}
