using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal class Readlcs
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter id");
            string fg = Console.ReadLine();
            int a,b;
            Console.WriteLine("enter first:");
            a= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter secondt:");
            b = Convert.ToInt32(Console.ReadLine());
            int c = a + b;
            Console.WriteLine("id is: " +fg +"jgfgf " +a +"ydfudf" +b);
            
            Console.WriteLine("The lenght of id is: " + fg.Length);
            Console.WriteLine("the sum is" + c);
            
        }
    }
}
