using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropExp
{
    
        class Vendor
        {
            int vendId;
            string vendName;

            public int VendorId
            {
                set { vendId = value; }
            }

            public string VendorName
            {
                set { vendName = value; }
            }
            public override string ToString()
            {
                return "Vendor Id  " + vendId + " Vendor Name  " + vendName;
            }
        }
        internal class WriteExp
        {
            static void Main()
            {
                Vendor vendor = new Vendor();
                vendor.VendorId = 564;
                vendor.VendorName = "Swigato";

                //Console.WriteLine(vendor.VendorId);
                Console.WriteLine(vendor);
            }
        }
}
