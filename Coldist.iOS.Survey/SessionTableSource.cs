using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace Columbia.POC.B
{
   public class SessionTableSource : UITableViewSource
    {
        static NSString cellId = new NSString("DayCell");
       List<Location> locations;
        public SessionTableSource(List<Survey> allSessions )
        {
            sessions = allSessions;
        }
        //  protected string[] tableItems;
        // protected string cellIdentifier = "TableCell";
        public event EventHandler<LocationClickedEventArgs> LocationClicked = delegate
        {

        };
        public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            this.LocationClicked(this, new LocationClickedEventArgs(locations[indexPath.Row]));
            tableView.DeselectRow(indexPath, true);
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            //// request a recycled cell to save memory
            //UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
            //// if there are no cells to reuse, create a new one
            //if (cell == null)
            //    cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
            //cell.TextLabel.Text = tableItems[indexPath.Row];
            //return cell;
            DayCell cell = tableView.DequeueReusableCell(cellId) as DayCell;

            if (cell == null)
                cell = new DayCell(sessions[indexPath.Row].Name, sessions[indexPath.Row].Name, cellId);
            else
                cell.UpdateCell(sessions[indexPath.Row].Name, sessions[indexPath.Row].Name);

            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return this.sessions.Count;
        }
    }
}
