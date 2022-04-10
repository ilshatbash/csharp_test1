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
    public class GroupModificationTest : GroupTestBase
    {
        [Test]
        public void GroupModificationTests()
        {
            GroupData newData = new GroupData("new1", "new1", "Group1");
            if (!app.Groups.IsGroupIn())
            {
                app.Groups.Create(newData);
            }

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];
            app.Groups.Modify(oldData, newData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if(group.Id==oldData.Id)
                {
                    Assert.AreEqual(newData.Name,group.Name);
                }
            }


        }
    }
}
