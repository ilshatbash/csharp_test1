﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
namespace addressbook_web_tests.tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver=null;
            int attempt = 0;

            do
            {
                System.Threading.Thread.Sleep(1000);
                attempt++;
            }
            while (driver.FindElements(By.Id("test")).Count == 0 && attempt < 60);
        }
    }
}
