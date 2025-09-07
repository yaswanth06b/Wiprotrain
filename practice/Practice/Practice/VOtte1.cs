using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal class VOtte1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter age: ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n >= 18)
            {
                Console.WriteLine("Eligible");
            }
            else
            {
                Console.WriteLine("not eligible");
            }
        }
    }
}
