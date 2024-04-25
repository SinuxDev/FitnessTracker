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

        //Form move
        int mov;
        int movX;
        int movY;

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

            if (GoalCalories < totalCaloriesBurned)
            {
                Motivation_Label.Text = "Keep up the Great Work! You've Hit Your Calorie Target!";
            }
            else if (GoalCalories == 0 && totalCaloriesBurned == 0)
            {
                Motivation_Label.Text = "Come on let's do it ! Now set your goals";
            }
            else
            {
                if (totalCaloriesBurned <= 0)
                {
                    Motivation_Label.Text = "Do Exercise and achieve your goals";
                }
                else
                {
                    Motivation_Label.Text = "Stay Focused! You're Closer to Your Goal Than You Think!";
                }
            }
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

            //Enable times_textBox only for exercises that require it
            times_textBox.Enabled = new List<string> { "Swimming", "Squat", "Anaerobic", "Push up", "Pull up" }.Contains(selectedExercise);

            //Enable step_textBox only for Walking exercise
            step_textBox.Enabled = selectedExercise == "Walking";
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void setGoal_btn_Click(object sender, EventArgs e)
        {
            string caloriesText = setGoals_textbox.Text;

            if(string.IsNullOrWhiteSpace(caloriesText))
            {
                MessageBox.Show("Please enter your goal calories", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(double.TryParse(caloriesText, out double calories))
            {
                try
                {
                     trackingClass.SetFitnessGoal(_name, calories);
                     MessageBox.Show("Goal set successfully","Set Goals",MessageBoxButtons.OK, MessageBoxIcon.Information);
                     doRefreshGoals();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("An Error Occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid calories format. Please enter a valid number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            setGoals_textbox.Text = "";
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            ReloadLabels();
        }

        private void Delete_acti_record_btn_Click(object sender, EventArgs e)
        {
            //Check if any row is selected
            if (dataGridView2.SelectedRows.Count > 0)
            {
                //Get the index of selected row
                int rowIndex = dataGridView2.SelectedRows[0].Index;

                DeleteRecordActivity(rowIndex);
            }
            else
            {
                MessageBox.Show("Please select a row to delete");
            }
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

        private int DeleteGoalsFromDatabase(string username, double goalCalories)
        {
            int rowsAffected = 0;

            using (MySqlConnection connection = new MySqlConnection(dbString))
            {
                try
                {
                    string query = "DELETE FROM user_goals WHERE username = @username AND goal_calories = @goalCalories";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@goalCalories", goalCalories);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting goal: " + ex.Message);
                }

                connection.Close();
            }

            return rowsAffected;
        }

        private void DeleteUserGoals(int rowIndex)
        {
            //Check if the index is valid
            if(rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
            {
                //Get the selected row's username and goal_calories
                DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];

                //Confirmation dialog
                DialogResult result = MessageBox.Show("Are you sure you want to delete this goal?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //If user confirms deletion
                if (result == DialogResult.Yes)
                {
                    string username = selectedRow.Cells["username"].Value.ToString();
                    double goalCalories = Convert.ToDouble(selectedRow.Cells["goal_calories"].Value);

                    int rowsAffected = DeleteGoalsFromDatabase(username, goalCalories);

                    //Check if the deletion was successful
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Goal deleted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete goal.");
                    }

                    doRefreshGoals();
                }
            }
        }

        private void DeleteRecordActivity(int rowIndex)
        {
            // Check if the index is valid
            if (rowIndex >= 0 && rowIndex < dataGridView2.Rows.Count)
            {
                // Get the user_name, activity, and calories_burned from the selected row
                string userName = dataGridView2.Rows[rowIndex].Cells["user_name"].Value.ToString();
                string activity = dataGridView2.Rows[rowIndex].Cells["activity"].Value.ToString();
                double caloriesBurned = Convert.ToDouble(dataGridView2.Rows[rowIndex].Cells["calories_burned"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this record activity?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If user confirms deletion
                if (result == DialogResult.Yes)
                {
                    // Open a connection to the database
                    using (MySqlConnection connection = new MySqlConnection(dbString))
                    {
                        try
                        {
                            string query = "DELETE FROM record_activities WHERE user_name = @userName AND activity = @activity AND calories_burned = @caloriesBurned";

                            MySqlCommand cmd = new MySqlCommand(query, connection);
                            cmd.Parameters.AddWithValue("@userName", userName);
                            cmd.Parameters.AddWithValue("@activity", activity);
                            cmd.Parameters.AddWithValue("@caloriesBurned", caloriesBurned);

                            connection.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            // Check if the deletion was successful
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Record activity deleted successfully!");
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete record activity.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting record activity: " + ex.Message);
                        }

                        connection.Close();
                        doRefreshRecord();
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid row index.");
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
            string query = "SELECT username,goal_calories FROM user_goals WHERE username = @username";
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

                if (GoalCalories < totalCaloriesBurned)
                {
                    Motivation_Label.Text = "Keep up the Great Work! You've Hit Your Calorie Target!";
                }
                else if (GoalCalories == 0 && totalCaloriesBurned == 0)
                {
                    Motivation_Label.Text = "Come on let's do it ! Now set your goals";
                }
                else
                {
                    if (totalCaloriesBurned <= 0)
                    {
                        Motivation_Label.Text = "Do Exercise and achieve your goals";
                    }
                    else
                    {
                        Motivation_Label.Text = "Stay Focused! You're Closer to Your Goal Than You Think!";
                    }
                }
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void Logout_btn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
