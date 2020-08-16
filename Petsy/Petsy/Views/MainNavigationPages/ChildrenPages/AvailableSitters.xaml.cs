using Petsy.Cache;
using Petsy.Models.DTO;
using Petsy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using static Petsy.Models.RequestJSON.RequestsJSON;

namespace Petsy.Views.MainNavigationPages.ChildrenPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AvailableSitters : ContentPage
    {
        private TypeSitter_x typeSitter;
        //private ICache<User_x> currentUser;
        IClientRestApi clientRestApi;
        public AvailableSitters(TypeSitter_x type)
        {
            //currentUser = CurrentUser.GetInstance();
            clientRestApi = ClientRestApi.getInstance();
            typeSitter = type;
            InitializeComponent();
            Logic();
        }

        private void Logic()
        {
            CollectionView sittersView = CollectionView_AvailableSitters;
            sittersView.SetBinding(ItemsView.ItemsSourceProperty, "Sitters");
            sittersView.ItemTemplate = new DataTemplate(() =>
            {
                Grid grid = new Grid { Padding = 10, HorizontalOptions = LayoutOptions.StartAndExpand };
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });



                Label nameLabel = new Label { FontAttributes = FontAttributes.Bold };
                nameLabel.SetBinding(Label.TextProperty, "Name");

                Label descriptionLable = new Label { FontAttributes = FontAttributes.Italic, MinimumHeightRequest = 30,
                    HeightRequest = 40
                };
                descriptionLable.SetBinding(Label.TextProperty, "Description");

                Label raitingLabel = new Label { FontAttributes = FontAttributes.Italic, VerticalOptions = LayoutOptions.End };
                raitingLabel.SetBinding(Label.TextProperty, "Raiting");

                //Overeide online status
               
                Image image = new Image { Aspect = Aspect.AspectFill, HeightRequest = 60, WidthRequest = 60, HorizontalOptions = LayoutOptions.EndAndExpand };
                image.SetBinding(Image.SourceProperty, "ImageUrl");

                BoxView onlineIndicate = new BoxView { BackgroundColor= Color.FromHex("#F0CDB1"), HeightRequest=15.0 , WidthRequest=15.0,
                             CornerRadius = 20.0 ,
                             HorizontalOptions = LayoutOptions.EndAndExpand,
                             VerticalOptions = LayoutOptions.EndAndExpand
                };

                Grid.SetRowSpan(image, 3);
                Grid.SetColumn(image, 1);

                grid.Children.Add(nameLabel, 0, 0);
                grid.Children.Add(descriptionLable, 0, 1);
                grid.Children.Add(raitingLabel, 0, 2);
                grid.Children.Add(image);

                return grid;

            });

            // Делаю запрос серверу на возрат всех ситтеров по фильтру, получаю ответ в виде списка DTO обьектов, перевожу этот
            // список в список моделей для ViewItem и возарщаю этот список елементу sittersVIew как источник данных
            sittersView.ItemsSource =
                clientRestApi.GetSittersByFilter(
                    new FilterRequest(new Filter_x() { KindOfPet = KindOfPet_x.DOG, TypeSitter = typeSitter })
            ).Result.SittersByFilter.Select(x => new ModelSitter(x));
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }

        private void ImageButton_Clicked_1(object sender, EventArgs e)
        {

        }
        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void CollectionView_AvailableSitters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Navigation.PushAsync(new Siteer_front_page((ModelSitter)((CollectionView)sender).SelectedItem));
        }
    }
    public class ModelSitter
    {
        public  Sitter_x sitter;
        public string Name { get; set; }
        public string Description { get; set; }
        public string Raiting { get; set; }
        public string ImageUrl { get; set; }

        public ModelSitter(Sitter_x sitter)
        {
            this.sitter = sitter;

            Name = sitter.Name + " " + sitter.Surname;
            Description = sitter.Description;
            Raiting = String.Format("{0} ★", Math.Round(sitter.Reiting / 10.0, 2));
            ImageUrl = sitter.UrlPhotoLable;
        }
    }
}