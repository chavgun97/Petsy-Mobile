using Petsy.Cache;
using Petsy.Models.DTO;
using Petsy.Services;
using Petsy.Services.APIClient;
using Petsy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Petsy.Models.RequestJSON.RequestsJSON;


//Обработай проверку на налл в воодимых полях!!!
namespace Petsy.Views.MainNavigationPages.ChildrenPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pet_info : ContentPage
    {
        private IApi client;
        private ICache<User> currentUser;
        private Pet pet;
        public Pet_info()
        {
            pet = new Pet();
            client = Api.GetInstance();
            currentUser = CurrentUser.GetInstance();
            InitializeComponent();
            Init();
        }

        public Pet_info(Pet pet)
        {
            this.pet = pet;
            client = Api.GetInstance();
            currentUser = CurrentUser.GetInstance();
            InitializeComponent();
            Init();
            InitAllredyExistingPet();

        }

        private void InitAllredyExistingPet()
        {
            NameEntry.Text = pet.Name;
            BreedPicker.SelectedItem = pet.Breed;
            var x = pet.Sex ? CheckMale.IsChecked = true : CheckFemale.IsChecked = true;
            DatePickerOfBithday.Date = pet.DateOfBirthday;
            EditorRecommendation.Text = pet.Recommendation;
        }

        private void Init()
        {
            var someModelVelue = client.GetAllBreeds();
            BreedPicker.Title = "Breed";
            foreach (var i in someModelVelue)
                BreedPicker.Items.Add(i);
        }
        private void CheckBoxSex_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sender.Equals(CheckMale))
            {
                CheckFemale.IsChecked = !CheckMale.IsChecked;

            }else if (sender.Equals(CheckFemale))
            {
                CheckMale.IsChecked = !CheckFemale.IsChecked;

            }

            pet.Sex = CheckMale.IsChecked; //init model
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();

        }

        private void Done_Clicked(object sender, EventArgs e)
        {
            // or init auto value:
            pet.Name = (NameEntry.Text != null) ? NameEntry.Text : "No name";
            pet.Breed = (BreedPicker.SelectedItem != null) ? BreedPicker.SelectedItem.ToString() : "No bread";
            pet.DateOfBirthday = DatePickerOfBithday.Date;
            pet.Recommendation = (EditorRecommendation.Text != null) ? EditorRecommendation.Text: "No recommendation";
            pet.UrlPhotoLable = (pet.UrlPhotoLable == null) ? "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRJz4u5WQK3cVU4rt3W1_GJwfAmgech3anrbw&usqp=CAU" : pet.UrlPhotoLable;


            if (pet.UserId == 0)
            {
                pet.UserId = currentUser.Get().Id;
                currentUser.Get().Pets.Add(pet);
                client.CreatePet(pet);//return status;   
            }
            else
            {
                client.UpdatePet(pet); //return status;    
            }
            Navigation.PopAsync();
        }
    }
}