using EmployeProjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployProjDao
{
    public class EmployDaoImpl : IEmployDao

    {
        static List<Employ> employlist;
        static EmployDaoImpl()
        {
            employlist = new List<Employ>();
        }

        public string AddEmploydao(Employ employ)
        {
            employlist.Add(employ);
            return "Employ Record Inserted...";
        }

        public string Employdao(Employ employ)
        {
            throw new NotImplementedException();
        }

        public Employ SearchEmployDao(int empno)
        {
            Employ employFound = null;
            foreach (Employ employ in employlist)
            {
                if (employ.EmpId == empno)
                {
                    employFound = employ;
                    break;
                }
            }
            return employFound;
        }
        public List<Employ> ShowEmployDao()
        {
            return employlist;
        }
    }
}

