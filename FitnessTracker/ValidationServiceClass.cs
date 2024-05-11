using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FitnessTracker
{
    public class ValidationServiceClass
    {
        //Method to validate the user's email format
        public Boolean ValidateEmail(string email)
        {
            //Define regular expression for email format
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            //Use Regex.Match method to check if the email format is valid
            if (!Regex.IsMatch(email, pattern))
            {
                return false; // Invalid email format
            }

            return true; // Valid email format
        }

        //Method to check if username contains special characters
        public Boolean CheckUsernameSpecialChars(string userNameInput)
        {
            //Define regular expression 
            string pattern = @"^[a-zA-Z0-9]+$";

            //Use Regex.Match method to check if the username contains special characters
            if (!Regex.IsMatch(userNameInput, pattern))
            {
                return false; // Sepecial characters found
            }

            return true; // No special characters
        }

        //Method to validate the password format
        public Boolean ValidatePassword(string password)
        {
            //Define regular expression for password format
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{12,}$";

            //Use Regex.Match method to check if the password format is valid
            if (!Regex.IsMatch(password, pattern))
            {
                return false; // Invalid password format
            }

            return true; // Valid password format
        }
    }
}
