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
using System.Data;


namespace FitnessTracker
{
    public partial class RegisterFom : Form
    {
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
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        //For SignUp button to register account
        private void reg_registerBtn_Click(object sender, EventArgs e)
        {
            //add new User
            connectdb db = new connectdb();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`firstname`, `lastname`, `emailaddress`, `username`, `password`) VALUES (@fn, @ln, @email, @usn, @pass)", db.getConnection());

            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = reg_firstName.Text;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = reg_lastName.Text;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = reg_email.Text;
            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = reg_userName.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = reg_password.Text;

            //open the db connection
            db.openConnection();

            if (checkUsername())
            {
                MessageBox.Show("This Username is already exists, select A different One");
            }
            else
            {
                //Query Execute
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Account Created!!");
                }
                else
                {
                    MessageBox.Show("ERROR");
                }
            }

            //close the db connection
            db.closeConnection();
        }

        //check if the username already exists
        public Boolean checkUsername()
        {
            connectdb db = new connectdb();

            String username = reg_userName.Text;
            
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            //check the user exists in the database 
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void reg_firstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void reg_firstName_Enter(object sender, EventArgs e)
        {
            String fname = reg_firstName.Text;
            if (fname.ToLower().Trim().Equals("first name"))
            {
                reg_firstName.Text = " ";
                reg_firstName.ForeColor = Color.Black;
            }
        }

        private void reg_firstName_Leave(object sender, EventArgs e)
        {
            String fname = reg_firstName.Text;
            if (fname.ToLower().Trim().Equals("first name") || fname.Trim().Equals(""))
            {
                reg_firstName.Text = "first name";
                reg_firstName.ForeColor = Color.Gray;
            }
        }

        private void reg_lastName_Enter(object sender, EventArgs e)
        {
            String lname = reg_lastName.Text;
            if (lname.ToLower().Trim().Equals("last name"))
            {
                reg_lastName.Text = " ";
                reg_lastName.ForeColor = Color.Black;
            }
        }

        private void reg_lastName_Leave(object sender, EventArgs e)
        {
            String lname = reg_lastName.Text;
            if(lname.ToLower().Trim().Equals("last name") || lname.Trim().Equals(""))
            {
                reg_lastName.Text = "last name";
                reg_lastName.ForeColor = Color.Gray;
            }
        }

        private void reg_email_Enter(object sender, EventArgs e)
        {
            String email = reg_email.Text;
            if(email.ToLower().Trim().Equals("email address"))
            {
                reg_email.Text = " ";
                reg_email.ForeColor = Color.Black;
            }
        }

        private void reg_email_Leave(object sender, EventArgs e)
        {
            String email = reg_email.Text;
            if(email.ToLower().Trim().Equals("email address") || email.Trim().Equals(""))
            {
                reg_email.Text = "email address";
                reg_email.ForeColor = Color.Gray;
            }
        }

        private void reg_userName_Enter(object sender, EventArgs e)
        {
            String userName = reg_userName.Text;
            if (userName.ToLower().Trim().Equals("username"))
            {
                reg_userName.Text = " ";
                reg_userName.ForeColor = Color.Black;
            }
        }

        private void reg_userName_Leave(object sender, EventArgs e)
        {
            String userName = reg_userName.Text;
            if(userName.ToLower().Trim().Equals("username") || userName.Trim().Equals(""))
            {
                reg_userName.Text = "username";
                reg_userName.ForeColor = Color.Gray;
            }
        }

        private void reg_password_Enter(object sender, EventArgs e)
        {
            String password = reg_password.Text;
            if (password.ToLower().Trim().Equals("password"))
            {
                reg_password.Text = "";
                reg_password.UseSystemPasswordChar = true;
                reg_password.ForeColor = Color.Black;
            }
        }

        private void reg_password_Leave(object sender, EventArgs e)
        {
            String password = reg_password.Text;
            if (password.ToLower().Trim().Equals("password") || password.Trim().Equals(""))
            {
                reg_password.Text = "password";
                reg_password.UseSystemPasswordChar = false;
                reg_password.ForeColor = Color.Gray;
            }
        }

        private void reg_confirmPassword_Enter(object sender, EventArgs e)
        {
            String cpassword = reg_confirmPassword.Text;
            if (cpassword.ToLower().Trim().Equals("confirm password"))
            {
                reg_confirmPassword.Text = "";
                reg_confirmPassword.UseSystemPasswordChar = true;
                reg_confirmPassword.ForeColor = Color.Black;
            }
        }

        private void reg_confirmPassword_Leave(object sender, EventArgs e)
        {
            String cpassword = reg_confirmPassword.Text;
            if (cpassword.ToLower().Trim().Equals("confirm password") || cpassword.Trim().Equals(""))
            {
                reg_confirmPassword.Text = "confirm password";
                reg_confirmPassword.UseSystemPasswordChar = false;
                reg_confirmPassword.ForeColor = Color.Gray;
            }
        }

        private void reg_closeLabelClick_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
