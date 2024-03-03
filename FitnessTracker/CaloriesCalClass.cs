using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker
{
    public class CaloriesCalClass
    {
        public string Name { get; set; }
        public double Metric1 { get; set; }
        public double Metric2 { get; set; }
        public double Metric3 { get; set; }

        public CaloriesCalClass(string name, double metric1, double metric2,double metric3)
        {
            this.Name = name;
            this.Metric1 = metric1;
            this.Metric2 = metric2;
            this.Metric3 = metric3;
        }

        
        public double CalculateCaloriesBurned()
        {
            double caloriesBurned = 0;

            switch(this.Name)
            {
                case "Walking":
                    const double WalkingMET = 3.0;
                    caloriesBurned = this.Metric1 * WalkingMET * this.Metric3 / 200; // M1(Steps) / M3(AvgHR = 200 )
                    break;
                case "Swimming":
                    const double SwimmingMET = 8.0;
                    caloriesBurned = this.Metric2 * SwimmingMET * this.Metric3 / 60; // M1(Times) / M3(AvgHR = 60 )
                    break;
                case "Squat":
                    const double SquatMET = 3.5;
                    caloriesBurned = this.Metric1 * SquatMET * this.Metric3 / 60; // M1(Times) / M3(AvgHR = 60 )
                    break;
                case "Anaerobic":
                    const double AnaerobicMET = 7.0;
                    caloriesBurned = this.Metric1 * AnaerobicMET * this.Metric3 / 60; // M1(Times) / M3(AvgHR = 60)
                    break;
                case "Push up":
                    const double PushUpMET = 3.8;
                    caloriesBurned = this.Metric1 * PushUpMET * this.Metric3 / 60; //M1(Times) / M3(AvgHR = 60 )
                    break;
                case "Pull up":
                    const double PullUpMET = 5.8;
                    caloriesBurned = this.Metric1 * PullUpMET * this.Metric3 / 60; // M1(Times) / M3(AvgHR = 60 )
                    break;
                default:
                    break;
            }

            return caloriesBurned;
        }


    }
}
