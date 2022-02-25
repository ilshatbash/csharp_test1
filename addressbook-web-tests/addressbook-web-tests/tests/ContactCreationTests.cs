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
    public class ContactCreationTest : TestBase
    {
       

        [Test]
        public void ContactCreationTests()
        {
            ContactData contact = new ContactData("Ilshat");
            contact.LastName = "ss";
            contact.MiddleName = "fff";
            contact.Phone2 = "412312341234";
            app.Contacts.Create(contact);
                
        }
        [Test]
        public void EmptyContactCreationTests()
        {
            ContactData contact = new ContactData("");
            contact.LastName = "";
            contact.MiddleName = "";
            contact.Phone2 = "";
            app.Contacts.Create(contact);
        }

        }
}
