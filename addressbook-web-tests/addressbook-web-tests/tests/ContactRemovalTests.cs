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
            List<ContactData> oldContacts = null;
            if (app.Contacts.IsContactIn())
            {
                oldContacts = app.Contacts.GetContactList();
                app.Contacts.Remove(0);          
            }
            else
            {


                ContactData contact = new ContactData("NewIvan", "NewIvanov");

                app.Contacts.Create(contact);

                oldContacts = app.Contacts.GetContactList();
                app.Contacts.Remove(0);

            }
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }
      
    }
}
