using Petsy.Cache;
using Petsy.Models;
using Petsy.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Petsy.Views.MainNavigationPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        private ICache<User> currentUser;
        public Profile()
        {
            currentUser = CurrentUser.GetInstance();
            InitializeComponent();
            InformAboutUser.Text =
                "User page: " + currentUser.Get().Name +
                " \n the user token: " + currentUser.Get().UID +
                "\n user id in the back-end system: " + currentUser.Get().Id;
            NameLable.Text = currentUser.Get().Name;
            Amount.Text = Math.Round(currentUser.Get().TestAmountInCoins / 100.0, 2).ToString();
            LableFoto.Source = (currentUser.Get().UrlPhotoLable != null) ? currentUser.Get().UrlPhotoLable :
                "http://vignette.wikia.nocookie.net/caramella-girls/images/9/99/Blankpfp.png/revision/latest?cb=20190122015011";

        }
    }
}