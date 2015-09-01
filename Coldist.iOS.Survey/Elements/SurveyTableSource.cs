using Coldist.iOS.Survey.Common.BL.Managers;
using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace Coldist.iOS.Survey.Elements
{
    public class SurveyTableSource : UITableViewSource
    {
        //  protected string[] tableItems;
        // protected string cellIdentifier = "TableCell";
        public event EventHandler<SurveyClickedEventArgs> SurveyClicked = delegate
        {

        };
        IList<string> days;
        static NSString cellId = new NSString("SurveyCell");
        public SurveyTableSource(string type)
        {
            days = SurveyManager.GetSurveys(type);
        }
        //public override int RowsInSection(UITableView tableview, int section)
        //{

        //}

        public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            this.SurveyClicked(this, new SurveyClickedEventArgs(days[indexPath.Row], indexPath.Row + 1));
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
            SurveyCell cell = tableView.DequeueReusableCell(cellId) as SurveyCell;

            if (cell == null)
                cell = new SurveyCell(days[indexPath.Row], days[indexPath.Row], cellId);
            else
                cell.UpdateCell(days[indexPath.Row], days[indexPath.Row]);

            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return this.days.Count;
        }       
    }
}
