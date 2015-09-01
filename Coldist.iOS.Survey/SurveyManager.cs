using System;
using System.Collections.Generic;

namespace Coldist.iOS.Survey
{
    //Reference - calling rest services
    //http://developer.xamarin.com/recipes/android/web_services/consuming_services/call_a_rest_web_service/
    public static class SurveyManager1
    {
        static SurveyManager1()
        {
        }

        public static List<string> GetDays(string type)
        {
            DateTime dayMin, dayMax;
            var days = new List<string>();

            switch (type)
            {
                case "NotStarted":
                     dayMin = DateTime.Now.AddDays(-2); //new DateTime ( 2012, 02, 27, 0, 0, 0 );
                    dayMax = DateTime.Now.AddDays(2);

                    for (var i = 0; dayMin.AddDays(i) < dayMax; i++)
                    {
                        days.Add(dayMin.AddDays(i).ToShortDateString());
                    }                 
                    break;
                case "Completed":
                    dayMin = DateTime.Now.AddDays(-4); //new DateTime ( 2012, 02, 27, 0, 0, 0 );
                    dayMax = DateTime.Now.AddDays(4);

                    for (var i = 0; dayMin.AddDays(i) < dayMax; i++)
                    {
                        days.Add(dayMin.AddDays(i).ToShortDateString());
                    }
                    break;
                case "InProgress":
                    dayMin = DateTime.Now.AddDays(-6); //new DateTime ( 2012, 02, 27, 0, 0, 0 );
                    dayMax = DateTime.Now.AddDays(6);

                    for (var i = 0; dayMin.AddDays(i) < dayMax; i++)
                    {
                        days.Add(dayMin.AddDays(i).ToShortDateString());
                    }
                    break;
                    
                default:
                    break;
            }
            return days;

        }

    }
}