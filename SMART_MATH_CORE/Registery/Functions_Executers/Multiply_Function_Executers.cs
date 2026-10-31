using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Functions_Executers
{
    public class Multiply_Function_Executer_Number : Function_Executer
    {
        public override Primary.Primary_Value.Primary_Value Execute(List<Primary.Primary_Value.Primary_Value> Inputs)
        {
            if (Inputs.Count == 0)
            {
                throw new Exception("No inputs provided for the Multiply function.");
            }
            Primary.Primary_Value.Primary_Value result = 
                new Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value 
                { Value = new Number_Type { Value = 1 } };

            foreach (Primary.Primary_Value.Primary_Value input in Inputs)
            {
                ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)result).Value.Value *=
                    ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)input).Value.Value;
            }
            return result;
        }

    }


    public class Multiply_Function_Executer_List : Function_Executer
    {
        public override Primary.Primary_Value.Primary_Value Execute(List<Primary.Primary_Value.Primary_Value> Inputs)
        {
            if (Inputs.Count != 2)
            {
                throw new Exception("No inputs provided for the Multiply function.");
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
                        ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[1]).Value[i].Value *=
                            ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[0]).Value[i].Value;
                    }
                    return Inputs[1];
                }
                else
                {
                    for (int i = 0; i < ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[0]).Value.Count; i++)
                    {
                        ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[0]).Value[i].Value *=
                            ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[1]).Value[i].Value;
                    }
                    return Inputs[0];
                }
            }
            else if (Inputs[0] is Registery.Primary_Values.List_Primary_Value.List_Primary_Value &&
                     Inputs[1] is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)
            {
                foreach (Number_Type item in ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[0]).Value)
                {
                    item.Value *= ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)Inputs[1]).Value.Value;
                }
                return Inputs[0];
            }
            else if (Inputs[0] is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value &&
                     Inputs[1] is Registery.Primary_Values.List_Primary_Value.List_Primary_Value)
            {
                foreach (Number_Type item in ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[1]).Value)
                {
                    item.Value *= ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)Inputs[0]).Value.Value;
                }
                return Inputs[1];
            }
            else
            {
                throw new Exception("Invalid input types for the Multiply function.");
            }
        }
    }


    public class Multiply_Function_Executer_Matrix : Function_Executer
    {
        bool IF_Can_Multiply(Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value A,
           Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value B)
        {
            int colnumB = B.Value[0].Count; //Semetry B?
            foreach (List<Number_Type> col in B.Value)
            {
                if (col.Count != colnumB)
                {
                    return false;
                    // Un Semetry matrix
                }
            }

            int colnumA = A.Value[0].Count;
            foreach (List<Number_Type> col in A.Value)
            {
                if (col.Count != colnumA)
                {
                    return false;
                    // Un Semetry matrix
                }
            }

            if (colnumA != B.Value.Count)
            {
                return false;
                //Can not multiply
            }
            return true;
        }

        Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value Multiply_Two_Matrices
    (Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value A,
     Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value B)
        {
            if (!IF_Can_Multiply(A, B))
            {
                throw new Exception("Cannot multiply these matrices.");
            }

            var Result = new Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value();

            for (int i = 0; i < A.Value.Count; i++)
            {
                List<Number_Type> row = new List<Number_Type>();

                for (int j = 0; j < B.Value[0].Count; j++)
                {
                    double sum = 0;

                    for (int k = 0; k < B.Value.Count; k++)
                    {
                        sum += A.Value[i][k].Value * B.Value[k][j].Value;
                    }

                    row.Add(new Number_Type { Value = sum });
                }

                Result.Value.Add(row);
            }

            return Result;
        }
        public override Primary.Primary_Value.Primary_Value Execute(List<Primary.Primary_Value.Primary_Value> Inputs)
        {
            if (Inputs.Count != 2)
            {
                throw new Exception("No inputs provided for the Multiply function.");
            }
            if (Inputs[0] is Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value &&
                Inputs[1] is Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)
            {
                if (((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[0]).Value.Count == 0 &&
                    ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[1]).Value.Count == 0)
                {
                    throw new Exception("Empty Matrices ");
                }

                return Multiply_Two_Matrices(((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[0]),
                    ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[1]));


            }
            else if (Inputs[0] is Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value &&
                     Inputs[1] is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)
            {
                foreach (List<Number_Type> row in ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[0]).Value)
                {
                    foreach (Number_Type item in row)
                    {
                        item.Value *= ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)Inputs[1]).Value.Value;
                    }
                }
                return Inputs[0];
            }
            else if (Inputs[0] is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value &&
                     Inputs[1] is Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)
            {
                foreach (List<Number_Type> row in ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[1]).Value)
                {
                    foreach (Number_Type item in row)
                    {
                        item.Value *= ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)Inputs[0]).Value.Value;
                    }
                }
                return Inputs[1];
            }
            else
            {
                throw new Exception("Invalid input types for the Multiply function.");
            }
        }
    }
}
