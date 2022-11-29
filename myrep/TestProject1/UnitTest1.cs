using FractionApp;
using System.Xml.Schema;

namespace OOP
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestToString()
        {
            Fraction f = new Fraction(1,2);
            var str = f.ToString();
            Assert.AreEqual(1, f.Numerator); Assert.AreEqual(2,f.Denominator); Assert.AreEqual("1/2", str);
            Assert.Pass();
        }

        public void TestFraction
    }
}


