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
        private string useremail;
        connectdb db = new connectdb();
        TrackingClass trackingClass = new TrackingClass(dbString);

        //Form move
        int mov;
        int movX;
        int movY;

        public ResultChart(string username, int userID, string useremail)
        {
            InitializeComponent();
            this.username = username;
            this.userID = userID;
            this.useremail = useremail;

            //set the username label
            show_userName.Text = username;
            show_userName.Visible = true;
            show_eamiladdress.Text = useremail;
            show_eamiladdress.Visible = true;
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

                        bool dataAdded = false; //Check if data is added to the chart

                        while (reader.Read())
                        {
                            string activity = reader["activity"].ToString();
                            double caloriesBurned = Convert.ToDouble(reader["calories_burned"]);

                            //Add data to chart
                            chart1.Series["Calories"].Points.AddXY(activity, caloriesBurned);
                            dataAdded = true;
                        }

                        //Add a title to the chart
                        chart1.Titles.Add("Calories Burned By Activity");
                        chart1.Titles[0].ForeColor = Color.Red;
                        chart1.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);

                        if (!dataAdded)
                        {
                            //Show a placeholder message on the chart
                            chart1.Titles.Add("No Data Available");
                            chart1.Titles[0].Alignment = ContentAlignment.MiddleCenter;
                            chart1.Titles[0].ForeColor = Color.Red;
                            chart1.Titles[0].Font = new Font("Arial", 14, FontStyle.Bold);
                        }
                    }
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
            MainForm mainForm = new MainForm(userID, username,useremail);
            mainForm.Show();
        }

        
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void logOut_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
