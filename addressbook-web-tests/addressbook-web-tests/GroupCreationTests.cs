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
            GoToHomePage();
            Login(new AccountData("admin","secret"));
            GoToGroupsPage();
            InitGroupsCreation();
            GroupData group = new GroupData("aaa"); //создаем новый экземпляр и далее добавляем значения к пустым полям
            group.Header = "ss";
            group.Footer = "fff";
            FillGroupForm(group); 
            SubmitGroupCreation();
            ReturnToGroupsPage();
        }

      

       

       
      

        

     
    }
}