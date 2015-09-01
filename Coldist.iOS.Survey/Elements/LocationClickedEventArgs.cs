using Coldist.iOS.Survey.Lib.BL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coldist.iOS.Survey.Elements
{
    public class LocationClickedEventArgs : EventArgs
    {
        public Location location;

        public LocationClickedEventArgs(Location session) : base()
        {
            this.location = location;
        }
    }
}
