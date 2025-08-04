using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Delegates.DelegEx1;

namespace Delegates
{
    internal class DelegEx3
    {
        public delegate void Calc(int x);
       
        public static void  Fact (int x)
        {
            int f = 1;
            for (int i = 1; i <= x; i++) 
            {
                f *= i;
            }
            Console.WriteLine(f);
        }


        static void Main()
        {
            int x;
            Console.WriteLine("Enter N value  ");
            x = Convert.ToInt32(Console.ReadLine());
            
            Calc obj = new Calc(Fact);
            
            
            obj(x);
            


        }


    }
}
