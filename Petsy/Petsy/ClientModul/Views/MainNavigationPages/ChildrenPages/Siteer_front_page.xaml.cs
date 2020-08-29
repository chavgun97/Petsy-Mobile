using Petsy.Cache;
using Petsy.ClientModul.Views.MainNavigationPages.PopUp;
using Petsy.Models.DTO;
using Petsy.Services;
using Petsy.Services.APIClient;
using Petsy.Services.Interfaces;
using Rg.Plugins.Popup.Services;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Petsy.Models.RequestJSON.RequestsJSON;

namespace Petsy.Views.MainNavigationPages.ChildrenPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Siteer_front_page : ContentPage
    {
        private Sitter sitter;
        private ModelSitter modelSitter;
        private IApi client;
        private ICache<User> currentUser;
        public Siteer_front_page(ModelSitter modelSitter)
        {
            this.modelSitter = modelSitter;
            sitter = modelSitter.sitter;
            client = Api.GetInstance();
            currentUser = CurrentUser.GetInstance();
            InitializeComponent();
            LabelNameSitter.Text = modelSitter.Name;
            PhotoOfSitter.Source = modelSitter.ImageUrl;
            OnlineStatusBoxView.BackgroundColor = sitter.OnlineStatus 
                ? Color.FromHex("F0CDB1") 
                : Color.FromHex("BABABA");
            RatingLable.Text = modelSitter.Raiting;
            PriceLable.Text = String.Format("{0}$/day|{1}$/hour", 
                Math.Round(sitter.PricePerDayInCoins / 10.0, 2), 
                Math.Round(sitter.PricePerHourInCoins / 100.0, 2));
            levelLable.Text = sitter.Level;
            DescriptionLable.Text = sitter.Description;
        }
        private void Contact_Clicked(object sender, EventArgs e)
        {

            PopupNavigation.Instance.PushAsync(new PopUpCreateOrder(modelSitter));
            Navigation.PushAsync(new New_order());

        }
        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}