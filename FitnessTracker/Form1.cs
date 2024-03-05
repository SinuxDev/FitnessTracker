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

        private void Login_Load(object sender, EventArgs e) { }

        //show the Register Form
        private void login_registerHere_Click(object sender, EventArgs e)
        {
            RegisterFom registerFom = new RegisterFom();
            registerFom.Show();
            this.Hide();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            connectdb db = new connectdb();

            String username = login_username.Text;
            String password = login_password.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand(
                "SELECT * FROM `users` WHERE `username` = @usn and `password` = @pass",
                db.getConnection()
            );

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            //check the user is valid or not
            if (table.Rows.Count > 0)
            {
                //Retrieve the user'ID from the database
                int userId = Convert.ToInt32(table.Rows[0]["id"]);

                this.Hide();
                MainForm mainForm = new MainForm(userId, username);
                mainForm.Show();
            }
            else
            {
                //Increment failed login attempts
                failedLoginAttempt++;

                //Check if maximum failed attempts reached
                if (failedLoginAttempt >= 3)
                {
                    MessageBox.Show(
                        "Maximum failed to login attempt reached",
                        "Try again",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                else
                {
                    if (username.Trim().Equals(""))
                    {
                        MessageBox.Show(
                            "Enter Your Username to Login",
                            "Empty Username",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                    else if (password.Trim().Equals(""))
                    {
                        MessageBox.Show(
                            "Enter Your Password to Login",
                            "Empty Password",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            "Wrong Username or Password",
                            "Wrong Data",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
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
    }
}
