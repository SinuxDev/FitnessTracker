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
        UserDataClass userDataClass = new UserDataClass();

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

            //Set the user id, name and email
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
            string currentUsername = GetName();

            //Get the user's fitness goal
            DataTable userGoalsTable = userDataClass.FillUserGoalsDGV(currentUsername);
            
            if(userGoalsTable != null)
            {
                user_goals_dataGrid.DataSource = userGoalsTable;
            }
            else
            {
                MessageBox.Show("Failed to load user goals");
            }

            //Get the user's record activities
            DataTable userRecordTable = userDataClass.FillUserRecordsDGV(currentUsername);
            
            if(userRecordTable != null)
            {
                user_recordActivities_DGV.DataSource = userRecordTable;
            }
            else
            {
                MessageBox.Show("Failed to load user record activities");
            }

            //Reload the User Goals
            userDataClass.doRefreshGoals(currentUsername, user_goals_dataGrid);

            //Reload the User Records
            userDataClass.doRefreshRecords(currentUsername, user_recordActivities_DGV);
        }

        private void Result_Btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResultChart resultChart = new ResultChart(_name,_userId,_email);
            resultChart.Show();
        }

        //Calculate calories button
        private void CaloriesCal_Btn_Click(object sender, EventArgs e)
        {
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
            userDataClass.doRefreshRecords(_name, user_recordActivities_DGV);
            MessageBox.Show("Data have been saved!");

            //Clear the textboxes after the process
            exe_duration_textBox.Text = "";
            times_textBox.Text = "";
            step_textBox.Text = "";
        }

        //Show error message
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Check if the exercise requires steps
        private bool ShouldValidateSteps(string exercise)
        {
            return exercise != "Swimming" && exercise != "Squat" && exercise != "Anaerobic" && exercise != "Push up" && exercise != "Pull up";
        }

        //Exercise combo list
        private void exe_ComboList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedExercise = exe_ComboList.Text;

            //Enable times_textBox only for exercises that require it
            times_textBox.Enabled = new List<string> { "Swimming", "Squat", "Anaerobic", "Push up", "Pull up" }.Contains(selectedExercise);

            //Enable step_textBox only for Walking exercise
            step_textBox.Enabled = selectedExercise == "Walking";
        }

        //Close button
        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Set goals button
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
                     userDataClass.doRefreshGoals(_name, user_goals_dataGrid);
                }
                catch (Exception ex)
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

        //Delete record activity button
        private void Delete_acti_record_btn_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = user_recordActivities_DGV.SelectedRows[0]; // Assuming single row selection

            if (selectedRow != null)
            {
                string userName = selectedRow.Cells["user_name"].Value?.ToString() ?? "";
                string activityName = selectedRow.Cells["activity"].Value?.ToString() ?? "";
                double caloriesBurned;

                if (double.TryParse(selectedRow.Cells["calories_burned"].Value?.ToString(), out caloriesBurned))
                {
                    if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (userDataClass.DeleteUserRecord(userName, activityName, caloriesBurned))
                        {
                            MessageBox.Show("Record deleted successfully!");
                            userDataClass.doRefreshRecords(_name, user_recordActivities_DGV); // Refresh data grid (assuming function exists)
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete record.");
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
                MessageBox.Show("Please select a record to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Delete goals button
        private void DelectGoals_btn_Click(object sender, EventArgs e)
        {
            //Check if any row is selected
            if(user_goals_dataGrid.SelectedRows.Count > 0)
            {
                //Get the index of selected row
                int rowIndex = user_goals_dataGrid.SelectedRows[0].Index;

                DeleteUserGoals(rowIndex);
            }
            else
            {
                MessageBox.Show("Please select a row to delete");
            }
        }

        //Delete user goals
        private void DeleteUserGoals(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < user_goals_dataGrid.Rows.Count)
            {
                DataGridViewRow selectedRow = user_goals_dataGrid.Rows[rowIndex];
                double goalCalories;

                if (double.TryParse(selectedRow.Cells["goal_calories"].Value?.ToString(), out goalCalories))
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this goal?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        if (userDataClass.DeleteUserGoal(_name, goalCalories)) // Call function with username and goalCalories
                        {
                            MessageBox.Show("Goal deleted successfully!");
                            userDataClass.doRefreshGoals(_name, user_goals_dataGrid); // Refresh data grid
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete goal.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid goal calorie value."); // Handle invalid conversion
                }
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
    }
}
