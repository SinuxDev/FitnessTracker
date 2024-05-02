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
using MySqlX.XDevAPI.Relational;

namespace FitnessTracker
{
    public partial class ResultChart : Form
    {
        static string dbString = "server=localhost;port=3306;uid=root;password=root;database=fitnessapp";
        private string username;
        private int userID;
        connectdb db = new connectdb();
        TrackingClass trackingClass = new TrackingClass(dbString);

        public ResultChart(string username, int userID)
        {
            InitializeComponent();
            this.username = username;
            this.userID = userID;
        }

        public string getUsername()
        {
            return username;
        }

        private void ResultChart_Load(object sender, EventArgs e)
        {
            FillChart();

            int goalCalories = trackingClass.GetUserGoalCalories(username);
            lastCal_txt.Text = goalCalories.ToString();

            int totalCaloriesBurned = trackingClass.GetTotalCaloriesBurned(username);
            totalBurned_txt.Text = totalCaloriesBurned.ToString();

            if (goalCalories < totalCaloriesBurned)
            {
                moti_label.Text = "Keep up the Great Work! You've Hit Your Calorie Target!";
            }
            else if (goalCalories == 0 && totalCaloriesBurned == 0)
            {
                moti_label.Text = "Come on let's do it ! Now set your goals";
            }
            else
            {
                if (totalCaloriesBurned <= 0)
                {
                    moti_label.Text = "Do Exercise and achieve your goals";
                }
                else
                {
                    moti_label.Text = "Stay Focused! You're Closer to Your Goal Than You Think!";
                }
            }
        }

        private void FillChart()
        {
            try
            {
                db.openConnection();

                string query = "SELECT activity, calories_burned FROM record_activities WHERE user_name = @username";

                using (var command = new MySqlCommand(query, db.getConnection()))
                {
                    command.Parameters.AddWithValue("@username", username);

                    chart1.Series["Calories"].Points.Clear();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string activity = reader["activity"].ToString();
                            double caloriesBurned = Convert.ToDouble(reader["calories_burned"]);

                            //Add data to chart
                            chart1.Series["Calories"].Points.AddXY(activity, caloriesBurned);
                        }
                    }

                    //Add a title to the chart
                    chart1.Titles.Add("Calories Burned By Activity");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void toBackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm(userID, username);
            mainForm.Show();
        }
    }
}
