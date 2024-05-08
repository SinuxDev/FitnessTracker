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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static Mysqlx.Datatypes.Scalar.Types;

namespace FitnessTracker
{
    public partial class MainForm : Form
    {
        static string dbString = "server=localhost;port=3306;uid=root;password=root;database=fitnessapp";
        connectdb db = new connectdb();
        TrackingClass trackingClass = new TrackingClass(dbString);

        private int _userId;
        private string _name;
        private string _email;

        //Form move
        int mov;
        int movX;
        int movY;

        public MainForm(int userId, string username, string email)
        {
            InitializeComponent();

            //Store the userId for later use
            _userId = userId;
            _name = username;
            _email = email;
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
            doRefreshGoals();
            doRefreshRecord();
        }

        private void Result_Btn_Click(object sender, EventArgs e)
        {
            if(trackingClass.GetTotalCaloriesBurned(_name) == 0)
            {
                MessageBox.Show("You have not recorded any activities yet. Please record some activities first.");
                return;
            }

            this.Hide();
            ResultChart resultChart = new ResultChart(_name,_userId,_email);
            resultChart.Show();
        }

        private void CaloriesCal_Btn_Click(object sender, EventArgs e)
        {
            TrackingClass trackingClass = new TrackingClass(dbString);
            
            // Validate and parse duration
            if (!double.TryParse(exe_duration_textBox.Text, out double duration) || duration <= 0)
            {
                ShowErrorMessage("Please enter a valid positive value for duration.");
                return;
            }

            double times = 1;
            if(exe_ComboList.Text != "Walking")
            {
                if(!double.TryParse(times_textBox.Text, out times) || times <= 0)
                {
                    ShowErrorMessage("Please enter a valid positive value for times.");
                    return;
                }
            }

            double steps = 1;
            if(ShouldValidateSteps(exe_ComboList.Text))
            {
                if(!double.TryParse(step_textBox.Text, out steps))
                {
                    ShowErrorMessage("Please enter a valid value for steps.");
                    return;
                }
            }

            string selectedExercise = exe_ComboList.Text;

            CaloriesCalClass calories = new CaloriesCalClass(selectedExercise, times, steps, duration);

            trackingClass.RecordActiviyAndCalculateCalories(_userId, _name, calories);
            doRefreshRecord();
            MessageBox.Show("Data have been saved!");

            //Clear the textboxes after the process
            exe_duration_textBox.Text = "";
            times_textBox.Text = "";
            step_textBox.Text = "";
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool ShouldValidateSteps(string exercise)
        {
            return exercise != "Swimming" && exercise != "Squat" && exercise != "Anaerobic" && exercise != "Push up" && exercise != "Pull up";
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
            if (rowIndex >= 0 && rowIndex < dataGridView2.Rows.Count)
            {
                string userName = dataGridView2.Rows[rowIndex].Cells["user_name"].Value.ToString();
                string activityName = dataGridView2.Rows[rowIndex].Cells["activity"].Value.ToString();

                //Check the username and activityname have values
                if(userName != null && activityName != null)
                {
                    double caloriesBurned;
                    if (double.TryParse(dataGridView2.Rows[rowIndex].Cells["calories_burned"].Value.ToString(), out caloriesBurned))
                    {
                        if(MessageBox.Show("Are you sure want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            using(MySqlConnection connection = new MySqlConnection(dbString))
                            {
                                try
                                {
                                    string query = "DELETE FROM record_activities WHERE user_name = @un AND activity = @an AND calories_burned = @cb";
                                    MySqlCommand command = new MySqlCommand(query, connection);
                                    command.Parameters.AddWithValue("@un", userName);
                                    command.Parameters.AddWithValue("@an", activityName);
                                    command.Parameters.AddWithValue("@cb", caloriesBurned);
                                    connection.Open();
                                    int rowsAffected = command.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Record deleted successfully!");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to delete record.");
                                    }
                                }
                                catch(Exception ex)
                                {
                                    MessageBox.Show("Error deleting record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                                connection.Close();
                                doRefreshRecord();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid calories values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or activity name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid row index", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillUserGoalsDGV(string username)
        {
            try
            {
                //Open the database connection
                db.openConnection();

                string query = "SELECT username,goal_calories FROM user_goals WHERE username = @username";
                MySqlCommand command = new MySqlCommand(query, db.getConnection());
                command.Parameters.AddWithValue("@username", username);

                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error on Loading user goals" + ex.Message);
            }
            finally
            {
                //Close the database connection
                db.closeConnection();
            }
        }

        private void FillRecordActivities(int userID)
        {
            try
            {
                //Open the database connection
                db.openConnection();

                string query = "SELECT user_name,activity,calories_burned FROM record_activities WHERE user_ID = @userID";
                MySqlCommand command = new MySqlCommand(query, db.getConnection());
                command.Parameters.AddWithValue("@userID", userID);

                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView2.DataSource = dataTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error on Loading record activities" + ex.Message);
            }
            finally
            {
                //Close the database connection
                db.closeConnection();
            }
        }

        public void doRefreshGoals()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            try
            {
                //Open the database connection
                db.openConnection();
                string query = "SELECT username,goal_calories FROM user_goals WHERE username = @username";
                MySqlCommand command = new MySqlCommand(query, db.getConnection());
                command.Parameters.AddWithValue("@username", _name);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error on Refreshing Goals" + ex.Message);
            }
            finally
            {
                //Close the database connection
                db.closeConnection();
            }
        }

        public void doRefreshRecord()
        {
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();

            try
            {
                //Open the database connection
                db.openConnection();
                string query = "SELECT user_name,activity,calories_burned FROM record_activities WHERE user_ID = @userID";
                MySqlCommand command = new MySqlCommand(query, db.getConnection());
                command.Parameters.AddWithValue("@userID", _userId);

                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);

                dataGridView2.DataSource = dataTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error on refreshing record" + ex.Message);
            }
            finally
            {
                //Close the database connection
                db.closeConnection();
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
