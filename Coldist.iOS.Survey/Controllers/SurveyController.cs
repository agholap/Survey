using Coldist.iOS.Survey.Elements;
using CoreGraphics;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace Coldist.iOS.Survey.Controllers
{
    public class SurveyController : UIViewController
    {
        UITableView SessionTable;//= new UITableView();
        SurveyTableSource tableSource;
        public override void ViewDidLoad()
        {
            //View.BackgroundColor = UIColor.Green;
            Title = "Survey 1.0.0.0";
            base.ViewDidLoad();

            //setting SessionTable 
            SessionTable = new UITableView(new CGRect(0, 20, View.Bounds.Width, View.Bounds.Height - 20)); // defaults to Plain style
            SessionTable.AutoresizingMask = UIViewAutoresizing.All;
            //load all in progress
            PopulateTable(0);
            //It is a view so need to add to UIViewController
            Add(SessionTable);


            var segmentControl = new UISegmentedControl();
            segmentControl.Frame = new CGRect(200, 200, 280, 40);

            segmentControl.InsertSegment("In Progress", 0, false);
            segmentControl.InsertSegment("Not Started", 1, false);
            segmentControl.InsertSegment("Completed", 1, false);
            segmentControl.SelectedSegment = 0;
            segmentControl.ValueChanged += (sender, e) => {
                var selectedSegmentId = (sender as UISegmentedControl).SelectedSegment;
                PopulateTable(selectedSegmentId);
                // do something with selectedSegmentId
                //Create Alert
                //var okAlertController = UIAlertController.Create("Title", selectedSegmentId.ToString(), UIAlertControllerStyle.Alert);
                ////Add Action
                //okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                //PresentViewController(okAlertController, true, null);

            };


            var segmentedButton = new UIBarButtonItem(segmentControl);
            //UIToolbar.vi
            //ToolbarItems = new UIBarButtonItem[] { segmentedButton };
            this.NavigationController.ToolbarHidden = false;
    
        //    this.ToolbarItems = new UIBarButtonItem[] { button };
            this.SetToolbarItems(new UIBarButtonItem[] { segmentedButton }, false);


          // View.AddSubview(segmentControl);
        }


        protected void PopulateTable(nint type)
        {
            switch (type)
            {
                case 0:
                    tableSource = new SurveyTableSource("InProgress");
                    break;

                case 1:
                    tableSource = new SurveyTableSource("NotStarted");
                    break;
                case 2:
                    tableSource = new SurveyTableSource("Completed");
                    break;
                default:
                    break;
            }
         
            SessionTable.Source = tableSource;
           SessionTable.ReloadData();
           tableSource.SurveyClicked += delegate (object sender,SurveyClickedEventArgs e) {
                LoadSessionScreen(e.DayName, e.Day);
            };
            
        }
        LocationController dayScheduleScreen;
        private void LoadSessionScreen(string dayName, int day)
        {
            dayScheduleScreen = new LocationController(dayName, day, null);
            NavigationController.PushViewController(dayScheduleScreen, true);           
        }
    }
}
