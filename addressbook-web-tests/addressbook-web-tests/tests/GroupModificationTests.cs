using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{

    [TestFixture]
    public class GroupModificationTest : AuthTestBase
    {
        [Test]
        public void GroupModificationTests()
        {
            GroupData newData = new GroupData("Rasdfadf");
            newData.Header = "Gasdf";
            newData.Footer = "Dsaddf";
            

            app.Groups.Modify(1,newData);

        }
    }
}
