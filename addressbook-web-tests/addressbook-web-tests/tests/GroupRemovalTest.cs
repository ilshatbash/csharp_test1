﻿using System;
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
    public class GroupRemovalTest : GroupTestBase
    {
        

        [Test]
        public void GroupRemovalTests()
        {
            if(!app.Groups.IsGroupIn())
            {
                GroupData newGroup = new GroupData("Sara", "Konor", "Test");
                app.Groups.Create(newGroup);
            }
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];
            app.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());


            List<GroupData> newGroups = GroupData.GetAll(); 
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups,newGroups);
            foreach (GroupData group in newGroups)
            {
                
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

        }

 

       

       
       

      

     
    }
}
