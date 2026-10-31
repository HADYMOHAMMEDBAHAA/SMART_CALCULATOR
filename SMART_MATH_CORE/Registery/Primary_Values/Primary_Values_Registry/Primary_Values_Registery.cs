using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Primary_Values.Primary_Values_Registry
{
    public class Primary_Values_Registery
    {
        static Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value Number_Primary_Value =
            new Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value();
        static Registery.Primary_Values.List_Primary_Value.List_Primary_Value List_Primary_Value =
            new Registery.Primary_Values.List_Primary_Value.List_Primary_Value();
        static Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value Matrix_Primary_Value =
            new Matrix_Primary_VaLue.Matrix_Primary_Value();
        static List<Primary.Primary_Value.Primary_Value> Primary_Values =
            new List<Primary.Primary_Value.Primary_Value>();
        static void Initialize()
        {
            Primary_Values.Add(Matrix_Primary_Value);
            Primary_Values.Add(List_Primary_Value);
            Primary_Values.Add(Number_Primary_Value);
        }

        static public List<Primary.Primary_Value.Primary_Value> Get_Primary_values()
        {
            if (Primary_Values.Count == 0)
            {
                Initialize();
            }
            return Primary_Values;
        }

        static public Primary.Primary_Value.Primary_Value? IsPrimary(Parser.Token.Token token)
        {
            foreach (Primary.Primary_Value.Primary_Value primary in Get_Primary_values())
            {
                Primary.Primary_Value.Primary_Value? p = primary.Is_Primary(token);
                if(p != null)
                {
                    return p;
                }
            }
            return null;
        }
    }
}
