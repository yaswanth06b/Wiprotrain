using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocking
{
    [TestFixture]   
    public class Mocktest
    {
        [Test]
        public void TestMileStone1()
        {
            Mock<Iwipridata> mock = new Mock<Iwipridata>();
            mock.Setup(x => x.MilestoneExam1()).Returns("MileStone Exam 1 on Aug 1...");
            Assert.AreEqual("MileStone Exam 1 on Aug 1...", mock.Object.MilestoneExam1());
        }

        [Test]
        public void TestMileStone2()
        {
            Mock<Iwipridata> mock = new Mock<Iwipridata>();
            mock.Setup(x => x.MileStoneExam2()).Returns("MileStone Exam 2 On Aug 10...");
            Assert.AreEqual("MileStone Exam 2 On Aug 10...", mock.Object.MileStoneExam2());
        }


    }
}
