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

namespace FitnessTracker
{
    public partial class Login : Form
    {
        private int failedLoginAttempt = 0;

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
            RegisterFom registerFom = new RegisterFom();
            registerFom.Show();
            this.Hide();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            string userName = login_username.Text;
            string password = login_password.Text;

            //Check if username and password are not empty
            if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter information", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (connectdb db = new connectdb())
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                DataTable table = new DataTable();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn", db.getConnection());
                command.Parameters.AddWithValue("@usn", userName);

                adapter.SelectCommand = command;
                adapter.Fill(table);

                //Check if user exists
                if(table.Rows.Count > 0)
                {
                    //Retrieve the hasehd password from the database
                    string hashedPasswordFromDatabase = table.Rows[0]["password"].ToString();

                    //Hash the password entered by the user
                    PasswordHash passwordHash = new PasswordHash(password);
                    string hashEnteredPassword = passwordHash.HashedPassword;

                    //Compare hashed password from database and entered password
                    if(hashedPasswordFromDatabase == hashEnteredPassword)
                    {
                        //Retrieve the user id from the database
                        int userId = Convert.ToInt32(table.Rows[0]["id"]);

                        //Reset failed login attempts
                        failedLoginAttempt = 0;

                        //Hide the login form and show the main form
                        this.Hide();
                        MainForm mainForm = new MainForm(userId,userName);
                        mainForm.Show();
                    }
                    else
                    {
                        HandleFailedLogin("Invalid Username or Password");
                    }
                }
                else
                {
                    HandleFailedLogin("User does not exists");
                }
            }
        }

        private async void HandleFailedLogin(string message)
        {
            //Increment failed login attempts
            failedLoginAttempt++;

            //Check if maximum failed attempts reached
            if (failedLoginAttempt >= 3)
            {
                //Disable the login button
                login_btn.Enabled = false;

                //Show message to user
                MessageBox.Show("Maximum failed to login attempt reached, You need wait 6 seconds", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //Show message on form
                attemptLabel.Text = "Maximum failed to login attempt reached, You need wait 6 seconds";

                //Wait for 6 seconds
                await Task.Delay(6000);

                //Re-enable the login button
                login_btn.Enabled = true;

                //Reset failed login attempts
                failedLoginAttempt = 0;

                //Clear the message on form
                attemptLabel.Text = "";
            }
            else
            {
                MessageBox.Show(message, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void login_closeLableClick_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

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
    }
}
