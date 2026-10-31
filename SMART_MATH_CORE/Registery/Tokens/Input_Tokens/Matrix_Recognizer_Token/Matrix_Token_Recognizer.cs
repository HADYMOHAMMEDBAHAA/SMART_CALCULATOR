using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Tokens.Input_Tokens.Matrix_Recognizer_Token
{
    public class Matrix_Token_Recognizer : Parser.Token_Recognizer.Token_Recognizer
    {
        
        public override Registery.Tokens.Input_Tokens.Matrix_Token? Recognize
            (string text, int start, out int end)
        {
            int originalstart = start;
            end = start;
            Registery.Tokens.Input_Tokens.Matrix_Token? matrix= null;
            bool Matrixcolumnset = false;
            bool OpenCurlybracket = false;
            bool CloseCurlybracket = false;
            bool firsttime = true;
            while(text != null && start < text.Length && text.Length > 0)
            {
                if (firsttime && text[originalstart] == '{')
                {
                    firsttime = false;
                    OpenCurlybracket=true;
                    start++;
                    continue;
                }
                if (firsttime && text[originalstart] != '{')
                {
                    break;
                }

                if (( text[start]=='}') && !OpenCurlybracket) 
                {
                    matrix = null;
                    break;
                }
                if (text[start]=='}' && OpenCurlybracket)
                {
                    CloseCurlybracket = true;
                    end = start + 1;
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
                if (numbers != null && numbers.Count > 0)
                {
                    if (matrix == null)
                    {
                        matrix = new Matrix_Token();
                    }
                    matrix.Row_Nums ++;

                    if (!Matrixcolumnset)
                    {
                        matrix.Col_Nums = numbers.Count;
                        Matrixcolumnset = true;
                    }
                    else if (numbers.Count != matrix.Col_Nums)
                    {
                        matrix = null;
                        return null;
                    }

                    if (matrix.Values == null)
                    {
                        matrix.Values = new List<List<string>>();
                    }
                    matrix.Values.Add(numbers);
                    start = end;
                }
                else
                {
                    matrix = null;
                    break;
                }
            }
           
            if(OpenCurlybracket != CloseCurlybracket || matrix == null)
            {
                end = originalstart;
                matrix = null;
                return null;
            }
            return matrix;
        }
    }
}
