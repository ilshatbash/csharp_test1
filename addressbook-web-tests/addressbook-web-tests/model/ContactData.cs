﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData
    {
        private string firstName;
        private string middleName = "";
        private string lastName = "";
        private string phone2 = "";
        public ContactData(string firstName)
        {
            this.firstName = firstName;
        }
        public ContactData(string firstName, string middleName, string lastName, string phone2)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.phone2 = phone2;
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string MiddleName
        {
            get
            { return middleName; }
            set
            { middleName = value; }
        }
        public string LastName
        {
            get
            { return lastName; }
            set
            { lastName = value; }
        }
        public string Phone2
        {
            get
            { return phone2; }
            set
            { phone2 = value; }
        }
    }
}
