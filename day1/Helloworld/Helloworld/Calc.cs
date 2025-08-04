using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helloworld
{
    internal class Calc
    {
        static void Main(string[] args)
        {
            int a, b, c;
            Console.WriteLine("Enter two numbers");
            a= Convert.ToInt32(Console.ReadLine());
            b=Convert.ToInt32(Console.ReadLine());
            c = a + b;
            Console.WriteLine("Sum is " + c);
            c = a -b;
            Console.WriteLine("diff" + c);
            c = a *b;
            Console.WriteLine("Prod" + c);
        }
    }
}
