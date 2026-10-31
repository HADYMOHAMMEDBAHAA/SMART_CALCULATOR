using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Parser.Token
{
    /// <summary>
    ///   <Name> 
    ///   Every Token have name for example "+" 
    ///   when string have + so its a plus token 
    ///   </Name>
    ///   <Aliases>
    ///   All possible names token may have
    ///   </Aliases>
    /// </summary>
    public class Token
    {
        public TokenType Type { get; set; } = TokenType.None;
        public string Name { get; set; } = string.Empty;
        public List<string>? Aliases { get; set; }
        public string Value { get; set; }= string.Empty;

        public virtual void Show()
        {
            string output =
                $"Token Type : {Type} , Token Name : {Name} , Token Value : {Value}\n";
            Console.WriteLine(output);
      
        }
    }
}
