using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Petsy.Droid
{
    [Activity(Label = "Petsy", MainLauncher = true, Theme = "@style/Theme.Splash", NoHistory = true)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //Display Splash Screen for 4 Sec  
            //Thread.Sleep(4000);
            //Start Activity1 Activity  
            StartActivity(typeof(MainActivity));
        }
    }
}