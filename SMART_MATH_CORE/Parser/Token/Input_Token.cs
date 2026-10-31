using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Parser.Token
{
    public enum InputType
    {
        None,
        Number,
        List,
        Matrix,
    }
    public class Input_Token : Token
    {
        public InputType InputType { get; set; } = InputType.None;
        public Input_Token() 
        {
          this.Type = TokenType.Input;
        }

        public virtual void ShowTwo()
        {

            string output =
                $"Token Type : {Type} , Token Name : {Name} , Token Value : {Value} , Input Type : {InputType}\n";
            Console.WriteLine(output);
        }
        public  override void Show()
        {
            ShowTwo();
        }
    }


}
