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


//Обработай проверку на налл в воодимых полях!!!
namespace Petsy.Views.MainNavigationPages.ChildrenPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pet_info : ContentPage
    {
        private IClientRestApi client;
        private ICache<User_x> currentUser;
        private Pet_x pet;
        public Pet_info()
        {
            pet = new Pet_x();
            client = ClientRestApi.getInstance();
            currentUser = CurrentUser.GetInstance();
            InitializeComponent();
            Init();
        }

        public Pet_info(Pet_x pet)
        {
            this.pet = pet;
            client = ClientRestApi.getInstance();
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
            var someModelVelue = client.GetAllBreeds().Result.AllBreeds;
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
            Navigation.PushAsync(new My_Pets());

        }

        private void Done_Clicked(object sender, EventArgs e)
        {
            pet.Name = NameEntry.Text;
            pet.Breed = BreedPicker.SelectedItem.ToString();
            pet.DateOfBirthday = DatePickerOfBithday.Date;
            pet.Recommendation = EditorRecommendation.Text;
            if(pet.User == null)
            {
                pet.User = currentUser.Get();
                currentUser.Get().Pets.Add(pet);
            }
            else
            {
                //Update
                var pets = currentUser.Get().Pets;
                pets.Remove(pets.First(x => x.Id == pet.Id));
                pets.Add(pet);
                //----
                    
            }
             client.UpdateUser(new UserRequest(currentUser.Get()));
             Navigation.PushAsync(new My_Pets());
        }
    }
}