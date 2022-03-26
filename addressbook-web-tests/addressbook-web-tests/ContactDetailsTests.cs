using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactDetailsTests : AuthTestBase
    {
        [Test]
        public void ContactDetailsTest()
        {
            string fromView = app.Contacts.GetContactInformationFromViewForm(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            string joinForm = app.Contacts.GetContactInformationJoinViewForm(fromForm);
            Assert.AreEqual(fromView, joinForm);



           
        }
    }
}
