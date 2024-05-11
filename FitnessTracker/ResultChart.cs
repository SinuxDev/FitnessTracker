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
            UserDataClass userDataClass = new UserDataClass();
            string currentUsername = getUsername();
            userDataClass.FillChart(currentUsername, result_chart);
            MotivationMessage();
        }

        //Display a motivational message based on the user's progress
        private void MotivationMessage()
        {
            int goalCalories = trackingClass.GetUserGoalCalories(username);
            int totalCaloriesBurned = trackingClass.GetTotalCaloriesBurned(username);

            lastCal_txt.Text = goalCalories.ToString();
            totalBurned_txt.Text = totalCaloriesBurned.ToString();

            string message = "";

            if (goalCalories < totalCaloriesBurned)
            {
                message = "Keep up the Great Work! You've Hit Your Calorie Target!";
            }
            else if (goalCalories == 0 && totalCaloriesBurned == 0)
            {
                message = "Come on let's do it! Now set your goals";
            }
            else
            {
                message = totalCaloriesBurned <= 0 ? "Do Exercise and achieve your goals" : "Stay Focused! You're Closer to Your Goal Than You Think!";
            }

            moti_label.Text = message;
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
