using Zadacha910;
namespace TestProject1
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
            var s1 = SpeedKPH.FromKPH(10).ToString();
            var s2 = SpeedKPH.FromMPH(1000).ToString();
            var s3 = SpeedKPH.FromMPS(3.6).ToString();
            Assert.AreEqual("10", s1);
            Assert.AreEqual("1609", s2);
            Assert.AreEqual("1", s3);
        }
        [Test]
        public void TestAdd()
        {
            var s1 = SpeedMPS.FromMPS(10);
            var s2 = SpeedMPS.FromKPH(10);
            Assert.AreEqual("46", (s1+s2).ToString());
        }
    }
}