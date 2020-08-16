using Petsy.Cache;
using Petsy.Models.DTO;
using Petsy.Services;
using Petsy.Views.MainNavigationPages.ChildrenPages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Petsy.Views.MainNavigationPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class My_Pets : ContentPage
    {
        private IClientRestApi client;
        private ICache<User_x> currentUser;
        public My_Pets()
        {
            client = ClientRestApi.getInstance();
            currentUser = CurrentUser.GetInstance();
            InitializeComponent();
            Logic();
        }

        private void Logic()
        {
            CollectionView petsView = CollectionViewAllPets;
            petsView.SetBinding(ItemsView.ItemsSourceProperty, "Pets");
            petsView.ItemTemplate = new DataTemplate(() =>
            {
                Grid grid = new Grid { Padding = 10, HorizontalOptions = LayoutOptions.StartAndExpand};
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });



                Label nameLabel = new Label { FontAttributes = FontAttributes.Bold };
                nameLabel.SetBinding(Label.TextProperty, "Name");

                Label locationLabel = new Label { FontAttributes = FontAttributes.Italic, VerticalOptions = LayoutOptions.End };
                locationLabel.SetBinding(Label.TextProperty, "Breed");

                Image image = new Image { Aspect = Aspect.AspectFill, HeightRequest = 60, WidthRequest = 60, HorizontalOptions = LayoutOptions.EndAndExpand};
                image.SetBinding(Image.SourceProperty, "ImageUrl");

                Grid.SetRowSpan(image, 2);
                Grid.SetColumn(image, 1);
       
                grid.Children.Add(nameLabel, 0, 0);
                grid.Children.Add(locationLabel, 0, 1);
                grid.Children.Add(image);

                return grid;

            });

            petsView.ItemsSource = currentUser.Get().Pets;
            
        }

        private async void AddPet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pet_info());
        }

        private void CollectionViewAllPets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pet_x PetModel  = (Pet_x)((CollectionView)sender).SelectedItem;
            Navigation.PushAsync(new Pet_info(PetModel));
        }
    }
   
}