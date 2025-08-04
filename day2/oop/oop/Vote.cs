using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    internal class Vote
    {
        public void Check(int age)
        {
            if (age >= 18)
            {
                Console.WriteLine("Eligible for voting");
            }
            else
            {
                Console.WriteLine("Not Eligble for voting"); 
            }
        }

            static void Main(string[] args)
        {
            int age;
            Console.WriteLine("Enter Age:  ");
            age= Convert.ToInt32(Console.ReadLine());
            Vote vote = new Vote();
            vote.Check(age);

        }
    }
}
