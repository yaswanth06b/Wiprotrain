using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal class DelegEx1
    {
        public delegate void Mydelegate();
        public static void Show()
        {
            Console.WriteLine("Good Morning..");
        }
        static void Main() {
            Mydelegate obj = new Mydelegate(Show);
            obj();
        }
    }
}
    