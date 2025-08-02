using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class Refe
    {
        public void Calc(int n, ref int f)
        {

            for (int i = 1; i <= n; i++)
            {
                f = f * i;
            }
        }
        static void Main()
        {
            int n, f = 1;
            Console.WriteLine("Enter N value   ");
            n = Convert.ToInt32(Console.ReadLine());
            Refe obj = new Refe();
            obj.Calc(n, ref f);
            Console.WriteLine("Factorial value is " + f);
        }
    }
}

