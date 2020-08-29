using Petsy.Cache;
using Petsy.Models.DTO;
using Petsy.Services.APIClient;
using Petsy.Services.Interfaces;
using Petsy.Views.MainNavigationPages;
using Petsy.Views.MainNavigationPages.ChildrenPages;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Petsy.ClientModul.Views.MainNavigationPages.PopUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpCreateOrder : PopupPage
    {
        private ModelSitter modelSitter;
        private IApi client;
        private ICache<User> currentUser;
        private IEnumerable<Pet> petsOfUser;
        public PopUpCreateOrder(ModelSitter modelSitter)
        {
            currentUser = CurrentUser.GetInstance();
            client = Api.GetInstance();
            InitializeComponent();
            this.modelSitter = modelSitter;
            petsOfUser = client.GetPetsByUserId(currentUser.Get().Id);

            NameOfOrder.Text = String.Format("{0} {1}", "Order", modelSitter.CurrentType);

            PetPicker.Title = "MyPets";
            foreach(var pet in petsOfUser)
            {
                PetPicker.Items.Add(pet.Name);
            }
            PetPicker.SelectedItem = PetPicker.Items.First();
        }

        private void Create_Clicked(object sender, EventArgs e)
        {
            var user = currentUser.Get();
            var newOrder = new Order
            {
                Name = NameOfOrder.Text,
                Sitter = modelSitter.sitter,
                Pet = petsOfUser.Where(x => x.Name == PetPicker.SelectedItem.ToString()).First(),
                IsActive = true,
                From = DateTime.Now,
                AddingInfornation = (AdiingInformationEntry.Text != null) ? AdiingInformationEntry.Text : "Defult"

            };
            client.CreateOrder(newOrder);
            PopupNavigation.Instance.PopAsync(true);
        }
    }
}