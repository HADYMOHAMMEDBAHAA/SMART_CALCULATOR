using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_MATH_CORE.Registery.Functions_Executers
{
    public class Functions_Executers_Dictionary
    {
        static Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer> Sin_Executers_ =
            new Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer>();

        static Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer> Cos_Executers_ =
            new Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer>();

        static   Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer> Tan_Executers_ =
            new Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer>();

        static Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer> Log_Executers_ =
            new Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer>();

        static Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer> Power_Executers_ =
            new Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer>();

        static Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer> Root_Executers_ =
            new Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer>();

        static Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer> Plus_Executers_ =
            new Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer>();

        static Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer> Minus_Executers_ =
            new Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer>();

        static Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer> Multiply_Executers_ =
           new Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer>();

        static Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer>Divide_Executers_ =
           new Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer>();

        static Dictionary<Parser.Token.Token, Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer>>
            Function_Executers_Dictionary_ = new Dictionary<Parser.Token.Token, Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer>>();

        static bool Get_Key( Parser.Token.Token function_token, out Parser.Token.Token? key )
        {
           foreach (Parser.Token.Token k in Function_Executers_Dictionary_.Keys)
            {
                foreach (string name in k.Aliases!)
                {
                    if (name.Equals(function_token.Name ,StringComparison.OrdinalIgnoreCase))
                    {
                        key = k;
                        return true;
                    }
                }
            }
           key = new Parser.Token.Token();
           return false;
        }
        static void Initialize_Function_Executers_Dictionary()
        {
            Sin_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.Number, new Sin_Function_Execute_Number());
            Sin_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.List, new Sin_Function_Execute_List());
            Sin_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.Matrix, new Sin_Function_Execute_Matrix());
            Cos_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.Number, new Cos_Function_Execute_Number());
            Cos_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.List, new Cos_Function_Execute_List());
            Cos_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.Matrix, new Cos_Function_Execute_Matrix());
            Tan_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.Number, new Tan_Function_Execute_Number());
            Tan_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.List, new Tan_Function_Execute_List());
            Tan_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.Matrix, new Tan_Function_Execute_Matrix());
            Log_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.Number, new Log_Function_Execute_Number());
            Log_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.List, new Log_Function_Execute_List());
            Log_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.Matrix, new Log_Function_Execute_Matrix());
            Power_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.Number, new Power_Function_Executer_Number());
            Power_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.List, new Power_Function_Executer_List());
            Power_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.Matrix, new Power_Function_Executer_Matrix());
            Root_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.Number, new Root_Function_Executer_Number());
            Root_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.List, new Root_Function_Executer_List());
            Root_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.Matrix, new Root_Function_Executer_Matrix());
            Plus_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.Number, new Plus_Function_Executer_Number());
            Plus_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.List, new Plus_Function_Executer_List());
            Plus_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.Matrix, new Plus_Function_Executer_Matrix());
            Minus_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.Number, new Minus_Function_Executer_Number());
            Minus_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.List, new Minus_Function_Executer_List());
            Minus_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.Matrix, new Minus_Function_Executer_Matrix());
            Multiply_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.Number, new Multiply_Function_Executer_Number());
            Multiply_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.List, new Multiply_Function_Executer_List());
            Multiply_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.Matrix, new Multiply_Function_Executer_Matrix());
            Divide_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.Number, new Divide_Function_Executer_Number());
            Divide_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.List, new Divide_Function_Executer_List());
            Divide_Executers_.Add(Primary.Primary_Value.Primary_Value_Type.Matrix, new Divide_Function_Executer_Matrix());
            Function_Executers_Dictionary_.Add(new Registery.Tokens.Function_Tokens.Sin_Token(), Sin_Executers_);
            Function_Executers_Dictionary_.Add(new Registery.Tokens.Function_Tokens.Cos_Token(), Cos_Executers_);
            Function_Executers_Dictionary_.Add(new Registery.Tokens.Function_Tokens.Tan_Token(), Tan_Executers_);
            Function_Executers_Dictionary_.Add(new Registery.Tokens.Function_Tokens.Log_Token(), Log_Executers_);
            Function_Executers_Dictionary_.Add(new Registery.Tokens.Operators_Tokens.Power_Token(), Power_Executers_);
            Function_Executers_Dictionary_.Add(new Registery.Tokens.Operators_Tokens.Root_Token(), Root_Executers_);
            Function_Executers_Dictionary_.Add(new Registery.Tokens.Operators_Tokens.Plus_Token(), Plus_Executers_);
            Function_Executers_Dictionary_.Add(new Registery.Tokens.Operators_Tokens.Minus_Token(), Minus_Executers_);
            Function_Executers_Dictionary_.Add(new Registery.Tokens.Operators_Tokens.Multiply_Token(), Multiply_Executers_);
            Function_Executers_Dictionary_.Add(new Registery.Tokens.Operators_Tokens.Divide_Token(), Divide_Executers_);
        }

        static public Function_Executer Get_Function_Executer(Parser.Token.Token function_token, Primary.Primary_Value.Primary_Value_Type input_type)
        {
            if(Function_Executers_Dictionary_.Count==0)
            {
               Initialize_Function_Executers_Dictionary();
            }
            if (Get_Key(function_token , out function_token!))
            {
                Dictionary<Primary.Primary_Value.Primary_Value_Type, Function_Executer> executers_dict
                    = Function_Executers_Dictionary_[function_token];

                if (executers_dict.ContainsKey(input_type))
                {
                    Function_Executer func_exe = executers_dict[input_type];
                    return func_exe;
                }
                else
                {
                    throw new Exception($"No executer found for input type {input_type} in function {function_token}");
                }
            }
            else
            {
                throw new Exception($"No executer found for function token {function_token}");
            }
        }
    }
}
