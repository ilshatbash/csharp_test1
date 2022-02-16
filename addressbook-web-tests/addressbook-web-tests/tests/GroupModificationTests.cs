using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]

        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("eee"); //создаем новый экземпляр и далее добавляем значения к пустым полям
            newData.Header = "qqq";
            newData.Footer = "ddd";

            app.Groups.Modify(1, newData);


        }
    }
}
