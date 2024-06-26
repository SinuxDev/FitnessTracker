﻿using System;
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

        // Record the activity in the database
        public void RecordActivity(int userID,string userName,string activityName,double timeInMinutes,double repetitions, double caloriesBurned)
        {
            string query = "INSERT INTO record_activities (user_ID, user_name, activity_name, time_minutes, repetitions, calories_burned) VALUES (@userID, @username, @activity, @timeMinutes, @repetitions, @caloriesBurned)";

            using (var connection = new MySqlConnection(_connectionString))
            using (var command = new  MySqlCommand(query,connection))
            {
                command.Parameters.AddWithValue("@userID", userID);
                command.Parameters.AddWithValue("@username", userName);
                command.Parameters.AddWithValue("@activity", activityName);
                command.Parameters.AddWithValue("@timeMinutes", timeInMinutes);
                command.Parameters.AddWithValue("@repetitions", repetitions);
                command.Parameters.AddWithValue("@caloriesBurned", caloriesBurned);

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

        // Get User Calories
        private int GetUserCalories(string username, string query)
        {
            using (var connection = new MySqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@username", username);

                var result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
            }

            return 0;
        }

        // Get total calories burned by the user
        public int GetTotalCaloriesBurned(string username)
        {
            return GetUserCalories(username, "SELECT COALESCE(SUM(calories_burned), 0) AS total_calories_burned FROM record_activities WHERE user_name = @username");
        }

        //Get User Goal Calories
        public int GetUserGoalCalories(string username)
        {
            return GetUserCalories(username, "SELECT COALESCE(goal_calories, 0) FROM user_goals WHERE username = @username ORDER BY created_at DESC LIMIT 1");
        }
    }
}
