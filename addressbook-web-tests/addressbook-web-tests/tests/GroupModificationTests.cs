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
    public class GroupModificationTest : AuthTestBase
    {
        [Test]
        public void GroupModificationTests()
        {
            GroupData newGroup = new GroupData("Test", "Test", "Test");

            if (!app.Contacts.IsElementPresent(By.Name("selected[]")))
            {
                app.Groups.Create(newGroup);
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Modify(0, newGroup);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newGroup.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);


        }
    }
}
