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
    public partial class CreateAccountPage : ContentPage
    {
        private bool EntryesIsValidate;
        public CreateAccountPage()
        {
            InitializeComponent();
            
        }
   

        void OnTextEntryChanged(object sender, TextChangedEventArgs e)
        {
            ValidateLogic();
        }
        void OnCheckBoxChanged(object sender, EventArgs e)
        {
            ValidateLogic();
            if (CheckBoxPrivatePolicy.IsChecked)
            {
                CheckBoxPrivatePolicy.Color = Color.FromHex("#F0cdb1");
            }
            else
            {
                CheckBoxPrivatePolicy.Color = Color.FromHex("#BABABA");

            }
        }


        async void OnCreateAccBtn(object sender, EventArgs e)
        {
            if (EntryesIsValidate)
            {
                var name = NameEntry.Text;
                var email = EmailEntry.Text;
                var psw = PSWEntry.Text;

                var FdImpl = DependencyService.Get<IFireBaseAuth>();
                ResultAuth result = await FdImpl.RegisteredWithEP(name, email, psw);
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
        private void ValidateLogic()
        {
            var name = NameEntry.Text;
            var email = EmailEntry.Text;
            var psw = PSWEntry.Text;
            var checkBox = CheckBoxPrivatePolicy.IsChecked;

            if ((email != null && psw != null && name != null) && psw.Length > 5 && email.Contains('@') && checkBox)
            {
                CreateAccBtn.BackgroundColor = Color.FromHex("#F0cdb1");
                EntryesIsValidate = true;

            }
            else
            {
                CreateAccBtn.BackgroundColor = Color.FromHex("#BABABA");
                EntryesIsValidate = false;
            }
        }

    }
}