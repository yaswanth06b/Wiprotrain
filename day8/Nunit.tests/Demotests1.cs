using Nunitdemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nunit.tests
{
    [TestFixture]
    public class Demotests1
    {
        [Test]
        public void TestDemo()
        {
            Demo demo = new Demo();
            Assert.IsNotNull(demo); 
        }
    }
}
