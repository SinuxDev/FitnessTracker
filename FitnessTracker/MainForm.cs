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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            //connected to database directly 
            string connectionString = "server=localhost;port=3306;uid=root;password=root;database=fitnessapp";
            TrackingClass trackingClass = new TrackingClass(connectionString);

            int userID = 2;

            // CaloriesCalClass object created
            CaloriesCalClass walkingActivity = new CaloriesCalClass("Walking", 1000, 30, 120);

            //Record the activity and calcualtes calories burned
            trackingClass.RecordActiviyAndCalculateCalories(userID,"Sinux", walkingActivity);

            MessageBox.Show("It's Completed");

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
