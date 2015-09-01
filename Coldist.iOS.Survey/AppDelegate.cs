using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Coldist.iOS.Survey.Controllers;

namespace Coldist.iOS.Survey
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations
        UIWindow window; 
        // HomeController home; 
        public static SurveyController customController;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
          //  home = new HomeController();
            // create a new window instance based on the screen size
            window = new UIWindow(UIScreen.MainScreen.Bounds);
            
            // If you have defined a view, add it here:
            // window.RootViewController  = rootNavController;

            //var controller = new UIViewController();
            //controller.View.BackgroundColor = UIColor.Gray;
            
            
            //Creating custom controller
            customController = new SurveyController();

            //adding it to navigation controller
            UINavigationController rootNavController = new UINavigationController();
            rootNavController.PushViewController(customController, false);

            window.RootViewController  = rootNavController;
            // make the window visible
            window.MakeKeyAndVisible();

            return true;
        }
    }
}