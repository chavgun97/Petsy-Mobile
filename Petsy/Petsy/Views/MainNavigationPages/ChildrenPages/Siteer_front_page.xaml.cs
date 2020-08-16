using Petsy.Cache;
using Petsy.Models.DTO;
using Petsy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Petsy.Models.RequestJSON.RequestsJSON;

namespace Petsy.Views.MainNavigationPages.ChildrenPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Siteer_front_page : ContentPage
    {
        private Sitter_x sitter;
        private IClientRestApi client;
        private ICache<User_x> currentUser;
        public Siteer_front_page(ModelSitter modelSitter)
        {
            sitter = modelSitter.sitter;
            client = ClientRestApi.getInstance();
            currentUser = CurrentUser.GetInstance();
            InitializeComponent();
            LabelNameSitter.Text = modelSitter.Name;
            PhotoOfSitter.Source = modelSitter.ImageUrl;
            OnlineStatusBoxView.BackgroundColor = sitter.OnlineStatus ? Color.FromHex("F0CDB1") : Color.FromHex("BABABA");
            RatingLable.Text = modelSitter.Raiting;
            PriceLable.Text = String.Format("{0}$/day|{1}$/hour", Math.Round(sitter.PricePerDayInCoins / 10.0, 2), Math.Round(sitter.PricePerHourInCoins / 100.0, 2));
            levelLable.Text = sitter.Level;
            DescriptionLable.Text = sitter.Description;
        }

        //Логика не правильная ТЕСТОВАЯ!!! После нажатия, должна перенаправлять на страницу создания заказа,
        //Вместо этого ТЕСТОВО, я сразу создам уже готовый ордер с дефолтными знчениями 
        private void Contact_Clicked(object sender, EventArgs e)
        {
            var user = currentUser.Get();
            user.Orders.Add(new Order_x
            {
                Name = "Новый ордер",
                Sitter = sitter,
                Pet = currentUser.Get().Pets.First(),
                IsActive = true,
                From = DateTime.Now
            }); ;
           

            client.UpdateUser(new UserRequest( currentUser.Get()));
            Navigation.PushAsync(new New_order());
        }
     
        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        
    }
}