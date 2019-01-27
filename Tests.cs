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


        //checking only those alerts whose permission has been implemented
        [Test]
        public void AlertShowsUp()
        {
            //app.ScrollDown();
            //Thread.Sleep(10 * 1000);
            //app.WaitForElement(x => x.Marked("background location"));
            //creating an anrray of possible permissions:
            string[] stringArray = new string[10];
            stringArray[0] = "background location";
            stringArray[1] = "contacts";
            stringArray[2] = "calendar";
            stringArray[3] = "reminders";
            //stringArray[4] = "photos";
            //stringArray[4] = "bluetooth";
            stringArray[4] = "microphone";
            stringArray[5] = "motion";
            stringArray[6] = "camera";
            //stringArray[7] = "facebook";
            //stringArray[10] = "twitter";
            //stringArray[7] = "home kit";
            // stringArray[12] = "health kit";
            stringArray[7] = "apns";
            stringArray[8] = "apple music";
            stringArray[9] = "speech recognition";

            for (int i = 0; i < stringArray.Length; i++)
            {
                app.Tap(x => x.Marked(stringArray[i]));
                app.Screenshot("Show Alert for " + stringArray[i]);
                // Thread.SpinWait(10 * 1000);
                //app.Tap(x => x.Marked(stringArray[i]));
                app.DismissSpringboardAlerts();
                app.Screenshot("Alert Dismissed");
                if (i >= 6)
                {
                    app.ScrollDown();
                }
            }

        }

        //checking separtely since tapping on photos naviagating to a new screen
        //test is failing on 11.* devices in App Center Test
        //Clicking Photos on 11.* devices diplays a Pop up saying "Apple ID Required"
        [Test]
        public void AlertShowsUpForPhotos()
        {
            Thread.Sleep(10 * 1000);
            app.Tap(x => x.Marked("photos"));
            app.Screenshot("Alert shows up");
            app.DismissSpringboardAlerts();
            app.Screenshot("Alert Dismissed");
        }
    }

}

