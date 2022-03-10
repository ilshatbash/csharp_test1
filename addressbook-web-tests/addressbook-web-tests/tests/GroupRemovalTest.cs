using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTest : AuthTestBase
    {
        

        [Test]
        public void GroupRemovalTests()
        {

           

            if (!app.Contacts.IsElementPresent(By.Name("selected[]")))
            {
                GroupData newGroup = new GroupData("Test", "Test", "Test");
                app.Groups.Create(newGroup);
            }
            
            app.Groups.Remove(1);
            
        }

 

       

       
       

      

     
    }
}
