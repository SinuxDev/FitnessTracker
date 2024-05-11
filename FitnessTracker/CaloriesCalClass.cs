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
        public double TimesInMinutes { get; set; }
        public double SpecificMetric { get; set; }
        public double BodyWeight { get; set; }
        

        public CaloriesCalClass(string name, double metric1, double metric2, double metric3)
        {
            this.Name = name;
            this.TimesInMinutes = metric1;
            this.SpecificMetric = metric2;
            this.BodyWeight = metric3;
        }

        public double CalculateCaloriesBurned()
        {
            double caloriesBurned = 0;

            if(this.TimesInMinutes > 0 && this.BodyWeight > 0)
            {
                if(this.Name == "Walking")
                {
                    caloriesBurned = this.TimesInMinutes * GETMETVALUE(Name) * this.BodyWeight / 200;
                }
                else
                {
                    caloriesBurned = this.SpecificMetric * GETMETVALUE(Name) * this.BodyWeight / 200;
                }
            }

            return caloriesBurned;
        }

        private double GETMETVALUE(string activityName)
        {
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

            if(exerciseMETs.ContainsKey(activityName))
            {
                return exerciseMETs[activityName];
            }
            else
            {
                return 0;
            }
        }
    }
}
