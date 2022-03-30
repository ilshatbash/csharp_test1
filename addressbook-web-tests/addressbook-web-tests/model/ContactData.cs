using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData:IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;

        public ContactData(string firstName)
        {
          FirstName = firstName;
        }
        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public ContactData(string firstname, string lastname, string phone2)
        {
            FirstName = firstname;
            LastName = lastname;
            Phone2 = phone2;
        }
        public ContactData(string firstName, string middleName, string lastName, string phone2)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Phone2 = phone2;
        }
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (FirstName == other.FirstName) && (LastName == other.LastName);

        }
        public override int GetHashCode()
        {
            return (FirstName+ LastName).GetHashCode();
        }
        public override string ToString()
        {
            return LastName + " " + FirstName;
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (LastName.CompareTo(other.LastName) == 0)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            else
            {
                return LastName.CompareTo(other.LastName);
            }

        }
      
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string NickName { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string Fax { get; set; }
        public string HomePage { get; set; }
        public string Phone2 { get; set; }
        public string Notes { get; set; }

        public string ADay { get; set; }
        public string AMonth { get; set; }
        public string AYear { get; set; }
        public string BDay { get; set; }
        public string BMonth { get; set; }
        public string BYear { get; set; }
        
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
                set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null|| phone=="")
            {
                return "";
            }
            else
            {
                return Regex.Replace(phone, "[- ()]", "") + "\r\n";
            }
            
        }
        private string allEmail;
        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    return CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3).Trim();
                }
            }
            set
            {
                allEmail = value;
            }
        }

        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            else
            {
                return email + "\r\n";
            }
        }
    }

}
