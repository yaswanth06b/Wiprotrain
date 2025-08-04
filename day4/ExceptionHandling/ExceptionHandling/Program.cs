using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class Program
    {

        static void Main()
        {
            int[] a = new int[] { 5, 8 };


            try
            {
                a[10] = 566;
            }

            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Array Size is Small...");
            }
          
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
 