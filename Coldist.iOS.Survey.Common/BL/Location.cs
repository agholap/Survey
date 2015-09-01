using System;
using System.Collections.Generic;
using System.Text;

namespace Coldist.iOS.Survey.Common.BL
{
    public class Location
    {

        public string Id { get; set; }

        public string LocationName { get; set; }

        public List<Question> Questions { get; set; }
    }
}
