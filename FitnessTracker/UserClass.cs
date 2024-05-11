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
        public UserClass(string firstName, string lastName, string emailAddress, string username, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailAddress = emailAddress;
            this.UserName = username;
            this.Password = password;
        }

        //Method to validate the user's email format
        public Boolean ValidateEmail()
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(this.EmailAddress, pattern);
        }

        //Method to check if username contains special characters
        public Boolean CheckUsernameSpecialChars()
        {
            string pattern = @"^[a-zA-Z0-9]*$";
            return Regex.IsMatch(this.UserName, pattern);
        }

        //Method to validate the password format
        public Boolean ValidatePassword()
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";
            return Regex.IsMatch(this.Password, pattern);
        }
    }
}
