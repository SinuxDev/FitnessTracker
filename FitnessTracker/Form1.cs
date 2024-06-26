﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FitnessTracker
{
    public partial class Login : Form
    {
        private int failedLoginAttempt = 0;
        private const int MaxFailedLoginAttempt = 3;
        private const int DelayTimeMilliseconds = 6000;

        //Form move
        int mov;
        int movX;
        int movY;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e) 
        {
            attemptLabel.Text = "";
        }

        //show the Register Form
        private void login_registerHere_Click(object sender, EventArgs e)
        {
            UserServiceClass userService = new UserServiceClass(new ValidationServiceClass());

            RegisterFom registerFom = new RegisterFom(userService);
            registerFom.Show();
            this.Hide();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            string userName = login_username.Text;
            string password = login_password.Text;

            //Check if username and password are not empty
            if(!IsInputValid(userName,password))
            {
                MessageBox.Show("Please enter information", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (connectdb db = new connectdb())
            {
                using (MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn", db.getConnection()))
                {
                    command.Parameters.AddWithValue("@usn", userName);

                    //Open the connection
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        //Check if username exists
                        if(table.Rows.Count > 0)
                        {
                            string hashedPasswordFromDatabase = table.Rows[0]["password"].ToString(); //Get the hashed password from database
                            PasswordHash passwordHash = PasswordHash.CreateHash(password); //Hash the input password
                            string hashedInputPassword = passwordHash.HashedPassword; //Get the hashed input password

                            if (hashedPasswordFromDatabase == hashedInputPassword)
                            {
                                int userId = Convert.ToInt32(table.Rows[0]["id"]); //Get the user id
                                string email = table.Rows[0]["emailaddress"].ToString(); //Get the email
                                failedLoginAttempt = 0;

                                //Show the main form
                                this.Hide();
                                ResultChart resultChart = new ResultChart(userName, userId, email);
                                resultChart.Show();
                            }
                            else
                            {
                                HandleFailedLogin("Invalid Useranme or Password");
                            }
                        }
                        else
                        {
                            HandleFailedLogin("User does not exist");
                        }
                    }
                }
            }
        }

        //Check if username and password are not empty
        private bool IsInputValid(string userName, string password)
        {
            return !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password);
        }

        private async void HandleFailedLogin(string message)
        {
            //Increment failed login attempts
            failedLoginAttempt++;

            //Check if maximum failed attempts reached
            if (failedLoginAttempt >= MaxFailedLoginAttempt)
            {
                //Disable the login button
                login_btn.Enabled = false;

                //Show message to user
                string warningMessage = "Maximum failed to login attempt reached, You need to wait 6 seconds";
                showErrorMessage(warningMessage);

                //Show message on form
                attemptLabel.Text = warningMessage;

                //Wait for 6 seconds
                await Task.Delay(DelayTimeMilliseconds);

                //Re-enable the login button
                login_btn.Enabled = true;

                //Reset failed login attempts
                failedLoginAttempt = 0;

                //Clear the message on form
                attemptLabel.Text = "";
            }
            else
            {
                showErrorMessage(message);
            }
        }

        //Show error message
        private void showErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Close the application
        private void login_closeLableClick_Click(object sender, EventArgs e)
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

        //Show or hide the password
        private void Login_showPassword_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Login_showPassword_checkBox.Checked)
            {
                login_password.PasswordChar = '\0';
                Login_showPassword_checkBox.Text = "Hide Password";
            }
            else
            {
                login_password.PasswordChar = '*';
                Login_showPassword_checkBox.Text = "Show Password";
            }
        }

        private void forget_password_click_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Instantiate the connectdb class
            using (connectdb db = new connectdb())
            {
                //Get the connection string from connectdb class
                string connectionString = db.getConnectionString();

                //Show the ForgetPasswordForm and pass the connection string
                forgetPasswordForm forgetPasswordForm = new forgetPasswordForm(connectionString);
                forgetPasswordForm.Show();
                this.Hide();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
