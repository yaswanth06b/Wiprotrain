using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Delegates.Program;

namespace Delegates
{
    internal class Program
    {

        public class Calculator
        {
            public static int Calc(int x, int y)
            {
                return x * y;
            }
        }
        static void Main(string[] args)
        {
          
            
            Console.WriteLine(Calculator.Calc(5, 4));
        }
    }
}