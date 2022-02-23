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
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin","secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.InitGroupsCreation();
            GroupData group = new GroupData("aaa"); //создаем новый экземпляр и далее добавляем значения к пустым полям
            group.Header = "ss";
            group.Footer = "fff";
            app.Groups.FillGroupForm(group);
            app.Groups.SubmitGroupCreation();
            app.Groups.ReturnToGroupsPage();
        }

      

       

       
      

        

     
    }
}