using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Functions_Executers
{

    public class Divide_Function_Executer_Number : Function_Executer
    {
        public override Primary.Primary_Value.Primary_Value Execute(List<Primary.Primary_Value.Primary_Value> Inputs)
        {
            if (Inputs.Count != 2)
            {
                throw new Exception("No inputs provided for the Divide function.");
            }
            if (Inputs[0] is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value &&
                Inputs[1] is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)
            {
                if (((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)Inputs[1]).Value.Value == 0)
                {
                    throw new Exception("Division by zero is not allowed.");
                }
                ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)Inputs[0]).Value.Value /=
                    ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)Inputs[1]).Value.Value;
                return Inputs[0];
            }
            else
            {
                throw new Exception("Invalid input types for the Divide function.");
            }
        }
    }



    public class Divide_Function_Executer_List : Function_Executer
    {
        public override Primary.Primary_Value.Primary_Value Execute(List<Primary.Primary_Value.Primary_Value> Inputs)
        {
            if (Inputs.Count != 2)
            {
                throw new Exception("No inputs provided for the Divide function.");
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
                        if (((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[1]).Value[i].Value == 0)
                        {
                            throw new Exception("Division by zero is not allowed.");
                        }
                        ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[1]).Value[i].Value /=
                            ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[0]).Value[i].Value;
                    }
                    return Inputs[1];
                }
                else
                {
                    for (int i = 0; i < ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[0]).Value.Count; i++)
                    {
                        if (((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[0]).Value[i].Value == 0)
                        {
                            throw new Exception("Division by zero is not allowed.");
                        }
                        ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[0]).Value[i].Value /=
                            ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[1]).Value[i].Value;

                    }
                    return Inputs[0];
                }
            }
            else if (Inputs[0] is Registery.Primary_Values.List_Primary_Value.List_Primary_Value &&
                Inputs[1] is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)
            {
                if (((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)Inputs[1]).Value.Value == 0)
                {
                    throw new Exception("Division by zero is not allowed.");
                }
                for (int i = 0; i < ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[0]).Value.Count; i++)
                {
                    ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[0]).Value[i].Value /=
                        ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)Inputs[1]).Value.Value;
                }
                return Inputs[0];
            }
            else if (Inputs[0] is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value &&
                Inputs[1] is Registery.Primary_Values.List_Primary_Value.List_Primary_Value)
            {
                for (int i = 0; i < ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[1]).Value.Count; i++)
                {
                    if (((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[1]).Value[i].Value == 0)
                    {
                        throw new Exception("Division by zero is not allowed.");
                    }
                    ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[1]).Value[i].Value =
                        ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)Inputs[0]).Value.Value /
                        ((Registery.Primary_Values.List_Primary_Value.List_Primary_Value)Inputs[1]).Value[i].Value;
                }
                return Inputs[1];
            }
            else
            {
                throw new Exception("Invalid input types for the Divide function.");
            }
        }
    }



    public class Divide_Function_Executer_Matrix : Function_Executer
    {
        bool IF_Can_Divide(
    Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value A,
    Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value B)
        {
            if (A.Value.Count == 0 || B.Value.Count == 0)
                return false;

            int A_Columns = A.Value[0].Count;
            int B_Columns = B.Value[0].Count;

            if (A.Value.Any(row => row.Count != A_Columns) ||
                B.Value.Any(row => row.Count != B_Columns))
                return false;

            if (B.Value.Count != B_Columns ||
                A_Columns != B.Value.Count)
                return false;

            int n = B.Value.Count;
            double[,] M = new double[n, 2 * n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    M[i, j] = B.Value[i][j].Value;

                M[i, i + n] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                int pivot = i;

                for (int r = i + 1; r < n; r++)
                {
                    if (Math.Abs(M[r, i]) > Math.Abs(M[pivot, i]))
                        pivot = r;
                }

                if (Math.Abs(M[pivot, i]) < 1e-12)
                    return false;

                for (int j = 0; j < 2 * n; j++)
                    (M[i, j], M[pivot, j]) = (M[pivot, j], M[i, j]);

                double divisor = M[i, i];

                for (int j = 0; j < 2 * n; j++)
                    M[i, j] /= divisor;

                for (int r = 0; r < n; r++)
                {
                    if (r == i)
                        continue;

                    double factor = M[r, i];

                    for (int j = 0; j < 2 * n; j++)
                        M[r, j] -= factor * M[i, j];
                }
            }

            return true;
        }


        Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value Divide_Two_Matrices(
            Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value A,
            Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value B)
        {
            if (!IF_Can_Divide(A, B))
                throw new Exception("Cannot divide these matrices.");

            int rowsA = A.Value.Count;
            int colsA = A.Value[0].Count;
            int n = B.Value.Count;

            double[,] M = new double[n, 2 * n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    M[i, j] = B.Value[i][j].Value;

                M[i, i + n] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                int pivot = i;

                for (int r = i + 1; r < n; r++)
                {
                    if (Math.Abs(M[r, i]) > Math.Abs(M[pivot, i]))
                        pivot = r;
                }

                for (int j = 0; j < 2 * n; j++)
                    (M[i, j], M[pivot, j]) = (M[pivot, j], M[i, j]);

                double divisor = M[i, i];

                for (int j = 0; j < 2 * n; j++)
                    M[i, j] /= divisor;

                for (int r = 0; r < n; r++)
                {
                    if (r == i)
                        continue;

                    double factor = M[r, i];

                    for (int j = 0; j < 2 * n; j++)
                        M[r, j] -= factor * M[i, j];
                }
            }

            var Result = new Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value();

            for (int i = 0; i < rowsA; i++)
            {
                var row = new List<Number_Type>();

                for (int j = 0; j < n; j++)
                {
                    double sum = 0;

                    for (int k = 0; k < n; k++)
                        sum += A.Value[i][k].Value * M[k, j + n];

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
                throw new Exception("No inputs provided for the Divide function.");
            }
            if (Inputs[0] is Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value &&
                Inputs[1] is Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)
            {
                if (((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[0]).Value.Count == 0 &&
                    ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[1]).Value.Count == 0)
                {
                    throw new Exception("Empty Matrices ");
                }
               
               if (IF_Can_Divide
                   (((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[0]),
                   ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[1])))
               {
                  return Divide_Two_Matrices(((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[0]),
                  ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[1]));
               }
               else
               {
                  throw new Exception("Can not Multiply");
               }
            }
            else if (Inputs[0] is Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value &&
                Inputs[1] is Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)
            {
                if (((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)Inputs[1]).Value.Value == 0)
                {
                    throw new Exception("Division by zero is not allowed.");
                }
                for (int i = 0; i < ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[0]).Value.Count; i++)
                {
                    for (int j = 0; j < ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[0]).Value[i].Count; j++)
                    {
                        ((Registery.Primary_Values.Matrix_Primary_VaLue.Matrix_Primary_Value)Inputs[0]).Value[i][j].Value /=
                            ((Registery.Primary_Values.Number_Primary_VaLue.Number_Primary_Value)Inputs[1]).Value.Value;
                    }
                }
                return Inputs[0];
            }
            else
            {
                throw new Exception("Invalid input types for the Divide function.");
            }
        }
    }

}
