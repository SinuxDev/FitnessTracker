using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Data;

namespace FitnessTracker
{
    public class UserDataClass
    {
        private readonly string connectionString;

        public UserDataClass()
        {
            connectdb db = new connectdb();
            connectionString = db.getConnectionString(); //Get the connection string from database class
        }

        //Fill the chart with data
        public void FillChart(string username, Chart resultChart)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT activity_name, SUM(calories_burned) As total_calories_burned FROM record_activities WHERE user_name = @username GROUP BY activity_name";

                    using(var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);

                        resultChart.Series["Calories"].Points.Clear();

                        using(var reader = command.ExecuteReader())
                        {
                            bool dataAdded = false; //Check if data is added to the chart

                            while (reader.Read())
                            {
                                string activity = reader["activity_name"].ToString();
                                double caloriesBurned = Convert.ToDouble(reader["total_calories_burned"]);

                                //Add data to chart
                                resultChart.Series["Calories"].Points.AddXY(activity, caloriesBurned);
                                dataAdded = true;
                            }

                            //Add a title to the chart
                            resultChart.Titles.Add("Calories Burned By Activity");
                            resultChart.Titles[0].ForeColor = Color.Red;
                            resultChart.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);

                            if (!dataAdded)
                            {
                                //Show a place holder message on the chart
                                resultChart.Titles.Add("No Data Available");
                                resultChart.Titles[0].Alignment = ContentAlignment.MiddleCenter;
                                resultChart.Titles[0].ForeColor = Color.Red;
                                resultChart.Titles[0].Font = new Font("Arial", 14, FontStyle.Bold);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Get user goals from the database
        private DataTable GetUserData(string username, string query)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);

                    DataTable dataTable = new DataTable();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data: " + ex.Message);
                return null;
            }
        }

        //Fill the DataGridView with user goals
        public DataTable FillUserGoalsDGV(string username)
        {
            return GetUserData(username, "SELECT goal_calories FROM user_goals WHERE username = @username");
        }

        //Fill the DataGridView with user goals (Reload)
        public void doRefreshGoals(string username,DataGridView dataGrid) 
        {
            dataGrid.DataSource = GetUserData(username, "SELECT username,goal_calories FROM user_goals WHERE username = @username");
        }

        //Fill the DataGridView with user records activity
        public DataTable FillUserRecordsDGV(string username)
        {
            return GetUserData(username, "SELECT user_name,activity_name,time_minutes,repetitions,calories_burned FROM record_activities WHERE user_name = @username");
        }

        //Fill the DataGridView with user records activity (Reload)
        public void doRefreshRecords(string username, DataGridView dataGrid)
        {
            dataGrid.DataSource = GetUserData(username, "SELECT user_name,activity_name,time_minutes,repetitions,calories_burned FROM record_activities WHERE user_name = @username");
        }

        //Delete a user goal from the database
        public bool DeleteUserGoal(string username, double goalCalories)
        {
            int rowsAffected = 0;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
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

            return rowsAffected > 0; // Return true if at least one row was affected
        }

        //Delete a user record activity from the database
        public bool DeleteUserRecord(string username, string activity, double caloriesBurned)
        {
            bool isDeleted = false;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    string query = "DELETE FROM record_activities WHERE user_name = @un AND activity = @an AND calories_burned = @cb";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@un", username);
                    command.Parameters.AddWithValue("@an", activity);
                    command.Parameters.AddWithValue("@cb", caloriesBurned);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    isDeleted = rowsAffected > 0; // Record deleted if rowsAffected > 0
                }
                catch (Exception ex)
                {
                    // Handle potential database errors
                    Console.WriteLine("Error deleting record activity: " + ex.Message); // Or use a logging mechanism
                }

                connection.Close();
            }

            return isDeleted;
        }


    }
}
