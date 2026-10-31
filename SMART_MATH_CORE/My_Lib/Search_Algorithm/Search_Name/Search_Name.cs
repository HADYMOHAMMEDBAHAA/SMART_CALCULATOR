using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.My_Lib.Search_Algorithm.Search_Name
{
    internal class Search_Name
    {
        public string? Search(string name,List<string> list , int start , out int end)
        {
            end = start;
            int indexname = start;
            if(list == null || list.Count == 0)
            {
                return null;
            }
            if (name == null || name.Length == 0)
            {
                return null;
            }
            foreach ( string item in list)
            {
                indexname = start;
                int indexToItem = 0;
                while (indexname < name.Length && indexToItem < item.Length)
                {
                    if (Char.ToLower(name[indexname]) != Char.ToLower(item[indexToItem]))
                    {
                        break;
                    }
                    if (indexToItem == item.Length-1)
                    {
                        end = indexname + 1; //Where next search will start
                        return item;
                    }
                    indexname++;
                    indexToItem++;
                }
               
            }
            return null;
        }
    }
}
