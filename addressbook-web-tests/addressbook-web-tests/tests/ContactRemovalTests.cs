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
    public class ContactRemovalTest : AuthTestBase
    {
        
        [Test]
        public void ContactRemovalTests()
        {
            if (!app.Contacts.IsElementPresent(By.Name("selected[]")))
            {
                ContactData newContact = new ContactData("asdfasd", "asdf","asdf","1234234");
                app.Contacts.Create(newContact);
            }
            app.Contacts.Remove(1);
        }

       
       

        
  
       

        

     


       
    }
}
