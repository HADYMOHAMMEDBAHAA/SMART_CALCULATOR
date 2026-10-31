using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Functions_Executers
{
    public class Plus_Function_Executer_Number : Function_Executer
    {
        public override Primary.Primary_Value.Primary_Value Execute(List<Primary.Primary_Value.Primary_Value> Inputs)
        {
            if (Inputs.Count == 0)
            {
                throw new Exception("No inputs provided for the Plus function.");
            }

            Primary.Primary_Value.Primary_Value result = 
                new Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value 
                { Value = new Number_Type { Value = 0 } };

            foreach (Primary.Primary_Value.Primary_Value input in Inputs)
            {
                ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)result).Value.Value +=
                    ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)input).Value.Value;
            }
            return result;
        }



    }



    public class Plus_Function_Executer_List : Function_Executer
    {
        public override Primary.Primary_Value.Primary_Value Execute(List<Primary.Primary_Value.Primary_Value> Inputs)
        {
            if (Inputs.Count != 2)
            {
                throw new Exception("No inputs provided for the Plus function.");
            }
            if (Inputs[0] is Registery.Primary_Values.List_Primary_Value.List_Primary_Value &&
                Inputs[1] is Registery.Primary_Values.List_Primary_Value.List_Primary_Value)
            {
                if (((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[0]).Value.Count == 0 &&
                    ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[1]).Value.Count == 0)
                {
                    throw new Exception("Empty Lists ");
                }
                if (((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[0]).Value.Count >=
                    ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[1]).Value.Count)
                {
                    for (int i = 0; i < ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[1]).Value.Count; i++)
                    {
                        ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[1]).Value[i].Value +=
                            ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[0]).Value[i].Value;
                    }
                    return Inputs[1];
                }
                else
                {
                    for (int i = 0; i < ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[0]).Value.Count; i++)
                    {
                        ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[0]).Value[i].Value +=
                            ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[1]).Value[i].Value;
                    }
                    return Inputs[0];
                }
            }
            else if (Inputs[0] is Registery.Primary_Values.List_Primary_Value.List_Primary_Value &&
                Inputs[1] is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)
            {
                for (int i = 0; i < ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[0]).Value.Count; i++)
                {
                    ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[0]).Value[i].Value +=
                        ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)Inputs[1]).Value.Value;
                }
                return Inputs[0];
            }
            else if (Inputs[0] is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value &&
                Inputs[1] is Registery.Primary_Values.List_Primary_Value.List_Primary_Value)
            {
                for (int i = 0; i < ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[1]).Value.Count; i++)
                {
                    ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[1]).Value[i].Value +=
                        ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)Inputs[0]).Value.Value;
                }
                return Inputs[1];
            }
            else
            {
                throw new Exception("Invalid input types for the Plus function.");
            }
        }
    }



    public class Plus_Function_Executer_Matrix : Function_Executer
    {
        public override Primary.Primary_Value.Primary_Value Execute(List<Primary.Primary_Value.Primary_Value> Inputs)
        {
            if (Inputs.Count != 2)
            {
                throw new Exception("No inputs provided for the Plus function.");
            }
            if (Inputs[0] is Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value &&
                Inputs[1] is Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)
            {
                if (((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[0]).Value.Count == 0 &&
                    ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[1]).Value.Count == 0)
                {
                    throw new Exception("Empty Matrices ");
                }
                if (((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[0]).Value.Count ==
                    ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[1]).Value.Count)
                {
                    for (int i = 0; i < ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[1]).Value.Count; i++)
                    {
                        for (int j = 0; j < ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[1]).Value[i].Count; j++)
                        {
                            ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[1]).Value[i][j].Value +=
                                ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[0]).Value[i][j].Value;
                        }
                    }
                    return Inputs[1];
                }
                else
                {
                    throw new Exception("Must Matrices be equal");
                }
            }
            else if (Inputs[0] is Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value &&
                Inputs[1] is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)
            {
                for (int i = 0; i < ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[0]).Value.Count; i++)
                {
                    for (int j = 0; j < ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[0]).Value[i].Count; j++)
                    {
                        ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[0]).Value[i][j].Value +=
                            ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)Inputs[1]).Value.Value;
                    }
                }
                return Inputs[0];
            }
            else if (Inputs[0] is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value &&
                Inputs[1] is Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)
            {
                for (int i = 0; i < ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[1]).Value.Count; i++)
                {
                    for (int j = 0; j < ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[1]).Value[i].Count; j++)
                    {
                        ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[1]).Value[i][j].Value +=
                            ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)Inputs[0]).Value.Value;
                    }
                }
                return Inputs[1];
            }
            else
            {
                throw new Exception("Invalid input types for the Plus function.");
            }
        }
    }




}
