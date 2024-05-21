using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessTracker
{
    public class UserServiceClass
    {
        private readonly string connectionString;
        private readonly ValidationServiceClass validationService;

        public UserServiceClass(ValidationServiceClass validationService)
        {
            connectdb db = new connectdb();
            connectionString = db.getConnectionString(); //Get the connection string from database class
            this.validationService = validationService;
        }

        //Method to register a new user
        public void RegisterUser(UserClass user)
        {
            //Check password format
            if (!validationService.ValidatePassword(user.GetPassword()))
            {
                throw new Exception("Password must contain at least 12 characters, one uppercase letter, one lowercase letter and one number");
            }

            //Check the username contains special characters
            if (!validationService.CheckUsernameSpecialChars(user.GetUserName()))
            {
                throw new Exception("Username must not contain special characters");
            }

            //Check the username exists or not 
            if (checkUsername(user.GetUserName()))
            {
                throw new Exception("Username already exists");
            }

            //Check the email exists or not
            if (checkEmailExits(user.GetEmailAddress()))
            {
                throw new Exception("Email already exists");
            }

            //Check the email format
            if (!validationService.ValidateEmail(user.GetEmailAddress()))
            {
                throw new Exception("Invalid email format");
            }

            //Hash password
            PasswordHash passwordHash = new PasswordHash(user.GetPassword());
            string hashedPassword = passwordHash.HashedPassword;

            //Save the user to the database using the connection string
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `users`(`firstname`, `lastname`, `emailaddress`, `username`, `password`) VALUES (@fn, @ln, @em, @un, @pass)", connection);
                cmd.Parameters.AddWithValue("@fn", user.GetFirstName());
                cmd.Parameters.AddWithValue("@ln", user.GetLastName());
                cmd.Parameters.AddWithValue("@em", user.GetEmailAddress());
                cmd.Parameters.AddWithValue("@un", user.GetUserName());
                cmd.Parameters.AddWithValue("@pass", hashedPassword);

                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new Exception("Failed to create your account");
                }
            }
        }

        //check if the username already exists
        public Boolean checkUsername(string username)
        {
            using (connectdb db = new connectdb())
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn", db.getConnection());
                command.Parameters.AddWithValue("@usn", username);

                try
                {
                    db.openConnection();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0; // Assuming username is exists
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error on checking username : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false; // Assuming username is not exists
                }
                finally
                {
                    db.closeConnection();
                }
            }
        }

        //Check if the emails is already exitst or not 
        public Boolean checkEmailExits(string email)
        {
            using (connectdb db = new connectdb())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM `users` WHERE `emailaddress` = @em", db.getConnection());
                cmd.Parameters.AddWithValue("@em", email);

                try
                {
                    db.openConnection();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
                catch (MySqlException ex)
                {
                    //Handle specific database connection error 
                    MessageBox.Show("Error on checking email : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true; // Assume the email exists
                }
                finally
                {
                    db.closeConnection();
                }
            }
        }
    }
}
