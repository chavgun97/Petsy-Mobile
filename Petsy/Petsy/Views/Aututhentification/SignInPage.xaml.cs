using Petsy.Cache;
using Petsy.Interfaces;
using Petsy.Models;
using Petsy.Models.DTO;
using Petsy.Services;
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
        private IClientRestApi restClient;
        private ICache<User_x> currentUser;

        public SignInPage()
        {
            currentUser = CurrentUser.GetInstance();
            InitializeComponent();       
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
                var Mail = EmailEntry.Text.Trim();
                var Psw = PSWEntry.Text.Trim();

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

                    currentUser.Get().Name = userName;
                    currentUser.Get().UID = result.UID;
                    restClient = ClientRestApi.CreateNewInstance(token);
                    var user = restClient.GetUserByToken().Result.UserExternal;
                    if (user != null)
                    {
                        currentUser.Update(user);
                        await Navigation.PushAsync(new MainPage());
                    }
                    else
                        ErrorMsgLable.Text = ("Ошибка авторизации на стороне сервера.");
                }
            }

        }


    }
}