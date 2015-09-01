using System;
using System.Collections.Generic;

namespace Coldist.iOS.Survey
{
    public class Location1
    {
        public string Id { get; set; }

        public string LocationName { get; set; }

        public List<Question1> Questions { get; set; }
    }

    public class Question1
    {
        public Guid Id { get; set; }
        public string QuestionType { get; set; }

        public string QuestionText{ get; set; }

        public string Answer { get; set; }
    }
}