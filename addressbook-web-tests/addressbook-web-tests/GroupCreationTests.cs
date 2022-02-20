using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTest : TestBase
    {
       

        [Test]
        public void GroupCreationTests()
        {
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData("admin","secret"));
            navigator.GoToGroupsPage();
            groupHelper.InitGroupsCreation();
            GroupData group = new GroupData("aaa"); //создаем новый экземпляр и далее добавляем значения к пустым полям
            group.Header = "ss";
            group.Footer = "fff";
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitGroupCreation();
            groupHelper.ReturnToGroupsPage();
        }

      

       

       
      

        

     
    }
}