using Restaurant365.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant365.App
{
    internal class Program
    {

        static void Main(string[] args)
        {
            ConsoleLogger logger = new ConsoleLogger();
            Calculator calculator = new Calculator(logger);

            calculator.Delimiters.Add(",");
            calculator.Delimiters.Add("\n");
            calculator.Delimiters.Add("abc");

            calculator.DenyNegativeNumber = true;

            ///Windows closes console apps when you press ctrl-c
            while (true)
            {
                try
                {
                    //set up the screen for the user
                    Console.Write("Enter List:");

                    //retrieve the input from the user
                    string input = Console.ReadLine();
                   
                    //print the solution. if logging is enabled the formula will also be displayed
                    int result = calculator.Add(input);
                    Console.WriteLine("Result:" + result.ToString());
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }
         
        }
    }
}
