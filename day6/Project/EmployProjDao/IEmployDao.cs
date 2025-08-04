using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeProjectModel;

namespace EmployProjDao
{
    internal interface IEmployDao
    {
        string Employdao(Employ employ);
        List<Employ> ShowEmployDao();
        Employ SearchEmployDao(int empno);
    }
}
