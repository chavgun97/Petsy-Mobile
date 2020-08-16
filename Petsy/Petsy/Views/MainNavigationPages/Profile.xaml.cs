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
        private ICache<User_x> currentUser;
        public Profile()
        {
            currentUser = CurrentUser.GetInstance();
            InitializeComponent();
            InformAboutUser.Text = 
                "Страница пользователя: " + currentUser.Get().Name +
                " \n токен пользователя: " + currentUser.Get().UID +
                "\n id пользователя в бек енд системе: " + currentUser.Get().Id;

        }
    }
}