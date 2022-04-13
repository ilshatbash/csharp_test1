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
            if (groups.Count == 0)
            {
                GroupData group = new GroupData("new","group","test");
                app.Groups.Create(group);
                groups = GroupData.GetAll();
            }

            List<ContactData> con = ContactData.GetAll();
            if (con.Count == 0)
            {
                ContactData contact = new ContactData("firstname_", "lastname_");
                contact.MiddleName = "middlename_";
                app.Contacts.Create(contact);
                app.Contacts.AddContactToGroup(ContactData.GetAll().First(), groups.First());

            }
            
            for (int i = 0; i < groups.Count; i++)
            {
                ContactData contact = groups[i].GetContacts().FirstOrDefault();

                if (contact != null)
                {
                    isOk = true;
                    GroupData group = groups[i];
                    Delete(contact, group);
                    break;
                }
            }
            if (!isOk)
            {
                GroupData group = GroupData.GetAll()[0];
                ContactData contact = ContactData.GetAll().First();
                app.Contacts.AddContactToGroup(contact, group);
                Delete(contact, group);
            }
        }
        public void Delete(ContactData contact, GroupData group)
        {
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

