using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker
{
    public class TrackingClass
    {
        private string _connectionString;

        public TrackingClass(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void RecordActiviyAndCalculateCalories(int userID,string userName, CaloriesCalClass calories)
        {
            double caloriesBurned = calories.CalculateCaloriesBurned();
            int goalCalories = GetFitnessGoal(userName);

            int reminingCalories = goalCalories - (int)caloriesBurned;

            RecordActivity(userID, userName, calories.Name, caloriesBurned);
        }

        private int GetFitnessGoal(string username)
        {
            int goalCalories = 0;

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT goal_calories FROM user_goals WHERE username = @username";
                using (var command = new MySqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if(result != null && result != DBNull.Value)
                    {
                        goalCalories = Convert.ToInt32(result);
                    }
                    else
                    {
                        goalCalories = 0;
                    }
                }
            }
            return goalCalories;
        }

        private void RecordActivity(int userID,string userName, string activityName, double caloriesBurned)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "INSERT INTO record_activities (user_ID, user_name, activity, calories_burned) VALUES (@userID, @username, @activity, @caloriesBurned);";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userID", userID);
                    command.Parameters.AddWithValue("@username", userName);
                    command.Parameters.AddWithValue("@activity", activityName);
                    command.Parameters.AddWithValue("@caloriesBurned",caloriesBurned);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void SetFitnessGoal(string username, double goalCalories)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "INSERT INTO user_goals (username, goal_calories) VALUES (@username, @goalcalories)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@goalcalories", goalCalories);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
