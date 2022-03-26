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

        public string GetContactInformationFromViewForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactViewDetailed(index);
            string text = driver.FindElement(By.CssSelector("div#content")).Text;
            return text;
        }

        public string GetContactInformationJoinViewForm(ContactData contact)
        {
            string joinForm = "";
            if (!string.IsNullOrEmpty(contact.FirstName) || !string.IsNullOrEmpty(contact.MiddleName) || !string.IsNullOrEmpty(contact.LastName))
            {
                joinForm += contact.FirstName + " " + contact.MiddleName + " " + contact.LastName;

            }
            if (!string.IsNullOrEmpty(contact.NickName))
            {
                joinForm += "\r\n" + contact.NickName;
            }
            if (!string.IsNullOrEmpty(contact.Title))
            {
                joinForm += "\r\n" + contact.Title;
            }
            if (!string.IsNullOrEmpty(contact.Company))
            {
                joinForm += "\r\n" + contact.Company;
            }
            if (!string.IsNullOrEmpty(contact.Address))
            {
                joinForm += "\r\n" + contact.Address;
            }
            if (!string.IsNullOrEmpty(contact.HomePhone))
            {
                joinForm += "\r\n\r\n" + "H: " + contact.HomePhone;
            }
            if (!string.IsNullOrEmpty(contact.MobilePhone))
            {
                joinForm += "\r\n" + "M: " + contact.MobilePhone.Trim();
            }
            if (!string.IsNullOrEmpty(contact.WorkPhone))
            {
                joinForm += "\r\n" + "W: " + contact.WorkPhone;
            }
            if (!string.IsNullOrEmpty(contact.Fax))
            {
                joinForm += "\r\n" + "F: " + contact.Fax;
            }
            if (!string.IsNullOrEmpty(contact.Email))
            {
                joinForm += "\r\n\r\n" + contact.Email;
            }
            if (!string.IsNullOrEmpty(contact.Email2))
            {
                joinForm += "\r\n" + contact.Email2;
            }
            if (!string.IsNullOrEmpty(contact.Email3))
            {
                joinForm += "\r\n" + contact.Email3;
            }
            if (!string.IsNullOrEmpty(contact.HomePage))
            {
                joinForm += "\r\n" + "Homepage:" + "\r\n" + contact.HomePage;
            }
            if (contact.BDay != "0" || contact.BMonth != "-" || !string.IsNullOrEmpty(contact.BYear))
            {
                joinForm += "\r\n\r\n" + "Birthday " + (contact.BDay == "0" ? "" : contact.BDay + ". ") + (contact.BMonth == "-" ? "" : contact.BMonth + " ") + contact.BYear;
            }
            if (contact.ADay != "0" || contact.AMonth != "-" || !string.IsNullOrEmpty(contact.AYear))
            {
                joinForm += "\r\n" + "Anniversary " + (contact.ADay == "0" ? "" : contact.ADay + ". ") + (contact.AMonth == "-" ? "" : contact.AMonth + " ") + contact.AYear;
            }
            if (!string.IsNullOrEmpty(contact.Address2))
            {
                joinForm += "\r\n\r\n" + contact.Address2;
            }
            if (!string.IsNullOrEmpty(contact.Phone2))
            {
                joinForm += "\r\n\r\n" + "P: " + contact.Phone2;
            }
            if (!string.IsNullOrEmpty(contact.Notes))
            {
                joinForm += "\r\n\r\n" + contact.Notes;
            }
            Regex r = new Regex("[ ]+");
            return r.Replace(joinForm.Trim(), @" ");

        }

        public void InitContactViewDetailed(int index)
        {
            driver.FindElement(By.XPath("//tbody/tr[@name='entry'][" + (index + 1) + "]" +
                    "//img[@alt='Details']")).Click();
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
        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);

        }
        public int GetNumberTableCount(string filtr)
        {
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
            int count = 0;
            foreach (IWebElement element in elements)
            {
                var data = Regex.Match(element.Text, filtr);
                if (data.Success)
                {
                    count++;
                }
            }
            return count;
        }
       public void ContactsFiltr(string filtr)
        {
            manager.Navigator.GoToHomePage();
            driver.FindElement(By.Name("searchstring")).SendKeys(filtr);
            driver.FindElement(By.Name("searchstring")).SendKeys(Keys.Enter);
        }




    }
}
