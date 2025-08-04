using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployProjExcp
{
    public class EmployExcp : ApplicationException
    {
        public EmployExcp() { }

        public EmployExcp(string message) : base(message) { }

    }
}
