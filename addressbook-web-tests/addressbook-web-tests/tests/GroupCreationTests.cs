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

            
            GroupData group = new GroupData("aaa"); //создаем новый экземпляр и далее добавляем значения к пустым полям
            group.Header = "ss";
            group.Footer = "fff";

            app.Groups.Create(group);
        }
        [Test]
        public void EmptyGroupCreationTests()
        {
            GroupData group = new GroupData(""); //создаем новый экземпляр и далее добавляем значения к пустым полям
            group.Header = "";
            group.Footer = "";
       
            app.Groups.Create(group);
        }
    }
}