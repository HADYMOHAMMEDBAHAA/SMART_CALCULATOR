using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Primary.Primary_To_String
{
    public interface Convert_Primary_To_String
    {
        public List<string> ConvertPrimaryToString(Primary.Primary_Value.Primary_Value primary_);
    }

     class Primary_Number_To_String : Convert_Primary_To_String
    {
        public List<string> ConvertPrimaryToString(Primary.Primary_Value.Primary_Value primary_)
        {
            List<string> result = new List<string>();
            if (primary_ is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value )
            {
                result.Add(" ");
                result.Add
                    ((((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)primary_).Value.Value).ToString());
                result.Add(" ");
                return result;
            }
            else
            {
                throw new ArgumentException("Input must be of type Primary_Number.");
            }
            
        }
    }

    public class Primary_List_To_String : Convert_Primary_To_String
    {
        public List<string> ConvertPrimaryToString(Primary.Primary_Value.Primary_Value primary_)
        {
            List<string> result = new List<string>();
            if (primary_ is Registery.Primary_Values.List_Primary_Value.List_Primary_Value)
            {
                Registery.Primary_Values.List_Primary_Value.List_Primary_Value list_ =
                    (Registery.Primary_Values.List_Primary_Value.List_Primary_Value)primary_;
                foreach (Number_Type item in list_.Value)
                {
                    result.Add(" ");
                    result.Add(item.Value.ToString());
                    result.Add(" ");
                }
                result.Add("\n");
                return result;
            }
            else
            {
                throw new ArgumentException("Input must be of type Primary_Number.");
            }

        }
    }


     class Primary_Matrix_To_String : Convert_Primary_To_String
    {
        public List<string> ConvertPrimaryToString(Primary.Primary_Value.Primary_Value primary_)
        {
            List<string> result = new List<string>();

            if (primary_ is Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)
            {
                Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value list_ =
                    (Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)primary_;
                foreach (List<Number_Type> item in list_.Value)
                {
                   foreach (Number_Type item2 in item)
                    {
                        result.Add(" ");
                        result.Add(item2.Value.ToString());
                        result.Add(" ");
                    }
                    result.Add("\n");
                }
                return result;
            }
            else
            {
                throw new ArgumentException("Input must be of type Primary_Number.");
            }

        }
    }

    public class Primary_Cinversion : Convert_Primary_To_String
    {
        public List<string> ConvertPrimaryToString(Primary.Primary_Value.Primary_Value primary_)
        {
            if(primary_ is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)
            {
                Primary_Number_To_String primary_Number_To_String = new Primary_Number_To_String();
                return primary_Number_To_String.ConvertPrimaryToString(primary_);
            }
            else if(primary_ is Registery.Primary_Values.List_Primary_Value.List_Primary_Value)
            {
                Primary_List_To_String primary_List_To_String = new Primary_List_To_String();
                return primary_List_To_String.ConvertPrimaryToString(primary_);
            }
            else if(primary_ is Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)
            {
                Primary_Matrix_To_String primary_Matrix_To_String = new Primary_Matrix_To_String();
                return primary_Matrix_To_String.ConvertPrimaryToString(primary_);
            }
            else
            {
                throw new ArgumentException("Input must be of type Primary_Number, Primary_List, or Primary_Matrix.");
            }
        }
    }
}
