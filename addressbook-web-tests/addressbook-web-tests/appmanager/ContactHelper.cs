using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    { 
        public ContactHelper(ApplicationManager manager):base(manager)
        {
           
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
               

            };

        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone=homePhone,
                MobilePhone=mobilePhone,
                WorkPhone=workPhone

            }; 
           

        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            GoToAddNew();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(int p, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(p);
            InitContactModification(p);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToHomePage();

            return this;
        }

        public int GetContactCount()
        {
         return   driver.FindElements(By.XPath("//tr[@name='entry']")).Count();
        }

        public ContactHelper Remove(int p)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(p);
            DeleteContact();
            ReturnToHomePage();

            return this;
        }
        public bool IsContactIn()
        {
            return IsElementPresent(By.XPath("//tr[@name='entry']"));
        }


        private List<ContactData> contactCache = null;


        public List<ContactData> GetContactList()
        {
            if (driver.Url != "http://localhost/addressbook")
            {
                driver.Navigate().GoToUrl("http://localhost/addressbook");
            }
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
                foreach (IWebElement tr in elements)
                {
                    var tds = tr.FindElements(By.TagName("td"));
                    if (tds.Count > 0)
                    {
                        var firstName = tds[2].Text;
                        var lastName = tds[1].Text;
                        
                        contactCache.Add(new ContactData(firstName, lastName)
                        {
                            Id = tr.FindElement(By.TagName("input")).GetAttribute("Value")
                        });
                    }
                }
            }

            
            return new List<ContactData>(contactCache);
        }


        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("phone2"), contact.Phone2);

           
            return this;
        }
        public ContactHelper GoToAddNew()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        
        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }
        public ContactHelper ReturnToContactPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }
        public ContactHelper DeleteContact()
        {
                driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
                contactCache = null;
                Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            
            return this;
        }

        public ContactHelper GoToContactPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;

        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//tbody//input[@type='checkbox'][" + (index+1) + "]")).Click();
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();

            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();

            return this;
        }



    }
}
