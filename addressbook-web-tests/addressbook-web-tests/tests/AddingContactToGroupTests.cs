using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests:AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            List<GroupData> groups = GroupData.GetAll();
            if (groups.Count == 0)
            {
                GroupData nGroup = new GroupData("nNmae", "nHeader", "nFooter");
                app.Groups.Create(nGroup);
            }
            List<ContactData> con = ContactData.GetAll();
            if (con.Count == 0)
            {
                ContactData nCont = new ContactData("nLastname", "nFirstname");
                app.Contacts.Create(nCont);
            }

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact= ContactData.GetAll().Except(oldList).FirstOrDefault();
            if (contact == null)
            {
                ContactData cont = new ContactData("nLastname2", "nFirstname2");
                cont.MiddleName = "";
                app.Contacts.Create(cont);
                contact = ContactData.GetAll().Except(oldList).FirstOrDefault();
            }

            app.Contacts.AddContactToGroup(contact, group);
            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);

        }
    }
}
