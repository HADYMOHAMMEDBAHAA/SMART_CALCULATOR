using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Input_Tokens
{
    /*
     * {1,2,3,4,5} this is a list our System Can do some available operation
     * like add 2 to each element in the list or multiply each element by 3 and so on
     * or can add two lists together or multiply two lists together and so on
     */
    public class List_Token : Parser.Token.Input_Token
    {
        public List_Token()
        {
            this.Type = Parser.Token.TokenType.Input;
            this.InputType = Parser.Token.InputType.List;
        }
        public List<string>? Values { get; set; }

        public override void ShowTwo()
        {
            string output =
                $"Token Type : {Type} , Token Name : {Name} , Token Value : {Value} , Input Type : {InputType}\n";
            if (Values != null)
            {
                output += "Values : { " + string.Join(", ", Values) + " }\n";
            }
            else
            {
                output += "Values : null\n";
            }
            Console.WriteLine(output);
        }
     }
}
