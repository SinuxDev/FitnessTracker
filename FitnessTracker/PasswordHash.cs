using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace FitnessTracker
{
    public class PasswordHash
    {
        public string hashedPassword;

        //Constructor to create a hash of the password
        private PasswordHash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedByte = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashedByte)
                {
                    sb.Append(b.ToString("x2"));
                }
                hashedPassword = sb.ToString();
            }
        }

        //Method to create a hash of the password
        public static PasswordHash CreateHash(string password)
        {
            return new PasswordHash(password);
        }

        //Getter for hashed password
        public string HashedPassword
        {
            get
            {
                return hashedPassword;
            }
        }
    }
}
