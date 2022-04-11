using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class DeleteContactFromGroup: AuthTestBase
    {
        [Test]
        public void TestDeleteContactFromGroup()
        {
            List<GroupData> groups = GroupData.GetAll();
            bool isOk = false;
            for (int i = 0; i < groups.Count; i++)
            {
                ContactData contact = groups[i].GetContacts().FirstOrDefault();

                if (contact != null)
                {
                    isOk = true;
                    GroupData group = groups[i];
                    List<ContactData> oldList = group.GetContacts();
                    app.Contacts.DeleteContactFromGroup(contact, group);
                    List<ContactData> newList = group.GetContacts();
                    oldList.Remove(contact);
                    newList.Sort();
                    oldList.Sort();
                    Assert.AreEqual(oldList, newList);
                    break;
                }
            }
            if (!isOk)
            {
                GroupData group = GroupData.GetAll()[0];
                ContactData contact = ContactData.GetAll().First();
                app.Contacts.AddContactToGroup(contact, group);
                List<ContactData> oldList = group.GetContacts();
                app.Contacts.DeleteContactFromGroup(contact, group);
                List<ContactData> newList = group.GetContacts();
                oldList.Remove(contact);
                newList.Sort();
                oldList.Sort();
                Assert.AreEqual(oldList, newList);
            }
        }
    }
}

