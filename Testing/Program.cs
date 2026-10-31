using Microsoft.Win32;
using SMART_MATH_CORE.Primary.Primary_Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{

    static void Main(string[] strgs)
    {

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\nENTER MATH EXPRESSION");
            Console.ForegroundColor = ConsoleColor.White;

            string input = Console.ReadLine()?? string.Empty;

            if (input.Length > 0)
            {
                List<string>? results = new List<string>();

                results = SMART_MATH_CORE.Parser.Parsing.Parse(input);

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine();
                foreach (string res in results!)
                {
                    Console.WriteLine(res);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }

            
        }

    }
}

