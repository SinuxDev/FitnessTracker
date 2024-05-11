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

                    string query = "SELECT activity, SUM(calories_burned) As total_calories_burned FROM record_activities WHERE user_name = @username GROUP BY activity";

                    using(var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);

                        resultChart.Series["Calories"].Points.Clear();

                        using(var reader = command.ExecuteReader())
                        {
                            bool dataAdded = false; //Check if data is added to the chart

                            while (reader.Read())
                            {
                                string activity = reader["activity"].ToString();
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
    }
}
