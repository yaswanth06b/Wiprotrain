using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class JaggedArr
    {
        static void Main()
        {
            int[][] jagArray = new int[2][];

            int[] x = new int[] { 34, 54, 78 };
            int[] y = new int[] { 43, 72,1 };

            jagArray[0] = x;
            jagArray[1] = y;

            Console.WriteLine(jagArray[0][0]);
            Console.WriteLine(jagArray[0][1]);
            Console.WriteLine(jagArray[0][2]);

            Console.WriteLine(jagArray[1][0]);
            Console.WriteLine(jagArray[1][1]);
            Console.WriteLine(jagArray[1][2]);
        }
    }
}
