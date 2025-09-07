using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal class loop
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter num");
            int n = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            int k=Convert.ToInt32(Console.ReadLine());
            string result = (n > m) ? "hi" : "bye";
            Console.WriteLine(result);


        
        
            if (n % 2 == 0)
            {
                Console.WriteLine("prime num");
            }
            else
            {
                Console.WriteLine("not a prime");
            }
            if (n > m && n>k)
            {
                Console.WriteLine(n + " is larger " 
                    );
            }
            else if(m > k) {
                Console.WriteLine(m +"m is large " );
            }
            else {
                Console.WriteLine(k +"k is larger " );
            }
        }
    }
}
