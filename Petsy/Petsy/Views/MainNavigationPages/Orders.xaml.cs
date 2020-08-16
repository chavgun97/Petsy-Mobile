using Petsy.Cache;
using Petsy.Models.DTO;
using Petsy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Petsy.Views.MainNavigationPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Orders : ContentPage
    {
        private IClientRestApi client;
        private ICache<User_x> currentUser;
        bool isRefreshing;
        public ICommand RefreshCommand { get; }

        public Orders()
        {
            client = ClientRestApi.getInstance();
            currentUser = CurrentUser.GetInstance();
            RefreshCommand = new Command(ExecuteRefreshCommand);
            InitializeComponent();
            Logic();
        }

        private void Logic()
        {
            CollectionView ordersView = CollectionView_Orders;
            ordersView.SetBinding(ItemsView.ItemsSourceProperty, "Pets");

            ordersView.ItemTemplate = new DataTemplate(() =>
            {
                Grid grid = new Grid { Padding = 10, HorizontalOptions = LayoutOptions.CenterAndExpand };
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });



                Label nameOrderLabel = new Label { FontAttributes = FontAttributes.Bold, FontSize = 20, HorizontalOptions = LayoutOptions.CenterAndExpand };
                nameOrderLabel.SetBinding(Label.TextProperty, "NameOrder");


                Label nameSitterLabel = new Label { FontAttributes = FontAttributes.Bold };
                nameSitterLabel.SetBinding(Label.TextProperty, "NameSitter");

                Image imageSitter = new Image { Aspect = Aspect.AspectFill, HeightRequest = 60, WidthRequest = 60, HorizontalOptions = LayoutOptions.EndAndExpand };
                imageSitter.SetBinding(Image.SourceProperty, "ImageUrlSitter");


                Label namePetLabel = new Label { FontAttributes = FontAttributes.Bold };
                namePetLabel.SetBinding(Label.TextProperty, "NamePet");

                Label BreedLabel = new Label { FontAttributes = FontAttributes.Italic, VerticalOptions = LayoutOptions.End };
                BreedLabel.SetBinding(Label.TextProperty, "Breed");

                Image imagePet = new Image { Aspect = Aspect.AspectFill, HeightRequest = 60, WidthRequest = 60, HorizontalOptions = LayoutOptions.EndAndExpand };
                imagePet.SetBinding(Image.SourceProperty, "ImageUrlPet");


                Label isActive = new Label { FontAttributes = FontAttributes.Bold, TextColor = Color.Green };
                isActive.SetBinding(Label.TextProperty, "IsActive");

                Label date = new Label { FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.EndAndExpand };
                date.SetBinding(Label.TextProperty, "Date");

                Grid.SetColumnSpan(nameOrderLabel, 2);
                Grid.SetRow(nameOrderLabel, 0);
                Grid.SetColumn(nameOrderLabel, 0);

                Grid.SetRowSpan(imageSitter, 2);
                Grid.SetColumn(imageSitter, 1);
                Grid.SetRow(imageSitter, 1);


                Grid.SetRowSpan(imagePet, 2);
                Grid.SetColumn(imagePet, 1);
                Grid.SetRow(imagePet, 3);

                //-----
                grid.Children.Add(nameOrderLabel);
                //---
                grid.Children.Add(nameSitterLabel, 0, 1);
                grid.Children.Add(imageSitter);
                //reting
                //---
                grid.Children.Add(namePetLabel, 0, 3);
                grid.Children.Add(BreedLabel, 0, 4);
                grid.Children.Add(imagePet);
                //---
                grid.Children.Add(isActive, 0, 5);
                grid.Children.Add(date, 1, 5);

                return grid;

            });
            ordersView.ItemsSource = currentUser.Get().Orders.Select(x => new OrderModel(x));

            // Refresh
             Refresh.Command = RefreshCommand;
         
        }

        public void ExecuteRefreshCommand()
        {
            Logic();

            // Stop refreshing
            Refresh.IsRefreshing = false;
        }

        private void CollectionView_Orders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Filter_Clicked(object sender, EventArgs e)
        {

        }
    }

    public class OrderModel
    {
        public string NameOrder { get; set; }
        public string NamePet { get; set; }
        public string NameSitter { get; set; }
        public string ImageUrlSitter { get; set; }
        public string ImageUrlPet { get; set; }
        public string Breed { get; set; }

        public string IsActive { get; set; }
        public string Date { get; set; }
        public OrderModel(Order_x order)
        {
            NameOrder = order.Name;
            NamePet = order.Pet.Name;
            NameSitter = order.Sitter.Name + " " + order.Sitter.Surname;
            ImageUrlSitter = order.Sitter.UrlPhotoLable; /////////////////////////////////////Сделай обработку на ноль
            ImageUrlPet = order.Pet.UrlPhotoLable == null ? 
                "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRJz4u5WQK3cVU4rt3W1_GJwfAmgech3anrbw&usqp=CAU" 
                : order.Pet.UrlPhotoLable;
            Breed = order.Pet.Breed;
            IsActive = order.IsActive ? "Active" : "Not active";
            Date = order.From.ToString();

        }
    }
    }