using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
//Добавлен тестовый комментарий на созданный branch
namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTest : TestBase
    {
       

        [Test]
        public void ContactCreationTests()
        {
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            contactHelper.GoToAddNew();
            contactHelper.FillGroupForm("asdf", "qwee", "dfasdf", "asdf","asdf", "fdsa", "zxcv", "fdsa", "lhhjkl", "43212344", "fdsadas");
            contactHelper.SubmitContactCreation();
            contactHelper.ReturnToHomePage();
        }

       

       
       

     

       

        
        
    }
}
