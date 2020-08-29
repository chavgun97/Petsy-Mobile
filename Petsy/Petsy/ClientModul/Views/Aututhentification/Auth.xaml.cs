using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Petsy.Views.Aututhentification
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Auth : ContentPage
    {
        public Auth()
        {
            InitializeComponent();

        }

        async void OnBtnSignInPage(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SignInPage());
        }

        async void OnBtnCreateAccauntPage(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CreateAccountPage());
        }
    }
}