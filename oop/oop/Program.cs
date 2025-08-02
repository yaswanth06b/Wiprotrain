using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b, c; 
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine(" " +a);
            Console.WriteLine(" " +b);
            
            c = a + b;
            Console.WriteLine("Sum is: " + c);
        }
    }
}
