using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    { 
        public ContactHelper(IWebDriver driver):base(driver)
        {
           
        }
        public void SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
        }
        public void FillGroupForm(string firstname, string middlename, string lastname, string nickname,
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
        public void GoToAddNew()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        
        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
        public void ReturnToContactPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
        public void DeleteContact()
        {
            acceptNextAlert = true;
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
        }

        public void GoToContactPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
           
        }
        public void SelectContact(int index)
        {

            driver.FindElement(By.XPath("//tbody//input[@type='checkbox'][" + index + "]")).Click();
        }

       


    }
}
