using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessTracker
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
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
            connectdb db = new connectdb();

            String username = login_username.Text;
            String password = login_password.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn and `password` = @pass", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            //check the user exists or not 
            if(table.Rows.Count > 0)
            {
                MessageBox.Show("Yes");
            }
            else
            {
                MessageBox.Show("No");
            }
        }

        private void login_closeLableClick_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
