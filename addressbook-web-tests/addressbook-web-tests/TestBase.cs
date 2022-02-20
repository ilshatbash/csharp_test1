using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
   public class TestBase
    {
        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        protected bool acceptNextAlert = true;
        protected string baseURL;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        protected BaseHelper baseHelper;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";
            verificationErrors = new StringBuilder();
            baseHelper = new BaseHelper(driver);
            loginHelper = new LoginHelper(driver);
            navigator = new NavigationHelper(driver,baseURL);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver);

        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
       
      
       
    }

}
