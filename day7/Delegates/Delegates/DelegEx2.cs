using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class DelegEx2
    {
        public  delegate void Mydeleg(string s);
      
       public static void Show (string s)
        {
            Console.WriteLine("Welcome to Delegates from " + s);
        }

        static void Main()
        {
            
            Mydeleg df = new Mydeleg(Show);

            df("uuhhjuhi"); 
            
        }

    }
}
