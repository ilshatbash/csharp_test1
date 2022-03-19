﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData:IEquatable<ContactData>, IComparable<ContactData>
    {
       

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
       
        public string Phone2 { get; set; }
        
    }
}
