using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionEx1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Caluc1 ab = new Caluc1();
            Console.WriteLine(ab.Sum(10, 30));
            Console.WriteLine(ab.Sub(50,80));
            Console.WriteLine(ab.Mul(900, 500));

        }
    }
}
