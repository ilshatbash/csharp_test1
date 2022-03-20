using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
    
{
    [TestFixture]
    class ContactModificationTest  : AuthTestBase
    {
        [Test]
        public void ContactModificationTests()
        {

            List<ContactData> oldContacts = null;
            ContactData oldContact; ;
            if (app.Contacts.IsContactIn())
            {
                oldContacts = app.Contacts.GetContactList();
                
                ContactData contactM = new ContactData("MIvan", "MIvanov");
                app.Contacts.Modify(0, contactM);
                oldContacts[0].FirstName = contactM.FirstName;
                oldContacts[0].LastName = contactM.LastName;

            }
            else
            {
                ContactData newContact = new ContactData("NewIvan", "NewIvanov");
                app.Contacts.Create(newContact);

                oldContacts = app.Contacts.GetContactList();
                
                ContactData contactM = new ContactData("MIvanov_", "MIvan_");
                app.Contacts.Modify(0, contactM);
              

                oldContacts[0].FirstName = contactM.FirstName;
                oldContacts[0].LastName = contactM.LastName;
            }
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContact = oldContacts[0];
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldContacts[0].Id)
                {
                    Assert.AreEqual(contact.FirstName, oldContact.FirstName);
                    Assert.AreEqual(contact.LastName, oldContact.LastName);
                }
            }

        }

    }
}
