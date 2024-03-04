using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mysqlx.Datatypes.Scalar.Types;

namespace FitnessTracker
{
    public partial class MainForm : Form
    {
        static string dbString = "server=localhost;port=3306;uid=root;password=root;database=fitnessapp";
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            ////connected to database directly 
            //string connectionString = "server=localhost;port=3306;uid=root;password=root;database=fitnessapp";
            //TrackingClass trackingClass = new TrackingClass(connectionString);

            //int userID = 2;

            //// CaloriesCalClass object created
            //CaloriesCalClass walkingActivity = new CaloriesCalClass("Walking", 1000, 30, 120);

            ////Record the activity and calcualtes calories burned
            //trackingClass.RecordActiviyAndCalculateCalories(userID,"Sinux", walkingActivity);

            //MessageBox.Show("It's Completed");

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void setGoal_btn_Click(object sender, EventArgs e)
        {
            TrackingClass trackingClass = new TrackingClass(dbString);
            string username = GoalsUserNametextbox.Text;
            string caloriesText = setGoals_textbox.Text;

            if(string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(caloriesText))
            {
                MessageBox.Show("Enter your username!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrWhiteSpace(caloriesText) || !string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Enter your calories!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                //parse calories as a double
                if(double.TryParse(caloriesText, out double calories))
                {
                    trackingClass.SetFitnessGoal(username, calories);
                    MessageBox.Show("Your Goals have been set", "SetGoals", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Invalid calories format. Enter a valid number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
