using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class SerchTest:AuthTestBase
    {
        [Test]
        public void ContactSearch()
        {
            List<ContactData> contacts = app.Contacts.GetContactList();
            if (app.Contacts.GetContactList().Count < 2)
            {
                ContactData contact = new ContactData("Ilshat", "fff");
                contact.MiddleName = "";
                app.Contacts.Create(contact);
                ContactData contact2 = new ContactData("Ilshat", "zzz");
                contact.MiddleName = "";
                app.Contacts.Create(contact2);
            }
            string f = "fff";
            app.Contacts.ContactsFiltr(f);
            int count = app.Contacts.GetNumberOfSearchResults();
            int filtr = app.Contacts.GetNumberTableCount(f);
            Assert.AreEqual(count, filtr);

            System.Console.Out.Write(app.Contacts.GetNumberOfSearchResults());
        }
    }
}
