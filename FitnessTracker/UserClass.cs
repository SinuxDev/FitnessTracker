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
        //Properties with automatic getters and setters
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        //Constructor to initialize the properties
        public UserClass(string firstName, string lastName, string emailAddress, string userName, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailAddress = emailAddress;
            this.UserName = userName;
            this.Password = password;
        }

        public string GetAndSetFirstName
        {
            get => FirstName;
            set => FirstName = value;
        }

        public string GetAndSetLastName
        {
            get => LastName;
            set => LastName = value;
        }

        public string GetAndSetEmailAddress
        {
            get => EmailAddress;
            set => EmailAddress = value;
        }

        public string GetAndSetUserName
        {
            get => UserName;
            set => UserName = value;
        }

        public string GetAndSetPassword
        {
            get => Password;
            set => Password = value;
        }
    }
}
