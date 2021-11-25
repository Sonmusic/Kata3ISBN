using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void TestISBN10()
        {
            bool isbn = Kata3.Program.Validate("123456789X");
            Assert.AreEqual(true, isbn);
        }

        [TestMethod]
        public void TestISBN13()
        {
            bool isbn = Kata3.Program.Validate("9782123456803");
            Assert.AreEqual(true, isbn);
        }

        [TestMethod]
        public void Testerror()
        {
            bool isbn = Kata3.Program.Validate("123456789x");
            Assert.AreEqual(false, isbn);
        }

        [TestMethod]
        public void Testmenor()
        {
            bool isbn = Kata3.Program.Validate("978212345680");
            Assert.AreEqual(false, isbn);
        }

        [TestMethod]
        public void TestNulo()
        {
            bool isbn = Kata3.Program.Validate("");
            Assert.AreEqual(false, isbn);
        }
    }
}
