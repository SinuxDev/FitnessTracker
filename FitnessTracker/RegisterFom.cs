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
    public partial class RegisterFom : Form
    {
        public RegisterFom()
        {
            InitializeComponent();
        }

        private void RegisterFom_Load(object sender, EventArgs e)
        {

        }

        private void reg_loginHere_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
