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
using static Mysqlx.Datatypes.Scalar.Types;

namespace FitnessTracker
{
    public partial class MainForm : Form
    {
        static string dbString ="server=localhost;port=3306;uid=root;password=root;database=fitnessapp";
        connectdb db = new connectdb();
        private int _userId;
        private string _name;

        public MainForm(int userId, string username)
        {
            InitializeComponent();

            //Store the userId for later use
            _userId = userId;
            _name = username;
        }

        public int GetUserId()
        {
            return _userId;
        }

        public string GetName()
        {
            return _name;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
            //// CaloriesCalClass object created
            //CaloriesCalClass walkingActivity = new CaloriesCalClass("Walking", 1000, 30, 120);

            ////Record the activity and calcualtes calories burned
            //trackingClass.RecordActiviyAndCalculateCalories(userID,"Sinux", walkingActivity);

            //MessageBox.Show("It's Completed");
        }

        private void CaloriesCal_Btn_Click(object sender, EventArgs e)
        {
            TrackingClass trackingClass = new TrackingClass(dbString);
            CaloriesCalClass calories;
            string durationInput = exe_duration_textBox.Text;
            double duration;
            if (!double.TryParse(durationInput, out duration))
            {
                MessageBox.Show(
                    "Please enter a valid value for duration.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            string timeInput = times_textBox.Text;
            double times;
            if (!double.TryParse(timeInput, out times))
            {
                MessageBox.Show(
                    "Please enter a valid value for times .",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            string stepInput = step_textBox.Text;
            double steps;
            if (!double.TryParse(stepInput, out steps))
            {
                MessageBox.Show(
                    "Please enter a valid value for steps .",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            string selectedExercise = exe_ComboList.Text;

            calories = new CaloriesCalClass(selectedExercise, times, steps, duration);

            trackingClass.RecordActiviyAndCalculateCalories(_userId,_name, calories);
            MessageBox.Show("It' completed");
        }

        private void exe_ComboList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedExercise = exe_ComboList.Text;

            if (selectedExercise == "Walking")
            {
                times_textBox.Enabled = false;
            }
            else
            {
                times_textBox.Enabled = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void setGoal_btn_Click(object sender, EventArgs e)
        {
            TrackingClass trackingClass = new TrackingClass(dbString);
            string caloriesText = setGoals_textbox.Text;

            if (string.IsNullOrWhiteSpace(caloriesText))
            {
                MessageBox.Show(
                    "Enter your calories!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                //parse calories as a double
                if (double.TryParse(caloriesText, out double calories))
                {
                    trackingClass.SetFitnessGoal(_name, calories);
                    MessageBox.Show(
                        "Your Goals have been set",
                        "SetGoals",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "Invalid calories format. Enter a valid number.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        private void FillUserDGV(string username)
        {
            db.openConnection();

            string query = "SELECT * FROM user_goals WHERE username = @username";
            MySqlCommand command = new MySqlCommand(query, db.getConnection());
            command.Parameters.AddWithValue("@username", username);

            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            db.closeConnection();
        }
    }
}
