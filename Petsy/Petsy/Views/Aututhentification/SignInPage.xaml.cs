using Petsy.Interfaces;
using Petsy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Petsy.Views.Aututhentification
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        private bool EntryesIsValidate = false;
        public SignInPage()
        {
            InitializeComponent();
            //logic();

            
        }

        private void logic()
        {
            throw new NotImplementedException();
        }

         void OnTextEntryChaged(object sender, TextChangedEventArgs e)
        {
            var email = EmailEntry.Text;
            var psw = PSWEntry.Text;

            if((email!=null && psw != null) && psw.Length>5 && email.Contains('@'))
            {
                SignInBtn.BackgroundColor = Color.FromHex("#F0cdb1");
                EntryesIsValidate = true;

            }
            else
            {
                SignInBtn.BackgroundColor = Color.FromHex("#BABABA");
                EntryesIsValidate = false;
            }

        }
        async void OnSignInBtn(object sender, EventArgs e)
        {
            if (EntryesIsValidate)
            {
                var Mail = EmailEntry.Text;
                var Psw = PSWEntry.Text;

                var fbImpl = DependencyService.Get<IFireBaseAuth>();
                ResultAuth result = await fbImpl.LoginWithEP(Mail, Psw);
                if (result.isError)
                {
                    ErrorMsgLable.Text = result.ErrorMsg;
                }
                else
                {
                    var token = result.Token;
                    var userName = result.Name;
                    TestDataUser.Name = userName;
                    TestDataUser.AuthKey = token;
                    await Navigation.PushAsync(new MainPage());
                }
            }

        }


    }
}