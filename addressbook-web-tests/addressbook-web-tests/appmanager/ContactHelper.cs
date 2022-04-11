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
            string paragraph1 = "", paragraph2 = "", paragraph3 = "", paragraph4 = "",
                paragraph5 = "", paragraph6 = "", paragraph7 = "";
            if (!string.IsNullOrEmpty(contact.FirstName) || !string.IsNullOrEmpty(contact.MiddleName) || !string.IsNullOrEmpty(contact.LastName))
            {
                 paragraph1 += contact.FirstName + " " + contact.MiddleName + " " + contact.LastName;

            }
            if (!string.IsNullOrEmpty(contact.NickName))
            {
                paragraph1 += "\r\n" + contact.NickName;
            }
            if (!string.IsNullOrEmpty(contact.Title))
            {
                paragraph1 += "\r\n" + contact.Title;
            }
            if (!string.IsNullOrEmpty(contact.Company))
            {
                paragraph1 += "\r\n" + contact.Company;
            }
            if (!string.IsNullOrEmpty(contact.Address))
            {
                paragraph1 += "\r\n" + contact.Address;
            }
           

            if (!string.IsNullOrEmpty(contact.HomePhone))
            {
                paragraph2 += "\r\n" + "H: " + contact.HomePhone;
            }
           
            if (!string.IsNullOrEmpty(contact.MobilePhone))
            {
                paragraph2 += "\r\n" + "M: " + contact.MobilePhone.Trim();
            }
            if (!string.IsNullOrEmpty(contact.WorkPhone))
            {
                paragraph2 += "\r\n" + "W: " + contact.WorkPhone;
            }
            if (!string.IsNullOrEmpty(contact.Fax))
            {
                paragraph2 += "\r\n" + "F: " + contact.Fax;
            }
            if (!string.IsNullOrEmpty(contact.Email))
            {
                paragraph3 += "\r\n" + contact.Email;
            }
           
            if (!string.IsNullOrEmpty(contact.Email2))
            {
                paragraph3 += "\r\n" + contact.Email2;
            }
            if (!string.IsNullOrEmpty(contact.Email3))
            {
                paragraph3 += "\r\n" + contact.Email3;
            }
            if (!string.IsNullOrEmpty(contact.HomePage))
            {
                paragraph3 += "\r\n" + "Homepage:" + "\r\n" + contact.HomePage;
            }
            if (contact.BDay != "0" || contact.BMonth != "-" || !string.IsNullOrEmpty(contact.BYear))
            {
                paragraph4 += "\r\n" + "Birthday " + (contact.BDay == "0" ? "" : contact.BDay + ". ") + (contact.BMonth == "-" ? "" : contact.BMonth + " ") + contact.BYear;
            }
            if (contact.ADay != "0" || contact.AMonth != "-" || !string.IsNullOrEmpty(contact.AYear))
            {
                paragraph4 += "\r\n" + "Anniversary " + (contact.ADay == "0" ? "" : contact.ADay + ". ") + (contact.AMonth == "-" ? "" : contact.AMonth + " ") + contact.AYear;
            }
            if (!string.IsNullOrEmpty(contact.Address2))
            {
                paragraph5 += "\r\n" + contact.Address2;
            }
            if (!string.IsNullOrEmpty(contact.Phone2))
            {
                paragraph6 += "\r\n" + "P: " + contact.Phone2;
            }
            if (!string.IsNullOrEmpty(contact.Notes))
            {
                paragraph7 += "\r\n" + contact.Notes;
            }
            joinForm = paragraph1 +
                 ((paragraph2 != "") ? "\r\n" : "") + paragraph2 +
                ((paragraph3 != "") ? "\r\n" : "") + paragraph3 +
                ((paragraph4 != "") ? "\r\n" : "") + paragraph4 +
                ((paragraph5 != "") ? "\r\n" : "") + paragraph5 +
                ((paragraph6 != "") ? "\r\n" : "") + paragraph6 +
                ((paragraph7 != "") ? "\r\n" : "") + paragraph7;

            Regex r = new Regex("[ ]+");

            return r.Replace(joinForm.Trim(), @" ");

        }

        public void DeleteContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            SelectGroupFilter(group.Name);
            SelectContact(contact.Id);
            DeleteContactFromGroup();
            manager.Navigator.GoToHomePage();
        }

        private void SelectGroupFilter(string name)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        public bool IsContactPhoneExist(ContactData contact)
        {
            if (string.IsNullOrEmpty(contact.HomePhone) || string.IsNullOrEmpty(contact.WorkPhone) ||
                string.IsNullOrEmpty(contact.MobilePhone) || string.IsNullOrEmpty(contact.Fax))
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public void InitContactViewDetailed(int index)
        {
            driver.FindElement(By.XPath("//tbody/tr[@name='entry'][" + (index + 1) + "]" +
                    "//img[@alt='Details']")).Click();
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            string aday = driver.FindElement(By.Name("aday"))
                 .FindElement(By.CssSelector("option[selected='selected']")).GetAttribute("value");
            string amonth = driver.FindElement(By.Name("amonth"))
                .FindElement(By.CssSelector("option[selected='selected']")).Text;
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");

            string bday = driver.FindElement(By.Name("bday"))
                .FindElement(By.CssSelector("option[selected='selected']")).GetAttribute("value");
            string bmonth = driver.FindElement(By.Name("bmonth"))
                .FindElement(By.CssSelector("option[selected='selected']")).Text;
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");



            return new ContactData(firstName, lastName)
            {
                MiddleName=middleName,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                NickName = nickname,
                Company = company,
                Title = title,
                Address2 = address2,
                Fax = fax,
                HomePage = homepage,
                Phone2 = phone2,
                Notes = notes,
                ADay = aday,
                AMonth = amonth,
                AYear = ayear,
                BDay = bday,
                BMonth = bmonth,
                BYear = byear

            };

        }

      
        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmail = cells[4].Text;
            string allPhones = cells[5].Text;
            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmail = allEmail


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
            //manager.Navigator.GoToHomePage();
            SelectContact(p);
            InitContactModification(p);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToHomePage();

            return this;
        }
        public ContactHelper Modify(ContactData oldContact, ContactData contactM)
        {
            //SelectContact(oldContact.Id);
            InitContactModification(oldContact.Id);
            FillContactForm(contactM);
            SubmitContactModification();
            ReturnToHomePage();

            return this;
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
               .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
             
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }
         public void DeleteContactFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public int GetContactCount()
        {
         return   driver.FindElements(By.XPath("//tr[@name='entry']")).Count();
        }

        public ContactHelper Remove(int p)
        {
           // manager.Navigator.GoToHomePage();
            SelectContact(p);
            DeleteContact();
            ReturnToHomePage();

            return this;
        }
        public  ContactHelper Remove(ContactData toBeRemoved)
        {
            SelectContact(toBeRemoved.Id);
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
        public ContactHelper SelectContact(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }
           

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();

            return this;
        }
        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("//tbody/tr[@name='entry'][" + (index + 1) + "]" +
                    "//img[@alt='Edit']")).Click();
            return this;
        }
        public ContactHelper InitContactModification(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "']/../.." +
                      "//img[@alt='Edit'])")).Click();
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
