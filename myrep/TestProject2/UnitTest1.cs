using time;
namespace TestTime
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
            Time f = new Time(3, 5, 9);
            var str = f.ToString();

            Assert.AreEqual("03:05:09\n",str);
        }

        [Test]
        public void TestT1lessT2()
        {
            Time t1 = new Time(3, 5, 9);
            Time t2 = new Time(3, 5, 10);
            var f = t1<t2;
            Assert.IsTrue(f);
        }
        //[TestCase()]
    }
}