using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FitnessTracker
{
    public class UserClass
    {
        private string FirstName;
        private string LastName;
        private string EmailAddress;
        private string UserName;
        private string Password;

        //Constructor to initialize the properties
        public UserClass(string firstName, string lastName, string emailAddress, string userName, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailAddress = emailAddress;
            this.UserName = userName;
            this.Password = password;
        }

        public string GetFirstName()
        {
            return this.FirstName;
        }

        public void SetFirstName(string firstName)
        {
            if(firstName.Length > 50)
            {
                throw new Exception("First name cannot be more than 50 characters");
            }
            this.FirstName = firstName;
        }


        public string GetLastName()
        {
            return this.LastName;
        }

        public void SetLastName(string lastName)
        {
            if (lastName.Length > 50)
            {
                throw new Exception("Last name cannot be more than 50 characters");
            }
            this.LastName = lastName;
        }

        public string GetEmailAddress()
        {
            return this.EmailAddress;
        }

        public void SetEmailAddress(string emailAddress)
        {
            if (!Regex.IsMatch(emailAddress, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                throw new Exception("Invalid email format");
            }
            this.EmailAddress = emailAddress;
        }

        public string GetUserName()
        {
            return this.UserName;
        }

        public void SetUserName(string userName)
        {
            if (userName.Length > 50)
            {
                throw new Exception("Username cannot be more than 50 characters");
            }
            this.UserName = userName;
        }

        public string GetPassword()
        {
            return this.Password;
        }

        public void SetPassword(string password)
        {
            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{12}$"))
            {
                throw new Exception("Password must contain 12 characters, one uppercase letter, one lowercase letter and one number");
            }
            this.Password = password;
        }
    }
}
