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

        public void RecordActiviyAndCalculateCalories(int userID, CaloriesCalClass calories)
        {
            double caloriesBurned = calories.CalculateCaloriesBurned();
            int goalCalories = GetFitnessGoal(userID);

            int reminingCalories = goalCalories - (int)caloriesBurned;

            RecordActivity(userID, calories.Name, caloriesBurned);
            
        }

        private int GetFitnessGoal(int userid)
        {
            int goalCalories = 0;
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT `goalCalories` FROM `usergoals` WHERE `userid` = @userid";
                using (var command = new MySqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@userid", userid);
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if(result != null && result != DBNull.Value)
                    {
                        goalCalories = Convert.ToInt32(result);
                    }
                }
            }
            return goalCalories;
        }

        private void RecordActivity(int userID, string activityName, double caloriesBurned)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "INSERT INTO `record_activities` (`user_ID`,`activity`,`calories_burned`,) VALUES (@userID, @activity, @caloriesBurned) ";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userID", userID);
                    command.Parameters.AddWithValue("@activity", activityName);
                    command.Parameters.AddWithValue("@caloriesBurned",caloriesBurned);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
