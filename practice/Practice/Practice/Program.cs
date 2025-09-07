using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fname = "john";
            string lname = "wick";
            string fullname=string.Concat(fname, lname);
            Console.WriteLine("Fullname is: " +fullname);
        }
    }
}
