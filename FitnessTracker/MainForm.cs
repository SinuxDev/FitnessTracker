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
        static string dbString =
            "server=localhost;port=3306;uid=root;password=root;database=fitnessapp";
        connectdb db = new connectdb();
        TrackingClass trackingClass = new TrackingClass(dbString);
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
            FillUserGoalsDGV(_name);
            FillRecordActivities(_userId);

            int totalCaloriesBurned = trackingClass.GetTotalCaloriesBurned(_name);
            calories_label.Text = totalCaloriesBurned.ToString();

            int GoalCalories = trackingClass.GetUserGoalCalories(_name);
            goal_calorieslabel.Text = GoalCalories.ToString();
        }

        private void CaloriesCal_Btn_Click(object sender, EventArgs e)
        {
            TrackingClass trackingClass = new TrackingClass(dbString);
            CaloriesCalClass calories;

            // Validate and parse duration
            if (!double.TryParse(exe_duration_textBox.Text, out double duration) || duration <= 0)
            {
                MessageBox.Show(
                    "Please enter a valid positive value for duration.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            //Set default vales for times when it's not need
            double times = 1;
            if (exe_ComboList.Text != "Walking")
            {
                // Validate and parse times
                if (!double.TryParse(times_textBox.Text, out times) || times <= 0)
                {
                    MessageBox.Show(
                        "Please enter a valid positive value for times.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }
            }

            // Set default value for steps when it's not need
            double steps = 1;
            if (
                exe_ComboList.Text != "Swimming"
                && exe_ComboList.Text != "Squat"
                && exe_ComboList.Text != "Anaerobic"
                && exe_ComboList.Text != "Push up"
                && exe_ComboList.Text != "Pull up"
            )
            {
                // Validate and parse steps
                if (!double.TryParse(step_textBox.Text, out steps))
                {
                    MessageBox.Show(
                        "Please enter a valid value for steps.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }
            }

            string selectedExercise = exe_ComboList.Text;

            calories = new CaloriesCalClass(selectedExercise, times, steps, duration);

            trackingClass.RecordActiviyAndCalculateCalories(_userId, _name, calories);
            doRefreshRecord();
            MessageBox.Show("Data have been saved!");

            //Clear the textboxes after the process
            exe_duration_textBox.Text = "";
            times_textBox.Text = "";
            step_textBox.Text = "";
        }

        private void exe_ComboList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedExercise = exe_ComboList.Text;

            switch (selectedExercise)
            {
                case "Walking":
                    times_textBox.Enabled = false;
                    step_textBox.Enabled = true;
                    break;
                case "Swimming":
                    times_textBox.Enabled = true;
                    step_textBox.Enabled = false;
                    break;
                case "Squat":
                    step_textBox.Enabled = false;
                    times_textBox.Enabled = true;
                    break;
                case "Anaerobic":
                    step_textBox.Enabled = false;
                    times_textBox.Enabled = true;
                    break;
                case "Push up":
                    step_textBox.Enabled = false;
                    times_textBox.Enabled = true;
                    break;
                case "Pull up":
                    step_textBox.Enabled = false;
                    times_textBox.Enabled = true;
                    break;
                default:
                    step_textBox.Enabled = true;
                    times_textBox.AcceptsReturn = true;
                    break;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void setGoal_btn_Click(object sender, EventArgs e)
        {
            string caloriesText = setGoals_textbox.Text;
            if (string.IsNullOrWhiteSpace(caloriesText))
            {
                MessageBox.Show(
                    "Enter your calories!",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
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
                        MessageBoxIcon.Information
                    );
                    doRefreshGoals();
                }
                else
                {
                    MessageBox.Show(
                        "Invalid calories format. Enter a valid number.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
            setGoals_textbox.Text = "";

        }

        
        private void DelectGoals_btn_Click(object sender, EventArgs e)
        {
            //Check if any row is selected
            if(dataGridView1.SelectedRows.Count > 0)
            {
                //Get the index of selected row
                int rowIndex = dataGridView1.SelectedRows[0].Index;

                DeleteUserGoals(rowIndex);
            }
            else
            {
                MessageBox.Show("Please select a row to delete");
            }
        }

        private void DeleteUserGoals(int rowIndex)
        {
            //Check if the index is valid
            if(rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
            {
                //Get the rowIndex 
                DataGridViewRow seletedRow = dataGridView1.Rows[rowIndex];

                //Confirmation dialog
                DialogResult res = MessageBox.Show("Are you sure you want to delete ?","Delete or not?", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    //Open connection to  database 
                    using (MySqlConnection conn = new MySqlConnection(dbString))
                    {
                        try
                        {
                            string query = "DELETE FROM user_goals WHERE username = @username AND goal_calories = @goal_calories";
                            MySqlCommand cmd = new MySqlCommand(query, conn);

                            cmd.Parameters.AddWithValue("@username", seletedRow.Cells["username"].Value.ToString());
                            cmd.Parameters.AddWithValue("@goal_calories", Convert.ToDouble(seletedRow.Cells["goal_calories"].Value));

                            conn.Open();
                            int rowAffected = cmd.ExecuteNonQuery();

                            //Check if the delete process is success
                            if (rowAffected > 0)
                            {
                                //Remove the selected row from the DataGridView
                                dataGridView1.Rows.RemoveAt(rowIndex);
                                MessageBox.Show("Goal deleted Successfully");
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete goal from database");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error Deleting goal : " + ex.Message);
                        }

                        conn.Close();
                        doRefreshGoals();
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid row index");
            }
        }

        private void FillUserGoalsDGV(string username)
        {
            db.openConnection();

            string query =
                "SELECT username,goal_calories FROM user_goals WHERE username = @username";
            MySqlCommand command = new MySqlCommand(query, db.getConnection());
            command.Parameters.AddWithValue("@username", username);

            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            db.closeConnection();
        }

        private void FillRecordActivities(int userID)
        {
            db.openConnection();

            string query =
                "SELECT user_name,activity,calories_burned FROM record_activities WHERE user_ID = @userID";
            MySqlCommand command = new MySqlCommand(query, db.getConnection());
            command.Parameters.AddWithValue("@userID", userID);

            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView2.DataSource = dataTable;

            db.closeConnection();
        }

        public void doRefreshGoals()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            db.openConnection();
            string query = "SELECT * FROM user_goals WHERE username = @username";
            MySqlCommand command = new MySqlCommand(query, db.getConnection());
            command.Parameters.AddWithValue("@username", _name);

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;

            db.closeConnection();
        }

        public void doRefreshRecord()
        {
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();

            db.openConnection();
            string query =
                "SELECT user_name,activity,calories_burned FROM record_activities WHERE user_ID = @userID";
            MySqlCommand command = new MySqlCommand(query, db.getConnection());
            command.Parameters.AddWithValue("@userID", _userId);

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);

            dataGridView2.DataSource = dataTable;

            db.closeConnection();
        }

        private void ReloadLabels()
        {
            try
            {
                int totalCaloriesBurned = trackingClass.GetTotalCaloriesBurned(_name);
                calories_label.Text = totalCaloriesBurned.ToString();

                int GoalCalories = trackingClass.GetUserGoalCalories(_name);
                goal_calorieslabel.Text = GoalCalories.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error reloading the labels : " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            ReloadLabels();
        }

        
    }
}
