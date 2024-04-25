using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FitnessTracker
{
    public class CaloriesCalClass
    {
        public string Name { get; set; }
        public double Metric1 { get; set; }
        public double Metric2 { get; set; }
        public double Metric3 { get; set; }

        public CaloriesCalClass(string name, double metric1, double metric2, double metric3)
        {
            this.Name = name;
            this.Metric1 = metric1;
            this.Metric2 = metric2;
            this.Metric3 = metric3;
        }

        public double CalculateCaloriesBurned()
        {
            double caloriesBurned = 0;

            //Dictionary to store MET Values for different activities
            Dictionary<string, double> exerciseMETs = new Dictionary<string, double>()
            {
                { "Walking", 3.0 },
                { "Swimming", 8.0 },
                { "Squat", 3.5 },
                { "Anaerobic", 7.0 },
                { "Push up", 3.8 },
                { "Pull up", 5.8 },
            };

            //Check if the exercise is present in the dictionary
            if (exerciseMETs.ContainsKey(this.Name))
            {
                //Retrieve MET value for the exercise
                double MET = exerciseMETs[this.Name];

                //Calculate calories burned based on exercise type
                switch (this.Name)
                {
                    case "Walking":
                        caloriesBurned = this.Metric2 * MET * this.Metric3 / 200; // M2(steps) * MET * M3(Duration) / 200
                        break;
                    default:
                        caloriesBurned = this.Metric1 * MET * this.Metric2 * this.Metric3 / 60; //M1(times) * MET * M3(Duration) / 60
                        break;
                }
            }

            return caloriesBurned;
        }
    }
}
