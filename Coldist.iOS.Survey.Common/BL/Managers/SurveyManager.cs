using Coldist.iOS.Survey.Common.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldist.iOS.Survey.Common.BL.Managers
{
    public static class SurveyManager
    {
        static SurveyManager()
        {
        }

        public static List<string> GetSurveys(string type)
        {
            return DataManager.GetSurveys(type);
        }
    }
}
