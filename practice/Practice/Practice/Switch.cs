using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal class Switch
    {


        public static void Main(string[] args)
        {
            Console.WriteLine("Choose ur order No; ");
            int s = Convert.ToInt32(Console.ReadLine());


            switch (s)
            {
                case 1:
                    Console.WriteLine("coffee");
                    Console.WriteLine("Your bill is $20");
                    break;
                case 2:
                    Console.WriteLine("Mactha");
                    Console.WriteLine("Your bill is $30");
                    break;
                case 3:
                    Console.WriteLine("Tea");
                    Console.WriteLine("Your bill is $15");
                    break;
                default:
                    Console.WriteLine("Thank you for ordering");
                    break;

            }

        }
    }

}

