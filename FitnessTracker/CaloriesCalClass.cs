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

            // Perform input validation and calculate calories burned
            switch (this.Name)
            {
                case "Walking":
                    const double WalkingMET = 3.0;
                    caloriesBurned = this.Metric2 * WalkingMET * this.Metric3 / 200; // M2(Steps) / M3(Duration = 200 )
                    break;
                case "Swimming":
                    const double SwimmingMET = 8.0;
                    caloriesBurned = this.Metric1 * SwimmingMET * this.Metric3 / 60; // M1(Times) / M3(Duration = 60 )
                    break;
                case "Squat":
                    // No need to calculate calories burned based on steps for Squat
                    // Use Metric1 (Times) and Metric3 (Duration)
                    const double SquatMET = 3.5;
                    caloriesBurned = this.Metric1 * SquatMET * this.Metric3 / 60; // M1(Times) / M3(Duration = 60 )
                    break;
                case "Anaerobic":
                    // No need to calculate calories burned based on steps for Anaerobic
                    // Use Metric1 (Times) and Metric3 (Duration)
                    const double AnaerobicMET = 7.0;
                    caloriesBurned = this.Metric1 * AnaerobicMET * this.Metric3 / 60; // M1(Times) / M3(Duration = 60)
                    break;
                case "Push up":
                    // No need to calculate calories burned based on steps for Push up
                    // Use Metric1 (Times) and Metric3 (Duration)
                    const double PushUpMET = 3.8;
                    caloriesBurned = this.Metric1 * PushUpMET * this.Metric3 / 60; //M1(Times) / M3(Duration = 60 )
                    break;
                case "Pull up":
                    // No need to calculate calories burned based on steps for Pull up
                    // Use Metric1 (Times) and Metric3 (Duration)
                    const double PullUpMET = 5.8;
                    caloriesBurned = this.Metric1 * PullUpMET * this.Metric3 / 60; // M1(Times) / M3(Duration = 60 )
                    break;
                default:
                    break;
            }

            return caloriesBurned;
        }
    }
}
