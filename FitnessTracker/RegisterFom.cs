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
           
        }
    }
}
