using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using System.Net;
using System.Text;

namespace Coldist.iOS.Survey.Common.DAL
{
   public class DataManager
    {
        //Rest method calls would go here
        static DataManager()
        {
            //get survey
            //Account Name, City, State
        }

        public static List<string> GetSurveys(string type)
        {
            //Url - Configure it to read from config/common place - 
            string method = "Survey/GetAll/NotStarted";
            // Create an HTTP web request using the URL:
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(Constants.CrmProxyBaseURI + method));
            request.ContentType = "application/json";
            request.Method = "GET";

            // Send the request to the server and wait for the response:
            using (WebResponse response = request.GetResponse())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    //code to call will go here
                    // Use this stream to build a JSON document object:
                    JsonValue jsonDoc = JsonObject.Load(stream);

                    //Console.Out.WriteLine("Response: {0}", (CrmSurvey) jsonDoc);

                    // Return the JSON document:
                    return new List<string>(jsonDoc.ToString().Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
                    
                }
            }
        }

        public static List<string> GetSurveysDummy(string type)
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
