using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTest : TestBase
    {
        
        [Test]
        public void ContactRemovalTests()
        {
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData("admin","secret"));
            contactHelper.GoToContactPage();
            contactHelper.SelectContact(1);
            contactHelper.DeleteContact();
            contactHelper.ReturnToContactPage();
        }

       
       

        
  
       

        

     


       
    }
}
