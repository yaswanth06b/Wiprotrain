using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeProjectModel
{
    public class Employ
    {
        public int EmpId {get; set;}
        public string Name {get; set;}
         public string Gender { get; set;}
        public string Department {  get; set;}
        public string Designation {  get; set;}
        public double BasePay {  get; set;}

        public Employ() { }
        public Employ(int empId, string name, string gender, string departmenr, string designation, double basePay)
        {
            EmpId = empId;
            Name = name;
            Gender = gender;
            Department = departmenr;
            Designation = designation;
            BasePay = basePay;
        }
        public override string ToString()
        {
            return "Employ Id " + EmpId +
                 "  Name " + Name +
                 "  Gender " + Gender +
                 "  Department " + Department +
                 " Designation  " + Designation +
                 " BasePay  " + BasePay;
        }
    }
}
