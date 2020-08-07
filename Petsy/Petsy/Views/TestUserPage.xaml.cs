using Petsy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Petsy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestUserPage : ContentPage
    {
        public TestUserPage()
        {
            InitializeComponent();
            InformAboutUser.Text = "Страница пользователя: " + TestDataUser.Name + " \n токен пользователя: " + TestDataUser.AuthKey;

        }
    }
}