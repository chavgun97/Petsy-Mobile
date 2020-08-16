using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Petsy.Services;
using Petsy.Views;
using Petsy.Views.Aututhentification;

namespace Petsy
{
    public partial class App : Application
    {
  

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Auth()); ;

        }

        protected override void OnStart()
        {
           
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
