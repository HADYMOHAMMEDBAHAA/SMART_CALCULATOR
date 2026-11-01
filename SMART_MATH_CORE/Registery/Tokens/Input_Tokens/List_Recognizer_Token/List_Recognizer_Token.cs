using SMART_MATH_CORE.My_Lib.Matrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Input_Tokens.List_Recognizer_Token
{
    public class List_Recognizer_Token : SMART_MATH_CORE.Parser.Token_Recognizer.Token_Recognizer
    {
        public override Registery.Tokens.Input_Tokens.List_Token? Recognize
             (string text, int start, out int end)
        {
            int originalstart = start;
            end = start;
            Registery.Tokens.Input_Tokens.List_Token? list = null;
            bool OpenCurlybracket = false;
            bool CloseCurlybracket = false;
            bool firsttime = true;
            while (text != null && start < text.Length && text.Length > 0)
            {
                if (firsttime && text[start] == '{')
                {
                    firsttime = false;
                    start++;
                    OpenCurlybracket = true;
                    continue;
                }
                if(!firsttime && text[start] == '{')
                {
                    break;
                }
                if ((text[start] == '}') && !OpenCurlybracket)
                {
                    list = null;
                    break;
                }
                if (text[start] == '}' && OpenCurlybracket)
                {
                    CloseCurlybracket = true;
                    break;
                }
                if (text[start] == ' ' || text[start] == ',')
                {
                    start++;
                    continue;
                }

                SMART_MATH_CORE.My_Lib.Read_Numbers_List.Extract_Numbers_List extract_numbers_list
                = new SMART_MATH_CORE.My_Lib.Read_Numbers_List.Extract_Numbers_List();
                List<string>? numbers = extract_numbers_list.Extract(text, start, out end);
                if (numbers != null)
                {
                    if (list == null)
                    {
                        list = new List_Token();
                    }
                    if (numbers.Count > 1)
                    {
                        if (list.Values == null)
                        {
                            list.Values = new List<string>();
                        }
                        list.Values = numbers;
                        return list;
                    }
                    else
                    {
                        list = null;
                    }
                }
                if (OpenCurlybracket != CloseCurlybracket || list == null)
                {
                    end = originalstart;
                    list = null;
                    return null;
                }
            }
            return list;
        }
    }
}

