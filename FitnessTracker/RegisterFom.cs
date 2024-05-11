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
using Microsoft.VisualBasic.ApplicationServices;
using FitnessTracker;

namespace FitnessTracker
{
    public partial class RegisterFom : Form
    {
        //For redirect to login form
        private readonly Login login = new Login();

        private readonly UserServiceClass userService;

        //Form move
        int mov;
        int movX;
        int movY;

        public RegisterFom(UserServiceClass userService)
        {
            InitializeComponent();
            this.userService = userService;
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
                UserClass user = new UserClass(firstName, lastName, email, userName, password);
                userService.RegisterUser(user); // Call UserService to register

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

            //Check if the password and confirm password match
            if (reg_password.Text != reg_confirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
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
