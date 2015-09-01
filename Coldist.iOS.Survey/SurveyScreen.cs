using CoreGraphics;
using MonoTouch.Dialog;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace Columbia.POC.B
{
    public class SurveyScreen : DialogViewController
    {
        RootElement _rootElement; QuestionB qb;
        Session session;
        UITableView surveryQuestionTable;//= new UITableView();
        SurveryQuestionTableSource tableSurveyQuestionsSource;
        UIButton button;
        public SurveyScreen(Session surveySession)
            : base(UITableViewStyle.Plain, null, true)
        {
            session = surveySession;
            // this.Title = session.Name;
            _rootElement = new RootElement(session.Name) { new Section() };
            Root = _rootElement;
            //setting SessionTable 
            //surveryQuestionTable = new UITableView(new CGRect(0, 20, View.Bounds.Width, View.Bounds.Height - 20)); // defaults to Plain style
            //surveryQuestionTable.AutoresizingMask = UIViewAutoresizing.All;
            //Add(surveryQuestionTable);
            this.NavigationItem.SetRightBarButtonItem(
             new UIBarButtonItem(UIBarButtonSystemItem.Done, (sender, args) =>
             {
                 
             }),false);
      
            LoadSurveyQuestions();

        }
        private void LoadSurveyQuestions()
        {
            foreach (var question in session.SessionSurvey.Questions)
            {
                if (question.QuestionType == "Whole")
                {
                    qb = new QuestionB();
                    Root.Add(new Section() {
                        
                        new EntryElement (question.QuestionText,
                                question.QuestionText,question.Answer)
                    });
                }
                //if (question.QuestionType == "Date")
                //{
                //    Root.Add(new Section() {
                //        new DateElement(question.QuestionText,
                //        (DateTime)question.Answer)
                //    });
                //}
            }
        }

        //private Element GetElement(Question question)
        //{
        //    Element ele;
        //    switch (question.QuestionType)
        //    {
        //        case "Whole":
        //            ele = new EntryElement(question.QuestionText,
        //                        question.QuestionText, (string)question.Answer);

        //            break;
        //        case "Date":
        //            break;
        //        default:
        //            break;
        //    }
        //    return
        //}
            
    }

    public class QuestionB
    {
        public string Question1 { get; set; }
        public string Answer1 { get; set; }

        public string Question2 { get; set; }
        public string Answer2 { get; set; }
    }
}
