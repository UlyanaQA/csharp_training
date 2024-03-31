using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace addressbook_web_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodSquare()
        {
            Square s1 = new Square(3);
            Square s2 = new Square(5);
            Square s3 = s1;

            Assert.AreEqual(s1.Size, 3);
            Assert.AreEqual(s2.Size, 5);
            Assert.AreEqual(s3.Size, 3);

            s3.Size = 15;

            Assert.AreEqual(s1.Size, 15);

            s2.Colored = true;
        }

        [TestMethod]
        public void TestMethodCircle()
        {
            Circle s1 = new Circle(3);
            Circle s2 = new Circle(5);
            Circle s3 = s1;

            Assert.AreEqual(s1.Radius, 3);
            Assert.AreEqual(s2.Radius, 5);
            Assert.AreEqual(s3.Radius, 3);

            s3.Radius = 15;

            Assert.AreEqual(s1.Radius, 15);

            s2.Colored = true;
        }
    }
}
