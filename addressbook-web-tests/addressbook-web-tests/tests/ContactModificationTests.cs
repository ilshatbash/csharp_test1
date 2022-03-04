using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
    
{
    [TestFixture]
    class ContactModificationTest  : AuthTestBase
    {
        [Test]
        public void ContactModificationTests()
        {
            ContactData newData = new ContactData("Ilshat");
            newData.LastName = "ss";
            newData.MiddleName = "fff";
            newData.Phone2 = "412312341234";

            app.Contacts.Modify(1, newData);

        }

    }
}
