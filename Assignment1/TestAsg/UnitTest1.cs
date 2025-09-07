using Assignment1;


namespace TestAsg
{
    public class Tests
    {
        [Test]
        public void TestAdd()
        {
            Calculator test = new Calculator();
            int result = (int)test.Add(1, 2);
            Assert.AreEqual(3, result);
        }
        [Test]
        public void TestSubtract()
        {
            Calculator test = new Calculator();
            int result = (int)test.Subtract(5, 2);
            Assert.AreEqual(3, result);
        }
        [Test]
        public void TestMul()
        {
            Calculator test = new Calculator();
            int result = (int)test.Mul(5, 2);
            Assert.AreEqual(10, result);
        }
        [Test]
        public void TestDivision()
        {
            Calculator test = new Calculator();
            Assert.Catch<DivideByZeroException>(() => test.Div(10, 0));

        }
    }
}