using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTest : AuthTestBase
    {

        public static IEnumerable<GroupData> RandomContactDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(50),
                    Footer = GenerateRandomString(50)
                });                    
            }
            return groups;
        }

      

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void GroupCreationTests(GroupData group)
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            //Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            List<GroupData>newGroups= app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups,newGroups);
        }
        
    }
}