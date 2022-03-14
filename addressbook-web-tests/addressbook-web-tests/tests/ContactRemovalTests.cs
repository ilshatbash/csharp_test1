using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

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

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Remove(0);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);


        }

       
       

        
  
       

        

     


       
    }
}
