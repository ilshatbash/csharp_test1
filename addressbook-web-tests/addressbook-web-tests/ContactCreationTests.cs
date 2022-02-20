﻿using System;
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
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToAddNew();
            FillGroupForm("asdf", "qwee", "dfasdf", "asdf","asdf", "fdsa", "zxcv", "fdsa", "lhhjkl", "43212344", "fdsadas");
            SubmitContactCreation();
            ReturnToHomePage();
        }

       

       
       

     

       

        
        
    }
}
