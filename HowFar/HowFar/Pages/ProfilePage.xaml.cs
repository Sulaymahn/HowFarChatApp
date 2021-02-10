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

        private void ConfirmClicked(object sender, EventArgs e)
        {
            ((App)Application.Current).Username = usernameEntry.Text;
        }
    }
}