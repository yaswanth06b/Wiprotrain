﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NullableEx
{
    internal class Emp
         public int Empno { get; set; }
    public string Name { get; set; }
    public double Basic { get; set; }

    public override string ToString()
    {
        return "Employ No " + Empno + " Name " + Name + " Basic  " + Basic;
    }
    
    }
}
