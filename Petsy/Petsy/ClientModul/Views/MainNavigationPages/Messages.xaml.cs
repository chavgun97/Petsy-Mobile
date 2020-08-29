using Petsy.Cache;
using Petsy.ClientModul.Views.MainNavigationPages.ChildrenPages;
using Petsy.Models.DTO;
using Petsy.Services.APIClient;
using Petsy.Services.FireBaseRealTimeDataBase;
using Petsy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Petsy.Views.MainNavigationPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Messages : ContentPage
    {
        ICache<User> currentUser;
        IApi clientRestApi;
        public Messages()
        {
            clientRestApi = Api.GetInstance();
            currentUser = CurrentUser.GetInstance();
            InitializeComponent();
            Logic();
        }
        private void Logic()
        {
            CollectionView chatView = CollectionView_Chats;
            chatView.SetBinding(ItemsView.ItemsSourceProperty, "Chats");
            chatView.ItemTemplate = new DataTemplate(() =>
            {
                Grid grid = new Grid { Padding = 1, HorizontalOptions = LayoutOptions.StartAndExpand };
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });



                Label nameLabel = new Label { FontAttributes = FontAttributes.Bold };
                nameLabel.SetBinding(Label.TextProperty, "Name");

                Label descriptionLable = new Label
                {
                    FontAttributes = FontAttributes.Italic,
                    MinimumHeightRequest = 30,
                    HeightRequest = 40,
                    WidthRequest = 100
                };
                descriptionLable.SetBinding(Label.TextProperty, "LastMsg");

                Image image = new Image { Aspect = Aspect.AspectFill, HeightRequest = 50, WidthRequest = 50, HorizontalOptions = LayoutOptions.EndAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand };
                image.SetBinding(Image.SourceProperty, "ImageUrl");

                BoxView onlineIndicate = new BoxView
                {
                    BackgroundColor = Color.FromHex("#F0CDB1"),
                    HeightRequest = 15.0,
                    WidthRequest = 15.0,
                    CornerRadius = 20.0,
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                    VerticalOptions = LayoutOptions.EndAndExpand
                };

                BoxView separator = new BoxView
                {
                    HeightRequest = 1,
                    BackgroundColor = Color.FromHex("F0CDB1"),
                    VerticalOptions = LayoutOptions.End
                };

                Grid.SetRowSpan(image, 3);
                Grid.SetColumn(image, 1);

                Grid.SetColumnSpan(separator, 2);
                Grid.SetRow(separator, 3);

                grid.Children.Add(nameLabel, 0, 0);
                grid.Children.Add(descriptionLable, 0, 1);
                grid.Children.Add(image);
                grid.Children.Add(separator);

                return grid;


            });

            //Взятие модели чатов не реализовано, это мок. Данные беруться с заказов
            chatView.ItemsSource = clientRestApi.GetOrdersByUserId(currentUser.Get().Id).Select(x => new ModelChat(x.Sitter, "Реализуй последнее сообщение!!!"));
            
            
            Refresh.Command = new Command(() => {
                Logic();  
                // Stop refreshing
                Refresh.IsRefreshing = false;
            } ); 
        }

        private void CollectionView_Chats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.PushAsync(new MessagesItemPage()) ;

        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }
    }

    public class ModelChat
    {
        public Sitter sitter;
        public string Name { get; set; }
        public string LastMsg { get; set; }
        public string ImageUrl { get; set; }

        public ModelChat(Sitter sitter, string LastMsg)
        {
            this.sitter = sitter;
            this.Name = sitter.Name;
            this.LastMsg = sitter.Name + ": " + LastMsg;  //тоже мок, последнее сообщение уже должно приходить с именем!!
            this.ImageUrl = sitter.UrlPhotoLable;
        }
    }
}