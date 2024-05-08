using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace FitnessTracker
{
    public partial class RegisterFom : Form
    {
        //For redirect to login form
        Login login = new Login();

        //Form move
        int mov;
        int movX;
        int movY;
        public RegisterFom()
        {
            InitializeComponent();
        }

        private void RegisterFom_Load(object sender, EventArgs e)
        {
            //remove the focus from the textboxes
            this.ActiveControl = label1;
        }

        //Show the Login Form
        private void reg_loginHere_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Hide();
        }

        //For SignUp button to register account
        private void reg_registerBtn_Click(object sender, EventArgs e)
        {
            if(!ValiateInput())
            {
                return;
            }

            string firstName = reg_firstName.Text;
            string lastName = reg_lastName.Text;
            string email = reg_email.Text;
            string userName = reg_userName.Text;
            string password = reg_password.Text;

            try
            {
                HashAndSaveUser(firstName, lastName, email, userName, password);
                MessageBox.Show("Your Account Has Been Created", "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearInputFileds();
                SwitchToLoginPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show("User Creating Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValiateInput()
        {
            //Check if all the textboxes has values
            if (checkTextBoxesValues())
            {
                MessageBox.Show("Enter your information first", "Empty Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Check if the password meet the requirement
            if (!ValidatePassword())
            {
                MessageBox.Show("Password must be 12 characters long and contain at least one uppercase and one lowercase letter", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false ;
            }

            //Check if the password and confirm password match
            if (reg_password.Text != reg_confirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Check if the username containes special characters
            if (!checkUsernameSpecialChar())
            {
                MessageBox.Show("Username can only contain letters and numbers", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Check if the username already exists
            if (checkUsername())
            {
                MessageBox.Show("This Username Already Exists, Select A Different One", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Check if the email format is valid
            if (!checkEmailFormat())
            {
                MessageBox.Show("Invalid Email Format", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Check if the email already exists
            if (checkEmailExits())
            {
                MessageBox.Show("This Email Already Exists, Select A Different One", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        //Hash the password and save the user into the database
        private void HashAndSaveUser(string firstname, string lastName, string email, string userName, string password)
        {
            //Hash the password
            PasswordHash passwordHash = new PasswordHash(password);
            string hashedPassword = passwordHash.HashedPassword;

            //Add new user into the database
            using (connectdb db = new connectdb())
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `users`(`firstname`, `lastname`, `emailaddress`, `username`, `password`) VALUES (@fn, @ln, @em, @un, @pass)", db.getConnection());
                cmd.Parameters.AddWithValue("@fn", firstname);
                cmd.Parameters.AddWithValue("@ln", lastName);
                cmd.Parameters.AddWithValue("@em", email);
                cmd.Parameters.AddWithValue("@un", userName);
                cmd.Parameters.AddWithValue("@pass", hashedPassword);

                db.openConnection();

                if(cmd.ExecuteNonQuery() != 1)
                {
                    throw new Exception("Failed to create your account");
                }
            }
        }

        //Clear the input fields
        private void ClearInputFileds()
        {
            reg_firstName.Text = "";
            reg_lastName.Text = "";
            reg_email.Text = "";
            reg_userName.Text = "";
            reg_password.Text = "";
            reg_confirmPassword.Text = "";
        }

        //Switch to the login page
        private void SwitchToLoginPage()
        {
            login.Show();
            this.Hide();
        }

        //check if the username already exists
        public Boolean checkUsername()
        {
            string username = reg_userName.Text;
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

        //Check if the username contain the special characters
        public Boolean checkUsernameSpecialChar()
        {
            String userNameInput= reg_userName.Text;

            //Define regular expression 
            string pattern = @"^[a-zA-Z0-9]+$";

            //Use Regex.Match method to check if the username contains special characters
            if (!Regex.IsMatch(userNameInput, pattern))
            {
                return false; // Sepecial characters found
            }

            return true; // No special characters
        }

        //Check if the emails is already exitst or not 
        public Boolean checkEmailExits()
        {
            string email = reg_email.Text;
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

        // Check the email format
        public Boolean checkEmailFormat()
        {
            string email = reg_email.Text;

            //Define regular expression for email format
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            //Use Regex.Match method to check if the email format is valid
            if (!Regex.IsMatch(email, pattern))
            {
                return false; // Invalid email format
            }

            return true; // Valid email format
        }

        //check if the textboxes has values
        public Boolean checkTextBoxesValues()
        {
            string firstName = reg_firstName.Text.Trim();
            string lastName = reg_lastName.Text.Trim();
            string email = reg_email.Text.Trim();
            string userName = reg_userName.Text.Trim();
            string password = reg_password.Text.Trim();
            string confirmPassword = reg_confirmPassword.Text.Trim();

            return string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword);
        }

        // check if the password meet the requirement
        public Boolean ValidatePassword()
        {
            string password = reg_password.Text;

            //Define regular expression for password format
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{12,}$";

            //Use Regex.Match method to check if the password format is valid
            if (!Regex.IsMatch(password, pattern))
            {
                return false; // Invalid password format
            }

            return true; // Valid password format
        }

        //Close the application
        private void reg_closeLabelClick_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Move the form
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        //Move the form
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        //Move the form
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        //Show and hide the password
        private void Reg_showPassword_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(Reg_showPassword_CheckBox.Checked)
            {
                reg_password.PasswordChar = '\0';
                reg_confirmPassword.PasswordChar = '\0';
                Reg_showPassword_CheckBox.Text = "Hide Password";
            }
            else
            {
                reg_password.PasswordChar = '*';
                reg_confirmPassword.PasswordChar = '*';
                Reg_showPassword_CheckBox.Text = "Show Password";
            }
        }
    }
}
