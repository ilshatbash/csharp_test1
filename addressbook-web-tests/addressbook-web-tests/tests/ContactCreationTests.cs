using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

            [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToAddNew();
            FillContactForm("asdf", "qwee", "dfasdf", "asdf","asdf", "fdsa", "zxcv", "fdsa", "lhhjkl", "43212344", "fdsadas");
            SubmitContactCreation();
            ReturnToHomePage();
        }

      
       

      
    }
}
