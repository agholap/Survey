using CoreGraphics;
using MonoTouch.Dialog;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Coldist.iOS.Survey.Lib.BL;

namespace Coldist.iOS.Survey.Controllers
{
    public partial class LocationController : DialogViewController
    {
        List<Lib.BL.Survey> surverys = new List<Lib.BL.Survey>();
        UITableView sessionDayTable;//= new UITableView();
        //SessionTableSource tableSessionSource; BindingContext bc;
        Dictionary<string, string> quesAnswers = new Dictionary<string, string>();
        public LocationController(string surveyName, int surveyId,SessionSplitView sessionSplitView) 
            : base(UITableViewStyle.Plain, null, true)
        {
          //bc = new BindingContext(this, sessions, "sessions");

            this.Title = surveyName;
            //setting SessionTable 
            //sessionDayTable = new UITableView(new CGRect(0, 20, View.Bounds.Width, View.Bounds.Height - 20)); // defaults to Plain style
            //sessionDayTable.AutoresizingMask = UIViewAutoresizing.All;

            //Add(sessionDayTable);
            _rootElement = new RootElement(surveyName) { new Section() };

            // code to create screens with MT.D will go here …

            Root = _rootElement;
            this.NavigationItem.RightBarButtonItems =
           new UIBarButtonItem[] {  new UIBarButtonItem(UIBarButtonSystemItem.Done, (sender, args) =>
             {
                 foreach (var item in quesAnswers)
                    {
                       Console.WriteLine(quesAnswers);
                    }
            
                // NavigationController.PushViewController(AppDelegate.customController,false);
             }),
            new UIBarButtonItem(UIBarButtonSystemItem.Add, (sender, args) => {
                   Guid locId = Guid.NewGuid();
                   var _survey = new Lib.BL.Survey
                   {
                       Name = "Location " + surverys.Count,
                       Id = locId.ToString(),
                      SurveyLocation = new Location
                       {
                           Id = Guid.NewGuid().ToString(),
                           LocationName =  "Location " + surverys.Count,
                           Questions = new List<Question>
                       {
                           new Question
                           {
                               QuestionText = "How many Taps",
                               QuestionType = "Whole",
                               Answer = "1",
                               Id = Guid.NewGuid()
                           },
                           new Question
                           {
                               QuestionText = "Date Of Survey",
                               QuestionType = "Date",
                               //Answer = DateTime.Now,
                               Id = Guid.NewGuid()
                           },

                       }

                       }
                   };
                   // button was clicked
                   surverys.Add(_survey);
                   LoadSurveyScreen(_survey);
                   //tableSessionSource = new SessionTableSource(sessions);
                   //sessionDayTable.Source = tableSessionSource;
                   //sessionDayTable.ReloadData();
                   //tableSessionSource.SessionClicked += delegate (object sender1, SessionClickedEventArgs e) {
                    //  LoadSurveyScreen(e.session);
                   //};
               })};
        }
        RootElement _rootElement; //Task task;
          private void LoadSurveyScreen(Lib.BL.Survey survey)
        {
            List<Element> elms = new List<Element>();

            foreach (var item in survey.SurveyLocation.Questions)
            {
                if(item.QuestionType == "Whole")
                {
                    EntryElement d = new EntryElement((elms.Count + 1).ToString() + ". "  +  item.QuestionText, "",item.Answer);
                    d.Changed += D_Changed1; ;
                    elms.Add(d);
                }
            }

            //task  = new Task { Name = "task ", DueDate = DateTime.Now };

            //DateElement dEle = new DateElement("Due Date", DateTime.Now);
            //dEle.DateSelected += DEle_DateSelected;

            var taskElement = new RootElement(survey.SurveyLocation.LocationName){
                new Section () {
                     elms

            //new EntryElement (session.SessionSurvey.Questions[0].QuestionText,
            //        "", session.SessionSurvey.Questions[0].Answer)
            //new EntryElement (task.Name,
            //      "Enter task description", task.Description)
        },

        //new Section () {
        //        new DateElement ("Due Date", session.SessionSurvey.Questions[1].Answer)
        //}
    };
            _rootElement[0].Add(taskElement);

            //SurveyScreen surveyQuestionScreen = new SurveyScreen(session);
            //NavigationController.PushViewController(surveyQuestionScreen, true);
        }

        private void D_Changed1(object sender, EventArgs e)
        {
            EntryElement ent = (EntryElement)sender;

            //Find the location for question 
            var location = ent.Parent.Parent.Caption;
            if (!quesAnswers.ContainsKey(location + "~"+ent.Caption))
            {
                quesAnswers.Add(location + "~" + ent.Caption, ent.Value);
            }
            else
            {
                quesAnswers[location + "~" + ent.Caption] = ent.Value;
            }
        }

        private void DEle_DateSelected(DateTimeElement obj)
        {
            throw new NotImplementedException();
        }
    }
    public class Task
    {
        public Task()
        {
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }
    }
}
