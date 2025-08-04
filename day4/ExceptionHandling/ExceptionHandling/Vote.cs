using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class Vote
    {
        static void Main(string[] args)
        {
            int a;
            Console.WriteLine("Enter age");
            try
            {
                a = Convert.ToInt32(Console.ReadLine());


                if (a >= 18)
            }
                {
                    Console.WriteLine("Eligible for voting");
                }
                else
                {
                    Console.WriteLine("Not Eligiblr");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
