using HowFar.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HowFar.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            confirmButton.Clicked += ConfirmClicked;
        }

        private async void ConfirmClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(usernameEntry.Text))
            {
                Storage.GetInstance().SetUsername(usernameEntry.Text);
                await Navigation.PopToRootAsync(true);
            }
            else
            {
                await DisplayAlert("Unassigned Username", "Please input a username before you continue", "Okay");
            }
        }
    }
}