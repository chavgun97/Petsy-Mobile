using Petsy.Models.DTO;
using Petsy.Views.MainNavigationPages.ChildrenPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Petsy.Views.MainNavigationPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class New_order : ContentPage
    {
        public New_order()
        {
            InitializeComponent();
        }

        private void Dog_walking_cklicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AvailableSitters(TypeSitter_x.Walking));
        }

        private void Dog_sitting_cklicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AvailableSitters(TypeSitter_x.PetSitting));

        }
    }
}