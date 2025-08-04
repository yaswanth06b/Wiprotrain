using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeProjectModel;
using EmployProjDao;
using EmployProjExcp;

namespace EmployProjBal
{
    public class EmployBal
    {
        
        public static StringBuilder sb = new StringBuilder();
        public static EmployDaoImpl daoImpl;

        static EmployBal()
        {
            daoImpl = new EmployDaoImpl();
        }

        public List<Employ> ShowEmployBal()
        {
            return daoImpl.ShowEmployDao();
        }

        public Employ SearchEmployBal(int empno)
        {
            return daoImpl.SearchEmployDao(empno);
        }

        public string AddEmployBal(Employ employ)
        {
            if (ValidateEmploy(employ) == true)
            {
                return daoImpl.AddEmploydao(employ);
            }
            throw new EmployExcp(sb.ToString());
        }

        public static bool ValidateEmploy(Employ employ)
        {
            bool flag = true;
            if (employ.EmpId <= 0)
            {
                sb.Append("Employ ID Cannot be Zero or Negative...\n");
                flag = false;
            }
            if (employ.Name.Length < 5)
            {
                sb.Append("Name Contains Min. 5 characters...\n");
                flag = false;
            }
            if (employ.BasePay < 10000 || employ.BasePay > 80000)
            {
                sb.Append("Basepay Must be Between 10000 and 80000...\n");
                flag = false;
            }
            return flag;
        }
    }
}
