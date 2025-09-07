using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal class For
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number");
            int f = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i < 10; i++)
            {
                f = f + i;
                Console.WriteLine(f);
            }
        }
    }
}
