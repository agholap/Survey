using System;

namespace Coldist.iOS.Survey.Elements
{
    public class SurveyClickedEventArgs : EventArgs
    {
        public int Day;
        public string DayName;

        public SurveyClickedEventArgs(string dayName, int day) : base()
        {
            this.DayName = dayName;
            this.Day = day;
        }
    }
}