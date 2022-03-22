using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace addressbook_web_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string a = "sdfg";
            string b = "sdfg";
            Console.Out.WriteLine(System.String.Format("(${0}) - (#{1})", a,b));
        }
    }
}
