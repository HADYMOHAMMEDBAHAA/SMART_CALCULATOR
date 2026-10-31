using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.My_Lib.Read_Numbers_List
{
    public class Extract_Numbers_List
    {

        public List<string>? Extract(string text, int start, out int end)
        {
            List<string>? numbers = new List<string>();
            string? num = null;
            end = start;
            int originalstart = start;
            int currerntpositionnumber = start;
            int countnums = 0;
            SMART_MATH_CORE.My_Lib.Read_Number.Read_Number read_number
                = new SMART_MATH_CORE.My_Lib.Read_Number.Read_Number();
            bool OpenCurlyBrackets = false;
            bool CloseCurlyBrackets = false;
            while (text != null && start < text.Length && text.Length > 0 && currerntpositionnumber < text.Length)
            {
                if(currerntpositionnumber == originalstart && text[currerntpositionnumber] == '{')
                {
                    OpenCurlyBrackets = true;
                    currerntpositionnumber++;
                    continue;
                }
                if (OpenCurlyBrackets && text[currerntpositionnumber] == '}')
                {
                    CloseCurlyBrackets = true;
                    end = currerntpositionnumber + 1;
                    break;
                }
                if (text[currerntpositionnumber] == ' ' || text[currerntpositionnumber] == ',' )
                {
                    currerntpositionnumber++;
                    continue;
                }
                num = read_number.Read(text, currerntpositionnumber, out end);
                if (num != null)
                {
                    numbers.Add(num);
                    countnums++;
                    currerntpositionnumber = end;
                    num = null;
                    continue;
                }
                else
                {

                    break;
                }
            }

 
            if (OpenCurlyBrackets == CloseCurlyBrackets  && numbers != null && numbers.Count > 1)
            {
                end = currerntpositionnumber + 1;
                return numbers;
            }
            else if(OpenCurlyBrackets != CloseCurlyBrackets)
            {
                end = originalstart;
                return null;
            }
            else
            {
                end = originalstart;
            }
             return null;
        }
    }
}

