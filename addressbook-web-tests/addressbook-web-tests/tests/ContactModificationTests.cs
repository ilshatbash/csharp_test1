using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
    
{
    [TestFixture]
    class ContactModificationTest  : AuthTestBase
    {
        [Test]
        public void ContactModificationTests()
        {

            ContactData newContact = new ContactData("Ilshat", "ss", "fff", "79228837773");
            if (!app.Contacts.IsElementPresent(By.Name("selected[]")))
            {
               
                app.Contacts.Create(newContact);

            }
  
            app.Contacts.Modify(0, newContact);

        }

    }
}
