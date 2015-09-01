using System;
using System.Collections.Generic;
using System.Text;

namespace Coldist.iOS.Survey.Common.BL
{
    public class Question
    {
        public Guid Id { get; set; }
        public string QuestionType { get; set; }
        public string QuestionText { get; set; }
        public string Answer { get; set; }
    }
}
