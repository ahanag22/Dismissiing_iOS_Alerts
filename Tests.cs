using System;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Queries;

namespace Permission_demo
{
    [TestFixture]
    public class Tests
    {
        iOSApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            // TODO: If the iOS app being tested is included in the solution then open
            // the Unit Tests window, right click Test Apps, select Add App Project
            // and select the app projects that should be tested.
            //
            // The iOS project should have the Xamarin.TestCloud.Agent NuGet package
            // installed. To start the Test Cloud Agent the following code should be
            // added to the FinishedLaunching method of the AppDelegate:
            //
            //    #if ENABLE_TEST_CLOUD
            //    Xamarin.Calabash.Start();
            //    #endif
            app = ConfigureApp
                .iOS
                // TODO: Update this path to point to your iOS app and uncomment the
                // code if the app is not included in the solution.
                .AppBundle("/Users/ahanag22/Desktop/Permissions/Products/app/Permissions.app")
              .StartApp();
        }

        //[Test]
        //public void AppLaunches()
        //{
        //    app.Screenshot("First screen.");
        //}
        //[Test]
        //public void repl()
        //{
        //    app.Repl();
        //}

       

        [Test]
        public void AlertShowsUp()
        {
            //app.ScrollDown();
            //Thread.Sleep(10 * 1000);
            //app.WaitForElement(x => x.Marked("background location"));
            //creating an anrray of possible permissions:
            string[] stringArray = new string[13];
            stringArray[0] = "background location";
            stringArray[1] = "contacts";
            stringArray[2] = "calendar";
            stringArray[3] = "reminders";
            //stringArray[4] = "photos";
            stringArray[4] = "bluetooth";
            stringArray[5] = "microphone";
            stringArray[6] = "motion";
            stringArray[7] = "camera";
            stringArray[8] = "facebook";
            //stringArray[10] = "twitter";
            stringArray[9] = "home kit";
           // stringArray[12] = "health kit";
            stringArray[10] = "apns";
            stringArray[11] = "apple music";
            stringArray[12] = "speech recognition";

            for (int i = 0; i < 4; i++){
                app.Tap(x => x.Marked(stringArray[i]));
                Thread.Sleep(10 * 1000);
                app.Screenshot("show_Alert for " + stringArray[i]);
                // Thread.SpinWait(10 * 1000);
                app.Tap(x => x.Marked(stringArray[i]));
                Thread.Sleep(10 * 1000);
                app.Screenshot("Alert_dismissed");
            }


            //app.Tap(x => x.Marked("speech recognition"));
            //Thread.Sleep(10 * 1000);
        }

        //[Test]
        //public void AlertDismiised()
        //{
        //    app.ScrollDown();
        //    app.ScrollUp();
        //    //Thread.Sleep(10 * 1000);
        //}

    }

}

