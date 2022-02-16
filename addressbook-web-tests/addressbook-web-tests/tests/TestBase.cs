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
{ public class TestBase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL= "http://localhost/addressbook/";
        private bool acceptNextAlert = true;

        protected ApplicationManager app;
        /*
        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));


        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
*/
       

        [SetUp]
        protected void SetupTest() 
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest() //Переименовал. В следующем шаге объединим с SetupTest
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

        protected void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }

        protected void RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
        }

        protected void SelectContact(int index)
        {
            acceptNextAlert = true;
            driver.FindElement(By.XPath("//tbody//input[@type='checkbox'][" + index + "]")).Click();
        }

        protected void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        protected void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }


    protected void SubmitContactCreation()
    {
        driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
    }

    protected void FillContactForm(string firstname, string middlename, string lastname, string nickname,
     string title, string company, string address, string home, string address2, string phone2, string notes)
    {
        driver.FindElement(By.Name("firstname")).Click();
        driver.FindElement(By.Name("firstname")).Clear();
        driver.FindElement(By.Name("firstname")).SendKeys(firstname);
        driver.FindElement(By.Name("middlename")).Click();
        driver.FindElement(By.Name("middlename")).Clear();
        driver.FindElement(By.Name("middlename")).SendKeys(middlename);
        driver.FindElement(By.Name("lastname")).Click();
        driver.FindElement(By.Name("lastname")).Clear();
        driver.FindElement(By.Name("lastname")).SendKeys(lastname);
        driver.FindElement(By.Name("nickname")).Click();
        driver.FindElement(By.Name("nickname")).Clear();
        driver.FindElement(By.Name("nickname")).SendKeys(nickname);
        driver.FindElement(By.Name("title")).Click();
        driver.FindElement(By.Name("title")).Clear();
        driver.FindElement(By.Name("title")).SendKeys(title);
        driver.FindElement(By.Name("company")).Click();
        driver.FindElement(By.Name("company")).Clear();
        driver.FindElement(By.Name("company")).SendKeys(company);
        driver.FindElement(By.Name("address")).Click();
        driver.FindElement(By.Name("address")).Clear();
        driver.FindElement(By.Name("address")).SendKeys(address);
        driver.FindElement(By.Name("home")).Click();
        driver.FindElement(By.Name("home")).Clear();
        driver.FindElement(By.Name("home")).SendKeys(home);
        driver.FindElement(By.Name("address2")).Click();
        driver.FindElement(By.Name("address2")).Clear();
        driver.FindElement(By.Name("address2")).SendKeys(address2);
        driver.FindElement(By.Name("phone2")).Click();
        driver.FindElement(By.Name("phone2")).Clear();
        driver.FindElement(By.Name("phone2")).SendKeys(phone2);
        driver.FindElement(By.Name("notes")).Click();
        driver.FindElement(By.Name("notes")).Clear();
        driver.FindElement(By.Name("notes")).SendKeys(notes);
    }


    protected void GoToAddNew()
    {
        driver.FindElement(By.LinkText("add new")).Click();
    }

    }
}

