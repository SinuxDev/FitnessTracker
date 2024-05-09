using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FitnessTracker
{
    public class TrackingClass
    {
        private string _connectionString;

        public TrackingClass(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void RecordActiviyAndCalculateCalories(int userID,string userName,CaloriesCalClass calories)
        {
            double caloriesBurned = calories.CalculateCaloriesBurned();
            
            RecordActivity(userID, userName, calories.Name, caloriesBurned);
        }

        // Record the activity in the database
        private void RecordActivity(int userID,string userName,string activityName,double caloriesBurned)
        {
            using (var connection = new MySqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                string query = "INSERT INTO record_activities (user_ID, user_name, activity, calories_burned) VALUES (@userID, @username, @activity, @caloriesBurned)";

                command.CommandText = query;
                command.Connection = connection;

                command.Parameters.AddWithValue("@userID", userID);
                command.Parameters.AddWithValue("@username", userName);
                command.Parameters.AddWithValue("@activity", activityName);
                command.Parameters.AddWithValue("@caloriesBurned", caloriesBurned);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while recording activity: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SetFitnessGoal(string username, double goalCalories)
        {
            string query = "INSERT INTO user_goals (username, goal_calories) VALUES (@username, @goalcalories)";

            using (var connection = new MySqlConnection(_connectionString))
            using (var command = new MySqlCommand(query, connection))
            {
                
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@goalcalories", goalCalories);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while setting fitness goal: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public int GetTotalCaloriesBurned(string username)
        {
            int totalCaloriesBurned = 0;

            using (var connection = new MySqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                string query = "SELECT COALESCE(SUM(calories_burned), 0) AS total_calories_burned FROM record_activities WHERE user_name = @username";

                command.CommandText = query;
                command.Parameters.AddWithValue("@username", username);

                var result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    totalCaloriesBurned = Convert.ToInt32(result);
                }
            }

            return totalCaloriesBurned;
        }

        public int GetUserGoalCalories(string username)
        {
            int goalCalories = 0;

            using (var connection = new MySqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                string query = "SELECT COALESCE(goal_calories, 0) FROM user_goals WHERE username = @username ORDER BY created_at DESC LIMIT 1";

                command.CommandText = query;
                command.Parameters.AddWithValue("@username", username);

                var result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    goalCalories = Convert.ToInt32(result);
                }
            }

            return goalCalories;
        }
    }
}
