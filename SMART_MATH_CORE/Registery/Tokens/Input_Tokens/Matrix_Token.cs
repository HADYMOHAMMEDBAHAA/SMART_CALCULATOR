using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Input_Tokens
{
    /*
     *   _        _
     *  |   2  3 4 |
     *  |   1  2 4 |
     *  |_        _|2x3 for 
     *  example {{2,3,4},{1,2,4}} this is a matrix our System Can do some 
     *  available operation
     */
    public class Matrix_Token : Parser.Token.Input_Token
    {
        public List<List<string>>? Values { get; set; }
        public int Row_Nums { get; set; } = default;
        public int Col_Nums { get; set; } = default;
        public SMART_MATH_CORE.My_Lib.Matrix.Matrix_Values? Matrix_Values { get; set; } 
            
        public Matrix_Token()
        {
            this.Type = Parser.Token.TokenType.Input;
            this.InputType = Parser.Token.InputType.Matrix;
        }

        public override void ShowTwo()
        {
            string output =
                $"Token Type : {Type} , Token Name : {Name} , Token Value : {Value} , Input Type : {InputType}\n";
            if (Values != null)
            {
                output += "Values : \n";
                foreach (var row in Values)
                {
                    output += "{ " + string.Join(", ", row) + " }\n";
                }
            }
            else
            {
                output += "Values : null\n";
            }
            Console.WriteLine(output);
        }
    }


    
}
