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
    class ContactModificationTest : ContactTestBase
    {
        [Test]
        public void ContactModificationTests()
        {

            
            if (!app.Contacts.IsContactIn())
            {
                app.Contacts.Create(new ContactData("NewIvan", "NewIvanov"));
            }
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData contactM = new ContactData("MIvan", "MIvanov");
            ContactData oldContact = oldContacts[0];
            app.Contacts.Modify(oldContact, contactM);
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].FirstName = contactM.FirstName;
            oldContacts[0].LastName = contactM.LastName;
            oldContact = oldContacts[0];
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldContact.Id)
                {
                    Assert.AreEqual(contact.FirstName + contact.LastName, oldContact.FirstName + oldContact.LastName);
                }

            }

        }
    }
}
